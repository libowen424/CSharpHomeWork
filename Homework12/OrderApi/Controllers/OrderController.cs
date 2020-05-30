using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace OrderApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly OrderContext orderDB;

        public OrderController(OrderContext context)
        {
            this.orderDB = context;
            IQueryable<Order> query = orderDB.Orders;
            //假如没有内容，填充一点内容。
            if (query.Count() == 0) {
                var a = new Order() {
                    ClientName = "test1",
                    ClientPhoneNumber = "1234",
                    Note = "test order",
                    OrderDate = DateTime.Now,
                };
                var b = new Order() {
                    ClientName = "test2",
                    ClientPhoneNumber = "1234",
                    Note = "test order",
                    OrderDate = DateTime.Now,
                };
                var item1 = new OrderItem() {
                    ProductName = "product1",
                    Description = "test",
                    Quantity = 2.0,
                    UnitPrice = 15.5,
                };
                a.AddOrderItem(item1);
                context.Orders.Add(a);
                context.Orders.Add(b);
                context.SaveChanges();
            }

        }


        #region 订单方法
        [HttpGet("{id}")]
        public ActionResult<Order> GetOrder(int id)
        {
            var order = orderDB.Orders.FirstOrDefault(i => i.OrderId == id);
            if (order == null) {
                return NotFound();
            }
            return order;
        }

        //按照客户名称或是包含的产品名进行订单查找。
        [HttpGet]
        public ActionResult<List<Order>> GetOrders(string clientName, string productName)
        {
            var query = buildQuery(clientName, productName);
            return query.ToList();
        }

        //分页查找
        [HttpGet("pageQuery")]
        public ActionResult<List<Order>> queryOrderItem(string clientName, string productName, int skip, int take)
        {
            var query = buildQuery(clientName, productName).Skip(skip).Take(take);
            return query.ToList();
        }

        private IQueryable<Order> buildQuery(string clientName, string productName)
        {
            IQueryable<Order> query = orderDB.Orders.Include("OrderItems");
            if (clientName != null) {
                query = query.Where(i => i.ClientName.Contains(clientName));
            }
            if (productName != null) {
                query = query.Where(i => i.ContainsProductNamed(productName));
            }
            return query;
        }

        [HttpPost]
        public ActionResult<Order> PostOrder(Order order)
        {
            try {
                orderDB.Orders.Add(order);
                orderDB.SaveChanges();
            }
            catch (Exception e) {
                string error = e.InnerException != null ? e.InnerException.Message : e.Message;
                return BadRequest(error);
            }
            return order;
        }

        [HttpPut("{id}")]
        public ActionResult<Order> PutOrderItem(int id, Order order)
        {
            if (id != order.OrderId) {
                return BadRequest("Do not modify id.");
            }
            try {
                orderDB.Entry(order).State = EntityState.Modified;
                orderDB.SaveChanges();
            }
            catch (Exception e) {
                string error = e.InnerException != null ? e.InnerException.Message : e.Message;
                return BadRequest(error);
            }
            return NoContent();
        }

        
        [HttpDelete("{id}")]
        public ActionResult DeleteOrderItem(int id)
        {
            try {
                var order = orderDB.Orders.FirstOrDefault(i => i.OrderId == id);
                if (order != null) {
                    orderDB.Entry(order).State = EntityState.Deleted;
                    orderDB.SaveChanges();
                }
            }
            catch (Exception e) {
                string error = e.InnerException != null ? e.InnerException.Message : e.Message;
                return BadRequest(error);
            }
            return NoContent();
        }

        #endregion

    }
}
