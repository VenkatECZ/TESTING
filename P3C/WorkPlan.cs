using FML;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using Microsoft.Office.Interop;
using System.Configuration;

namespace P3C
{
    
    public partial class WorkPlan : Form
    {
        public WorkPlan()
        {
            InitializeComponent();
        }
        private void WorkPlan_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            //Telling the operating system that we want to set the start position manually
            this.StartPosition = FormStartPosition.Manual;
            //Actually setting our Width, Height, and Location
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
            //this.WindowState = FormWindowState.Maximized;
            BindData();
        }
        public void BindData()
        {
            SqlDataReader rdr1 = null;
            string _squery1 = "";
            _squery1 = "select Line from LineMaster";
            rdr1 = Utilities.executeQuery(_squery1);
            while(rdr1.Read())
            {
                Line_cmb.Items.Add(rdr1["Line"].ToString());
            }
            rdr1.Close();
        }
        private int GetMaxId()
        {
            int pid = 0;
            string _squery4 = "  SELECT MAX(ID) AS ID FROM Tbl_Work_Plan";
            SqlDataReader rdr4 = Utilities.executeQuery(_squery4);
            if(rdr4.Read())
            {
                string p_id = rdr4["ID"].ToString();
                if(p_id!="" & p_id!=null)
                {
                    pid = Convert.ToInt32(p_id) + 1;
                }
                else
                {
                    p_id = "1";
                    pid = Convert.ToInt32(p_id);
                }
                
            }
            rdr4.Close();
            if (pid == 0)
            {
                pid++;
            }
            return pid;
        }
        public void save()
        {
            bool rdr2 = false;
            for (int index = 0; index < workplan_grd.Rows.Count - 1; index++)
            {
                string _squery3 = "Select * from Tbl_Work_Plan";
                SqlDataReader rdr3= Utilities.executeQuery(_squery3);
                rdr3.Read();
                DateTime dt1 = Convert.ToDateTime(workplan_grd.Rows[index].Cells[0].Value.ToString());
                string date = "";
                if (DateTime.Now.ToString().Contains('-'))
                { 
                    date = dt1.ToString("dd-MM-yyyy 00:00:00");
                }
                else
                {
                    date = dt1.ToString("dd/MM/yyyy 00:00:00");
                }
                string shift = workplan_grd.Rows[index].Cells[2].Value.ToString();
                string MCS = workplan_grd.Rows[index].Cells[1].Value.ToString();
                string pm = workplan_grd.Rows[index].Cells[5].Value.ToString();
                string _squery2 = "";
                //string cur_dt = DateTime.Now.ToString("dd-MM-yyyy"); dt.ToString("dd-MM-yyyy 00:00:00")
                //string cr_dt =rdr3["Created_Date"].ToString();
                string _squery5 = "Select * from Tbl_Work_Plan where Created_Date='"+ DateTime.Now.ToString("dd-MM-yyyy") + "'";
                SqlDataReader rdr5 = Utilities.executeQuery(_squery5);
                if(rdr5.Read())
                {

                }
                else
                {
                    string _squery6 = "DBCC CHECKIDENT (Tbl_Work_Plan, RESEED, 0)";
                    bool rdr6 = Utilities.executeNonQuery(_squery6);
                }
                rdr5.Close();
                string i_d="";
                int pid = GetMaxId();
                if (pid.ToString().Length==5)
                {
                    i_d = pid.ToString();
                }
                else if(pid.ToString().Length == 4)
                {
                    i_d = "0"+ pid.ToString();
                }
                else if (pid.ToString().Length == 3)
                {
                   i_d = "0" + "0" + pid.ToString();
                }
                else if (pid.ToString().Length == 2)
                {
                   i_d = "0" + "0" + "0" + pid.ToString();
                }
                else if (pid.ToString().Length == 1)
                {
                   i_d = "0" + "0" + "0" + "0" + pid.ToString();
                }
                string dt = (DateTime.Now).ToString("ddMMyyyy")+ i_d;
                _squery2 = "IF NOT EXISTS(select * from Tbl_Work_Plan where DATE='"+date+ "' and SHIFT='"+shift+ "' and MCS='"+MCS+ "' and PARTNO_MODEL='"+pm+"' and Line='"+Line_cmb.Text+ "') begin insert into Tbl_Work_Plan (LINE, WPNO, DATE, MCS, SHIFT, CUST, PARTNO_MODEL, PROCESS_NO, PART_NAME, STAGE, STANDARD_LOADING_PER_JIG, STANDARD_LOADING_PER_HANGER, CO2_COIL_CONSM, CO2_GAS_CONSUMPTION, PART_WT, MATL_PRESS_COST, SUB_PART_COST, SUB_PROCESS_UNIT_COST, UPH_PLAN, HRS_PLAN, QTY_PLAN, FORECAST, COMENTS, Created_Date, STATUS) values('" + Line_cmb.Text+"','"+dt+"','" + date + "','" + workplan_grd.Rows[index].Cells[1].Value.ToString() + "','" + workplan_grd.Rows[index].Cells[2].Value.ToString() + "','" + workplan_grd.Rows[index].Cells[3].Value.ToString() + "','" + workplan_grd.Rows[index].Cells[4].Value.ToString() + "','" + workplan_grd.Rows[index].Cells[5].Value.ToString() + "','" + workplan_grd.Rows[index].Cells[6].Value.ToString() + "','" + workplan_grd.Rows[index].Cells[7].Value.ToString() + "','" + workplan_grd.Rows[index].Cells[8].Value.ToString() + "','" + workplan_grd.Rows[index].Cells[9].Value.ToString() + "','" + workplan_grd.Rows[index].Cells[10].Value.ToString() + "','" + workplan_grd.Rows[index].Cells[11].Value.ToString() + "','" + workplan_grd.Rows[index].Cells[12].Value.ToString() + "','" + workplan_grd.Rows[index].Cells[13].Value.ToString() + "','" + workplan_grd.Rows[index].Cells[14].Value.ToString() + "','" + workplan_grd.Rows[index].Cells[15].Value.ToString() + "','" + workplan_grd.Rows[index].Cells[16].Value.ToString() + "','" + workplan_grd.Rows[index].Cells[17].Value.ToString() + "','" + workplan_grd.Rows[index].Cells[18].Value.ToString() + "','" + workplan_grd.Rows[index].Cells[19].Value.ToString() + "','" + workplan_grd.Rows[index].Cells[20].Value.ToString() + "','"+ DateTime.Now.ToString("dd-MM-yyyy") + "','ACTIVE')END";
                rdr2 = Utilities.executeNonQuery(_squery2);
               
            }
            if (rdr2)
            {
                MessageBox.Show("Records Saved Successfully");
            }
        }
        //public void db_data()
        //{
        //    string con_str = ConfigurationSettings.AppSettings["strcon"].ToString();
        //    string _squery2 = "Select * from Tbl_Work_Plan";
        //    SqlDataAdapter rdr3 = new SqlDataAdapter(_squery2, con_str);
        //    DataSet ds = new DataSet();
        //    rdr3.Fill(ds, "Tbl_Work_Plan");
        //    workplan_grd.DataSource = ds.Tables["Tbl_Work_Plan"].DefaultView;
        //}
        public void color()
        {

            
            this.workplan_grd.DefaultCellStyle.Font = new Font("Verdana", 10);
            workplan_grd.EnableHeadersVisualStyles = false;
            workplan_grd.Columns[0].HeaderCell.Style.BackColor = Color.SkyBlue;
            workplan_grd.Columns[0].HeaderCell.Style.Font= new Font("Verdana", 12, FontStyle.Bold);
            workplan_grd.Columns[1].HeaderCell.Style.BackColor = Color.SkyBlue;
            workplan_grd.Columns[1].HeaderCell.Style.Font = new Font("Verdana", 12, FontStyle.Bold);
            workplan_grd.Columns[2].HeaderCell.Style.BackColor = Color.SkyBlue;
            workplan_grd.Columns[2].HeaderCell.Style.Font = new Font("Verdana", 12, FontStyle.Bold);
            workplan_grd.Columns[3].HeaderCell.Style.BackColor = Color.SkyBlue;
            workplan_grd.Columns[3].HeaderCell.Style.Font = new Font("Verdana", 12, FontStyle.Bold);
            workplan_grd.Columns[4].HeaderCell.Style.BackColor = Color.SkyBlue;
            workplan_grd.Columns[4].HeaderCell.Style.Font = new Font("Verdana", 12, FontStyle.Bold);
            workplan_grd.Columns[5].HeaderCell.Style.BackColor = Color.SkyBlue;
            workplan_grd.Columns[5].HeaderCell.Style.Font = new Font("Verdana", 12, FontStyle.Bold);
            workplan_grd.Columns[6].HeaderCell.Style.BackColor = Color.SkyBlue;
            workplan_grd.Columns[6].HeaderCell.Style.Font = new Font("Verdana", 12, FontStyle.Bold);
            workplan_grd.Columns[7].HeaderCell.Style.BackColor = Color.SkyBlue;
            workplan_grd.Columns[7].HeaderCell.Style.Font = new Font("Verdana", 12, FontStyle.Bold);
            workplan_grd.Columns[8].HeaderCell.Style.BackColor = Color.SkyBlue;
            workplan_grd.Columns[8].HeaderCell.Style.Font = new Font("Verdana", 12, FontStyle.Bold);
            workplan_grd.Columns[9].HeaderCell.Style.BackColor = Color.SkyBlue;
            workplan_grd.Columns[9].HeaderCell.Style.Font = new Font("Verdana", 12, FontStyle.Bold);
            workplan_grd.Columns[10].HeaderCell.Style.BackColor = Color.SkyBlue;
            workplan_grd.Columns[10].HeaderCell.Style.Font = new Font("Verdana", 12, FontStyle.Bold);
            workplan_grd.Columns[11].HeaderCell.Style.BackColor = Color.SkyBlue;
            workplan_grd.Columns[11].HeaderCell.Style.Font = new Font("Verdana", 12, FontStyle.Bold);
            workplan_grd.Columns[12].HeaderCell.Style.BackColor = Color.SkyBlue;
            workplan_grd.Columns[12].HeaderCell.Style.Font = new Font("Verdana", 12, FontStyle.Bold);
            workplan_grd.Columns[13].HeaderCell.Style.BackColor = Color.SkyBlue;
            workplan_grd.Columns[13].HeaderCell.Style.Font = new Font("Verdana", 12, FontStyle.Bold);
            workplan_grd.Columns[14].HeaderCell.Style.BackColor = Color.SkyBlue;
            workplan_grd.Columns[14].HeaderCell.Style.Font = new Font("Verdana", 12, FontStyle.Bold);
            workplan_grd.Columns[15].HeaderCell.Style.BackColor = Color.SkyBlue;
            workplan_grd.Columns[15].HeaderCell.Style.Font = new Font("Verdana", 12, FontStyle.Bold);
            workplan_grd.Columns[16].HeaderCell.Style.BackColor = Color.SkyBlue;
            workplan_grd.Columns[16].HeaderCell.Style.Font = new Font("Verdana", 12, FontStyle.Bold);
            workplan_grd.Columns[17].HeaderCell.Style.BackColor = Color.SkyBlue;
            workplan_grd.Columns[17].HeaderCell.Style.Font = new Font("Verdana", 12, FontStyle.Bold);
            workplan_grd.Columns[18].HeaderCell.Style.BackColor = Color.SkyBlue;
            workplan_grd.Columns[18].HeaderCell.Style.Font = new Font("Verdana", 12, FontStyle.Bold);
            workplan_grd.Columns[19].HeaderCell.Style.BackColor = Color.SkyBlue;
            workplan_grd.Columns[19].HeaderCell.Style.Font = new Font("Verdana", 12, FontStyle.Bold);
            workplan_grd.Columns[20].HeaderCell.Style.BackColor = Color.SkyBlue;
            workplan_grd.Columns[20].HeaderCell.Style.Font = new Font("Verdana", 12, FontStyle.Bold);
        }
        public void upload(string path)
        {
            OleDbConnection mycon = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source='"+path+"';Extended Properties='Excel 12.0;HDR=YES';");
            OleDbDataAdapter oda = new OleDbDataAdapter("select * from [sheet1$]", mycon);
            DataSet ds = new DataSet();
            oda.Fill(ds);//Color.ActiveCaption  .Columns["NameOfColumn"].DefaultCellStyle.ForeColor = …..
            workplan_grd.DataSource = ds.Tables[0];
            color();
            mycon.Close();
        }
        private void browse_btn_Click(object sender, EventArgs e)
        {
            if(Line_cmb.Text=="")
            {
                MessageBox.Show("Please Select Line");
            }
            else
            {
                OpenFileDialog dailog = new OpenFileDialog();
                if (dailog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.txt_path.Text = dailog.FileName;
                    upload(txt_path.Text);
                    //db_data();
                }
            }
            
        }

        private void Line_cmb_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            WorkPlan wp = new WorkPlan();
            ProductionEntry pde = new ProductionEntry();
            Reports rp = new Reports();
            if (wp.WindowState == FormWindowState.Normal)
            {
                foreach (Form frm in Application.OpenForms)
                {
                    frm.WindowState = FormWindowState.Minimized;
                }
            }
            if (pde.WindowState == FormWindowState.Normal)
            {
                foreach (Form frm in Application.OpenForms)
                {
                    frm.WindowState = FormWindowState.Minimized;
                }
            }
            if (rp.WindowState == FormWindowState.Normal)
            {
                foreach (Form frm in Application.OpenForms)
                {
                    frm.WindowState = FormWindowState.Minimized;
                }
            }
            this.WindowState = FormWindowState.Minimized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            save();
            workplan_grd.Columns.Clear();
            txt_path.Clear();
            Line_cmb.Text = "";
        }
    }
}
