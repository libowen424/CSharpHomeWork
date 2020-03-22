using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace order_manage
{
    //一次总订单中有不同类型商品订单，不同商品订单信息在订单明细
    class Order
    {
        public int OrderId;
        public int OrderSum
        {
            get
            {
                int TempSum = 0;
               foreach (OrderDetail temp in OrderDetailsList)
                {
                    TempSum += temp.ProductNum * temp.ProductPrice;
                } 
                return TempSum;

            }
        }
        //也要定义属性 才能查询
        public List<OrderDetail> OrderDetailsList = new List<OrderDetail>();
        public Order(int id, List<OrderDetail> list)
        {
            this.OrderId = id;
            foreach (OrderDetail temp in list)
            {
                OrderDetailsList.Add(temp);
            }
        }
        public override String ToString()
        {
            return "订单ID："+OrderId + "总价:" + OrderSum;
        }
        public override bool Equals(object obj)
        {
            Order temp = obj as Order;
            return temp.OrderId == OrderId;
        }
    }
    //订单明细
    class OrderDetail
    {
        //detail id
        public int DetailId { get; set; }
        //客户在order
        public string Customer { get; set; }
        public int ProductNum { get; set; }
        public int ProductPrice { get; set; }
        public override String ToString()
        {
            return "orderId:"+DetailId + "customer:" +Customer+"productNum:"+ProductNum+"productPrice:"+ProductPrice;
        }
        public OrderDetail(int id,string custom,int num,int price)
        {
            this.DetailId = id;
            this.Customer = custom;
            this.ProductNum = num;
            this.ProductPrice = price;
        }
    }
    class OrderService
    {
        public List<Order> OrderList = new List<Order>();
        public IEnumerable<Order> queryOrderById(int id)
        {
            var query = from order in OrderList
                        where order.OrderId == id
                        orderby order.OrderSum
                        select order;
            return query;
        }
        public IEnumerable<OrderDetail> queryOrderDetailById(int orderid,int itemid)
        {

            var query = queryOrderById(orderid);
            var query2 = from orderdetail in query.ToList()[0].OrderDetailsList
                         where orderdetail.DetailId == itemid
                         select orderdetail;
            return query2;
        }
        public OrderDetail placeOrderDetail(int i, string c, int n, int p)
        {
            return new OrderDetail(i, c, n, p);
        }
        public Order GenerateOrder(int orderI, List<OrderDetail> list)
        {
            return new Order(orderI,list);
        }
        public bool isSameOrder(Order order)
        {
            bool flag=true;
            foreach (Order temp in OrderList)
            {
                if (order == temp)
                    flag = false;
            }
            return flag;
        }
        public void AddOrder(Order order)
        {
            if (isSameOrder(order))
                OrderList.Add(order);
        }
        public void DeleteOrder(int orderid)
        {
            var temp = OrderList.FirstOrDefault(t => t.OrderId == orderid);
            OrderList.Remove(temp);
        }

    }
    class Program
    {

        static void Main(string[] args)
        {
            OrderService lbw_service = new OrderService();
            
            List<OrderDetail> orderDetailsList1 = new List<OrderDetail>(new OrderDetail[]
            {
                lbw_service.placeOrderDetail(1, "lbw", 2, 20),
                lbw_service.placeOrderDetail(2, "lbw", 4, 30),
            });
            Console.WriteLine(orderDetailsList1.Count);
            lbw_service.AddOrder(lbw_service.GenerateOrder(1, orderDetailsList1));
            List<Order> a = lbw_service.queryOrderById(1).ToList<Order>();
            Console.WriteLine(a[0]);
        }
    }
}
