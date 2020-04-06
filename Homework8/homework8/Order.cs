using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework8
{
    public class Order
    {
        public int orderId { get; set; }
        public string customer { get; set; }
        public List<OrderDetail> orderDetailsList = new List<OrderDetail>();
        public List<OrderDetail> orderDetails { get
            { return orderDetailsList; }
             }

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
        public Order(int id,string cusname, List<OrderDetail> list)
        {
            this.orderId = id;
            this.customer = cusname;
            foreach (OrderDetail temp in list)
            {
                orderDetailsList.Add(temp);
            }
        }
    }
}
