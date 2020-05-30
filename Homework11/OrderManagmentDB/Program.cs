using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace OrderManagementDB
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
           //如果数据库不存在，创建数据库并加入一些数据
            using (var context = new OrderContext()) {
                if (context.Database.CreateIfNotExists()) {
                    var order = new Order() {
                        OrderId = 1,
                        ClientName = "client1",
                        ClientPhoneNumber = "1234567",
                        OrderDate = DateTime.Now,
                        Note = "new order"
                    };
                    order.OrderItems = new List<OrderItem>() {
                        new OrderItem() {
                            ItemId = 1,
                            ProductName = "pd1",
                            UnitPrice = 12,
                            Quantity = 2,
                            Description  = "产品1"
                        },
                        new OrderItem() {
                            ItemId = 2,
                            ProductName = "pd2",
                            UnitPrice = 155,
                            Quantity = 1,
                            Description  = "产品2"
                        }
                    };

                    context.Orders.Add(order);
                    context.SaveChanges();
                }
                else {

                }
            }


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new OrderManagement());
        }
    }
}
