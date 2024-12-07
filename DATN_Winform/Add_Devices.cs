using Microsoft.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Windows.Forms;
namespace DATN_Winform
{
    public partial class Add_Devices : UserControl
    {
        SqlConnection conn = null;
        /*Create ArrayList that contain IP_Address*/
        ArrayList total_IP_Address = new ArrayList();
        //Create a ManualResetEvent
        private ManualResetEvent mre = new ManualResetEvent(false);
        //Create a global DataTable
        DataTable dt = new DataTable();
        public Add_Devices()
        {
            InitializeComponent();
            this.ActiveControl = txt_ip_devices; 
        }
        //Starting Ping
        private void StartingPingThread(ref ArrayList totalElement)
        {
            if (totalElement.Count > 0)
            {
                Console.WriteLine("Starting create Thread in Add_Devices");
                foreach (ArrayList element in totalElement)
                {
                    Console.WriteLine($"Total Devices: {totalElement.Count}");
                    /*Each IP will create a Thread to check if that IP Address is existed */
                    Thread pingThread = new Thread(() => ping(1, element));
                    pingThread.IsBackground = true;
                    pingThread.Start();
                }
            }
        }
        private void ping(double tout, ArrayList element)
        {
            bool initStatus = false;
            while (!mre.WaitOne(250))
            {
                /*Nếu DataTable được tạo trước đó hoặc không phải DataTable trống*/
                if (this.dt.Rows.Count > 0)
                {
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
                    }
                    if (reply == null || reply.Status == IPStatus.TimedOut)
                    {
                        /*If devices was connected before*/
                        if ((bool)element[1] == true)
                        {
                            element[1] = false;
                            Console.WriteLine("Insert False in Add_Devices");
                            //Travel the DataTable to find the IP Address
                            foreach (DataRow row in this.dt.Rows)
                            {
                                int result = String.Compare(row["IP_Address"].ToString(), element[0].ToString());
                                Console.WriteLine($"Number Columns: {row.ItemArray.Length}");
                                //Find in IP Columns
                                if (result == 0 && row != null) // avoid DataRace
                                {
                                    row[2] = "Chưa kết nối";
                                    Console.WriteLine("Insert False OK");
                                    this.updateDataGrid();
                                    break;
                                }
                            }
                        }
                        if (initStatus == false)
                        {
                            Console.WriteLine("Insert False in Add_Devices");
                            //Travel the DataTable to find the IP Address
                            foreach (DataRow row in this.dt.Rows)
                            {
                                int result = String.Compare(row["IP_Address"].ToString(), element[0].ToString());
                                //Find in IP Columns
                                if (result == 0) // avoid DataRace
                                {
                                    row[2] = "Chưa kết nối";
                                    Console.WriteLine("Insert False OK");
                                    this.updateDataGrid();
                                    break;
                                }
                            }
                            initStatus = true;
                        }
                    }
                    else if(reply.Status == IPStatus.Success)
                    {
                        /*If device was not connected before*/
                        if ((bool)element[1] == false)
                        {
                            element[1] = true;
                            Console.WriteLine("Insert True in Add_Devices");
                            foreach (DataRow row in this.dt.Rows)
                            {
                                int result = String.Compare(row["IP_Address"].ToString(), element[0].ToString());
                                //Find in IP Columns
                                if (result == 0) // avoid DataRace
                                {
                                    row[2] = "Đã kết nối";
                                    Console.WriteLine("Insert True OK");
                                    this.updateDataGrid();
                                    break;
                                }
                            }
                        }
                        if (initStatus == false)
                        {
                            Console.WriteLine("Insert True in Add_Devices");
                            foreach (DataRow row in this.dt.Rows)
                            {
                                int result = String.Compare(row["IP_Address"].ToString(), element[0].ToString());
                                //Find in IP Columns
                                if (result == 0 && row != null) // avoid DataRace
                                {
                                    row[2] = "Đã kết nối";
                                    Console.WriteLine("Insert True OK");
                                    this.updateDataGrid();
                                    break;
                                }
                            }
                            initStatus = true;
                        }
                    }
                    
                    Thread.Sleep(500);
                }
            }
            Console.WriteLine("Kill Thread in Add_Devices");
        }
        private void updateDataGrid()
        {
            if (this.dataGrid_Device_Productivity.InvokeRequired)
            {
                this.dataGrid_Device_Productivity.Invoke(new Action(() =>
                {
                    if (this.dt != null)
                    {
                        var oldTable = dataGrid_Device_Productivity.DataSource as IDisposable;
                        dataGrid_Device_Productivity.DataSource = this.dt;
                        if (oldTable != null)
                        {
                            oldTable.Dispose();
                        }
                        dataGrid_Device_Productivity.Refresh();
                    }
                }));
            }
        }
        /*Check if the IP Address is a valid Address*/
        private bool ValidateIPv4(string ipString)
        {
            if (String.IsNullOrWhiteSpace(ipString))
            {
                return false;
            }
            string[] splitValues = ipString.Split('.');
            if (splitValues.Length != 4)
            {
                return false;
            }
            byte tempForParsing; //because 1 bytes = 255 bit
            return splitValues.All(result => byte.TryParse(result, out tempForParsing));
        }
        //Clicked
        private void txt_ip_devices_Clicked(object sender, EventArgs e)
        {
            txt_ip_devices.BackColor = Color.White;
            txt_ip_devices.Text = String.Empty;
        }
        private void txt_name_devices_Clicked(object sender, EventArgs e)
        {
            txt_name_devices.BackColor = Color.White;
            txt_name_devices.Text = String.Empty;
        }
        //Button
        private void btn_add_device_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txt_ip_devices.Text) || String.IsNullOrEmpty(txt_name_devices.Text))
            {
                if (String.IsNullOrEmpty(txt_ip_devices.Text))
                {
                    txt_ip_devices.BackColor = Color.Red;
                }
                if (String.IsNullOrEmpty(txt_name_devices.Text))
                {
                    txt_name_devices.BackColor = Color.Red;
                }
            }
            else
            {
                //Check the IP Address is valid or not
                if (!this.ValidateIPv4(txt_ip_devices.Text))
                {
                    DialogResult message = MessageBox.Show($"Địa chỉ IP: {txt_ip_devices.Text} không hợp lệ. Hãy nhập lại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_ip_devices.BackColor = Color.White;
                    txt_name_devices.BackColor = Color.White;
                    this.ActiveControl = txt_ip_devices;
                }
                else
                {
                    //Kiểm tra xem địa chỉ IP có trùng lặp ?
                    string query = $"SELECT * FROM Devices WHERE IP_Address = '{txt_ip_devices.Text}';";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    try
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            DialogResult message = MessageBox.Show($"Địa chỉ IP: {txt_ip_devices.Text} đã tồn tại. Hãy nhập lại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txt_ip_devices.BackColor = Color.Red;
                            txt_name_devices.BackColor = Color.Red;
                            txt_ip_devices.Text = "";
                            txt_name_devices.Text = "";
                            this.ActiveControl = txt_ip_devices;
                        }
                        else
                        {
                            //Tiến hành thêm thiết bị
                            query = $"INSERT INTO Devices VALUES ('{txt_ip_devices.Text}','{txt_name_devices.Text}');";
                            cmd = new SqlCommand(query, conn);
                            try
                            {
                                cmd.ExecuteNonQuery();
                                DialogResult message = MessageBox.Show("Insert to Devices Table Successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                query = "SELECT Devices.IP_Address, Devices.Device_Name, Devices_Productivity.Total_Product, Devices_Productivity.Electric_Product, Devices_Productivity.Clothes_Product, Devices_Productivity.Diff_Product FROM Devices INNER JOIN Devices_Productivity ON Devices.IP_Address = Devices_Productivity.IP_Address;";
                                cmd = new SqlCommand(query, conn);
                                try
                                {
                                    adapter = new SqlDataAdapter(cmd);
                                    ds = new DataSet();
                                    adapter.Fill(ds);
                                    if (ds.Tables[0].Rows.Count > 0)
                                    {
                                        var oldTable = dataGrid_Device_Productivity.DataSource as IDisposable;
                                        dt.Dispose();
                                        dt = ds.Tables[0];
                                        //Bổ sung cột trạng thái
                                        dt.Columns.Add("Status").SetOrdinal(2);
                                        dataGrid_Device_Productivity.DataSource = dt;
                                        /*Sửa tên cột*/
                                        dataGrid_Device_Productivity.Columns[0].HeaderText = "Địa chỉ IP";
                                        dataGrid_Device_Productivity.Columns[1].HeaderText = "Tên thiết bị";
                                        dataGrid_Device_Productivity.Columns[2].HeaderText = "Trạng thái";
                                        dataGrid_Device_Productivity.Columns[3].HeaderText = "Tổng số sản phẩm phân loại";
                                        dataGrid_Device_Productivity.Columns[4].HeaderText = "Số sản phẩm Thiết bị điện tử";
                                        dataGrid_Device_Productivity.Columns[5].HeaderText = "Số sản phẩm Quần áo";
                                        dataGrid_Device_Productivity.Columns[6].HeaderText = "Số sản phẩm thuộc lại Khác";
                                        /*Sửa màu cột*/
                                        dataGrid_Device_Productivity.EnableHeadersVisualStyles = false;
                                        dataGrid_Device_Productivity.ColumnHeadersDefaultCellStyle.BackColor = Color.AliceBlue;
                                        dataGrid_Device_Productivity.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                                        if(oldTable != null)
                                        {
                                            oldTable.Dispose();
                                        }

                                    }
                                    txt_ip_devices.Text = "";
                                    txt_name_devices.Text = "";
                                    this.ActiveControl = txt_ip_devices;
                                }
                                catch (SqlException ex)
                                {
                                    message = MessageBox.Show($"Can't Execute Query to Devices Table with error: {ex} ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                            }
                            catch (SqlException ex)
                            {
                                DialogResult message = MessageBox.Show($"Can't Insert to Devices Table with error: {ex} ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        DialogResult message = MessageBox.Show($"Can't Execute Query to Devices Table with error: {ex} ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void btn_reset_products_Click(object sender, EventArgs e)
        {
            dt.Clear();
            txt_ip_devices.BackColor = Color.White;
            txt_name_devices.BackColor = Color.White;
            txt_ip_devices.Text = string.Empty;
            txt_name_devices.Text = string.Empty;
            this.ActiveControl = txt_ip_devices;
        }

        //Set IP_Address_ArrayList
        public ArrayList set_IP_Address_ArrayList
        {
            set
            {
                Console.WriteLine("Reset ManualResetEvent in Add_Devices");
                this.total_IP_Address.Clear();
                mre.Set();
                Thread.Sleep(250);
                this.total_IP_Address = value;
                mre.Reset();
                this.StartingPingThread(ref total_IP_Address);
            }
        }
        //Display Early
        private void displayEarly()
        {
            string query = "SELECT Devices.IP_Address, Devices.Device_Name, Devices_Productivity.Total_Product, Devices_Productivity.Electric_Product, Devices_Productivity.Clothes_Product, Devices_Productivity.Diff_Product FROM Devices INNER JOIN Devices_Productivity ON Devices.IP_Address = Devices_Productivity.IP_Address;";
            SqlCommand cmd = new SqlCommand(query, conn);
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    var oldTable = dataGrid_Device_Productivity.DataSource as IDisposable;
                    dt.Dispose();
                    dt = ds.Tables[0];
                    //Bổ sung cột trạng thái
                    dt.Columns.Add("Status").SetOrdinal(2);
                    dataGrid_Device_Productivity.DataSource = dt;
                    /*Sửa tên cột*/
                    dataGrid_Device_Productivity.Columns[0].HeaderText = "Địa chỉ IP";
                    dataGrid_Device_Productivity.Columns[1].HeaderText = "Tên thiết bị";
                    dataGrid_Device_Productivity.Columns[2].HeaderText = "Trạng thái";
                    dataGrid_Device_Productivity.Columns[3].HeaderText = "Tổng số sản phẩm phân loại";
                    dataGrid_Device_Productivity.Columns[4].HeaderText = "Số sản phẩm Thiết bị điện tử";
                    dataGrid_Device_Productivity.Columns[5].HeaderText = "Số sản phẩm Quần áo";
                    dataGrid_Device_Productivity.Columns[6].HeaderText = "Số sản phẩm thuộc lại Khác";
                    /*Sửa màu cột*/
                    dataGrid_Device_Productivity.EnableHeadersVisualStyles = false;
                    dataGrid_Device_Productivity.ColumnHeadersDefaultCellStyle.BackColor = Color.AliceBlue;
                    dataGrid_Device_Productivity.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    if (oldTable != null)
                    {
                        oldTable.Dispose();
                    }

                }
                txt_ip_devices.Text = "";
                txt_name_devices.Text = "";
                this.ActiveControl = txt_ip_devices;
            }
            catch (SqlException ex)
            {
                DialogResult message = MessageBox.Show($"Can't Execute Query to Devices Table with error: {ex} ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Sync Connection
        public SqlConnection syncConnection
        {
            set
            {
                this.conn = value;
                this.displayEarly();
            }
        }
    }
}
