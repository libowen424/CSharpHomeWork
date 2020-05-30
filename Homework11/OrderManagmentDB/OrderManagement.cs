using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace OrderManagementDB
{
    public partial class OrderManagement : Form
    {
        public static OrderManagement mainWindow;
        
        private OrderService service = new OrderService();
        private Order _selectedOrder;
        private Order selectedOrder {
            get => _selectedOrder;
            set {
                _selectedOrder = value;
                if(value == null) {
                    modifyButton.Enabled = false;
                    deleteButton.Enabled = false;
                }
                else {
                    modifyButton.Enabled = true;
                    deleteButton.Enabled = true;
                }
            }
        }

        private Dictionary<QueryMethod, string> queryMethodBoxDict = new Dictionary<QueryMethod, string> {
            {QueryMethod.OrderID, "订单ID" },
            {QueryMethod.ClientName, "客户名" },
            {QueryMethod.ProductName, "产品名" }
        };


        public OrderManagement() {
            mainWindow = this;
            InitializeComponent();
            this.MinimumSize = new Size(800, 600);
            BindingSource queryMethodBoxSource = new BindingSource();
            queryMethodBoxSource.DataSource = queryMethodBoxDict;
            queryModeComboBox.DataSource = queryMethodBoxSource;
            queryModeComboBox.ValueMember = "Key";
            queryModeComboBox.DisplayMember = "Value";
            queryModeComboBox.SelectedIndex = 0;

        }

        private void OrderManagment_Load(object sender, EventArgs e) {
            service.LoadOrderFromDB();
            //添加一些数据
            //service.AddOrder(2, "lhz", "13367816628", "test order data");
            //service.AddOrder(3, "lhz", "13367816628", "test order data");
            //service.AddOrder(4, "lhz", "13367816628", "test order data");
            //service.AddOrder(5, "lhz", "13367816628", "test order data");
            //foreach(var a in service.GetOrders()) {
            //    Debug.WriteLine(a.OrderId);
            //}
            //service.GetOrderByID(1).AddOrderItem(new OrderItem(3, "笔记本", 3.0, 12, "优质笔记本"));
            //service.GetOrderByID(1).AddOrderItem(new OrderItem(4, "中性笔", 3.0, 12, "大容量"));
            //service.GetOrderByID(2).AddOrderItem(new OrderItem(1, "笔记本", 3.0, 12, "优质笔记本"));
            //service.GetOrderByID(2).AddOrderItem(new OrderItem(2, "中性笔", 3.0, 12, "大容量"));
            initOrderGrid();
        }

        public void reloadGridData()
        {
            orderBindingSource.ResetBindings(false);
        }

        private void initOrderGrid() {
            orderBindingSource.DataSource = this.service.GetOrders();
            OrderGrid.DataSource = orderBindingSource;
            foreach (DataGridViewColumn column in OrderGrid.Columns) {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void OrderGrid_SelectionChanged(object sender, EventArgs e)
        {
            if(OrderGrid.SelectedRows != null && OrderGrid.SelectedRows.Count > 0) {
                this.selectedOrder = OrderGrid.SelectedRows[0].DataBoundItem as Order;
            }
            
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            string text = queryTextBox.Text;
            if (text == null || text == "" || queryModeComboBox.SelectedItem == null) {
                orderBindingSource.DataSource = service.GetOrders();
                return;
            }

            var method = ((KeyValuePair<QueryMethod, string>)queryModeComboBox.SelectedItem).Key;
            orderBindingSource.DataSource = service.QueryOrders(method, text);
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveXMLDialog = new SaveFileDialog();

            //设置文件类型 
            saveXMLDialog.Filter = "XML文件（*.XML）|*.XML";

            //设置默认文件类型显示顺序 
            saveXMLDialog.FilterIndex = 1;

            //保存对话框是否记忆上次打开的目录 
            saveXMLDialog.RestoreDirectory = true;

            //设置默认的文件名
            saveXMLDialog.FileName = "Order";

            //点了保存按钮进入 
            if (saveXMLDialog.ShowDialog() == DialogResult.OK) {
                //获得文件路径 
                string localFilePath = saveXMLDialog.FileName.ToString();
                //获得文件名
                string fileNameExt = localFilePath.Substring(localFilePath.LastIndexOf("\\") + 1);
                service.ExportToXML(localFilePath);

            }
        }

        private void importButton_Click(object sender, EventArgs e)
        {
            var openXMLDialog = new OpenFileDialog();
            openXMLDialog.Filter = "XML文件（*.XML）|*.XML";
            DialogResult result = openXMLDialog.ShowDialog();
            if (result == DialogResult.OK) {
                service.ImportFromXML(openXMLDialog.FileName);
                orderBindingSource.ResetBindings(false);
            }
        }

        private void editClick(object sender, EventArgs e)
        {
            var button = sender as Button;
            if(button == deleteButton) {
                service.RemoveOrder(selectedOrder);
                orderBindingSource.ResetBindings(false);
            }
            else if(button == modifyButton) {
                if (selectedOrder != null)
                    new ModifyOrder(service, selectedOrder).Show();
            }
            else if(button == addButton) {
                if (IDtextBox.Text == null || IDtextBox.Text == "")
                    return;

                if(!int.TryParse(IDtextBox.Text, out int ID)) {
                    MessageBox.Show("订单ID格式错误");
                    return;
                }
                else if(NameTextBox.Text == null || NameTextBox.Text == "") {
                    MessageBox.Show("客户名不能为空");
                    return;
                }
                try {
                    service.AddOrder(ID, NameTextBox.Text, PhoneTextBox.Text, NameTextBox.Text);
                }
                catch(Exception exc) {
                    MessageBox.Show(exc.Message);
                }
                orderBindingSource.ResetBindings(false);

            }
        }
    }
}
