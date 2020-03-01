using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.My_Conbobox();
        }

        public void My_Conbobox()
        {
            comboBox1.Items.Add("+");
            comboBox1.Items.Add("-");
            comboBox1.Items.Add("*");
            comboBox1.Items.Add("/");
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedItem.ToString()) //获取选择的内容
            {

                case "+": label3.Text = "+"; break;

                case "-": label3.Text = "-"; break;

                case "*": label3.Text = "*"; break;

                case "/": label3.Text = "/";  break;


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try {
                double firstNumber, secondNumber;
                char sign;
                firstNumber = Double.Parse(textBox1.Text);
                secondNumber = Double.Parse(textBox2.Text);
                sign = Char.Parse(label3.Text);
                switch (sign)
                {
                    case '+':
                        label4.Text = (firstNumber + secondNumber).ToString();
                        break;
                    case '-':
                        label4.Text = (firstNumber - secondNumber).ToString();
                        break;
                    case '*':
                        label4.Text = (firstNumber * secondNumber).ToString();
                        break;
                    case '/':
                        label4.Text = (firstNumber / secondNumber).ToString();
                        break;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            label3.Text = "";
            label4.Text = "";
           
        }
    }
    
}
