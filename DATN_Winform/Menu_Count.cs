using Microsoft.Data.SqlClient;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Net.NetworkInformation;
namespace DATN_Winform
{
    public partial class Menu_Count : UserControl
    {
        private SqlConnection conn = null;
        /*Create ArrayList that contain IP_Address*/
        ArrayList total_IP_Address = new ArrayList();
        //Create a ManualResetEvent
        private ManualResetEvent mre = new ManualResetEvent(false);
        //Number of active device
        private int active_device = 0;
        public Menu_Count()
        {
            InitializeComponent();
        }
        //Starting Ping
        private void StartingPingThread(ref ArrayList totalElement)
        {
            if (totalElement.Count > 0)
            {
                Console.WriteLine("Starting create Thread");
                foreach (ArrayList element in totalElement)
                {
                    /*Each IP will create a Thread to check if that IP Address is existed */
                    Thread pingThread = new Thread(() => ping(1, element));
                    pingThread.IsBackground = true;
                    pingThread.Start();
                }
            }
        }
        //Ping to Registered Device
        private void ping(double tout, ArrayList element)
        {
            //Wait for mre flags
            while (!mre.WaitOne(250))
            {
                Console.WriteLine("Thread OK");
                PingReply reply = null;
                Ping ping = new Ping();
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                long timeout = (long)tout * 1000;
                while (stopwatch.ElapsedMilliseconds < timeout)
                {
                    reply = ping.Send(element[0].ToString(), 1000);
                    if (reply.Status == IPStatus.Success)
                    {
                        break;
                    }
                    Thread.Sleep((int)timeout);
                }
                if (reply.Status != IPStatus.Success)
                {
                    /*If devices was connected before*/
                    if ((bool)element[1] == true)
                    {
                        element[1] = false;
                        active_device -= 1;
                        this.updateLabel_Online_Devices(active_device.ToString());
                    }
                }
                else
                {
                    /*If device was not connected before*/
                    if ((bool)element[1] == false)
                    {
                        element[1] = true;
                        active_device += 1;
                        this.updateLabel_Online_Devices(active_device.ToString());
                    }
                }
                Thread.Sleep((int)timeout);
            }
            Console.WriteLine("Kill");
        }
        //Update Label
        private void updateLabel_Online_Devices(string content)
        {
            if (this.label_onl_device.InvokeRequired)
            {
                this.label_onl_device.Invoke(new Action(() => this.label_onl_device.Text = content));
            }
            else
            {
                this.label_onl_device.Text = content;
            }
        }
        //Sync Connection
        public SqlConnection syncConnection
        {
            set
            {
                this.conn = value;
            }
        }
        //Set Label_Total_Device
        public void changeLabelTotalDevice(string numberTotalDevices)
        {
            label_total_device.Text = numberTotalDevices;
        }
        /*Combox SelectedIndexChanged*/
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboBox1.SelectedIndex;
            if (index != -1)
            {
                dataGrid_weighed_Product.DataSource = null;
                /*If you choose Certificate Product*/
                if (index == 0)
                {
                    string query = "SELECT Products.ID_Product,Products.Name_Product,Type_Product.Name_Type_Product,Weigh_Certificate.Weighs FROM Products INNER JOIN Type_Product ON Type_Product.ID_Type_Product = Products.ID_Type_Product INNER JOIN Weigh_Certificate ON Products.ID_Product = Weigh_Certificate.ID_Product;";
                    SqlCommand cmd = new SqlCommand(query, this.conn);
                    try
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            dataGrid_weighed_Product.DataSource = ds.Tables[0];
                            /*Sửa tên cột*/
                            dataGrid_weighed_Product.Columns[0].HeaderText = "ID sản phẩm";
                            dataGrid_weighed_Product.Columns[1].HeaderText = "Tên sản phẩm";
                            dataGrid_weighed_Product.Columns[2].HeaderText = "Tên loại sản phẩm";
                            dataGrid_weighed_Product.Columns[3].HeaderText = "Cân nặng (g)";
                            /*Sửa màu cột*/
                            dataGrid_weighed_Product.EnableHeadersVisualStyles = false;
                            dataGrid_weighed_Product.ColumnHeadersDefaultCellStyle.BackColor = Color.AliceBlue;
                            dataGrid_weighed_Product.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        }
                    }
                    catch (SqlException ex)
                    {
                        DialogResult message = MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                /*If you choose Non-Certificate Product*/
                else
                {
                    string query = "SELECT Weigh_Non_Certificate.ID_Product, Weigh_Non_Certificate.Weighs FROM Weigh_Non_Certificate";
                    SqlCommand cmd = new SqlCommand(query,conn);
                    try
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            DataTable dt = ds.Tables[0];
                            dt.Columns.Add("Name_Product").SetOrdinal(1);
                            dt.Columns.Add("Type_Product").SetOrdinal(2);
                            foreach(DataRow row in dt.Rows)
                            {
                                //Change Content of row[1] and row[2]
                                row["Name_Product"] = "Không xác định";
                                row["Type_Product"] = "Khác";
                            }
                            dataGrid_weighed_Product.DataSource = dt;
                            /*Sửa tên cột*/
                            dataGrid_weighed_Product.Columns[0].HeaderText = "ID sản phẩm";
                            dataGrid_weighed_Product.Columns[1].HeaderText = "Tên sản phẩm";
                            dataGrid_weighed_Product.Columns[2].HeaderText = "Tên loại sản phẩm";
                            dataGrid_weighed_Product.Columns[3].HeaderText = "Cân nặng (g)";
                            /*Sửa màu cột*/
                            dataGrid_weighed_Product.EnableHeadersVisualStyles = false;
                            dataGrid_weighed_Product.ColumnHeadersDefaultCellStyle.BackColor = Color.AliceBlue;
                            dataGrid_weighed_Product.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        }
                    }
                    catch (Exception ex)
                    {
                        DialogResult message = MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        //Set ArrayList
        public ArrayList setIP_Address_ArrayList
        {
            set
            {
                this.active_device = 0;
                this.total_IP_Address.Clear();
                mre.Set();
                Thread.Sleep(250);
                this.total_IP_Address = value;
                mre.Reset();
                this.StartingPingThread(ref this.total_IP_Address);
            }
        }
    }
}
