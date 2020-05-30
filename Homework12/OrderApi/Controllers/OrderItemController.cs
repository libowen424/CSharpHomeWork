using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderItemController: ControllerBase
    {
        private readonly OrderContext orderDB;

        public OrderItemController(OrderContext context)
        {
            this.orderDB = context;
            IQueryable<Order> query = orderDB.Orders;
        }

        /*
         * 
         * 查找订单时返回的结果包括订单明细。
         * 因此这里的查询方法大部分时候单独使用没有太大意义。
         */

        #region 订单明细方法
        [HttpGet("{id}")]
        public ActionResult<OrderItem> GetOrderItem(int id)
        {
            var orderItem = orderDB.OrderItems.FirstOrDefault(i => i.ItemId == id);
            if (orderItem == null) {
                return NotFound();
            }
            return orderItem;
        }

        //查询包含某种商品的订单明细
        [HttpGet]
        public ActionResult<List<OrderItem>> GetOrderItems(string productName)
        {
            IQueryable<OrderItem> query = orderDB.OrderItems;
            if (productName != null) {
                query = query.Where(x => x.ProductName.Contains(productName));
            }
            return query.ToList();
        }

        //查询包含某种商品的订单明细
        //分页查找
        [HttpGet("pageQuery")]
        public ActionResult<List<OrderItem>> queryOrderItem(string productName, int skip, int take)
        {
            IQueryable<OrderItem> query = orderDB.OrderItems;
            if (productName != null) {
                query = query.Where(x => x.ProductName.Contains(productName));
            }
            query = query.Skip(skip).Take(take);
            return query.ToList();
        }


        [HttpPost]
        public ActionResult<OrderItem> PostOrderItem(OrderItem orderItem)
        {
            try {
                orderDB.OrderItems.Add(orderItem);
                orderDB.SaveChanges();
            }
            catch (Exception e) {
                string error = e.InnerException != null ? e.InnerException.Message : e.Message;
                return BadRequest(error);
            }
            return orderItem;
        }

        [HttpPut("{id}")]
        public ActionResult<OrderItem> PutOrderItem(int id, OrderItem orderItem)
        {
            if (id != orderItem.ItemId) {
                return BadRequest("Do not modify id.");
            }
            try {
                orderDB.Entry(orderItem).State = EntityState.Modified;
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
                var orderItem = orderDB.OrderItems.FirstOrDefault(i => i.ItemId == id);
                if (orderItem != null) {
                    orderDB.Entry(orderItem).State = EntityState.Deleted;
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
