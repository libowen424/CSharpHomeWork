using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderApi
{

    [Serializable]
    public class OrderItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemId { get; set; }
        public string ProductName { get; set; }
        public double UnitPrice { get; set; }
        public double Quantity { get; set; }
        public string Description { get; set; }
        //似乎如果加上这个属性，webapi在序列化json的时候会发生循环导致报错。
        //去掉似乎也不影响多对一关联。
        //public Order Order { get; set; }

        public int OrderId { get; set; }
        

        [NotMapped]
        public double ItemTotalPrice {
            get {
                return UnitPrice * Quantity;
            }
        }

        public OrderItem() { }

        public OrderItem(int ItemID, string ProductName, double UnitPrice, double Quantity, string Description = null) {
            this.ItemId = ItemID;
            this.ProductName = ProductName;
            this.UnitPrice = UnitPrice;
            this.Quantity = Quantity;
            this.Description = Description;
        }

        public OrderItem(OrderItem newOne) {
            this.ItemId = newOne.ItemId;
            this.ProductName = newOne.ProductName;
            this.Description = newOne.Description;
            this.UnitPrice = newOne.UnitPrice;
            this.Quantity = newOne.Quantity;
        }

        // override object.Equals
        public override bool Equals(object obj) {

            if (obj == null || GetType() != obj.GetType()) return false;
            var item = (OrderItem)obj;
            return (ProductName == item.ProductName && Description == item.Description
                && UnitPrice == item.UnitPrice && Quantity == item.Quantity)
                || ItemId == item.ItemId;

        }
        
        // override object.GetHashCode
        public override int GetHashCode() {
            return ProductName.GetHashCode() + ItemId.GetHashCode();
        }

        public override string ToString() {
            return "产品名称：" + ProductName + "； 单价：" + UnitPrice + "； 数量：" + Quantity;
        }
    }
}
