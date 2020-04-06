namespace homework8
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.deliverDetail = new System.Windows.Forms.Button();
            this.price = new System.Windows.Forms.TextBox();
            this.num = new System.Windows.Forms.TextBox();
            this.id = new System.Windows.Forms.TextBox();
            this.name = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.deliverOrder = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.productIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productNumDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.OrderId = new System.Windows.Forms.TextBox();
            this.Customer = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.deliverDetail);
            this.groupBox1.Controls.Add(this.price);
            this.groupBox1.Controls.Add(this.num);
            this.groupBox1.Controls.Add(this.id);
            this.groupBox1.Controls.Add(this.name);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(62, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(251, 185);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "订单明细";
            // 
            // deliverDetail
            // 
            this.deliverDetail.Location = new System.Drawing.Point(78, 158);
            this.deliverDetail.Name = "deliverDetail";
            this.deliverDetail.Size = new System.Drawing.Size(75, 23);
            this.deliverDetail.TabIndex = 6;
            this.deliverDetail.Text = "提交订单明细";
            this.deliverDetail.UseVisualStyleBackColor = true;
            this.deliverDetail.Click += new System.EventHandler(this.deliverDetail_Click);
            // 
            // price
            // 
            this.price.Location = new System.Drawing.Point(109, 86);
            this.price.Name = "price";
            this.price.Size = new System.Drawing.Size(100, 25);
            this.price.TabIndex = 5;
            // 
            // num
            // 
            this.num.Location = new System.Drawing.Point(109, 56);
            this.num.Name = "num";
            this.num.Size = new System.Drawing.Size(100, 25);
            this.num.TabIndex = 4;
            // 
            // id
            // 
            this.id.Location = new System.Drawing.Point(109, 25);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(100, 25);
            this.id.TabIndex = 3;
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(109, 117);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(100, 25);
            this.name.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "productName";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "productNum";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "productPrice";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "productId";
            // 
            // deliverOrder
            // 
            this.deliverOrder.Location = new System.Drawing.Point(372, 388);
            this.deliverOrder.Name = "deliverOrder";
            this.deliverOrder.Size = new System.Drawing.Size(75, 23);
            this.deliverOrder.TabIndex = 7;
            this.deliverOrder.Text = "提交订单";
            this.deliverOrder.UseVisualStyleBackColor = true;
            this.deliverOrder.Click += new System.EventHandler(this.deliverOrder_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.productIdDataGridViewTextBoxColumn,
            this.productNumDataGridViewTextBoxColumn,
            this.productPriceDataGridViewTextBoxColumn,
            this.productNameDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.bindingSource1;
            this.dataGridView1.Location = new System.Drawing.Point(360, 52);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(612, 185);
            this.dataGridView1.TabIndex = 8;
            // 
            // productIdDataGridViewTextBoxColumn
            // 
            this.productIdDataGridViewTextBoxColumn.DataPropertyName = "productId";
            this.productIdDataGridViewTextBoxColumn.HeaderText = "productId";
            this.productIdDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.productIdDataGridViewTextBoxColumn.Name = "productIdDataGridViewTextBoxColumn";
            this.productIdDataGridViewTextBoxColumn.Width = 125;
            // 
            // productNumDataGridViewTextBoxColumn
            // 
            this.productNumDataGridViewTextBoxColumn.DataPropertyName = "productNum";
            this.productNumDataGridViewTextBoxColumn.HeaderText = "productNum";
            this.productNumDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.productNumDataGridViewTextBoxColumn.Name = "productNumDataGridViewTextBoxColumn";
            this.productNumDataGridViewTextBoxColumn.Width = 125;
            // 
            // productPriceDataGridViewTextBoxColumn
            // 
            this.productPriceDataGridViewTextBoxColumn.DataPropertyName = "productPrice";
            this.productPriceDataGridViewTextBoxColumn.HeaderText = "productPrice";
            this.productPriceDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.productPriceDataGridViewTextBoxColumn.Name = "productPriceDataGridViewTextBoxColumn";
            this.productPriceDataGridViewTextBoxColumn.Width = 125;
            // 
            // productNameDataGridViewTextBoxColumn
            // 
            this.productNameDataGridViewTextBoxColumn.DataPropertyName = "productName";
            this.productNameDataGridViewTextBoxColumn.HeaderText = "productName";
            this.productNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.productNameDataGridViewTextBoxColumn.Name = "productNameDataGridViewTextBoxColumn";
            this.productNameDataGridViewTextBoxColumn.Width = 125;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(homework8.OrderDetail);
            // 
            // OrderId
            // 
            this.OrderId.Location = new System.Drawing.Point(232, 332);
            this.OrderId.Name = "OrderId";
            this.OrderId.Size = new System.Drawing.Size(100, 25);
            this.OrderId.TabIndex = 9;
            // 
            // Customer
            // 
            this.Customer.Location = new System.Drawing.Point(622, 335);
            this.Customer.Name = "Customer";
            this.Customer.Size = new System.Drawing.Size(100, 25);
            this.Customer.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(137, 335);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "订单ID：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(515, 338);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 15);
            this.label6.TabIndex = 12;
            this.label6.Text = "用户名：";
            // 
            // Form2
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1073, 484);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Customer);
            this.Controls.Add(this.OrderId);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.deliverOrder);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button deliverDetail;
        private System.Windows.Forms.TextBox price;
        private System.Windows.Forms.TextBox num;
        private System.Windows.Forms.TextBox id;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.Button deliverOrder;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn productIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productNumDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.TextBox OrderId;
        private System.Windows.Forms.TextBox Customer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}