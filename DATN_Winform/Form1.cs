using Microsoft.Data.SqlClient;
using System;
namespace DATN_Winform
{
    public partial class Form1 : Form
    {
        SqlConnection conn = null;
        public Form1()
        {
            InitializeComponent();
            this.ActiveControl = this.txt_taikhoan;
            this.txt_matkhau.PasswordChar = '*';
        }

        private void label1_Click(object sender, EventArgs e)
        {
            DialogResult message = MessageBox.Show("Are you sure you want to exit ?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (message == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void bt_signin_Click(object sender, EventArgs e)
        {
            string connectionString =
                "Data Source = DESKTOP-DVLLCVU;" +
                "DATABASE = DATN;" +
                $"User ID = {txt_taikhoan.Text};" +
                $"Password = {txt_matkhau.Text};" +
                "Trust Server Certificate = True;" +
                "Connection Timeout = 5;";
            //Connect to DB
            conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                DialogResult message = MessageBox.Show("Connection Successfully","Information",MessageBoxButtons.OK, MessageBoxIcon.Information);
                Menu mn = new Menu();
                mn.syncConnection = conn;
                mn.syncID = txt_taikhoan.Text;
                //Change Label Name as admin name
                mn.changeLabelName(conn);
                txt_taikhoan.BackColor = Color.White;
                txt_matkhau.BackColor = Color.White;
                txt_taikhoan.Clear();
                txt_matkhau.Clear();
                mn.Show(this);
                this.Hide();
            }
            catch (SqlException ex) { 
                /*Ki?m tra xem có spam ?? tr?ng không ?*/
                if(String.IsNullOrWhiteSpace(txt_taikhoan.Text) || String.IsNullOrWhiteSpace(txt_matkhau.Text))
                {
                    if (String.IsNullOrWhiteSpace(txt_taikhoan.Text))
                    {
                        txt_taikhoan.BackColor = Color.Red;
                        txt_taikhoan.Clear();
                    }
                    if (String.IsNullOrWhiteSpace(txt_matkhau.Text))
                    {
                        txt_matkhau.BackColor = Color.Red;
                        txt_matkhau.Clear();
                    }
                }
                else
                {
                    txt_taikhoan.BackColor = Color.White;
                    txt_matkhau.BackColor= Color.White;
                    if(ex.Number == 18456)
                    {
                        DialogResult dialog = MessageBox.Show("Please check the login and password\n" + "or contact to the manager of database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if(ex.Number == -2)
                    {
                        DialogResult dialog = MessageBox.Show("Connection Timeout. May be check your connection to Server or contact to the manage of its", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (ex.Number == -1)
                    {
                        DialogResult dialog = MessageBox.Show("Check if you are connect to correct Server", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    txt_taikhoan.Clear();
                    txt_matkhau.Clear();
                }
            }
        }
        /*Nh?n Enter là t? ??ng Signin*/
        private void bt_signin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bt_signin.PerformClick();
            }
        }
    }
}
