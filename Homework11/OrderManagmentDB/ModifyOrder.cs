using OrderManagmentDB;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace OrderManagementDB
{
    public partial class ModifyOrder : Form
    {
        public OrderService service { get; set; }
        public Order selectedOrder { get; set; }

        //对传入的订单进行深拷贝，以支持不提交（撤销）
        private Order copiedOrder;

        public ModifyOrder() {
            InitializeComponent();
        }

        public ModifyOrder(OrderService service, Order selectedOrder) {
            InitializeComponent();
            this.MinimumSize = new Size(800, 800);
            this.service = service;
            this.selectedOrder = selectedOrder;
            this.copiedOrder = new Order(selectedOrder);

        }


        private void ModifyOrder_Load(object sender, EventArgs e) {
            clientNameTextBox.DataBindings.Add("Text", copiedOrder, "ClientName");
            clientPhoneNumberTextBox.DataBindings.Add("Text", copiedOrder, "ClientPhoneNumber");
            orderIDlabel.DataBindings.Add("Text", copiedOrder, "OrderId");
            orderDateLabel.DataBindings.Add("Text", copiedOrder, "OrderDate");
            noteTextBox.DataBindings.Add("Text", copiedOrder, "Note");
            //似乎这个绑定没有起作用。有点奇怪
            totalPriceLabel.DataBindings.Add("Text", this.copiedOrder, "TotalPrice");

            detailBindingSource.DataSource = this.copiedOrder.GetOrderItems();
            OrderDetailGridView.DataSource = detailBindingSource;
            
            foreach (DataGridViewColumn column in OrderDetailGridView.Columns) {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            OrderDetailGridView.Columns[0].Visible = false;
            OrderDetailGridView.Columns[5].Visible = false;
            OrderDetailGridView.Columns[6].Visible = false;
        }


        private void ModifyOrder_FormClosed(object sender, FormClosedEventArgs e)
        {
            OrderManagement.mainWindow.reloadGridData();
        }


        private void submitButton_Click(object sender, EventArgs e)
        {
            if(copiedOrder.ClientName == null || copiedOrder.ClientName == "") {
                MessageBox.Show("客户名不能为空");
                return;
            }
            service.ModifyOrder(selectedOrder, copiedOrder);
            OrderManagement.mainWindow.reloadGridData();
            this.Close();
        }


        private void OrderDetailGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            OrderManagement.mainWindow.reloadGridData();
            this.totalPriceLabel.Text = this.copiedOrder.TotalPrice.ToString();
        }


        private void addItemBtn_Click(object sender, EventArgs e)
        {
            string productName = productNameBox.Text;
            bool singlePriceValid = double.TryParse(unitPriceBox.Text, out double unitPrice);
            bool quantityValid = double.TryParse(quantityBox.Text, out double quantity);
            string description = descriptionBox.Text;

            if (productName == "" || !quantityValid || !singlePriceValid) {
                MessageBox.Show("信息不完整或有误，无法添加订单条目");
                return;
            }

            int max;
            if (copiedOrder.OrderItems.Count == 0)
                max = 0;
            else
                max = copiedOrder.OrderItems.Select(x => x.ItemId).Max();

            var newItem = new OrderItem(max + 1, productName, unitPrice, quantity, description);
            copiedOrder.AddOrderItem(newItem);
        }


        private void deleteSelectionBtn_Click(object sender, EventArgs e)
        {
            if (OrderDetailGridView.SelectedRows.Count <= 0)
                return;
            var item = OrderDetailGridView.SelectedRows[0].DataBoundItem as OrderItem;
            copiedOrder.OrderItems.Remove(item);
            ReloadData();
        }


        private void editSelectedItemBtn_Click(object sender, EventArgs e)
        {
            if (OrderDetailGridView.SelectedRows.Count <= 0)
                return;
            var item = OrderDetailGridView.SelectedRows[0].DataBoundItem as OrderItem;
            new ModifyOrderItem(this, item).Show();
        }

        public void ReloadData()
        {
            this.detailBindingSource.ResetBindings(false);
            this.totalPriceLabel.Text = this.copiedOrder.TotalPrice.ToString();
        }
    }
}
