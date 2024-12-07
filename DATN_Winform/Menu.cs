using Microsoft.Data.SqlClient;
using System.Collections;
using System.Data;
namespace DATN_Winform
{
    public partial class Menu : Form
    {
        private SqlConnection conn = null;
        bool isPush = false;
        private string id = null;
        ArrayList total_IP_Address = new ArrayList();
        public Menu()
        {
            InitializeComponent();
            /*Show only menu at startup*/
            this.menu_Count1.Visible = true;
            this.add_Product2.Visible = false;
            this.delete_Products1.Visible = false;
            this.add_Devices1.Visible = false;
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
            if (this.menu_Count1.Visible == false)
            {
                this.changeContentOnMenu_Count();
            }
            this.menu_Count1.Visible = true;
            this.add_Product2.Visible = false;
            this.delete_Products1.Visible = false;
            this.add_Devices1.Visible = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.add_Product2.Visible = true;
            this.menu_Count1.Visible = false;
            this.delete_Products1.Visible = false;
            this.add_Devices1.Visible = false;
            this.add_Product2.fillInTypeProductCboBox();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.menu_Count1.Visible = false;
            this.add_Product2.Visible = false;
            this.delete_Products1.Visible = true;
            this.add_Devices1.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (this.add_Devices1.Visible == false)
            {
                DialogResult message = MessageBox.Show("Việc thiết bị có thể làm sai lệch hệ thống giám sát. Bạn có thêm thiết bị mới không?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (message == DialogResult.Yes)
                {
                    this.updateArrayListOnAdd_Devices();
                    this.menu_Count1.Visible = false;
                    this.add_Product2.Visible = false;
                    this.delete_Products1.Visible = false;
                    this.add_Devices1.Visible = true;
                }
            }
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
            /*Load -> Sync*/
            this.menu_Count1.syncConnection = conn;
            changeContentOnMenu_Count();
        }
        private void add_Product2_Load(object sender, EventArgs e)
        {
            /*Load -> Sync*/
            this.add_Product2.syncConnection = conn;

        }
        private void delete_Products1_Load(object sender, EventArgs e)
        {
            /*Load -> Sync*/
            this.delete_Products1.syncConnection = conn;
        }
        private void add_Devices1_Load(object sender, EventArgs e)
        {
            /*Load -> Sync*/
            this.add_Devices1.syncConnection = conn;
            //updateArrayListOnAdd_Devices();
        }
        private void updateArrayListOnAdd_Devices()
        {
            if (conn != null)
            {
                if (this.total_IP_Address.Count == 0)
                {
                    /*Thực hiện truy vấn*/
                    string queryCollectIPAddress = "SELECT IP_Address FROM Devices;";
                    SqlCommand cmd = new SqlCommand(queryCollectIPAddress, conn);
                    try
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        /*Collect IP Address*/
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            ArrayList element = new ArrayList();
                            element.Add(row[0].ToString());
                            element.Add(false);
                            this.total_IP_Address.Add(element);
                        }
                        this.add_Devices1.set_IP_Address_ArrayList = this.total_IP_Address;
                    }
                    catch (SqlException ex)
                    {
                        DialogResult message = MessageBox.Show($"Can't execute on Collect IP_Address in Devices Tables with error {ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    this.add_Devices1.set_IP_Address_ArrayList = this.total_IP_Address;
                }
            }
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
                        total_IP_Address.Clear();
                        total_IP_Address = new ArrayList();
                        foreach (DataRow row in ds.Tables[0].Rows)
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
                    catch (SqlException ex)
                    {
                        DialogResult message = MessageBox.Show($"Can't execute on Collect IP_Address in Devices Tables with error {ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (SqlException ex)
                {
                    DialogResult message = MessageBox.Show($"Can't execute on Couting Total IP_Address in Devices Tables with error {ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
