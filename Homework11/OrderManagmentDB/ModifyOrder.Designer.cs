namespace OrderManagementDB
{
    partial class ModifyOrder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.submitButton = new System.Windows.Forms.Button();
            this.clientPhoneNumberTextBox = new System.Windows.Forms.TextBox();
            this.clientNameTextBox = new System.Windows.Forms.TextBox();
            this.noteTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.totalPriceLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.orderIDlabel = new System.Windows.Forms.Label();
            this.orderDateLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.OrderDetailGridView = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.editSelectedItemBtn = new System.Windows.Forms.Button();
            this.deleteSelectionBtn = new System.Windows.Forms.Button();
            this.addItemBtn = new System.Windows.Forms.Button();
            this.descriptionBox = new System.Windows.Forms.TextBox();
            this.unitPriceBox = new System.Windows.Forms.TextBox();
            this.quantityBox = new System.Windows.Forms.TextBox();
            this.productNameBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.detailBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OrderDetailGridView)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.detailBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel1.Controls.Add(this.submitButton);
            this.panel1.Controls.Add(this.clientPhoneNumberTextBox);
            this.panel1.Controls.Add(this.clientNameTextBox);
            this.panel1.Controls.Add(this.noteTextBox);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.totalPriceLabel);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.orderIDlabel);
            this.panel1.Controls.Add(this.orderDateLabel);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1350, 279);
            this.panel1.TabIndex = 0;
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(1144, 127);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(154, 49);
            this.submitButton.TabIndex = 2;
            this.submitButton.Text = "提交";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // clientPhoneNumberTextBox
            // 
            this.clientPhoneNumberTextBox.Location = new System.Drawing.Point(608, 135);
            this.clientPhoneNumberTextBox.Name = "clientPhoneNumberTextBox";
            this.clientPhoneNumberTextBox.Size = new System.Drawing.Size(238, 35);
            this.clientPhoneNumberTextBox.TabIndex = 1;
            // 
            // clientNameTextBox
            // 
            this.clientNameTextBox.Location = new System.Drawing.Point(608, 55);
            this.clientNameTextBox.Name = "clientNameTextBox";
            this.clientNameTextBox.Size = new System.Drawing.Size(238, 35);
            this.clientNameTextBox.TabIndex = 1;
            // 
            // noteTextBox
            // 
            this.noteTextBox.Location = new System.Drawing.Point(184, 201);
            this.noteTextBox.Name = "noteTextBox";
            this.noteTextBox.Size = new System.Drawing.Size(1114, 35);
            this.noteTextBox.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(870, 55);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label3.Size = new System.Drawing.Size(134, 31);
            this.label3.TabIndex = 0;
            this.label3.Text = "创建日期：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(78, 201);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label6.Size = new System.Drawing.Size(86, 31);
            this.label6.TabIndex = 0;
            this.label6.Text = "备注：";
            // 
            // totalPriceLabel
            // 
            this.totalPriceLabel.AutoSize = true;
            this.totalPriceLabel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.totalPriceLabel.Location = new System.Drawing.Point(996, 134);
            this.totalPriceLabel.Name = "totalPriceLabel";
            this.totalPriceLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.totalPriceLabel.Size = new System.Drawing.Size(0, 31);
            this.totalPriceLabel.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(870, 135);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label5.Size = new System.Drawing.Size(134, 31);
            this.label5.TabIndex = 0;
            this.label5.Text = "订单总额：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(482, 135);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label4.Size = new System.Drawing.Size(134, 31);
            this.label4.TabIndex = 0;
            this.label4.Text = "客户电话：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(482, 55);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(134, 31);
            this.label2.TabIndex = 0;
            this.label2.Text = "客户姓名：";
            // 
            // orderIDlabel
            // 
            this.orderIDlabel.AutoSize = true;
            this.orderIDlabel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.orderIDlabel.Location = new System.Drawing.Point(178, 55);
            this.orderIDlabel.Name = "orderIDlabel";
            this.orderIDlabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.orderIDlabel.Size = new System.Drawing.Size(0, 31);
            this.orderIDlabel.TabIndex = 0;
            // 
            // orderDateLabel
            // 
            this.orderDateLabel.AutoSize = true;
            this.orderDateLabel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.orderDateLabel.Location = new System.Drawing.Point(996, 55);
            this.orderDateLabel.Name = "orderDateLabel";
            this.orderDateLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.orderDateLabel.Size = new System.Drawing.Size(0, 31);
            this.orderDateLabel.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(78, 55);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(110, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "订单号：";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.OrderDetailGridView);
            this.panel2.Location = new System.Drawing.Point(12, 297);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1350, 578);
            this.panel2.TabIndex = 1;
            // 
            // OrderDetailGridView
            // 
            this.OrderDetailGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.OrderDetailGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OrderDetailGridView.Location = new System.Drawing.Point(0, 0);
            this.OrderDetailGridView.MultiSelect = false;
            this.OrderDetailGridView.Name = "OrderDetailGridView";
            this.OrderDetailGridView.RowHeadersWidth = 82;
            this.OrderDetailGridView.RowTemplate.Height = 37;
            this.OrderDetailGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.OrderDetailGridView.Size = new System.Drawing.Size(1350, 578);
            this.OrderDetailGridView.TabIndex = 0;
            this.OrderDetailGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.OrderDetailGridView_CellEndEdit);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.editSelectedItemBtn);
            this.panel3.Controls.Add(this.deleteSelectionBtn);
            this.panel3.Controls.Add(this.addItemBtn);
            this.panel3.Controls.Add(this.descriptionBox);
            this.panel3.Controls.Add(this.unitPriceBox);
            this.panel3.Controls.Add(this.quantityBox);
            this.panel3.Controls.Add(this.productNameBox);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Location = new System.Drawing.Point(12, 881);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1350, 180);
            this.panel3.TabIndex = 2;
            // 
            // editSelectedItemBtn
            // 
            this.editSelectedItemBtn.Location = new System.Drawing.Point(970, 21);
            this.editSelectedItemBtn.Name = "editSelectedItemBtn";
            this.editSelectedItemBtn.Size = new System.Drawing.Size(161, 43);
            this.editSelectedItemBtn.TabIndex = 6;
            this.editSelectedItemBtn.Text = "编辑选中项";
            this.editSelectedItemBtn.UseVisualStyleBackColor = true;
            this.editSelectedItemBtn.Click += new System.EventHandler(this.editSelectedItemBtn_Click);
            // 
            // deleteSelectionBtn
            // 
            this.deleteSelectionBtn.Location = new System.Drawing.Point(1137, 20);
            this.deleteSelectionBtn.Name = "deleteSelectionBtn";
            this.deleteSelectionBtn.Size = new System.Drawing.Size(161, 43);
            this.deleteSelectionBtn.TabIndex = 6;
            this.deleteSelectionBtn.Text = "删除选中项";
            this.deleteSelectionBtn.UseVisualStyleBackColor = true;
            this.deleteSelectionBtn.Click += new System.EventHandler(this.deleteSelectionBtn_Click);
            // 
            // addItemBtn
            // 
            this.addItemBtn.Location = new System.Drawing.Point(810, 21);
            this.addItemBtn.Name = "addItemBtn";
            this.addItemBtn.Size = new System.Drawing.Size(154, 43);
            this.addItemBtn.TabIndex = 5;
            this.addItemBtn.Text = "添加";
            this.addItemBtn.UseVisualStyleBackColor = true;
            this.addItemBtn.Click += new System.EventHandler(this.addItemBtn_Click);
            // 
            // descriptionBox
            // 
            this.descriptionBox.Location = new System.Drawing.Point(463, 82);
            this.descriptionBox.Name = "descriptionBox";
            this.descriptionBox.Size = new System.Drawing.Size(835, 35);
            this.descriptionBox.TabIndex = 4;
            // 
            // unitPriceBox
            // 
            this.unitPriceBox.Location = new System.Drawing.Point(463, 27);
            this.unitPriceBox.Name = "unitPriceBox";
            this.unitPriceBox.Size = new System.Drawing.Size(140, 35);
            this.unitPriceBox.TabIndex = 3;
            // 
            // quantityBox
            // 
            this.quantityBox.Location = new System.Drawing.Point(184, 82);
            this.quantityBox.Name = "quantityBox";
            this.quantityBox.Size = new System.Drawing.Size(174, 35);
            this.quantityBox.TabIndex = 2;
            // 
            // productNameBox
            // 
            this.productNameBox.Location = new System.Drawing.Point(184, 26);
            this.productNameBox.Name = "productNameBox";
            this.productNameBox.Size = new System.Drawing.Size(174, 35);
            this.productNameBox.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(380, 82);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 31);
            this.label11.TabIndex = 0;
            this.label11.Text = "描述";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(78, 82);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 31);
            this.label8.TabIndex = 0;
            this.label8.Text = "数量";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(380, 26);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 31);
            this.label10.TabIndex = 0;
            this.label10.Text = "单价";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(78, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 31);
            this.label7.TabIndex = 0;
            this.label7.Text = "产品名";
            // 
            // ModifyOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1374, 1073);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(1000, 900);
            this.Name = "ModifyOrder";
            this.Text = "ModifyOrder";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ModifyOrder_FormClosed);
            this.Load += new System.EventHandler(this.ModifyOrder_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.OrderDetailGridView)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.detailBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView OrderDetailGridView;
        private System.Windows.Forms.BindingSource detailBindingSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label orderIDlabel;
        private System.Windows.Forms.Label orderDateLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox clientPhoneNumberTextBox;
        private System.Windows.Forms.TextBox clientNameTextBox;
        private System.Windows.Forms.TextBox noteTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label totalPriceLabel;
        private System.Windows.Forms.DataGridViewImageColumn imageDataGridViewImageColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isDesignableDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button addItemBtn;
        private System.Windows.Forms.TextBox descriptionBox;
        private System.Windows.Forms.TextBox unitPriceBox;
        private System.Windows.Forms.TextBox quantityBox;
        private System.Windows.Forms.TextBox productNameBox;
        private System.Windows.Forms.Button deleteSelectionBtn;
        private System.Windows.Forms.Button editSelectedItemBtn;
    }
}