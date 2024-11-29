namespace DATN_Winform
{
    partial class Add_Product
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
            label1 = new Label();
            dataGrid_Products = new DataGridView();
            panel2 = new Panel();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txt_ma_san_pham = new TextBox();
            txt_ten_san_pham = new TextBox();
            cbo_ma_chung_loai_san_pham = new ComboBox();
            btn_add_product = new Button();
            btn_reset_products = new Button();
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
            panel1.Location = new Point(32, 43);
            panel1.Name = "panel1";
            panel1.Size = new Size(1077, 415);
            panel1.TabIndex = 0;
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
            // dataGrid_Products
            // 
            dataGrid_Products.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGrid_Products.Location = new Point(56, 98);
            dataGrid_Products.Name = "dataGrid_Products";
            dataGrid_Products.RowHeadersWidth = 62;
            dataGrid_Products.Size = new Size(940, 264);
            dataGrid_Products.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ButtonHighlight;
            panel2.Controls.Add(btn_reset_products);
            panel2.Controls.Add(btn_add_product);
            panel2.Controls.Add(cbo_ma_chung_loai_san_pham);
            panel2.Controls.Add(txt_ten_san_pham);
            panel2.Controls.Add(txt_ma_san_pham);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(32, 507);
            panel2.Name = "panel2";
            panel2.Size = new Size(1077, 358);
            panel2.TabIndex = 1;
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
            // txt_ma_san_pham
            // 
            txt_ma_san_pham.Location = new Point(521, 51);
            txt_ma_san_pham.Name = "txt_ma_san_pham";
            txt_ma_san_pham.Size = new Size(364, 31);
            txt_ma_san_pham.TabIndex = 3;
            // 
            // txt_ten_san_pham
            // 
            txt_ten_san_pham.Location = new Point(521, 220);
            txt_ten_san_pham.Name = "txt_ten_san_pham";
            txt_ten_san_pham.Size = new Size(364, 31);
            txt_ten_san_pham.TabIndex = 4;
            // 
            // cbo_ma_chung_loai_san_pham
            // 
            cbo_ma_chung_loai_san_pham.FormattingEnabled = true;
            cbo_ma_chung_loai_san_pham.Location = new Point(521, 129);
            cbo_ma_chung_loai_san_pham.Name = "cbo_ma_chung_loai_san_pham";
            cbo_ma_chung_loai_san_pham.Size = new Size(364, 33);
            cbo_ma_chung_loai_san_pham.TabIndex = 5;
            // 
            // btn_add_product
            // 
            btn_add_product.BackColor = SystemColors.Highlight;
            btn_add_product.ForeColor = SystemColors.Control;
            btn_add_product.Location = new Point(175, 281);
            btn_add_product.Name = "btn_add_product";
            btn_add_product.Size = new Size(153, 59);
            btn_add_product.TabIndex = 6;
            btn_add_product.Text = "Thêm";
            btn_add_product.UseVisualStyleBackColor = false;
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
            // Add_Product
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Add_Product";
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
        private Label label1;
        private DataGridView dataGrid_Products;
        private Panel panel2;
        private Label label4;
        private Label label3;
        private Label label2;
        private Button btn_reset_products;
        private Button btn_add_product;
        private ComboBox cbo_ma_chung_loai_san_pham;
        private TextBox txt_ten_san_pham;
        private TextBox txt_ma_san_pham;
    }
}
