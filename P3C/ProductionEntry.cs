using FML;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P3C
{
    public partial class ProductionEntry : Form
    {
        public ProductionEntry()
        {
            InitializeComponent();
            //if (this.WindowState == FormWindowState.Maximized)
            //{
            //    this.WindowState = FormWindowState.Normal;
            //    this.CenterToScreen();
            //}

            ////maximises window
            //else
            //{
            //    this.WindowState = FormWindowState.Maximized;
            //    this.CenterToScreen();
            //}
            BindData();
        }
        public void BindData()
        {
            SqlDataReader rdr1 = null;
            string _squery1 = "";
            _squery1 = "select Line from LineMaster";
            rdr1 = Utilities.executeQuery(_squery1);
            while (rdr1.Read())
            {
                Line_cmb.Items.Add(rdr1["Line"].ToString());
            }
            rdr1.Close();
        }
        public void clear()
        {
            Line_cmb.Text = "Select Line";
            shift_cmb.Text = "Select Shift";
        }
        public void color()
        {
            this.ProductionEntry_grd.DefaultCellStyle.Font = new Font("Verdana", 10);
            ProductionEntry_grd.EnableHeadersVisualStyles = false;
            ProductionEntry_grd.Columns[0].HeaderCell.Style.BackColor = Color.SkyBlue;
            ProductionEntry_grd.Columns[0].HeaderCell.Style.Font = new Font("Verdana", 12, FontStyle.Bold);
            ProductionEntry_grd.Columns[1].HeaderCell.Style.BackColor = Color.SkyBlue;
            ProductionEntry_grd.Columns[1].HeaderCell.Style.Font = new Font("Verdana", 12, FontStyle.Bold);
            ProductionEntry_grd.Columns[2].HeaderCell.Style.BackColor = Color.SkyBlue;
            ProductionEntry_grd.Columns[2].HeaderCell.Style.Font = new Font("Verdana", 12, FontStyle.Bold);
            ProductionEntry_grd.Columns[3].HeaderCell.Style.BackColor = Color.SkyBlue;
            ProductionEntry_grd.Columns[3].HeaderCell.Style.Font = new Font("Verdana", 12, FontStyle.Bold);
            ProductionEntry_grd.Columns[4].HeaderCell.Style.BackColor = Color.SkyBlue;
            ProductionEntry_grd.Columns[4].HeaderCell.Style.Font = new Font("Verdana", 12, FontStyle.Bold);
            ProductionEntry_grd.Columns[5].HeaderCell.Style.BackColor = Color.SkyBlue;
            ProductionEntry_grd.Columns[5].HeaderCell.Style.Font = new Font("Verdana", 12, FontStyle.Bold);
            ProductionEntry_grd.Columns[6].HeaderCell.Style.BackColor = Color.SkyBlue;
            ProductionEntry_grd.Columns[6].HeaderCell.Style.Font = new Font("Verdana", 12, FontStyle.Bold);
            ProductionEntry_grd.Columns[7].HeaderCell.Style.BackColor = Color.SkyBlue;
            ProductionEntry_grd.Columns[7].HeaderCell.Style.Font = new Font("Verdana", 12, FontStyle.Bold);
            ProductionEntry_grd.Columns[8].HeaderCell.Style.BackColor = Color.SkyBlue;
            ProductionEntry_grd.Columns[8].HeaderCell.Style.Font = new Font("Verdana", 12, FontStyle.Bold);
            ProductionEntry_grd.Columns[9].HeaderCell.Style.BackColor = Color.SkyBlue;
            ProductionEntry_grd.Columns[9].HeaderCell.Style.Font = new Font("Verdana", 12, FontStyle.Bold);
            ProductionEntry_grd.Columns[10].HeaderCell.Style.BackColor = Color.SkyBlue;
            ProductionEntry_grd.Columns[10].HeaderCell.Style.Font = new Font("Verdana", 12, FontStyle.Bold);
            ProductionEntry_grd.Columns[11].HeaderCell.Style.BackColor = Color.SkyBlue;
            ProductionEntry_grd.Columns[11].HeaderCell.Style.Font = new Font("Verdana", 12, FontStyle.Bold);
            ProductionEntry_grd.Columns[12].HeaderCell.Style.BackColor = Color.SkyBlue;
            ProductionEntry_grd.Columns[12].HeaderCell.Style.Font = new Font("Verdana", 12, FontStyle.Bold);
            ProductionEntry_grd.Columns[13].HeaderCell.Style.BackColor = Color.SkyBlue;
            ProductionEntry_grd.Columns[13].HeaderCell.Style.Font = new Font("Verdana", 12, FontStyle.Bold);
            ProductionEntry_grd.Columns[14].HeaderCell.Style.BackColor = Color.SkyBlue;
            ProductionEntry_grd.Columns[14].HeaderCell.Style.Font = new Font("Verdana", 12, FontStyle.Bold);
            ProductionEntry_grd.Columns[15].HeaderCell.Style.BackColor = Color.SkyBlue;
            ProductionEntry_grd.Columns[15].HeaderCell.Style.Font = new Font("Verdana", 12, FontStyle.Bold);
            ProductionEntry_grd.Columns[16].HeaderCell.Style.BackColor = Color.SkyBlue;
            ProductionEntry_grd.Columns[16].HeaderCell.Style.Font = new Font("Verdana", 12, FontStyle.Bold);
            ProductionEntry_grd.Columns[17].HeaderCell.Style.BackColor = Color.SkyBlue;
            ProductionEntry_grd.Columns[17].HeaderCell.Style.Font = new Font("Verdana", 12, FontStyle.Bold);
        }

        private void ProductionEntry_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            clear();
            this.ProductionEntry_grd.DefaultCellStyle.Font = new Font("Verdana", 8);
            this.ProductionEntry_grd.ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 9, FontStyle.Bold);
            ProductionEntry_grd.Rows.Clear();
            ProductionEntry_grd.ColumnCount = 18;
            ProductionEntry_grd.ColumnHeadersVisible = true;
            ProductionEntry_grd.RowHeadersWidth = 10;
            ProductionEntry_grd.Columns[0].Name = "WORKPLAN";
            ProductionEntry_grd.Columns[0].Width = 99;
            ProductionEntry_grd.Columns[0].ReadOnly = true;
            ProductionEntry_grd.Columns[1].Name = "LINE";
            ProductionEntry_grd.Columns[1].Width = 99;
            ProductionEntry_grd.Columns[1].ReadOnly = true;
            ProductionEntry_grd.Columns[2].Name = "DATE";
            ProductionEntry_grd.Columns[2].Width = 99;
            ProductionEntry_grd.Columns[2].ReadOnly = true;
            ProductionEntry_grd.Columns[3].Name = "M/C'S";
            ProductionEntry_grd.Columns[3].Width = 99;
            ProductionEntry_grd.Columns[3].ReadOnly = true;
            ProductionEntry_grd.Columns[4].Name = "SHIFT";
            ProductionEntry_grd.Columns[4].Width = 99;
            ProductionEntry_grd.Columns[4].ReadOnly = true;
            ProductionEntry_grd.Columns[5].Name = "CUSTOMER";
            ProductionEntry_grd.Columns[5].Width = 99;
            ProductionEntry_grd.Columns[5].ReadOnly = true;
            ProductionEntry_grd.Columns[6].Name = "PART NO/ MODEL";
            ProductionEntry_grd.Columns[6].Width = 103;
            ProductionEntry_grd.Columns[6].ReadOnly = true;
            ProductionEntry_grd.Columns[7].Name = "PROCESS NO";
            ProductionEntry_grd.Columns[7].Width = 101;
            ProductionEntry_grd.Columns[7].ReadOnly = true;
            ProductionEntry_grd.Columns[8].Name = "PLAN HRS";
            ProductionEntry_grd.Columns[8].Width = 99;
            ProductionEntry_grd.Columns[9].Name = "PLAN QTY";
            ProductionEntry_grd.Columns[9].Width = 99;
            ProductionEntry_grd.Columns[10].Name = "HRS ACT";
            ProductionEntry_grd.Columns[10].Width = 99;
            ProductionEntry_grd.Columns[10].ReadOnly = false;
            ProductionEntry_grd.Columns[11].Name = "QTY ACT";
            ProductionEntry_grd.Columns[11].Width = 99;
            ProductionEntry_grd.Columns[11].ReadOnly = false;
            ProductionEntry_grd.Columns[12].Name = "REJECTION QTY";
            ProductionEntry_grd.Columns[12].Width = 101;
            ProductionEntry_grd.Columns[12].ReadOnly = false;
            ProductionEntry_grd.Columns[13].Name = "REASON";
            ProductionEntry_grd.Columns[13].Width = 99;
            ProductionEntry_grd.Columns[13].ReadOnly = false;
            ProductionEntry_grd.Columns[14].Name = "LOSS CODE";
            ProductionEntry_grd.Columns[14].Width = 99;
            ProductionEntry_grd.Columns[14].ReadOnly = false;
            ProductionEntry_grd.Columns[15].Name = "LOSS HRS";
            ProductionEntry_grd.Columns[15].Width = 99;
            ProductionEntry_grd.Columns[15].ReadOnly = false;
            ProductionEntry_grd.Columns[16].Name = "MOVE TO";
            ProductionEntry_grd.Columns[16].Width = 99;
            ProductionEntry_grd.Columns[16].ReadOnly = false;
            ProductionEntry_grd.Columns[17].Name = "COMENTS";
            ProductionEntry_grd.Columns[17].Width = 99;
            ProductionEntry_grd.Columns[17].ReadOnly = false;
            color();
            this.ProductionEntry_grd.Columns["PROCESS NO"].Frozen = true;
            this.ProductionEntry_grd.Columns["PLAN HRS"].ReadOnly = true;
            this.ProductionEntry_grd.Columns["PLAN QTY"].ReadOnly = true;
        }

        private void Line_cmb_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void shift_cmb_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void ProdEnt_dt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void save_btn_Click_1(object sender, EventArgs e)
        {
            try
            {
                bool rdr3 = false;
                if (ProductionEntry_grd.Rows.Count > 0)
                {
                    for (int r = 0; r <= ProductionEntry_grd.Rows.Count - 1; r++)
                    {
                        if (ProductionEntry_grd.Rows[r].Cells[9].Value == null)
                        {
                            ProductionEntry_grd.Rows[r].Cells[9].Value = "0";
                        }
                        if (ProductionEntry_grd.Rows[r].Cells[10].Value == null)
                        {
                            ProductionEntry_grd.Rows[r].Cells[10].Value = "0";
                        }
                        if (ProductionEntry_grd.Rows[r].Cells[11].Value == null)
                        {
                            ProductionEntry_grd.Rows[r].Cells[11].Value = "0";
                        }
                        if (ProductionEntry_grd.Rows[r].Cells[12].Value == null)
                        {
                            ProductionEntry_grd.Rows[r].Cells[12].Value = "0";
                        }
                        if (ProductionEntry_grd.Rows[r].Cells[13].Value == null)
                        {
                            ProductionEntry_grd.Rows[r].Cells[13].Value = "0";
                        }
                        if (ProductionEntry_grd.Rows[r].Cells[14].Value == null)
                        {
                            ProductionEntry_grd.Rows[r].Cells[14].Value = "0";
                        }
                        if (ProductionEntry_grd.Rows[r].Cells[15].Value == null)
                        {
                            ProductionEntry_grd.Rows[r].Cells[15].Value = "0";
                        }
                        if (ProductionEntry_grd.Rows[r].Cells[16].Value == null)
                        {
                            ProductionEntry_grd.Rows[r].Cells[16].Value = "0";
                        }
                        if (ProductionEntry_grd.Rows[r].Cells[17].Value == null)
                        {
                            ProductionEntry_grd.Rows[r].Cells[17].Value = "0";
                        }


                        string _squery5 = "Insert into Tbl_Production_Entry(WPNO,LINE,DATE,MCS,SHIFT,CUST,PARTNO_MODEL,PROCESS_NO,PLAN_HRS,PLAN_QTY,HRS_ACT,QTY_ACT,REJECTION_QTY,REASON,LOSS_CODE,LOSS_HRS,MOVE_TO,COMENTS,Created_Date,STATUS) Values('" + ProductionEntry_grd.Rows[r].Cells[0].Value + "','" + ProductionEntry_grd.Rows[r].Cells[1].Value + "','" + ProductionEntry_grd.Rows[r].Cells[2].Value + "','" + ProductionEntry_grd.Rows[r].Cells[3].Value + "','" + ProductionEntry_grd.Rows[r].Cells[4].Value + "','" + ProductionEntry_grd.Rows[r].Cells[5].Value + "','" + ProductionEntry_grd.Rows[r].Cells[6].Value + "','" + ProductionEntry_grd.Rows[r].Cells[7].Value + "','" + ProductionEntry_grd.Rows[r].Cells[8].Value + "','" + ProductionEntry_grd.Rows[r].Cells[9].Value + "','" + ProductionEntry_grd.Rows[r].Cells[10].Value + "','" + ProductionEntry_grd.Rows[r].Cells[11].Value + "','" + ProductionEntry_grd.Rows[r].Cells[12].Value + "','" + ProductionEntry_grd.Rows[r].Cells[13].Value + "','" + ProductionEntry_grd.Rows[r].Cells[14].Value + "','" + ProductionEntry_grd.Rows[r].Cells[15].Value + "','" + ProductionEntry_grd.Rows[r].Cells[16].Value + "','" + ProductionEntry_grd.Rows[r].Cells[17].Value + "','" + DateTime.Now.ToString("dd-MM-yyyy") + "','ACTIVE')";
                        bool rdr2 = Utilities.executeNonQuery(_squery5);
                        if (rdr2)
                        {
                            string _squery6 = "update Tbl_Work_Plan set STATUS='DEACTIVE' where WPNO='" + ProductionEntry_grd.Rows[r].Cells[0].Value + "'";
                            rdr3 = Utilities.executeNonQuery(_squery6);
                        }
                        //string WorkPlan_No = "" + ProductionEntry_grd.Rows[r].Cells[0].Value;
                        //if (ProductionEntry_grd.Rows[r].Cells[8].Value != null & ProductionEntry_grd.Rows[r].Cells[9].Value != null & ProductionEntry_grd.Rows[r].Cells[10].Value != null & ProductionEntry_grd.Rows[r].Cells[11].Value != null & ProductionEntry_grd.Rows[r].Cells[12].Value != null & ProductionEntry_grd.Rows[r].Cells[13].Value != null & ProductionEntry_grd.Rows[r].Cells[14].Value != null & ProductionEntry_grd.Rows[r].Cells[15].Value != null & ProductionEntry_grd.Rows[r].Cells[16].Value != null & ProductionEntry_grd.Rows[r].Cells[17].Value != null)
                        //{

                        //}
                        //else
                        //{
                        //    MessageBox.Show("All Fields in the Grid Should be Mandatory");
                        //}
                    }
                    if(rdr3)
                    {
                        MessageBox.Show("Production Data Saved Successfully");
                        this.ProductionEntry_grd.Rows.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("There is no data in the Grid");
                }
            }
            catch (Exception ex)
            {

            }
        }
        public static void LogErrors(Exception ex)
        {
            StringBuilder sb = new StringBuilder();
            string path = AppDomain.CurrentDomain.BaseDirectory + "LogError.txt";
            // flush every 20 seconds as you do it

            sb.AppendLine();
            sb.Append("Log Time: " + DateTime.Now);
            sb.AppendLine();
            sb.Append("--------------------------------------------------");
            sb.AppendLine();
            if (ex != null)
            {
                sb.Append("Exception: " + ex.ToString());
                if (ex.InnerException != null)
                {
                    sb.Append("Inner Exception: " + ex.InnerException.ToString());
                }
            }
            sb.AppendLine();
            sb.Append("--------------------------------------------------");
            sb.AppendLine();

            File.AppendAllText(path, sb.ToString());
            sb.Clear();
        }
        public void Log_QRY(string ex)
        {
            //ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('QUERY LOG')", true);
            StringBuilder sb = new StringBuilder();
            string path = AppDomain.CurrentDomain.BaseDirectory + "LogQuery.txt";

            sb.AppendLine();
            sb.Append("Log Time: " + DateTime.Now);
            sb.AppendLine();
            sb.Append("--------------------------------------------------");
            sb.AppendLine();
            if (ex != null)
            {
                sb.Append("Exception: " + ex.ToString());
                if (ex != null)
                {
                    sb.Append("Inner Exception: " + ex.ToString());
                }
            }
            sb.AppendLine();
            sb.Append("--------------------------------------------------");

            System.IO.File.AppendAllText(path, sb.ToString());
            sb.Clear();
        }
        private void search_btn_Click_1(object sender, EventArgs e)
        {
            string sysdtFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern+" 00:00:00 ";
            //string systimeFormat = DateTime.Now.ToString("tt", CultureInfo.InvariantCulture);
            //if(systimeFormat=="PM")
            //{
            //    systimeFormat = "AM";
            //}
            ProductionEntry_grd.Rows.Clear();
            string dt = ProdEnt_dt.Value.ToString(sysdtFormat);
            string line = Line_cmb.Text;
            //dt = dt + "AM";

            string wp = wp_txt.Text;
            if (line != "" & shift_cmb.Text != "" & line != "Select Line" & shift_cmb.Text != "Select Shift")
            {
                string shift = "";
                if (shift_cmb.Text == "SHIFT 1")
                {
                    shift = "1";
                }
                else if (shift_cmb.Text == "SHIFT 2")
                {
                    shift = "2";
                }
                else if (shift_cmb.Text == "SHIFT 3")
                {
                    shift = "3";
                }

                SqlDataReader rdr2 = null;
                string _squery2 = "";
                _squery2 = "select * from Tbl_Work_Plan where Line='" + line + "' and SHIFT like '%" + shift + "%' and DATE='" + dt + "' and STATUS='ACTIVE'";
                rdr2 = Utilities.executeQuery(_squery2);
                Log_QRY(_squery2);
                int c = 0;
                while (rdr2.Read())
                {
                    c++;
                    DateTime d_t = new DateTime();
                    string date_wp = rdr2["DATE"].ToString();
                    d_t = Convert.ToDateTime(date_wp);
                    string date = d_t.ToString("dd-MM-yyyy");
                    string[] row1 = new string[] { rdr2["WPNO"].ToString(), rdr2["Line"].ToString(), date.ToString(), rdr2["MCS"].ToString(), rdr2["SHIFT"].ToString(), rdr2["CUST"].ToString(), rdr2["PARTNO_MODEL"].ToString(), rdr2["PROCESS_NO"].ToString(), rdr2["HRS_PLAN"].ToString(), rdr2["QTY_PLAN"].ToString() };
                    object[] rows = new object[] { row1 };
                    foreach (string[] rowArray in rows)
                    {
                        ProductionEntry_grd.Rows.Add(rowArray);
                    }

                }
                if (c == 0)
                {
                    MessageBox.Show("Record Not Found");
                }

                rdr2.Close();
            }
            else if (wp != "")
            {
                SqlDataReader rdr3 = null;
                string _squery3 = "";
                _squery3 = "select * from Tbl_Work_Plan where WPNO='" + wp + "' and STATUS='ACTIVE'";
                Log_QRY(_squery3);
                rdr3 = Utilities.executeQuery(_squery3);
                int c = 0;
                while (rdr3.Read())
                {
                    c++;
                    DateTime d_t = new DateTime();
                    string date_wp = rdr3["DATE"].ToString();
                    d_t = Convert.ToDateTime(date_wp);
                    string date = d_t.ToString("dd-MM-yyyy");
                    string[] row1 = new string[] { rdr3["WPNO"].ToString(), rdr3["Line"].ToString(), date.ToString(), rdr3["MCS"].ToString(), rdr3["SHIFT"].ToString(), rdr3["CUST"].ToString(), rdr3["PARTNO_MODEL"].ToString(), rdr3["PROCESS_NO"].ToString(), rdr3["HRS_PLAN"].ToString(), rdr3["QTY_PLAN"].ToString() };
                    object[] rows = new object[] { row1 };
                    foreach (string[] rowArray in rows)
                    {
                        ProductionEntry_grd.Rows.Add(rowArray);
                    }

                }
                if (c == 0)
                {
                    MessageBox.Show("Record Not Found");
                }
                rdr3.Close();
            }
            else
            {
                MessageBox.Show("Please Select Date,Line,Shift Or Workplan Number to search data");
            }
            clear();
        }
    }
}
