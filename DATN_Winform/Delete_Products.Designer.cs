namespace DATN_Winform
{
    partial class Delete_Products
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
            dataGrid_Products = new DataGridView();
            label1 = new Label();
            panel2 = new Panel();
            btn_reset_products = new Button();
            btn_delete_product = new Button();
            txt_ten_san_pham = new TextBox();
            txt_ma_san_pham = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGrid_Products).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ButtonHighlight;
            panel1.Controls.Add(dataGrid_Products);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(32, 42);
            panel1.Name = "panel1";
            panel1.Size = new Size(1077, 415);
            panel1.TabIndex = 1;
            // 
            // dataGrid_Products
            // 
            dataGrid_Products.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGrid_Products.Location = new Point(56, 98);
            dataGrid_Products.Name = "dataGrid_Products";
            dataGrid_Products.RowHeadersWidth = 62;
            dataGrid_Products.Size = new Size(940, 264);
            dataGrid_Products.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(37, 38);
            label1.Name = "label1";
            label1.Size = new Size(178, 29);
            label1.TabIndex = 0;
            label1.Text = "Bảng sản phẩm";
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ButtonHighlight;
            panel2.Controls.Add(textBox1);
            panel2.Controls.Add(btn_reset_products);
            panel2.Controls.Add(btn_delete_product);
            panel2.Controls.Add(txt_ten_san_pham);
            panel2.Controls.Add(txt_ma_san_pham);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(32, 507);
            panel2.Name = "panel2";
            panel2.Size = new Size(1077, 358);
            panel2.TabIndex = 2;
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
            // 
            // btn_delete_product
            // 
            btn_delete_product.BackColor = SystemColors.Highlight;
            btn_delete_product.ForeColor = SystemColors.Control;
            btn_delete_product.Location = new Point(175, 281);
            btn_delete_product.Name = "btn_delete_product";
            btn_delete_product.Size = new Size(153, 59);
            btn_delete_product.TabIndex = 6;
            btn_delete_product.Text = "Xóa";
            btn_delete_product.UseVisualStyleBackColor = false;
            // 
            // txt_ten_san_pham
            // 
            txt_ten_san_pham.Location = new Point(521, 220);
            txt_ten_san_pham.Name = "txt_ten_san_pham";
            txt_ten_san_pham.ReadOnly = true;
            txt_ten_san_pham.Size = new Size(364, 31);
            txt_ten_san_pham.TabIndex = 4;
            // 
            // txt_ma_san_pham
            // 
            txt_ma_san_pham.Location = new Point(521, 51);
            txt_ma_san_pham.Name = "txt_ma_san_pham";
            txt_ma_san_pham.Size = new Size(364, 31);
            txt_ma_san_pham.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(56, 219);
            label4.Name = "label4";
            label4.Size = new Size(165, 29);
            label4.TabIndex = 2;
            label4.Text = "Tên sản phẩm";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(56, 128);
            label3.Name = "label3";
            label3.Size = new Size(272, 29);
            label3.TabIndex = 1;
            label3.Text = "Mã chủng loại sản phẩm";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(56, 50);
            label2.Name = "label2";
            label2.Size = new Size(157, 29);
            label2.TabIndex = 0;
            label2.Text = "Mã sản phẩm";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(521, 128);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(364, 31);
            textBox1.TabIndex = 8;
            // 
            // Delete_Products
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Delete_Products";
            Size = new Size(1167, 903);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGrid_Products).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private DataGridView dataGrid_Products;
        private Label label1;
        private Panel panel2;
        private TextBox textBox1;
        private Button btn_reset_products;
        private Button btn_delete_product;
        private TextBox txt_ten_san_pham;
        private TextBox txt_ma_san_pham;
        private Label label4;
        private Label label3;
        private Label label2;
    }
}
