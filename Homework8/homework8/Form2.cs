using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace homework8
{
    public partial class Form2 : Form
    {
        public List<OrderDetail> orderDetailsList = new List<OrderDetail>();
        private Form1 form1;
        public Form2(Form1 form1)
        {
            InitializeComponent();
            bindingSource1.DataSource = orderDetailsList;
            this.form1 = form1;
        }

        private void deliverDetail_Click(object sender, EventArgs e)
        {
            int id = int.Parse(this.id.Text);
            string name = this.name.Text;
            int num = int.Parse(this.num.Text);
            int price = int.Parse(this.price.Text);
            orderDetailsList.Add(new OrderDetail(id, name, num, price));
            bindingSource1.ResetBindings(false);
            foreach (Control i in groupBox1.Controls)
            {
                if (i is TextBox)
                {
                    i.Text = "";
                }
            }
        }

        private void deliverOrder_Click(object sender, EventArgs e)
        {
            Order order = new Order(int.Parse(this.OrderId.Text),this.Customer.Text,orderDetailsList);
            this.form1.ordersList.Add(order);
            this.form1.bindingSource1.ResetBindings(false);
            this.Close();
        }
    }
}
