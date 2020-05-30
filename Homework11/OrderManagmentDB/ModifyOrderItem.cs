using OrderManagementDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderManagementDB
{
    public partial class ModifyOrderItem : Form
    {
        private OrderItem orderItem;
        private ModifyOrder modifyOrder;

        public ModifyOrderItem()
        {
            InitializeComponent();
        }

        public ModifyOrderItem(ModifyOrder mf, OrderItem item)
        {
            InitializeComponent();
            this.MinimumSize = new Size(500, 300);

            modifyOrder = mf;
            orderItem = item;
            productNameBox.Text = item.ProductName;
            unitPriceBox.Text = item.UnitPrice.ToString();
            quantityBox.Text = item.Quantity.ToString();
            descriptionBox.Text = item.Description;
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            orderItem.ProductName = productNameBox.Text;
            orderItem.Description = descriptionBox.Text;
            bool singlePriceValid = double.TryParse(unitPriceBox.Text, out double unitPrice);
            bool quantityValid = double.TryParse(quantityBox.Text, out double quantity);
            if (orderItem.ProductName == "" || !quantityValid || !singlePriceValid) {
                MessageBox.Show("信息不完整或有误，无法添加订单条目");
                return;
            }

            orderItem.UnitPrice = unitPrice;
            orderItem.Quantity = quantity;
            modifyOrder.ReloadData();
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
