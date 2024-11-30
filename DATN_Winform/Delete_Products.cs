using Microsoft.Data.SqlClient;
using System.Data;
namespace DATN_Winform
{
    public partial class Delete_Products : UserControl
    {
        SqlConnection conn = null;
        public Delete_Products()
        {
            InitializeComponent();
            this.ActiveControl = this.cbo_choice;
        }
        //Sync Connection
        public SqlConnection syncConnection
        {
            set
            {
                this.conn = value;
            }
        }
        private void cbo_choice_Clicked(object sender, EventArgs e)
        {
            cbo_choice.BackColor = Color.White;
        }
        private void txt_input_Clicked(object sender, EventArgs e)
        {
            txt_input.BackColor = Color.White;
        }
        private void btn_delete_product_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(cbo_choice.Text) || String.IsNullOrEmpty(txt_input.Text))
            {
                if (String.IsNullOrEmpty(cbo_choice.Text))
                {
                    cbo_choice.BackColor = Color.Red;
                }
                if (String.IsNullOrEmpty(txt_input.Text))
                {
                    txt_input.BackColor = Color.Red;
                }
            }
            else
            {
                /*Nếu lựa chọn muốn xóa là mã sản phẩm*/
                if (cbo_choice.SelectedIndex == 0)
                {
                    /*Kiểm tra xem mã sản phẩm đó có tồn tại không ?*/
                    string query = $"SELECT ID_Product FROM Products WHERE ID_Product = '{txt_input.Text}'";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    try
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            /*Thực hiện xóa dữ liệu ở bảng Weigh_Certificate*/
                            query = $"DELETE FROM Weigh_Certificate WHERE ID_Product = '{txt_input.Text}'";
                            cmd = new SqlCommand(query, conn);
                            try
                            {
                                cmd.ExecuteNonQuery();
                                /*Thực hiện xóa dữ liệu ở bảng Products*/
                                query = $"DELETE FROM Products WHERE ID_Product = '{txt_input.Text}'";
                                cmd = new SqlCommand(query, conn);
                                try
                                {
                                    cmd.ExecuteNonQuery();
                                    DialogResult message = MessageBox.Show($"Delete Product with ID: {txt_input.Text} From Products Table Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    query = "SELECT Products.ID_Product, Products.Name_Product, Type_Product.Name_Type_Product FROM Products INNER JOIN Type_Product ON Products.ID_Type_Product = Type_Product.ID_Type_Product;";
                                    cmd = new SqlCommand(query, conn);
                                    try
                                    {
                                        adapter = new SqlDataAdapter(cmd);
                                        ds = new DataSet();
                                        adapter.Fill(ds);
                                        if (ds.Tables[0].Rows.Count > 0)
                                        {
                                            this.dataGrid_Products.DataSource = ds.Tables[0];
                                            /*Sửa tên cột*/
                                            this.dataGrid_Products.Columns[0].HeaderText = "ID kiểu sản phẩm";
                                            this.dataGrid_Products.Columns[1].HeaderText = "Tên sản phẩm";
                                            this.dataGrid_Products.Columns[2].HeaderText = "Tên kiểu sản phẩm";
                                            /*Sửa màu cột*/
                                            this.dataGrid_Products.EnableHeadersVisualStyles = false;
                                            this.dataGrid_Products.ColumnHeadersDefaultCellStyle.BackColor = Color.AliceBlue;
                                            this.dataGrid_Products.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                                        }
                                    }
                                    catch (SqlException ex)
                                    {
                                        message = MessageBox.Show($"Can't Execute Query to Products Table with error: {ex} ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    txt_input.Text = "";
                                    cbo_choice.SelectedIndex = -1;
                                    this.ActiveControl = this.cbo_choice;
                                }
                                catch (SqlException ex)
                                {
                                    DialogResult message = MessageBox.Show($"Can't delete from Products Tables with error: {ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            catch (SqlException ex)
                            {
                                DialogResult message = MessageBox.Show($"Can't delete from Weigh_Certificate Tables with error: {ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            DialogResult message = MessageBox.Show("Can't find that ID in Products Tables", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (SqlException ex)
                    {
                        DialogResult message = MessageBox.Show($"Can't execute query to Products Table with error: {ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (cbo_choice.SelectedIndex == 1)
                {
                    /*Trích xuất mã sản phẩm nếu tên sản phẩm đó có tồn tại*/
                    string query = $"SELECT ID_Product FROM Products WHERE Name_Product = '{txt_input.Text}'";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    try
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            /*Có thể sẽ có nhiều ID trùng tên?*/
                            foreach (DataRow row in ds.Tables[0].Rows)
                            {
                                string id_product = row[0].ToString();
                                /*Thực hiện xóa ở Weigh_Certificate Table*/
                                query = $"DELETE FROM Weigh_Certificate WHERE ID_Product = '{id_product}';";
                                cmd = new SqlCommand(query, conn);
                                try
                                {
                                    cmd.ExecuteNonQuery();
                                    /*Thực hiện xóa ở Products Table*/
                                    query = $"DELETE FROM Products WHERE ID_Product = '{id_product}';";
                                    cmd = new SqlCommand(query, conn);
                                    try
                                    {
                                        cmd.ExecuteNonQuery();
                                        DialogResult message = MessageBox.Show($"Delete Product with Name: {txt_input.Text} From Products Table Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        cmd.ExecuteNonQuery();
                                        query = "SELECT Products.ID_Product, Products.Name_Product, Type_Product.Name_Type_Product FROM Products INNER JOIN Type_Product ON Products.ID_Type_Product = Type_Product.ID_Type_Product;";
                                        cmd = new SqlCommand(query, conn);
                                        try
                                        {
                                            adapter = new SqlDataAdapter(cmd);
                                            ds = new DataSet();
                                            adapter.Fill(ds);
                                            if (ds.Tables[0].Rows.Count > 0)
                                            {
                                                this.dataGrid_Products.DataSource = ds.Tables[0];
                                                /*Sửa tên cột*/
                                                this.dataGrid_Products.Columns[0].HeaderText = "ID kiểu sản phẩm";
                                                this.dataGrid_Products.Columns[1].HeaderText = "Tên sản phẩm";
                                                this.dataGrid_Products.Columns[2].HeaderText = "Tên kiểu sản phẩm";
                                                /*Sửa màu cột*/
                                                this.dataGrid_Products.EnableHeadersVisualStyles = false;
                                                this.dataGrid_Products.ColumnHeadersDefaultCellStyle.BackColor = Color.AliceBlue;
                                                this.dataGrid_Products.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                                            }
                                        }
                                        catch (SqlException ex)
                                        {
                                            message = MessageBox.Show($"Can't Execute Query to Products Table with error: {ex} ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                        txt_input.Text = "";
                                        cbo_choice.SelectedIndex = -1;
                                        this.ActiveControl = this.cbo_choice;
                                    }
                                    catch (SqlException ex)
                                    {
                                        DialogResult message = MessageBox.Show($"Can't delete from Products Tables with error: {ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                catch (SqlException ex)
                                {
                                    DialogResult message = MessageBox.Show($"Can't delete from Weigh_Certificate Tables with error: {ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    break;
                                }
                            }
                        }
                        else
                        {
                            DialogResult message = MessageBox.Show("Can't find that Name in Products Tables", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (SqlException ex)
                    {
                        DialogResult message = MessageBox.Show($"Can't execute query to Products Table with error: {ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btn_reset_products_Click(object sender, EventArgs e)
        {
            txt_input.BackColor = Color.White;
            cbo_choice.BackColor = Color.White;
            txt_input.Text = "";
            cbo_choice.SelectedIndex = -1;
            this.ActiveControl = this.cbo_choice;
            this.dataGrid_Products.DataSource = null;
        }
    }
}
