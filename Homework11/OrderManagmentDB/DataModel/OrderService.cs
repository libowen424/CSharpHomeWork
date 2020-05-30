using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace OrderManagementDB
{
    public enum SortMethod
    {
        OrderID, ClientName, OrderDateAscend, OrderDateDescend
    }

    public enum QueryMethod
    {
        OrderID, ClientName, ProductName
    }

    //目前，此类会自己维护一个order列表，OrderContext也会维护一个order列表，手动保持两者一致。
    public class OrderService
    {
        private List<Order> orders = new List<Order>();

        //原本设计OrderService的时候，OrderId被认为不一定是连续、可以由高层用户指定的。
        //但后来考虑到可能有需要低层托管OrderId的情况，因此增加了这个属性。不一定用到。
        public int CurrentMaxOrderId { get; private set; }

        public Order GetOrderByID(int ID)
        {
            foreach (Order order in orders) {
                if (order.OrderId == ID)
                    return order;
            }
            return null;
        }

        public List<Order> GetOrders()
        {
            return orders;
        }

        //从数据库加载订单到内存
        public void LoadOrderFromDB()
        {
            orders = new List<Order>();

            using (var context = new OrderContext()) {
                //假如数据库不存在
                if (context.Database.CreateIfNotExists()) {
                    CurrentMaxOrderId = 0;
                }
                else {
                    orders = context.Orders.Include("OrderItems").ToList();
                    CurrentMaxOrderId = orders.Select(x => x.OrderId).ToList().Max();
                }
            }
        }

        //订单Id受到自动管理的增加方式
        public void ManagedAddOrder(string ClientName, string phoneNumber = null, string note = null)
        {
            var newOrder = new Order(CurrentMaxOrderId + 1, ClientName, DateTime.Now, phoneNumber, note);
            AddOrder(newOrder);
        }

        public void AddOrder(int OrderID, string ClientName, string phoneNumber = null, string note = null)
        {
            var newOrder = new Order(OrderID, ClientName, phoneNumber, note);
            AddOrder(newOrder);
        }



        public void AddOrder(int OrderID, string ClientName, DateTime time, string phoneNumber = null, string note = null)
        {
            var newOrder = new Order(OrderID, ClientName, time, phoneNumber, note);
            AddOrder(newOrder);
        }

        private void AddOrder(Order newOrder)
        {
            var result = orders.Where(x => x.Equals(newOrder)).ToList();

            if (result.Count != 0)
                throw new Exception("已有相同订单。");

            orders.Add(newOrder);
            using (var context = new OrderContext()) {
                context.Entry(newOrder).State = EntityState.Added;
                context.SaveChanges();
                CurrentMaxOrderId++;
            }
        }

        //往某个订单里增加订单项
        public void AddOrderItem(Order order, OrderItem item)
        {
            
            using (var context = new OrderContext()) {
                int maxItemId = context.OrderItems.Select(x => x.ItemId).Max();
                item.ItemId = maxItemId + 1;
                order.AddOrderItem(item);
                var temp = context.Orders.Include("OrderItems").FirstOrDefault(x => x.OrderId == order.OrderId);
                temp.OrderItems.Add(item);
                context.SaveChanges();
            }
        }

        public void RemoveOrderByID(int OrderID)
        {
            var temp = GetOrderByID(OrderID);
            if (temp == null) {
                throw new Exception($"未找到id为{OrderID}的订单");
            }
            RemoveOrder(temp);
        }

        public void RemoveOrder(Order order)
        {
            if (order == null)
                return;
            orders.Remove(order);
            using (var context = new OrderContext()) {
                var temp = context.Orders.Include("OrderItems").FirstOrDefault(x => x.OrderId == order.OrderId);
                context.Orders.Remove(temp);
                context.SaveChanges();
            }
        }

        //获取数据库里的订单。测试用。
        public List<Order> GetContextOrders()
        {
            using (var context = new OrderContext()) {
                return context.Orders.Include("OrderItems").ToList();
            }
        }

        //修改订单，适用于打开修改订单窗口后对订单进行深拷贝，从而支持取消更改的情况。
        public void ModifyOrder(Order order, Order newOne)
        {
            //先修改内存中的信息
            order.ClientName = newOne.ClientName;
            order.ClientPhoneNumber = newOne.ClientPhoneNumber;
            order.Note = newOne.Note;
            order.OrderItems.Clear();
            //相当混乱，大概是先找数据库中item最大的Id，然后从它开始增加以避免重复。
            //也就是，即使只是修改某个订单明细，它的Id也可能会改变。（不过，此程序认为OrderItem的Id对人而言是没有意义的。）
            using (var context = new OrderContext()) {
                var temp = context.Orders.Include("OrderItems").FirstOrDefault(x => x.OrderId == order.OrderId);
                if (temp != null) {
                    temp.ClientName = order.ClientName;
                    temp.ClientPhoneNumber = order.ClientPhoneNumber;
                    temp.Note = order.Note;


                    var relatedItems = context.OrderItems.Where(x => x.OrderId == temp.OrderId);
                    foreach(var item in relatedItems) {
                        context.Entry(item).State = EntityState.Deleted;
                    }

                    var itemIdMax = context.OrderItems.Count() > 0 ? context.OrderItems.Select(x => x.ItemId).Max() : 0;

                    foreach(var item in newOne.OrderItems) {
                        item.ItemId = itemIdMax + 1;
                        order.OrderItems.Add(item);
                        temp.AddOrderItem(item);
                        itemIdMax++;
                    }

                    context.SaveChanges();
                }
            }
        }

        public void ModifyOrder(Order order, string ClientName, string ClientPhoneNumber = null, string Note = null)
        {
            if (!orders.Contains(order))
                throw new Exception("订单列表中找不到要修改的订单。");
            order.ClientName = ClientName ?? order.ClientName;
            order.ClientPhoneNumber = ClientPhoneNumber ?? order.ClientPhoneNumber;
            order.Note = Note ?? order.Note;

            using (var context = new OrderContext()) {
                var temp = context.Orders.Include("OrderItems").FirstOrDefault(x => x.OrderId == order.OrderId);
                if (temp != null) {
                    temp.ClientName = order.ClientName;
                    temp.ClientPhoneNumber = order.ClientPhoneNumber;
                    temp.Note = order.Note;
                    context.SaveChanges();
                }
            }
        }

        public void ModifyOrderByID(int ID, string ClientName, string ClientPhoneNumber = null, string Note = null)
        {
            var order = GetOrderByID(ID);
            if (order == null)
                throw new Exception("订单列表中找不到要修改的订单。");
            ModifyOrder(order, ClientName, ClientPhoneNumber, Note);
        }

        public IEnumerable<Order> QueryOrders(QueryMethod method, string arg)
        {
            switch (method) {
                case QueryMethod.OrderID:
                    //为了统一方法的返回，假如ID有误，直接返回一个空表。
                    if (!int.TryParse(arg, out int ID))
                        return new List<Order>();
                    return orders.Where(x => x.OrderId == ID).OrderByDescending(x => x.TotalPrice);
                case QueryMethod.ClientName:
                    return orders.Where(x => x.ClientName == arg).OrderByDescending(x => x.TotalPrice);
                case QueryMethod.ProductName:
                    return orders.Where(x => x.ContainsProductNamed(arg)).OrderByDescending(x => x.TotalPrice);
                default:
                    return new List<Order>();
            }
        }

        //传入自定义排序函数的排序方法
        public void SortOrders(Func<Order, Order, int> compareFunc)
        {
            orders.Sort((a, b) => compareFunc(a, b));
        }

        //传入特定排序方式的排序方法
        public void SortOrders(SortMethod method)
        {
            if (orders.Count == 0)
                return;
            switch (method) {
                case SortMethod.OrderID:
                    orders.Sort();
                    break;
                case SortMethod.OrderDateAscend:
                    SortOrders((a, b) => (int)(a.OrderDate - b.OrderDate).TotalSeconds);
                    break;
                case SortMethod.OrderDateDescend:
                    SortOrders((a, b) => -(int)(a.OrderDate - b.OrderDate).TotalSeconds);
                    break;
                case SortMethod.ClientName:
                    orders = orders.OrderBy(x => x.ClientName).ToList();
                    break;
                default:
                    orders.Sort();
                    break;
            }
        }

        public void ExportToXML(string filePath)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream(filePath, FileMode.Create)) {
                xmlSerializer.Serialize(fs, orders);
            }
        }

        public void ImportFromXML(string filePath)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream(filePath, FileMode.Open)) {
                List<Order> orders = (List<Order>)xmlSerializer.Deserialize(fs);
                orders.ForEach(x => this.orders.Add(x));
            }
        }
    }
}
