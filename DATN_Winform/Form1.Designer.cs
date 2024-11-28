namespace DATN_Winform
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txt_taikhoan = new TextBox();
            txt_matkhau = new TextBox();
            bt_signin = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.DodgerBlue;
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(430, 65);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Narrow", 12F);
            label1.ForeColor = Color.White;
            label1.Location = new Point(400, 9);
            label1.Name = "label1";
            label1.Size = new Size(23, 29);
            label1.TabIndex = 0;
            label1.Text = "x";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16F);
            label2.Location = new Point(12, 164);
            label2.Name = "label2";
            label2.Size = new Size(406, 45);
            label2.TabIndex = 1;
            label2.Text = "Quản lý hệ thống phân loại";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(24, 384);
            label3.Name = "label3";
            label3.Size = new Size(113, 25);
            label3.TabIndex = 2;
            label3.Text = "Tài khoản SA";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(24, 475);
            label4.Name = "label4";
            label4.Size = new Size(86, 25);
            label4.TabIndex = 3;
            label4.Text = "Mật khẩu";
            // 
            // txt_taikhoan
            // 
            txt_taikhoan.Location = new Point(161, 381);
            txt_taikhoan.Name = "txt_taikhoan";
            txt_taikhoan.Size = new Size(242, 31);
            txt_taikhoan.TabIndex = 4;
            // 
            // txt_matkhau
            // 
            txt_matkhau.Location = new Point(161, 472);
            txt_matkhau.Name = "txt_matkhau";
            txt_matkhau.Size = new Size(242, 31);
            txt_matkhau.TabIndex = 5;
            // 
            // bt_signin
            // 
            bt_signin.BackColor = SystemColors.GradientActiveCaption;
            bt_signin.Location = new Point(41, 593);
            bt_signin.Name = "bt_signin";
            bt_signin.Size = new Size(362, 45);
            bt_signin.TabIndex = 6;
            bt_signin.Text = "Đăng nhập";
            bt_signin.UseVisualStyleBackColor = false;
            bt_signin.Click += bt_signin_Click;
            bt_signin.KeyDown += bt_signin_KeyDown;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(430, 690);
            Controls.Add(bt_signin);
            Controls.Add(txt_matkhau);
            Controls.Add(txt_taikhoan);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            KeyPreview = true;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            KeyDown += bt_signin_KeyDown;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txt_taikhoan;
        private TextBox txt_matkhau;
        private Button bt_signin;
    }
}
