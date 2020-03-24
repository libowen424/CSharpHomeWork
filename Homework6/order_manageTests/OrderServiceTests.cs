using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManage.Tests
{
    [TestClass()]
    public class OrderServiceTests
    {
        public OrderService lbw_service = new OrderService();


        [TestCleanup()]
        public void testCleanup()
        {
            lbw_service = new OrderService();
        }
     
    [TestMethod()]
        public void queryOrderByIdTest()
        {
            List<OrderDetail> orderDetailsList1 = new List<OrderDetail>(new OrderDetail[]
            {
                lbw_service.placeOrderDetail(1, "牙膏","lbw", 2, 20),
                lbw_service.placeOrderDetail(2, "牙刷","lbw", 4, 30),
            });
            lbw_service.AddOrder(lbw_service.GenerateOrder(1, orderDetailsList1));
            Order rightResult = lbw_service.queryOrderById(1);
            Order falseResult = lbw_service.queryOrderById(2);
            Assert.IsTrue(rightResult.orderDetailsList[0].detailId == 1);
            Assert.IsNull(falseResult);
        }

        [TestMethod()]
        public void queryOrderDetailByIdTest()
        {
            List<OrderDetail> orderDetailsList1 = new List<OrderDetail>(new OrderDetail[]
                        {
                lbw_service.placeOrderDetail(1, "牙膏","lbw", 2, 20),
                lbw_service.placeOrderDetail(2, "牙刷","lbw", 4, 30),
                        });
            lbw_service.AddOrder(lbw_service.GenerateOrder(1, orderDetailsList1));
            OrderDetail rightResult = lbw_service.queryOrderDetailById(1,1);
            OrderDetail falseResult = lbw_service.queryOrderDetailById(1,3);
            Assert.IsTrue(rightResult.productName == "牙膏");
            Assert.IsNull(falseResult);
        }

        [TestMethod()]
        public void queryOrderByProductNameTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void queryOrderByProductName1Test()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void placeOrderDetailTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GenerateOrderTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void isSameOrderTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AddOrderTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteOrderTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ExportTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ImportTest()
        {
            Assert.Fail();
        }
    }
}