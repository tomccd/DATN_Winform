using Microsoft.Data.SqlClient;
using System.Data;
namespace DATN_Winform
{
    public partial class Add_Type_Product : Form
    {
        Add_Product ref_product = null;
        SqlConnection conn = null;
        public Add_Type_Product()
        {
            InitializeComponent();
        }
        public Add_Product setRef
        {
            set
            {
                this.ref_product = value;
            }
        }
        public SqlConnection syncConnection
        {
            set
            {
                this.conn = value;
            }
        }
        private void label2_Click(object sender, EventArgs e)
        {
            DialogResult message = MessageBox.Show("Do you want to exit ?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (message == DialogResult.Yes)
            {
                ref_product.fillInTypeProductCboBox();
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txt_id_type_product.Text) || String.IsNullOrEmpty(this.txt_name_type_product.Text))
            {
                if (String.IsNullOrEmpty(this.txt_id_type_product.Text))
                {
                    txt_id_type_product.BackColor = Color.Red;
                }
                if (String.IsNullOrEmpty(this.txt_name_type_product.Text))
                {
                    txt_name_type_product.BackColor = Color.Red;
                }
            }
            else
            {
                string query = $"SELECT * FROM Type_Product WHERE ID_Type_Product = '{txt_id_type_product.Text}'";
                SqlCommand cmd = new SqlCommand(query, conn);
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        DialogResult message = MessageBox.Show($"Đã tồn tại ID {txt_id_type_product.Text}. Xin mời nhập lại", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txt_id_type_product.Text = "";
                        txt_name_type_product.Text = "";
                        this.ActiveControl = this.txt_id_type_product;
                    }
                    else
                    {
                        query = $"INSERT INTO Type_Product VALUES ('{txt_id_type_product.Text}','{txt_name_type_product.Text}');";
                        cmd = new SqlCommand(query, conn);
                        try
                        {
                            cmd.ExecuteNonQuery();
                            DialogResult message = MessageBox.Show("Insert to Type Product Table Successfully. Do you want to add more type of product?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (message != DialogResult.Yes)
                            {
                                ref_product.fillInTypeProductCboBox();
                                ref_product.updateCboBox = txt_name_type_product.Text;
                                Owner.Show();
                                this.Close();
                            }
                            else
                            {
                                txt_id_type_product.Text = "";
                                txt_name_type_product.Text = "";
                                this.ActiveControl = this.txt_id_type_product;
                            }
                        }
                        catch (SqlException ex)
                        {
                            DialogResult message = MessageBox.Show($"Can't Insert to Type Product Table with error: {ex} ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (SqlException ex)
                {
                    DialogResult message = MessageBox.Show($"Can't Execute Query to Type Product Table with error: {ex} ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txt_id_type_product.Text = "";
            txt_name_type_product.Text = "";
            this.ActiveControl = this.txt_id_type_product;
        }
        private void btn1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }
    }
}
