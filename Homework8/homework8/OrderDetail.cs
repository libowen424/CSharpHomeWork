using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework8
{
    public class OrderDetail
    {
        public int productId { get; set; }
        public int productNum { get; set; }
        public int productPrice { get; set; }
        public string productName { get; set; }
        public OrderDetail(int id, string name, int num, int price)
        {
            this.productName = name;
            this.productId = id;
            this.productNum = num;
            this.productPrice = price;
        }
    }
}
