using Microsoft.Data.SqlClient;
using System.Data;
namespace DATN_Winform
{
    public partial class Menu : Form
    {
        SqlConnection conn = null;
        string id = null;
        public Menu()
        {
            InitializeComponent();
        }
        public SqlConnection syncConnection
        {
            set
            {
                this.conn = value;
            }
        }
        public string syncID
        {
            set
            {
                this.id = value;
            }
        }
        /*Thay đổi bằng tên của admin*/
        public void changeLabelName(SqlConnection conn)
        {
            string name = returnAdminName(conn);
            this.label_nameuser.Text = this.label_nameuser.Text + name;
            Refresh();
        }
        public string returnAdminName(SqlConnection conn)
        {
            string name = null;
            if (conn != null)
            {
                string query = $"SELECT admin_name FROM Admin WHERE id='{this.id}';";
                SqlCommand sql = new SqlCommand(query, conn);
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(sql);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        name = ds.Tables[0].Rows[0][0].ToString(); // ROW index 0, Column Index 0
                        return name;
                    }
                }
                catch (Exception ex)
                {
                    DialogResult message = MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return name;
                }
            }
            return name;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult message = MessageBox.Show("This feature will be available in the future !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult message = MessageBox.Show("This feature will be available in the future !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult message = MessageBox.Show("This feature will be available in the future !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult message = MessageBox.Show("This feature will be available in the future !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult message = MessageBox.Show("Are you sure to logout?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (message == DialogResult.Yes)
            {
                Owner.Show();
                this.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            DialogResult message = MessageBox.Show("Are you sure to exit?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (message == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
