namespace DATN_Winform
{
    partial class Add_Devices
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
            dataGrid_Device_Productivity = new DataGridView();
            label1 = new Label();
            panel2 = new Panel();
            btn_reset_products = new Button();
            btn_add_devices = new Button();
            txt_name_devices = new TextBox();
            txt_ip_devices = new TextBox();
            label4 = new Label();
            label2 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGrid_Device_Productivity).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ButtonHighlight;
            panel1.Controls.Add(dataGrid_Device_Productivity);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(34, 44);
            panel1.Name = "panel1";
            panel1.Size = new Size(1077, 415);
            panel1.TabIndex = 2;
            // 
            // dataGrid_Device_Productivity
            // 
            dataGrid_Device_Productivity.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGrid_Device_Productivity.Location = new Point(56, 98);
            dataGrid_Device_Productivity.Name = "dataGrid_Device_Productivity";
            dataGrid_Device_Productivity.RowHeadersWidth = 62;
            dataGrid_Device_Productivity.Size = new Size(940, 264);
            dataGrid_Device_Productivity.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(37, 38);
            label1.Name = "label1";
            label1.Size = new Size(202, 29);
            label1.TabIndex = 0;
            label1.Text = "Năng suất thiết bị";
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ButtonHighlight;
            panel2.Controls.Add(btn_reset_products);
            panel2.Controls.Add(btn_add_devices);
            panel2.Controls.Add(txt_name_devices);
            panel2.Controls.Add(txt_ip_devices);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(34, 512);
            panel2.Name = "panel2";
            panel2.Size = new Size(1077, 358);
            panel2.TabIndex = 3;
            // 
            // btn_reset_products
            // 
            btn_reset_products.BackColor = SystemColors.Highlight;
            btn_reset_products.ForeColor = SystemColors.Control;
            btn_reset_products.Location = new Point(683, 281);
            btn_reset_products.Name = "btn_reset_products";
            btn_reset_products.Size = new Size(150, 59);
            btn_reset_products.TabIndex = 7;
            btn_reset_products.Text = "Reset";
            btn_reset_products.UseVisualStyleBackColor = false;
            btn_reset_products.Click += btn_reset_products_Click;
            // 
            // btn_add_devices
            // 
            btn_add_devices.BackColor = SystemColors.Highlight;
            btn_add_devices.ForeColor = SystemColors.Control;
            btn_add_devices.Location = new Point(175, 281);
            btn_add_devices.Name = "btn_add_devices";
            btn_add_devices.Size = new Size(153, 59);
            btn_add_devices.TabIndex = 6;
            btn_add_devices.Text = "Thêm";
            btn_add_devices.UseVisualStyleBackColor = false;
            btn_add_devices.Click += btn_add_device_Click;
            // 
            // txt_name_devices
            // 
            txt_name_devices.Location = new Point(521, 180);
            txt_name_devices.Name = "txt_name_devices";
            txt_name_devices.Size = new Size(364, 31);
            txt_name_devices.TabIndex = 4;
            txt_name_devices.Click += txt_name_devices_Clicked;
            // 
            // txt_ip_devices
            // 
            txt_ip_devices.Location = new Point(521, 76);
            txt_ip_devices.Name = "txt_ip_devices";
            txt_ip_devices.Size = new Size(364, 31);
            txt_ip_devices.TabIndex = 3;
            txt_ip_devices.Click += txt_ip_devices_Clicked;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(56, 179);
            label4.Name = "label4";
            label4.Size = new Size(134, 29);
            label4.TabIndex = 2;
            label4.Text = "Tên thiết bị";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(56, 75);
            label2.Name = "label2";
            label2.Size = new Size(127, 29);
            label2.TabIndex = 0;
            label2.Text = "IP Address";
            // 
            // Add_Devices
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Add_Devices";
            Size = new Size(1167, 903);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGrid_Device_Productivity).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private DataGridView dataGrid_Device_Productivity;
        private Label label1;
        private Panel panel2;
        private Button btn_reset_products;
        private Button btn_add_devices;
        private TextBox txt_name_devices;
        private TextBox txt_ip_devices;
        private Label label4;
        private Label label2;
    }
}
