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
    public partial class UserMaster : Form
    {
        public UserMaster()
        {
            InitializeComponent();
        }
        private void checkclear()
        {
            WP_chk.Checked = false;
            Prod_chk.Checked = false;
            Reports_chk.Checked = false;
        }
        private void enabletools()
        {
            User_Name_txt.Enabled = true;
            User_Password_txt.Enabled = true;
            User_Conf_Password_txt.Enabled = true;
            User_Dept_txt.Enabled = true;
            User_Name_cmb.Hide();
            Prod_chk.Enabled = true;
            Reports_chk.Enabled = true;
            WP_chk.Enabled = true;
        }
        private void disabletools()
        {
            User_Name_txt.Enabled = false;
            User_Password_txt.Enabled = false;
            User_Conf_Password_txt.Enabled = false;
            User_Dept_txt.Enabled = false;
            User_Name_cmb.Show();
            Prod_chk.Enabled = false;
            Reports_chk.Enabled = false;
            WP_chk.Enabled = false;
        }

        private void Add_btn_Click(object sender, EventArgs e)
        {
            if(Add_btn.Text=="ADD")
            {
                enabletools();
                Edit_User_btn.Enabled = false;
                Cancel_User_btn.Enabled = true;
                Add_btn.Text = "SAVE";
                User_Name_txt.Text = "";
                User_Name_cmb.Text = "";
                User_Password_txt.Text = "";
                User_Conf_Password_txt.Text = "";
                User_Dept_txt.Text = "";
                checkclear();
            }
            else if(Add_btn.Text == "SAVE")
            {
                if (User_Name_txt.Text.Trim() == "" && User_Password_txt.Text.Trim() == "" || User_Conf_Password_txt.Text.Trim() == "")
                {
                    MessageBox.Show(this, "User Name or Password Missing", "YSI Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    User_Name_txt.Enabled = true;
                    User_Name_txt.BackColor = Color.Red;
                    User_Name_txt.Select();
                    return;
                }
                else if (User_Password_txt.Text != "" && User_Password_txt.Text == User_Conf_Password_txt.Text)
                {
                    String usrcnfrmpass = User_Conf_Password_txt.Text;
                    string prvlgs = "";

                    if (WP_chk.Checked == true)
                    {
                        prvlgs = prvlgs + "1";//0
                    }
                    else { prvlgs = prvlgs + "0"; }
                    if (Prod_chk.Checked == true)
                    {
                        prvlgs = prvlgs + ",1";
                    }
                    else { prvlgs = prvlgs + ",0"; }
                    if (Reports_chk.Checked == true)
                    {
                        prvlgs = prvlgs + ",1"; 
                    }
                    else { prvlgs = prvlgs + ",0"; }

                    if (User_Name_cmb.FindString(User_Name_txt.Text) > 0)
                    {
                        MessageBox.Show("User Already Exists", "YSI Warning", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else
                    {
                        if (User_Password_txt.Text == "")
                            if (User_Conf_Password_txt.Text == "")
                                usrcnfrmpass = User_Name_txt.Text;
                        string _sQuery = "insert into USER_MASTER VALUES('" + User_Name_txt.Text + "','" + usrcnfrmpass + "','" + prvlgs + "','DEACTIVE',getdate(),'" + User_Dept_txt.Text + "')";
                        bool _bResult = Utilities.executeNonQuery(_sQuery);
                        if (_bResult == true)
                        {
                            MessageBox.Show("UserID Created Succesfully", "YSI Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            checkclear();
                            User_Name_txt.Text = "";
                            User_Name_cmb.Text = "";
                            User_Password_txt.Text = "";
                            User_Conf_Password_txt.Text = "";
                            User_Dept_txt.Text = "";
                            Add_btn.Text = "ADD";
                            Edit_User_btn.Enabled = true;
                            Cancel_User_btn.Enabled = true;
                            disabletools();
                        }
                    }
                }
                else
                {
                    User_Conf_Password_txt.Clear();
                    MessageBox.Show("Confirm Password is incorrect");
                }
            }
        }

        private void Edit_User_btn_Click(object sender, EventArgs e)
        {
            enabletools();
            Cancel_User_btn.Enabled = true;
            string prvlgs = "";
            if (Edit_User_btn.Text == "EDIT")
            {
                User_Name_cmb.Enabled = true;

                User_Name_txt.Visible = false;
                User_Password_txt.Text = "";
                User_Conf_Password_txt.Text = "";
                User_Dept_txt.Text = "";
                checkclear();
                Edit_User_btn.Text = "UPDATE";
                User_Name_txt.Visible = false;
                User_Name_cmb.Visible = true;
                SqlDataReader rdr = null;
                SqlDataReader rdr1 = null;

                User_Name_cmb.Items.Clear();
                string _sQuery = "SELECT * FROM USER_MASTER order by USER_NAME";
                rdr = Utilities.executeQuery(_sQuery);
                while (rdr.Read())
                {
                    User_Name_cmb.Items.Add(rdr["USER_NAME"].ToString().ToUpper());
                    User_Name_cmb.Refresh();

                }
                rdr.Close();
            }
            else if (Edit_User_btn.Text == "UPDATE")
            {
                if (User_Password_txt.Text.Trim() == "")
                {
                    MessageBox.Show(this, "User Name is Missing", "YSIalert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (User_Password_txt.Text == User_Conf_Password_txt.Text)
                {
                    if (WP_chk.Checked == true)   //0
                    {
                        prvlgs = prvlgs + "1";
                    }
                    else { prvlgs = prvlgs + "0"; }

                    if (Prod_chk.Checked == true)   //1
                    {
                        prvlgs = prvlgs + ",1";
                    }
                    else { prvlgs = prvlgs + ",0"; }

                    if (Reports_chk.Checked == true)   //2
                    {
                        prvlgs = prvlgs + ",1";
                    }
                    else { prvlgs = prvlgs + ",0"; }

                    string _sQuery = "update USER_MASTER set STATUS= 'DEACTIVE',PRIVILEGE= '" + prvlgs + "', PASSWORD= '" + User_Conf_Password_txt.Text + "', USER_NAME='" + User_Name_cmb.Text + "', USER_DEPT='" + User_Dept_txt.Text + "' where USER_NAME='" + User_Name_cmb.Text + "'";
                    bool _bResult = Utilities.executeNonQuery(_sQuery);
                    if (_bResult == true)
                    {
                        MessageBox.Show("Profile Updated Successfully");
                        Edit_User_btn.Text = "EDIT";
                        Cancel_User_btn.Enabled = false;
                        disabletools();
                    }
                }
                else
                {
                    User_Conf_Password_txt.BackColor = Color.Red;
                    User_Conf_Password_txt.SelectAll();
                }
            }
        }

        private void User_Name_cmb_TextChanged(object sender, EventArgs e)
        {
            string un_cmb = User_Name_cmb.Text;
            string _sQuery1 = "SELECT * FROM USER_MASTER where USER_NAME='" + un_cmb + "'";
            SqlDataReader rdr1 = Utilities.executeQuery(_sQuery1);
            if(rdr1.Read())
            {
                User_Password_txt.Text = rdr1["PASSWORD"].ToString();
                User_Conf_Password_txt.Text = rdr1["PASSWORD"].ToString();
                User_Dept_txt.Text = rdr1["USER_DEPT"].ToString();
                if(rdr1["PRIVILEGE"].ToString()=="1,0,0")
                {
                    WP_chk.Checked = true;
                    Prod_chk.Checked = false;
                    Reports_chk.Checked = false;
                }
                else if (rdr1["PRIVILEGE"].ToString() == "0,1,0")
                {
                    WP_chk.Checked = false;
                    Prod_chk.Checked = true;
                    Reports_chk.Checked = false;
                }
                else if (rdr1["PRIVILEGE"].ToString() == "0,0,1")
                {
                    WP_chk.Checked = false;
                    Prod_chk.Checked = false;
                    Reports_chk.Checked = true;
                }
                else if (rdr1["PRIVILEGE"].ToString() == "1,0,1")
                {
                    WP_chk.Checked = true;
                    Prod_chk.Checked = false;
                    Reports_chk.Checked = true;
                }
                else if (rdr1["PRIVILEGE"].ToString() == "1,1,1")
                {
                    WP_chk.Checked = true;
                    Prod_chk.Checked = true;
                    Reports_chk.Checked = true;
                }
                else if (rdr1["PRIVILEGE"].ToString() == "0,1,1")
                {
                    WP_chk.Checked = false;
                    Prod_chk.Checked = true;
                    Reports_chk.Checked = true;
                }
                else if (rdr1["PRIVILEGE"].ToString() == "1,1,0")
                {
                    WP_chk.Checked = true;
                    Prod_chk.Checked = true;
                    Reports_chk.Checked = false;
                }
            }
        }

        private void Cancel_User_btn_Click(object sender, EventArgs e)
        {
            disabletools();
            Add_btn.Enabled = true;
            Add_btn.Text = "ADD";
            Edit_User_btn.Enabled = true;
            Edit_User_btn.Text = "EDIT";
            this.ActiveControl = Add_btn;
            checkclear();
            User_Name_cmb.Text = "";
            User_Name_txt.Text = "";
            User_Conf_Password_txt.Text = "";
            User_Password_txt.Text = "";
            User_Dept_txt.Text = "";
            User_Name_cmb.Items.Clear();
        }

        private void UserMaster_Load(object sender, EventArgs e)
        {
            disabletools();
            User_Name_cmb.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            //Application.Exit();
        }
    }
}
