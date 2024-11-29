namespace DATN_Winform
{
    partial class Menu_Count
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            panel2 = new Panel();
            label_total_device = new Label();
            label5 = new Label();
            panel3 = new Panel();
            label_onl_device = new Label();
            label2 = new Label();
            panel4 = new Panel();
            comboBox1 = new ComboBox();
            label4 = new Label();
            label3 = new Label();
            dataGrid_weighed_Product = new DataGridView();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGrid_weighed_Product).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ButtonHighlight;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(panel3);
            panel1.Location = new Point(29, 35);
            panel1.Name = "panel1";
            panel1.Size = new Size(1088, 317);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.Highlight;
            panel2.Controls.Add(label_total_device);
            panel2.Controls.Add(label5);
            panel2.Location = new Point(100, 49);
            panel2.Name = "panel2";
            panel2.Size = new Size(313, 225);
            panel2.TabIndex = 2;
            // 
            // label_total_device
            // 
            label_total_device.AutoSize = true;
            label_total_device.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_total_device.ForeColor = SystemColors.ControlLightLight;
            label_total_device.Location = new Point(144, 115);
            label_total_device.Name = "label_total_device";
            label_total_device.Size = new Size(26, 29);
            label_total_device.TabIndex = 1;
            label_total_device.Text = "0";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = SystemColors.ControlLightLight;
            label5.Location = new Point(58, 55);
            label5.Name = "label5";
            label5.Size = new Size(179, 29);
            label5.TabIndex = 0;
            label5.Text = "Tổng số thiết bị";
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.Highlight;
            panel3.Controls.Add(label_onl_device);
            panel3.Controls.Add(label2);
            panel3.Location = new Point(701, 49);
            panel3.Name = "panel3";
            panel3.Size = new Size(313, 225);
            panel3.TabIndex = 1;
            // 
            // label_onl_device
            // 
            label_onl_device.AutoSize = true;
            label_onl_device.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_onl_device.ForeColor = SystemColors.ControlLightLight;
            label_onl_device.Location = new Point(144, 115);
            label_onl_device.Name = "label_onl_device";
            label_onl_device.Size = new Size(26, 29);
            label_onl_device.TabIndex = 1;
            label_onl_device.Text = "0";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ControlLightLight;
            label2.Location = new Point(28, 55);
            label2.Name = "label2";
            label2.Size = new Size(271, 29);
            label2.TabIndex = 0;
            label2.Text = "Thiết bị đang trực tuyến";
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.ButtonHighlight;
            panel4.Controls.Add(comboBox1);
            panel4.Controls.Add(label4);
            panel4.Controls.Add(label3);
            panel4.Controls.Add(dataGrid_weighed_Product);
            panel4.Location = new Point(29, 430);
            panel4.Name = "panel4";
            panel4.Size = new Size(1088, 427);
            panel4.TabIndex = 1;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Certificate Product", "Non-Certificate Product" });
            comboBox1.Location = new Point(365, 367);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(250, 33);
            comboBox1.TabIndex = 3;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(76, 367);
            label4.Name = "label4";
            label4.Size = new Size(248, 29);
            label4.TabIndex = 2;
            label4.Text = "Loại sản phẩm đã cân";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(76, 27);
            label3.Name = "label3";
            label3.Size = new Size(305, 29);
            label3.TabIndex = 1;
            label3.Text = "Thông tin sản phẩm đã cân";
            // 
            // dataGrid_weighed_Product
            // 
            dataGrid_weighed_Product.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGrid_weighed_Product.Location = new Point(76, 79);
            dataGrid_weighed_Product.Name = "dataGrid_weighed_Product";
            dataGrid_weighed_Product.RowHeadersWidth = 62;
            dataGrid_weighed_Product.Size = new Size(939, 252);
            dataGrid_weighed_Product.TabIndex = 0;
            // 
            // Menu_Count
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel4);
            Controls.Add(panel1);
            Name = "Menu_Count";
            Size = new Size(1167, 903);
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGrid_weighed_Product).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel3;
        private Label label2;
        private Label label_onl_device;
        private Panel panel4;
        private Label label4;
        private Label label3;
        private DataGridView dataGrid_weighed_Product;
        private ComboBox comboBox1;
        private Panel panel2;
        private Label label_total_device;
        private Label label5;
    }
}
