using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderManagementDB
{
    static class Extensions
    {
        //判断两个日期是否是同一天。
        public static bool EqualsToDay(this DateTime dateTime1, DateTime dateTime2) {
            return (dateTime1 - dateTime2).TotalDays == 0
                && dateTime1.Day == dateTime2.Day;
        }
    }

    [Serializable]
    public class Order : IComparable
    {
        public int OrderId { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public string ClientName { get; set; }
        public string ClientPhoneNumber { get; set; } = null;
        public DateTime OrderDate { get; set; }
        public string Note { get; set; } = null;

        [NotMapped]
        public double TotalPrice {
            get {
                double price = 0.0;
                foreach (OrderItem item in OrderItems) {
                    price += item.ItemTotalPrice;
                }
                return price;
            }
        }

        public Order() { }

        public Order(Order newOne)
        {
            this.OrderId = newOne.OrderId;
            this.ClientName = newOne.ClientName;
            this.ClientPhoneNumber = newOne.ClientPhoneNumber;
            this.OrderDate = newOne.OrderDate;
            this.Note = newOne.Note;
            foreach(var item in newOne.OrderItems) {
                this.OrderItems.Add(new OrderItem(item));
            }
        }

        public Order(int OrderID, string ClientName, string ClientPhoneNumber = null, string Note = null) {
            this.ClientName = ClientName;
            this.OrderId = OrderID;
            this.ClientPhoneNumber = ClientPhoneNumber;
            this.OrderDate = DateTime.Now;
            this.Note = Note;
        }

        public Order(int OrderID, string ClientName, DateTime OrderDate, string ClientPhoneNumber = null, string Note = null) {
            this.ClientName = ClientName;
            this.OrderId = OrderID;
            this.ClientPhoneNumber = ClientPhoneNumber;
            this.OrderDate = OrderDate;
            this.Note = Note;
        }

        public int CompareTo(object obj) {
            if (obj == null || GetType() != obj.GetType()) throw new ArgumentException();
            return OrderId - (obj as Order).OrderId;
        }

        public List<OrderItem> GetOrderItems() {
            return this.OrderItems;
        }

        public void AddOrderItem(OrderItem newItem) {
            if (OrderItems == null) OrderItems = new List<OrderItem>();
            foreach (OrderItem item in OrderItems) {
                if (item.Equals(newItem)) {
                    throw new Exception("已有相同的订单明细项。");
                }
            }
            OrderItems.Add(new OrderItem(newItem));
        }

        public bool ContainsProductNamed(string name) {
            if (OrderItems == null) return false;
            foreach (OrderItem item in OrderItems) {
                if (item.ProductName.Contains(name)) return true;
            }
            return false;
        }

        // override object.Equals
        public override bool Equals(object obj) {
            if (obj == null || GetType() != obj.GetType()) return false;
            return OrderId == ((Order)obj).OrderId;
        }

        // override object.GetHashCode
        public override int GetHashCode() {
            return OrderId.GetHashCode();
        }

        public override string ToString() {
            var phoneNumber = ClientPhoneNumber ?? "空";
            var note = Note ?? "空";
            return "订单号：" + OrderId + "； 客户姓名：" + ClientName + "； 订单日期：" + OrderDate.ToString("d")
                + "； 客户电话：" + phoneNumber + "； 备注：" + note;
        }
    }
}
