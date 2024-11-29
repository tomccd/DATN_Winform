namespace DATN_Winform
{
    partial class Add_Type_Product
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
            panel2 = new Panel();
            label2 = new Label();
            label1 = new Label();
            panel3 = new Panel();
            label3 = new Label();
            dataGridView1 = new DataGridView();
            panel4 = new Panel();
            button2 = new Button();
            button1 = new Button();
            txt_name_type_product = new TextBox();
            txt_id_type_product = new TextBox();
            label5 = new Label();
            label4 = new Label();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Highlight;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1167, 116);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Location = new Point(-1, 111);
            panel2.Name = "panel2";
            panel2.Size = new Size(1167, 399);
            panel2.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ControlLightLight;
            label2.Location = new Point(1105, 45);
            label2.Name = "label2";
            label2.Size = new Size(25, 29);
            label2.TabIndex = 1;
            label2.Text = "x";
            label2.Click += label2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(39, 45);
            label1.Name = "label1";
            label1.Size = new Size(335, 29);
            label1.TabIndex = 0;
            label1.Text = "Cập nhật chủng loại sản phẩm";
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ButtonHighlight;
            panel3.Controls.Add(label3);
            panel3.Controls.Add(dataGridView1);
            panel3.Location = new Point(12, 147);
            panel3.Name = "panel3";
            panel3.Size = new Size(1131, 393);
            panel3.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(21, 27);
            label3.Name = "label3";
            label3.Size = new Size(351, 29);
            label3.TabIndex = 1;
            label3.Text = "Danh sách chủng loại sản phẩm";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(23, 80);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(1091, 281);
            dataGridView1.TabIndex = 0;
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.ButtonHighlight;
            panel4.Controls.Add(button2);
            panel4.Controls.Add(button1);
            panel4.Controls.Add(txt_name_type_product);
            panel4.Controls.Add(txt_id_type_product);
            panel4.Controls.Add(label5);
            panel4.Controls.Add(label4);
            panel4.Location = new Point(12, 582);
            panel4.Name = "panel4";
            panel4.Size = new Size(1131, 289);
            panel4.TabIndex = 2;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.Highlight;
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.ForeColor = SystemColors.Control;
            button2.Location = new Point(667, 219);
            button2.Name = "button2";
            button2.Size = new Size(131, 48);
            button2.TabIndex = 5;
            button2.Text = "Reset";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.Highlight;
            button1.ForeColor = SystemColors.Control;
            button1.Location = new Point(260, 219);
            button1.Name = "button1";
            button1.Size = new Size(127, 48);
            button1.TabIndex = 4;
            button1.Text = "Thêm";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // txt_name_type_product
            // 
            txt_name_type_product.Location = new Point(476, 139);
            txt_name_type_product.Name = "txt_name_type_product";
            txt_name_type_product.Size = new Size(322, 31);
            txt_name_type_product.TabIndex = 3;
            // 
            // txt_id_type_product
            // 
            txt_id_type_product.Location = new Point(476, 54);
            txt_id_type_product.Name = "txt_id_type_product";
            txt_id_type_product.Size = new Size(322, 31);
            txt_id_type_product.TabIndex = 2;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(97, 138);
            label5.Name = "label5";
            label5.Size = new Size(209, 29);
            label5.TabIndex = 1;
            label5.Text = "Tên loại sản phẩm";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(97, 56);
            label4.Name = "label4";
            label4.Size = new Size(201, 29);
            label4.TabIndex = 0;
            label4.Text = "Mã loại sản phẩm";
            // 
            // Add_Type_Product
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1167, 903);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            KeyPreview = true;
            Name = "Add_Type_Product";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Add_Type_Product";
            KeyDown += btn1_KeyDown;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label2;
        private Label label1;
        private Panel panel2;
        private Panel panel3;
        private DataGridView dataGridView1;
        private Label label3;
        private Panel panel4;
        private Button button2;
        private Button button1;
        private TextBox txt_name_type_product;
        private TextBox txt_id_type_product;
        private Label label5;
        private Label label4;
    }
}