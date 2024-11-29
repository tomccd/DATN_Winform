using Microsoft.Data.SqlClient;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Threading;
namespace DATN_Winform
{
    public partial class Menu : Form
    {
        private SqlConnection conn = null;
        private string id = null;
        ArrayList total_IP_Address = new ArrayList();
        public Menu()
        {
            InitializeComponent();
            /*Show only menu at startup*/
            this.menu_Count1.Visible = true;
            //this.add_Devices1.Visible = false;
            //this.add_Product1.Visible = false;
            //this.delete_Products1.Visible = false;
        }

        /*Sync Connection between Tab*/
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
            this.menu_Count1.Visible = true;
            //this.add_Devices1.Visible = false;
            //this.add_Product1.Visible = false;
            //this.delete_Products1.Visible = false;
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

        private void menu_Count1_Load(object sender, EventArgs e)
        {
            this.menu_Count1.syncConnection = conn;
            changeContentOnMenu_Count();
        }
        private void changeContentOnMenu_Count()
        {
            if (conn != null)
            {
                /*Thực hiện truy vấn*/
                string numberOfTotalDevices = null;
                string queryNumberTotalDevices = "SELECT COUNT(IP_Address) FROM Devices;";
                string queryCollectIPAddress = "SELECT IP_Address FROM Devices;";
                SqlCommand cmd = new SqlCommand(queryNumberTotalDevices, conn);
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    numberOfTotalDevices = ds.Tables[0].Rows[0][0].ToString();
                    this.total_IP_Address.Clear();
                    try
                    {
                        cmd = new SqlCommand(queryCollectIPAddress, conn);
                        adapter = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        adapter.Fill(ds);
                        /*Collect IP Address*/
                        foreach(DataRow row in ds.Tables[0].Rows)
                        {
                            ArrayList element = new ArrayList();
                            element.Add(row[0].ToString());
                            element.Add(false);
                            this.total_IP_Address.Add(element);
                        }
                        /*Update content in Menu_Count*/
                        this.menu_Count1.changeLabelTotalDevice(numberOfTotalDevices);
                        this.menu_Count1.setIP_Address_ArrayList = this.total_IP_Address;
                    }
                    catch(SqlException ex)
                    {
                        DialogResult message = MessageBox.Show($"Can't execute on Collect IP_Address in Devices with error {ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (SqlException ex)
                {
                    DialogResult message = MessageBox.Show($"Can't execute on Couting Total IP_Address in Devices with error {ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
