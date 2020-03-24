using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OrderManage
{
    //一次总订单中有不同类型商品订单，不同商品订单信息在订单明细
    public class Order
    {
        public int orderId;
        public int orderSum
        {
            get
            {
                int temSum = 0;
               foreach (OrderDetail temp in orderDetailsList)
                {
                    temSum += temp.productNum * temp.productPrice;
                } 
                return temSum;
            }
        }
        //也要定义属性 才能查询
        public List<OrderDetail> orderDetailsList = new List<OrderDetail>();
        public Order(int id, List<OrderDetail> list)
        {
            this.orderId = id;
            foreach (OrderDetail temp in list)
            {
                orderDetailsList.Add(temp);
            }
        }
        public override String ToString()
        {
            return "订单ID："+orderId + "总价:" + orderSum;
        }
        public override bool Equals(object obj)
        {
            Order temp = obj as Order;
            return temp.orderId == orderId;
        }
    }
    //订单明细
    public class OrderDetail
    {
        //detail id
        public int detailId { get; set; }
        //客户在order
        public string customer { get; set; }
        public int productNum { get; set; }
        public int productPrice { get; set; }
        public string productName { get; set; }
        public override String ToString()
        {
            return "orderId:"+detailId +"product's name"+ productName + "customer:" +customer+"productNum:"+productNum+"productPrice:"+productPrice;
        }
        public OrderDetail(int id,string name,string custom,int num,int price)
        {
            this.productName = name;
            this.detailId = id;
            this.customer = custom;
            this.productNum = num;
            this.productPrice = price;
        }
    }

    [Serializable]
    public class OrderService
    {
        public List<Order> orderList = new List<Order>();
        public Order queryOrderById(int id)
        {
            var query = from order in orderList
                        where order.orderId == id
                        orderby order.orderSum
                        select order;
            return query.FirstOrDefault<Order>();
        }
        public OrderDetail queryOrderDetailById(int orderId,int itemid)
        {

            var query = queryOrderById(orderId);
            var query2 = from orderdetail in query.orderDetailsList
                         where orderdetail.detailId == itemid
                         select orderdetail;
            return query2.FirstOrDefault<OrderDetail>();
        }
        public Order queryOrderByProductName(string name)
        {
            return orderList.Where(
                order => order.orderDetailsList.Exists(item => item.productName == name)).FirstOrDefault<Order>();
        }
        public Order queryOrderByProductName1(string name)
        {
            return orderList.Where(
                order =>
                {
                    foreach (OrderDetail item in order.orderDetailsList)
                    {
                        if (item.productName == name) return true;
                        return false;
                    }
                    return false;
                }).FirstOrDefault<Order>();
        }
        //from o in oderlist where hasGoods(order,productname)select o
        public OrderDetail placeOrderDetail(int i,string name, string c, int num, int price)
        {
            return new OrderDetail(i,name, c, num, price);
        }
        public Order GenerateOrder(int orderId, List<OrderDetail> list)
        {
            return new Order(orderId,list);
        }
        public bool hasSameOrder(Order order)
        {
            bool flag=true;
            foreach (Order temp in orderList)
            {
                if (order == temp)
                    flag = false;
            }
            return flag;
        }
        public void AddOrder(Order order)
        {
            if (hasSameOrder(order))
                orderList.Add(order);
        }
        public void DeleteOrder(int orderid)
        {
            var temp = orderList.FirstOrDefault(t => t.orderId == orderid);
            orderList.Remove(temp);
        }
        public void Export(string path)
        {
            XmlSerializer xmlSerizlizer = new XmlSerializer(typeof(Order[]));
            using (FileStream fs = new FileStream(path , FileMode.Create))
            {
                xmlSerizlizer.Serialize(fs, orderList);
            }
            Console.WriteLine("Serialized as XML");
            Console.WriteLine(File.ReadAllText(path));
        }
        public void Import(string path)
        {
            XmlSerializer xmlSerizlizer = new XmlSerializer(typeof(Order[]));
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                Order[] orderList1 = (Order[])xmlSerizlizer.Deserialize(fs);
                Console.WriteLine("Serialized as XML");
                foreach (Order order in orderList1)
                {
                    Console.WriteLine(order);
                }
            }

        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            OrderService lbw_service = new OrderService();
            
            List<OrderDetail> orderDetailsList1 = new List<OrderDetail>(new OrderDetail[]
            {
                lbw_service.placeOrderDetail(1, "牙膏","lbw", 2, 20),
                lbw_service.placeOrderDetail(2, "牙刷","lbw", 4, 30),
            });
            Console.WriteLine(orderDetailsList1.Count);
            lbw_service.AddOrder(lbw_service.GenerateOrder(1, orderDetailsList1));
            Order a = lbw_service.queryOrderById(1);
            Console.WriteLine(a);
        }
    }
}
