using FML;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P3C
{
    public partial class Login : System.Windows.Forms.Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int c = 0;
            SqlDataReader rdr1 = null;
            string _squery1 = "";
            _squery1 = "select * from USER_MASTER";
            rdr1 = Utilities.executeQuery(_squery1);
            while (rdr1.Read())
            {
                if (txt_user.Text.ToUpper() == rdr1["USER_NAME"].ToString() & txt_pwd.Text.ToUpper() == rdr1["PASSWORD"].ToString())
                {
                        c++;
                        this.Hide();
                        MainForm MF = new MainForm();
                        MF.Show();
                        MF.Log_in(txt_user.Text);
                    }
                }
            rdr1.Close();
            if (txt_user.Text.ToUpper() =="ADMIN" & txt_pwd.Text.ToUpper() == "ADMIN@123")
            {
                this.Hide();
                UserMaster UM = new UserMaster();
                UM.Show();
            }
            //if (c == 0)
            //{
            //    MessageBox.Show("Login Authentication");
            //    clear();
            //}
        }

        private void reset_btn_Click(object sender, EventArgs e)
        {
            clear();
        }
        public void clear()
        {
            txt_user.Text = "";
            txt_pwd.Text = "";
        }

        private void txt_pwd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                int c = 0;
                SqlDataReader rdr1 = null;
                string _squery1 = "";
                _squery1 = "select * from USER_MASTER";
                rdr1 = Utilities.executeQuery(_squery1);
                while (rdr1.Read())
                {
                    if (txt_user.Text.ToUpper() == rdr1["USER_NAME"].ToString() & txt_pwd.Text.ToUpper() == rdr1["PASSWORD"].ToString())
                    {
                        c++;
                        this.Hide();
                        MainForm MF = new MainForm();
                        MF.Show();
                        MF.Log_in(txt_user.Text);
                    }
                }
                rdr1.Close();
                if (txt_user.Text.ToUpper() == "ADMIN" & txt_pwd.Text.ToUpper() == "ADMIN@123")
                {
                    this.Hide();
                    UserMaster UM = new UserMaster();
                    UM.Show();
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
