using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace homework8
{
    public partial class Form1 : Form
    {
        public List<Order> ordersList = new List<Order>();
        public Form1()
        {
            InitializeComponent();
            ordersList.Add(new Order(1,"lbw", new List<OrderDetail>(new OrderDetail[]
            {
                new OrderDetail(1, "牙膏", 2, 20),
                new OrderDetail(2, "牙刷", 4, 30),
            })));
            ordersList.Add(new Order(2, "lbw", new List<OrderDetail>(new OrderDetail[]
           {

                new OrderDetail(1, "苹果", 2, 20),
                new OrderDetail(2, "李子", 4, 30),
           })));
            bindingSource1.DataSource = ordersList;
        }

        private void delete_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow item in this.dataGridView1.SelectedRows)
            {
                this.dataGridView1.Rows.Remove(item);
            }
        }

        private void build_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(this);
            form2.Show();
        }

        private void fix_Click(object sender, EventArgs e)
        {
            this.bindingSource1.ResetBindings(false);
        }

        private void query_Click(object sender, EventArgs e)
        {
            if (this.textBoxOrderId.Text == "" && this.textBoxCustomer.Text == "")
            {
                bindingSource1.DataSource = ordersList;
            }
            else
            {
                bindingSource1.DataSource =
                    ordersList.Where(o => o.orderId == int.Parse(this.textBoxOrderId.Text)||o.customer==this.textBoxCustomer.Text).ToList<Order>();
            }
        }

        private void input_Click(object sender, EventArgs e)
        {
            XmlSerializer xmlSerizlizer = new XmlSerializer(typeof(Order[]));
            using (FileStream fs = new FileStream("path", FileMode.Open))
            {
                Order[] orderList1 = (Order[])xmlSerizlizer.Deserialize(fs);
                foreach (Order order in orderList1)
                {
                    Console.WriteLine(order);
                }
            }
        }

        private void Export_Click(object sender, EventArgs e)
        {
            XmlSerializer xmlSerizlizer = new XmlSerializer(typeof(Order[]));
            using (FileStream fs = new FileStream("path", FileMode.Create))
            {
                xmlSerizlizer.Serialize(fs, ordersList);
            }
        }
    }
}
