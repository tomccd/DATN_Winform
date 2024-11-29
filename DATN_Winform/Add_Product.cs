using Microsoft.Data.SqlClient;
using System.Data;
namespace DATN_Winform
{
    public partial class Add_Product : UserControl
    {
        SqlConnection conn = null;
        public Add_Product()
        {
            InitializeComponent();
        }
        //Sync Connection
        public SqlConnection syncConnection
        {
            set
            {
                this.conn = value;
            }
        }
        private void txt_ma_san_pham_Clicked(object sender, EventArgs e)
        {
            txt_ma_san_pham.BackColor = Color.White;
        }
        private void cbo_ten_chung_loai_san_pham_Clicked(object sender, EventArgs e)
        {
            cbo_ten_chung_loai_san_pham.BackColor = Color.White;
        }
        private void txt_ten_san_pham_Clicked(object sender, EventArgs e)
        {
            txt_ten_san_pham.BackColor = Color.White;
        }
        /*Fill in cbox*/
        public void fillInTypeProductCboBox()
        {
            this.cbo_ten_chung_loai_san_pham.Items.Clear();
            /*Tạo Query*/
            string query = "SELECT Name_Type_Product FROM Type_Product;";
            SqlCommand cmd = new SqlCommand(query, conn);
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Console.WriteLine(row[0].ToString());
                    this.cbo_ten_chung_loai_san_pham.Items.Add(row[0].ToString());
                }
                this.cbo_ten_chung_loai_san_pham.Items.Add("Lựa chọn khác");
            }
            catch (SqlException ex)
            {
                DialogResult message = MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public string updateCboBox
        {
            set
            {
                this.cbo_ten_chung_loai_san_pham.Text = value;
            }
        }

        private void cbo_ten_chung_loai_san_pham_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*Nếu là lựa chọn cuối cùng => Chuyển sang tab bổ sung loại sản phẩm khác*/
            if (this.cbo_ten_chung_loai_san_pham.Text == "Lựa chọn khác")
            {
                DialogResult message = MessageBox.Show("Có vẻ loại sản phẩm bạn không tìm thấy. Bạn có muốn thêm loại sản phẩm nữa không? Cảnh báo: Việc này có thể thay đổi trạng thái làm việc của cả hệ thống", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (message == DialogResult.Yes)
                {
                    Add_Type_Product add_type_product = new Add_Type_Product();
                    add_type_product.setRef = this;
                    add_type_product.syncConnection = conn;
                    add_type_product.Show(this);
                }
                else
                {
                    cbo_ten_chung_loai_san_pham.Text = "";
                }
            }
        }

        private void btn_add_product_Click_1(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txt_ten_san_pham.Text) || String.IsNullOrEmpty(this.cbo_ten_chung_loai_san_pham.Text) || String.IsNullOrEmpty(this.txt_ma_san_pham.Text))
            {
                if (String.IsNullOrEmpty(this.txt_ten_san_pham.Text))
                {
                    this.txt_ten_san_pham.BackColor = Color.Red;
                }
                if (String.IsNullOrEmpty(this.cbo_ten_chung_loai_san_pham.Text))
                {
                    this.cbo_ten_chung_loai_san_pham.BackColor = Color.Red;
                }
                if (String.IsNullOrEmpty(this.txt_ma_san_pham.Text))
                {
                    this.txt_ten_san_pham.BackColor = Color.Red;
                }
            }
            else
            {
                string query = $"SELECT ID_Type_Product FROM Type_Product WHERE Name_Type_Product = '{cbo_ten_chung_loai_san_pham.Text}'";
                SqlCommand cmd = new SqlCommand(query, conn);
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        string id_product = ds.Tables[0].Rows[0][0].ToString();
                        query = $"INSERT INTO Products VALUES('{txt_ma_san_pham.Text}','{id_product}','{txt_ten_san_pham.Text}');";
                        cmd = new SqlCommand(query, conn);
                        try
                        {
                            cmd.ExecuteNonQuery();
                            DialogResult message = MessageBox.Show("Insert to Type Product Table Successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txt_ma_san_pham.Text = "";
                            cbo_ten_chung_loai_san_pham.Text = "";
                            txt_ten_san_pham.Text = "";
                        }
                        catch (SqlException ex)
                        {
                            DialogResult message = MessageBox.Show($"Can't Insert to Products Table with error: {ex} ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (SqlException ex)
                {
                    DialogResult message = MessageBox.Show($"Can't Execute Query to Products Table with error: {ex} ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_reset_products_Click(object sender, EventArgs e)
        {
            txt_ma_san_pham.BackColor = Color.White;
            cbo_ten_chung_loai_san_pham.BackColor = Color.White;
            txt_ten_san_pham.BackColor = Color.White;
            //Reset
            txt_ma_san_pham.Text = "";
            cbo_ten_chung_loai_san_pham.Text = "";
            this.fillInTypeProductCboBox();
            txt_ten_san_pham.Text = "";
            this.ActiveControl = this.txt_ma_san_pham;
        }
    }
}
