namespace DATN_Winform
{
    partial class Menu
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
            panel1 = new Panel();
            label2 = new Label();
            label1 = new Label();
            panel2 = new Panel();
            button5 = new Button();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            label_nameuser = new Label();
            panel3 = new Panel();
            add_Product2 = new Add_Product();
            menu_Count1 = new Menu_Count();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Highlight;
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1571, 97);
            panel1.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ControlLightLight;
            label2.Location = new Point(12, 38);
            label2.Name = "label2";
            label2.Size = new Size(446, 29);
            label2.TabIndex = 1;
            label2.Text = "Quản lý hệ thống phân loại - Form Chính\r\n";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(1523, 38);
            label1.Name = "label1";
            label1.Size = new Size(25, 29);
            label1.TabIndex = 0;
            label1.Text = "x";
            label1.Click += label1_Click;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.Highlight;
            panel2.Controls.Add(button5);
            panel2.Controls.Add(button4);
            panel2.Controls.Add(button3);
            panel2.Controls.Add(button2);
            panel2.Controls.Add(button1);
            panel2.Controls.Add(label_nameuser);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 97);
            panel2.Name = "panel2";
            panel2.Size = new Size(404, 903);
            panel2.TabIndex = 1;
            // 
            // button5
            // 
            button5.BackColor = SystemColors.Highlight;
            button5.Font = new Font("Tahoma", 12F);
            button5.ForeColor = Color.White;
            button5.Location = new Point(290, 835);
            button5.Name = "button5";
            button5.Size = new Size(114, 68);
            button5.TabIndex = 5;
            button5.Text = "Log out";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // button4
            // 
            button4.BackColor = SystemColors.Highlight;
            button4.Font = new Font("Tahoma", 12F);
            button4.ForeColor = Color.White;
            button4.Location = new Point(77, 712);
            button4.Name = "button4";
            button4.Size = new Size(239, 68);
            button4.TabIndex = 4;
            button4.Text = "Thêm thiết bị";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.BackColor = SystemColors.Highlight;
            button3.Font = new Font("Tahoma", 12F);
            button3.ForeColor = Color.White;
            button3.Location = new Point(77, 586);
            button3.Name = "button3";
            button3.Size = new Size(239, 68);
            button3.TabIndex = 3;
            button3.Text = "Xóa sản phẩm";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.Highlight;
            button2.Font = new Font("Tahoma", 12F);
            button2.ForeColor = Color.White;
            button2.Location = new Point(77, 467);
            button2.Name = "button2";
            button2.Size = new Size(239, 68);
            button2.TabIndex = 2;
            button2.Text = "Thêm sản phẩm";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.Highlight;
            button1.Font = new Font("Tahoma", 12F);
            button1.ForeColor = Color.White;
            button1.Location = new Point(77, 341);
            button1.Name = "button1";
            button1.Size = new Size(239, 68);
            button1.TabIndex = 1;
            button1.Text = "Trang chủ";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label_nameuser
            // 
            label_nameuser.AutoSize = true;
            label_nameuser.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_nameuser.ForeColor = SystemColors.ControlLightLight;
            label_nameuser.Location = new Point(60, 225);
            label_nameuser.Name = "label_nameuser";
            label_nameuser.Size = new Size(118, 29);
            label_nameuser.TabIndex = 0;
            label_nameuser.Text = "Xin chào, ";
            // 
            // panel3
            // 
            panel3.Controls.Add(add_Product2);
            panel3.Controls.Add(menu_Count1);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(404, 97);
            panel3.Name = "panel3";
            panel3.Size = new Size(1167, 903);
            panel3.TabIndex = 2;
            // 
            // add_Product2
            // 
            add_Product2.Location = new Point(0, 0);
            add_Product2.Name = "add_Product2";
            add_Product2.Size = new Size(1167, 903);
            add_Product2.TabIndex = 1;
            add_Product2.Load += add_Product2_Load;
            // 
            // menu_Count1
            // 
            menu_Count1.Location = new Point(0, 0);
            menu_Count1.Name = "menu_Count1";
            menu_Count1.Size = new Size(1167, 903);
            menu_Count1.TabIndex = 0;
            menu_Count1.Load += menu_Count1_Load;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1571, 1000);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Menu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Menu";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Label label1;
        private Label label2;
        private Button button1;
        private Label label_nameuser;
        private Button button5;
        private Button button4;
        private Button button3;
        private Button button2;
        private Panel panel3;
        private Menu_Count menu_Count1;
        private Add_Product add_Product2;
    }
}