using FML;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace P3C
{
    public partial class Reports : Form
    {
        public Reports()
        {
            InitializeComponent();
            Reports_Grd.Rows.Clear();
        }

        private void Reports_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            BindData();
            this.Reports_Grd.DefaultCellStyle.Font = new Font("Verdana", 8);
            this.Reports_Grd.ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 9, FontStyle.Bold);
            Reports_Grd.Rows.Clear();
            Reports_Grd.ColumnCount = 38;
            Reports_Grd.ColumnHeadersVisible = true;
            Reports_Grd.RowHeadersWidth = 10;
            Reports_Grd.Columns[0].Name = "S.NO";
            Reports_Grd.Columns[0].Width = 50;
            Reports_Grd.Columns[1].Name = "M/C'S";
            Reports_Grd.Columns[1].Width = 50;
            Reports_Grd.Columns[2].Name = "CUST";
            Reports_Grd.Columns[2].Width = 99;
            Reports_Grd.Columns[3].Name = "PART-NO/MODEL";
            Reports_Grd.Columns[3].Width = 130;
            Reports_Grd.Columns[4].Name = "PROCESS-NO";
            Reports_Grd.Columns[4].Width = 99;
            Reports_Grd.Columns[5].Name = "PART-NAME";
            Reports_Grd.Columns[5].Width = 99;
            this.Reports_Grd.Columns["PART-NAME"].Frozen = true;
            Reports_Grd.Columns[6].Name = "S1-UPH(PLAN)";
            Reports_Grd.Columns[6].Width = 111;
            Reports_Grd.Columns[7].Name = "S1-UPH(ACT)";
            Reports_Grd.Columns[7].Width = 111;
            Reports_Grd.Columns[8].Name = "S1-UPH(RATE)";
            Reports_Grd.Columns[8].Width = 111;
            Reports_Grd.Columns[9].Name = "S1-HRS(PLAN)";
            Reports_Grd.Columns[9].Width = 111;
            Reports_Grd.Columns[10].Name = "S1-HRS(ACT)";
            Reports_Grd.Columns[10].Width = 111;
            Reports_Grd.Columns[11].Name = "S1-HRS(RATE)";
            Reports_Grd.Columns[11].Width = 111;
            Reports_Grd.Columns[12].Name = "S1-QTY(PLAN)";
            Reports_Grd.Columns[12].Width = 111;
            Reports_Grd.Columns[13].Name = "S1-QTY(ACT)";
            Reports_Grd.Columns[13].Width = 111;
            Reports_Grd.Columns[14].Name = "S1-QTY(RATE)";
            Reports_Grd.Columns[14].Width = 111;
            Reports_Grd.Columns[15].Name = "LOSS HRS";
            Reports_Grd.Columns[15].Width = 99;
            Reports_Grd.Columns[16].Name = "LOSS %";
            Reports_Grd.Columns[16].Width = 99;
            Reports_Grd.Columns[17].Name = "PROD-LOSS%";
            Reports_Grd.Columns[17].Width = 99;
            Reports_Grd.Columns[18].Name = "COMENTS";
            Reports_Grd.Columns[18].Width = 99;
            Reports_Grd.Columns[19].Name = "S2-UPH(PLAN)";
            Reports_Grd.Columns[19].Width = 111;
            Reports_Grd.Columns[20].Name = "S2-UPH(ACT)";
            Reports_Grd.Columns[20].Width = 111;
            Reports_Grd.Columns[21].Name = "S2-UPH(RATE)";
            Reports_Grd.Columns[21].Width = 111;
            Reports_Grd.Columns[22].Name = "S2-HRS(PLAN)";
            Reports_Grd.Columns[22].Width = 111;
            Reports_Grd.Columns[23].Name = "S2-HRS(ACT)";
            Reports_Grd.Columns[23].Width = 111;
            Reports_Grd.Columns[24].Name = "S2-HRS(RATE)";
            Reports_Grd.Columns[24].Width = 111;
            Reports_Grd.Columns[25].Name = "S2-QTY(PLAN)";
            Reports_Grd.Columns[25].Width = 111;
            Reports_Grd.Columns[26].Name = "S2-QTY(ACT)";
            Reports_Grd.Columns[26].Width = 111;
            Reports_Grd.Columns[27].Name = "S2-QTY(RATE)";
            Reports_Grd.Columns[27].Width = 111;
            Reports_Grd.Columns[28].Name = "LOSS HRS";
            Reports_Grd.Columns[28].Width = 99;
            Reports_Grd.Columns[29].Name = "LOSS %";
            Reports_Grd.Columns[29].Width = 99;
            Reports_Grd.Columns[30].Name = "PROD-LOSS%";
            Reports_Grd.Columns[30].Width = 99;
            Reports_Grd.Columns[31].Name = "COMENTS";
            Reports_Grd.Columns[31].Width = 99;
            Reports_Grd.Columns[32].Name = "FORECAST-PLAN";
            Reports_Grd.Columns[32].Width = 140;
            Reports_Grd.Columns[33].Name = "TOTAL-PLAN-QTY";
            Reports_Grd.Columns[33].Width = 140;
            Reports_Grd.Columns[34].Name = "TOTAL-ACT-QTY";
            Reports_Grd.Columns[34].Width = 140;
            Reports_Grd.Columns[35].Name = "TOTAL-ACT-UPH";
            Reports_Grd.Columns[35].Width = 140;
            Reports_Grd.Columns[36].Name = "PLAN-WHRS";
            Reports_Grd.Columns[36].Width = 99;
            Reports_Grd.Columns[37].Name = "ACT-WHRS";
            Reports_Grd.Columns[37].Width = 99;
            color();
        }
        public void color()
        {
            this.Reports_Grd.DefaultCellStyle.Font = new Font("Verdana", 8);
            Reports_Grd.EnableHeadersVisualStyles = false;
            Reports_Grd.Columns[0].HeaderCell.Style.BackColor = Color.SkyBlue;
            Reports_Grd.Columns[0].HeaderCell.Style.Font = new Font("Verdana", 10, FontStyle.Regular);
            Reports_Grd.Columns[1].HeaderCell.Style.BackColor = Color.SkyBlue;
            Reports_Grd.Columns[1].HeaderCell.Style.Font = new Font("Verdana", 10, FontStyle.Regular);
            Reports_Grd.Columns[2].HeaderCell.Style.BackColor = Color.SkyBlue;
            Reports_Grd.Columns[2].HeaderCell.Style.Font = new Font("Verdana", 10, FontStyle.Regular);
            Reports_Grd.Columns[3].HeaderCell.Style.BackColor = Color.SkyBlue;
            Reports_Grd.Columns[3].HeaderCell.Style.Font = new Font("Verdana", 10, FontStyle.Regular);
            Reports_Grd.Columns[4].HeaderCell.Style.BackColor = Color.SkyBlue;
            Reports_Grd.Columns[4].HeaderCell.Style.Font = new Font("Verdana", 10, FontStyle.Regular);
            Reports_Grd.Columns[5].HeaderCell.Style.BackColor = Color.SkyBlue;
            Reports_Grd.Columns[5].HeaderCell.Style.Font = new Font("Verdana", 10, FontStyle.Regular);
            Reports_Grd.Columns[6].HeaderCell.Style.BackColor = Color.SkyBlue;
            Reports_Grd.Columns[6].HeaderCell.Style.Font = new Font("Verdana", 10, FontStyle.Regular);
            Reports_Grd.Columns[7].HeaderCell.Style.BackColor = Color.SkyBlue;
            Reports_Grd.Columns[7].HeaderCell.Style.Font = new Font("Verdana", 10, FontStyle.Regular);
            Reports_Grd.Columns[8].HeaderCell.Style.BackColor = Color.SkyBlue;
            Reports_Grd.Columns[8].HeaderCell.Style.Font = new Font("Verdana", 10, FontStyle.Regular);
            Reports_Grd.Columns[9].HeaderCell.Style.BackColor = Color.SkyBlue;
            Reports_Grd.Columns[9].HeaderCell.Style.Font = new Font("Verdana", 10, FontStyle.Regular);
            Reports_Grd.Columns[10].HeaderCell.Style.BackColor = Color.SkyBlue;
            Reports_Grd.Columns[10].HeaderCell.Style.Font = new Font("Verdana", 10, FontStyle.Regular);
            Reports_Grd.Columns[11].HeaderCell.Style.BackColor = Color.SkyBlue;
            Reports_Grd.Columns[11].HeaderCell.Style.Font = new Font("Verdana", 10, FontStyle.Regular);
            Reports_Grd.Columns[12].HeaderCell.Style.BackColor = Color.SkyBlue;
            Reports_Grd.Columns[12].HeaderCell.Style.Font = new Font("Verdana", 10, FontStyle.Regular);
            Reports_Grd.Columns[13].HeaderCell.Style.BackColor = Color.SkyBlue;
            Reports_Grd.Columns[13].HeaderCell.Style.Font = new Font("Verdana", 10, FontStyle.Regular);
            Reports_Grd.Columns[14].HeaderCell.Style.BackColor = Color.SkyBlue;
            Reports_Grd.Columns[14].HeaderCell.Style.Font = new Font("Verdana", 10, FontStyle.Regular);
            Reports_Grd.Columns[15].HeaderCell.Style.BackColor = Color.SkyBlue;
            Reports_Grd.Columns[15].HeaderCell.Style.Font = new Font("Verdana", 10, FontStyle.Regular);
            Reports_Grd.Columns[16].HeaderCell.Style.BackColor = Color.SkyBlue;
            Reports_Grd.Columns[16].HeaderCell.Style.Font = new Font("Verdana", 10, FontStyle.Regular);
            Reports_Grd.Columns[17].HeaderCell.Style.BackColor = Color.SkyBlue;
            Reports_Grd.Columns[17].HeaderCell.Style.Font = new Font("Verdana", 10, FontStyle.Regular);
            Reports_Grd.Columns[18].HeaderCell.Style.BackColor = Color.SkyBlue;
            Reports_Grd.Columns[18].HeaderCell.Style.Font = new Font("Verdana", 10, FontStyle.Regular);
            Reports_Grd.Columns[19].HeaderCell.Style.BackColor = Color.SkyBlue;
            Reports_Grd.Columns[19].HeaderCell.Style.Font = new Font("Verdana", 10, FontStyle.Regular);
            Reports_Grd.Columns[20].HeaderCell.Style.BackColor = Color.SkyBlue;
            Reports_Grd.Columns[20].HeaderCell.Style.Font = new Font("Verdana", 10, FontStyle.Regular);
            Reports_Grd.Columns[21].HeaderCell.Style.BackColor = Color.SkyBlue;
            Reports_Grd.Columns[21].HeaderCell.Style.Font = new Font("Verdana", 10, FontStyle.Regular);
            Reports_Grd.Columns[22].HeaderCell.Style.BackColor = Color.SkyBlue;
            Reports_Grd.Columns[22].HeaderCell.Style.Font = new Font("Verdana", 10, FontStyle.Regular);
            Reports_Grd.Columns[23].HeaderCell.Style.BackColor = Color.SkyBlue;
            Reports_Grd.Columns[23].HeaderCell.Style.Font = new Font("Verdana", 10, FontStyle.Regular);
            Reports_Grd.Columns[24].HeaderCell.Style.BackColor = Color.SkyBlue;
            Reports_Grd.Columns[24].HeaderCell.Style.Font = new Font("Verdana", 10, FontStyle.Regular);
            Reports_Grd.Columns[25].HeaderCell.Style.BackColor = Color.SkyBlue;
            Reports_Grd.Columns[25].HeaderCell.Style.Font = new Font("Verdana", 10, FontStyle.Regular);
            Reports_Grd.Columns[26].HeaderCell.Style.BackColor = Color.SkyBlue;
            Reports_Grd.Columns[26].HeaderCell.Style.Font = new Font("Verdana", 10, FontStyle.Regular);
            Reports_Grd.Columns[27].HeaderCell.Style.BackColor = Color.SkyBlue;
            Reports_Grd.Columns[27].HeaderCell.Style.Font = new Font("Verdana", 10, FontStyle.Regular);
            Reports_Grd.Columns[28].HeaderCell.Style.BackColor = Color.SkyBlue;
            Reports_Grd.Columns[28].HeaderCell.Style.Font = new Font("Verdana", 10, FontStyle.Regular);
            Reports_Grd.Columns[29].HeaderCell.Style.BackColor = Color.SkyBlue;
            Reports_Grd.Columns[29].HeaderCell.Style.Font = new Font("Verdana", 10, FontStyle.Regular);
            Reports_Grd.Columns[30].HeaderCell.Style.BackColor = Color.SkyBlue;
            Reports_Grd.Columns[30].HeaderCell.Style.Font = new Font("Verdana", 10, FontStyle.Regular);
            Reports_Grd.Columns[31].HeaderCell.Style.BackColor = Color.SkyBlue;
            Reports_Grd.Columns[31].HeaderCell.Style.Font = new Font("Verdana", 10, FontStyle.Regular);
            Reports_Grd.Columns[32].HeaderCell.Style.BackColor = Color.SkyBlue;
            Reports_Grd.Columns[32].HeaderCell.Style.Font = new Font("Verdana", 10, FontStyle.Regular);
            Reports_Grd.Columns[33].HeaderCell.Style.BackColor = Color.SkyBlue;
            Reports_Grd.Columns[33].HeaderCell.Style.Font = new Font("Verdana", 10, FontStyle.Regular);
            Reports_Grd.Columns[34].HeaderCell.Style.BackColor = Color.SkyBlue;
            Reports_Grd.Columns[34].HeaderCell.Style.Font = new Font("Verdana", 10, FontStyle.Regular);
            Reports_Grd.Columns[35].HeaderCell.Style.BackColor = Color.SkyBlue;
            Reports_Grd.Columns[35].HeaderCell.Style.Font = new Font("Verdana", 10, FontStyle.Regular);
            Reports_Grd.Columns[36].HeaderCell.Style.BackColor = Color.SkyBlue;
            Reports_Grd.Columns[36].HeaderCell.Style.Font = new Font("Verdana", 10, FontStyle.Regular);
            Reports_Grd.Columns[37].HeaderCell.Style.BackColor = Color.SkyBlue;
            Reports_Grd.Columns[37].HeaderCell.Style.Font = new Font("Verdana", 10, FontStyle.Regular);
        }
        DateTime d_t_S1 = new DateTime();
        string date_wp_S1 = "";
        string date_S1 = "";
        decimal UP_uphplan_S1 = Convert.ToDecimal(null);
        decimal UP_hrsplan_S1 = Convert.ToDecimal(null);
        decimal UP_qtyplan_S1 = Convert.ToDecimal(null);
        decimal PE_uphact_S1 = Convert.ToDecimal(null);
        decimal PE_hrsact_S1 = Convert.ToDecimal(null);
        decimal v = Convert.ToDecimal(null);
        decimal uph_RT = Convert.ToDecimal(null);
        decimal hrs_RT = Convert.ToDecimal(null);
        decimal UP_uphplan = Convert.ToDecimal(null);
        decimal UP_hrsplan = Convert.ToDecimal(null);
        decimal UP_qtyplan1 = Convert.ToDecimal(null);
        decimal UP_qtyplan2 = Convert.ToDecimal(null);
        decimal PE_uphact = Convert.ToDecimal(null);
        decimal loss_hrs1 = Convert.ToDecimal(null);
        decimal PE_hrsact = Convert.ToDecimal(null);
        decimal PE_hrsact2 = Convert.ToDecimal(null);
        decimal PE_qtyact2 = Convert.ToDecimal(null);
        decimal PE_qtyact1 = Convert.ToDecimal(null);
        decimal k = Convert.ToDecimal(null);
        decimal qty_RT = Convert.ToDecimal(null);
        decimal loss_hrs3 = Convert.ToDecimal(null);
        decimal PL2 = Convert.ToDecimal(null);
        decimal PL = Convert.ToDecimal(null);
        decimal PE_qtyact_S1 = Convert.ToDecimal(null);
        decimal uph_RT_S1 = Convert.ToDecimal(null);
        decimal hrs_RT_S1 = Convert.ToDecimal(null);
        decimal qty_RT_S1 = Convert.ToDecimal(null);
        decimal loss_hrs1_S1 = Convert.ToDecimal(null);
        decimal loss_hrs2_S1 = Convert.ToDecimal(null);
        decimal loss_hrs3_S1 = Convert.ToDecimal(null);
        decimal PL_S1 = Convert.ToDecimal(null);

        DateTime d_t_S2 = new DateTime();
        string date_wp_S2 = "";
        string date_S2 = "";
        decimal UP_uphplan_S2 = Convert.ToDecimal(null);
        decimal UP_hrsplan_S2 = Convert.ToDecimal(null);
        decimal UP_qtyplan_S2 = Convert.ToDecimal(null);
        decimal PE_uphact_S2 = Convert.ToDecimal(null);
        decimal PE_hrsact_S2 = Convert.ToDecimal(null);
        decimal PE_qtyact_S2 = Convert.ToDecimal(null);
        decimal uph_RT_S2 = Convert.ToDecimal(null);
        decimal hrs_RT_S2 = Convert.ToDecimal(null);
        decimal qty_RT_S2 = Convert.ToDecimal(null);
        decimal loss_hrS2_S2 = Convert.ToDecimal(null);
        decimal loss_hrs2_S2 = Convert.ToDecimal(null);
        decimal loss_hrs3_S2 = Convert.ToDecimal(null);
        decimal PL_S2 = Convert.ToDecimal(null);
        private void search_btn_Click(object sender, EventArgs e)
        {
            #region
            try
            {
                Reports_Grd.Rows.Clear();
                string dt = ProdEnt_dt.Value.ToString("dd-MM-yyyy");
                string dt10 = ProdEnt_To_dt.Value.ToString("dd-MM-yyyy");
                string line = Line_cmb.Text;
                string shift = "";
                if (shift_cmb.Text.Trim() == "SHIFT 1")
                {
                    shift = "1";
                }
                else if (shift_cmb.Text.Trim() == "SHIFT 2")
                {
                    shift = "2";
                }
                else if (shift_cmb.Text.Trim() == "SHIFT 3")
                {
                    shift = "3";
                }
                else if (shift_cmb.Text.Trim() == "ALL")
                {
                    shift = "ALL";
                }
                else { MessageBox.Show("Please Select Shift"); }


                SqlDataReader rdr2 = null;
                string _squery2 = "";
                if (shift == "1")
                {
                    _squery2 = "select * from Tbl_Work_Plan AS TWP JOIN Tbl_Production_Entry AS TPE  ON TWP.WPNO=TPE.WPNO and TWP.SHIFT like '%" + shift + "%'  where TPE.DATE between '" + dt + "' and '" + dt10 + "' and TPE.LINE='" + line + "'";
                    rdr2 = Utilities.executeQuery(_squery2);
                    int ce = 0;
                    while (rdr2.Read())
                    {
                        ce++;
                        DateTime d_t = new DateTime();
                        string date_wp = rdr2["DATE"].ToString();
                        d_t = Convert.ToDateTime(date_wp);
                        string date = d_t.ToString("dd-MM-yyyy");

                        string zero = "0";
                        //WP Data's 
                        if (rdr2["UPH_PLAN"].ToString() == "")
                        {
                            UP_uphplan = Convert.ToDecimal(zero);
                        }
                        else
                        {
                            UP_uphplan = Convert.ToDecimal(rdr2["UPH_PLAN"].ToString());
                        }
                        if (rdr2["HRS_PLAN"].ToString() == "")
                        {
                            UP_hrsplan = Convert.ToDecimal(zero);
                        }
                        else
                        {
                            UP_hrsplan = Convert.ToDecimal(rdr2["HRS_PLAN"]);
                        }
                        if (rdr2["QTY_PLAN"].ToString() == "")
                        {
                            UP_qtyplan1 = Convert.ToDecimal(zero);
                        }
                        else
                        {
                            UP_qtyplan1 = Convert.ToDecimal(rdr2["QTY_PLAN"]);
                        }

                        //PE Data's 
                        if (rdr2["PLAN_HRS"].ToString() == "")
                        {
                            PE_uphact = Convert.ToDecimal(zero);
                        }
                        else
                        {
                            PE_uphact = Convert.ToDecimal(rdr2["PLAN_HRS"]);
                        }
                        if (rdr2["HRS_ACT"].ToString() == "")
                        {
                            PE_hrsact = Convert.ToDecimal(zero);
                        }
                        else
                        {
                            PE_hrsact = Convert.ToDecimal(rdr2["HRS_ACT"]);
                        }
                        if (rdr2["QTY_ACT"].ToString() == "")
                        {
                            PE_qtyact1 = Convert.ToDecimal(zero);
                        }
                        else
                        {
                            PE_qtyact1 = Convert.ToDecimal(rdr2["QTY_ACT"]);
                        }

                        if (UP_uphplan != 0)
                        {
                            uph_RT = PE_uphact / UP_uphplan * 100;
                        }
                        else
                        {
                            uph_RT = 0;
                        }
                        if (UP_hrsplan != 0)
                        {
                            hrs_RT = PE_hrsact / UP_hrsplan * 100;
                        }
                        else
                        {
                            hrs_RT = 0;
                        }
                        if (UP_qtyplan1 != 0)
                        {
                            qty_RT = PE_qtyact1 / UP_qtyplan1 * 100;
                        }
                        else
                        {
                            qty_RT = 0;
                        }

                        //Loss% values
                        if (rdr2["LOSS_HRS"].ToString() == "")
                        {
                            loss_hrs1 = Convert.ToDecimal(zero);
                        }
                        else
                        {
                            loss_hrs1 = (Convert.ToDecimal(rdr2["LOSS_HRS"])) * UP_uphplan;
                        }
                        decimal loss_hrs2 = UP_uphplan * UP_hrsplan;
                        if (loss_hrs2 != 0)
                        {
                            loss_hrs3 = loss_hrs1 / loss_hrs2;
                        }
                        else
                        {
                            loss_hrs3 = 0;
                        }

                        //PROD LOSS%
                        decimal PL = 100 - (Math.Round(qty_RT, 1) + (Math.Round(loss_hrs3 * 100, 1)));
                        if (PE_hrsact != 0)
                        {
                            k = (PE_qtyact1 / PE_hrsact);
                        }
                        else
                        {
                            k = 0;
                        }

                        decimal test = Convert.ToDecimal((100 * 6.3) / 6.3);
                        string[] row1 = new string[] { ce.ToString(), rdr2["MCS"].ToString(), rdr2["CUST"].ToString(), rdr2["PARTNO_MODEL"].ToString(), rdr2["PROCESS_NO"].ToString(), rdr2["PART_NAME"].ToString(), UP_uphplan.ToString(), PE_uphact.ToString(), (Math.Round(uph_RT, 1)).ToString() + "%", UP_hrsplan.ToString(), PE_hrsact.ToString(), (Math.Round(hrs_RT, 1)).ToString() + "%", UP_qtyplan1.ToString(), PE_qtyact1.ToString(), (Math.Round(qty_RT, 1)).ToString() + "%", rdr2["LOSS_HRS"].ToString(), (Math.Round(loss_hrs3 * 100, 1)).ToString() + "%", (Math.Round(PL, 1)).ToString() + "%", rdr2["COMENTS"].ToString(), "", "", "", "", "", "", "", "", "", "", "", "", "", rdr2["FORECAST"].ToString(), UP_qtyplan1.ToString(), PE_qtyact1.ToString(), k.ToString(), UP_hrsplan.ToString(), PE_hrsact.ToString() };
                        object[] rows = new object[] { row1 };
                        foreach (string[] rowArray in rows)
                        {
                            Reports_Grd.Rows.Add(rowArray);
                        }


                    }
                    if (ce == 0)
                    {
                        MessageBox.Show("Record Not Found");
                    }

                    rdr2.Close();
                }
                else if (shift == "2")
                {
                    _squery2 = "select * from Tbl_Work_Plan AS TWP JOIN Tbl_Production_Entry AS TPE  ON TWP.WPNO=TPE.WPNO and TWP.SHIFT like '%" + shift + "%'  where TPE.DATE between '" + dt + "' and '" + dt10 + "' and TPE.LINE='" + line + "'";
                    rdr2 = Utilities.executeQuery(_squery2);
                    int c = 0;
                    while (rdr2.Read())
                    {
                        c++;
                        DateTime d_t = new DateTime();
                        string date_wp = rdr2["DATE"].ToString();
                        d_t = Convert.ToDateTime(date_wp);
                        string date = d_t.ToString("dd-MM-yyyy");
                        string zero = "0";

                        //WP Data's 
                        if (rdr2["UPH_PLAN"].ToString() == "")
                        {
                            UP_uphplan = Convert.ToDecimal(zero);
                        }
                        else
                        {
                            UP_uphplan = Convert.ToDecimal(rdr2["UPH_PLAN"].ToString());
                        }
                        if (rdr2["HRS_PLAN"].ToString() == "")
                        {
                            UP_hrsplan = Convert.ToDecimal(zero);
                        }
                        else
                        {
                            UP_hrsplan = Convert.ToDecimal(rdr2["HRS_PLAN"]);
                        }
                        if (rdr2["QTY_PLAN"].ToString() == "")
                        {
                            UP_qtyplan2 = Convert.ToDecimal(zero);
                        }
                        else
                        {
                            UP_qtyplan2 = Convert.ToDecimal(rdr2["QTY_PLAN"]);
                        }

                        //PE Data's 
                        if (rdr2["PLAN_HRS"].ToString() == "")
                        {
                            PE_uphact = Convert.ToDecimal(zero);
                        }
                        else
                        {
                            PE_uphact = Convert.ToDecimal(rdr2["PLAN_HRS"]);
                        }
                        if (rdr2["HRS_ACT"].ToString() == "")
                        {
                            PE_hrsact2 = Convert.ToDecimal(zero);
                        }
                        else
                        {
                            PE_hrsact2 = Convert.ToDecimal(rdr2["HRS_ACT"]);
                        }
                        if (rdr2["QTY_ACT"].ToString() == "")
                        {
                            PE_qtyact2 = Convert.ToDecimal(zero);
                        }
                        else
                        {
                            PE_qtyact2 = Convert.ToDecimal(rdr2["QTY_ACT"]);
                        }


                        ////WP Data's 
                        //decimal UP_uphplan = Convert.ToDecimal(rdr2["UPH_PLAN"]);
                        //decimal UP_hrsplan = Convert.ToDecimal(rdr2["HRS_PLAN"]);
                        //decimal UP_qtyplan = Convert.ToDecimal(rdr2["QTY_PLAN"]);

                        ////PE Data's 
                        //decimal PE_uphact = Convert.ToDecimal(rdr2["PLAN_HRS"]);
                        //decimal PE_hrsact = Convert.ToDecimal(rdr2["HRS_ACT"]);
                        //decimal PE_qtyact = Convert.ToDecimal(rdr2["QTY_ACT"]);


                        if (UP_uphplan != 0)
                        {
                            uph_RT = PE_uphact / UP_uphplan * 100;
                        }
                        else
                        {
                            uph_RT = 0;
                        }
                        if (UP_hrsplan != 0)
                        {
                            hrs_RT = PE_hrsact2 / UP_hrsplan * 100;
                        }
                        else
                        {
                            hrs_RT = 0;
                        }
                        if (UP_qtyplan2 != 0)
                        {
                            qty_RT = PE_qtyact2 / UP_qtyplan2 * 100;
                        }
                        else
                        {
                            qty_RT = 0;
                        }

                        //Loss% values
                        if (rdr2["LOSS_HRS"].ToString() == "")
                        {
                            loss_hrs1 = Convert.ToDecimal(zero);
                        }
                        else
                        {
                            loss_hrs1 = (Convert.ToDecimal(rdr2["LOSS_HRS"])) * UP_uphplan;
                        }
                        decimal loss_hrs2 = UP_uphplan * UP_hrsplan;

                        if (loss_hrs2 != 0)
                        {
                            loss_hrs3 = loss_hrs1 / loss_hrs2;
                        }
                        else
                        {
                            loss_hrs3 = 0;
                        }

                        //PROD LOSS%
                        decimal PL = 100 - (Math.Round(qty_RT, 1) + (Math.Round(loss_hrs3 * 100, 1)));
                        if (PE_hrsact2 != 0)
                        {
                            k = (PE_qtyact2 / PE_hrsact2);
                        }
                        else
                        {
                            k = 0;
                        }
                        string[] row1 = new string[] { c.ToString(), rdr2["MCS"].ToString(), rdr2["CUST"].ToString(), rdr2["PARTNO_MODEL"].ToString(), rdr2["PROCESS_NO"].ToString(), rdr2["PART_NAME"].ToString(), "", "", "", "", "", "", "", "", "", "", "", "", "", UP_uphplan.ToString(), PE_uphact.ToString(), (Math.Round(uph_RT, 1)).ToString() + "%", UP_hrsplan.ToString(), PE_hrsact2.ToString(), (Math.Round(hrs_RT, 1)).ToString() + "%", UP_qtyplan2.ToString(), PE_qtyact2.ToString(), (Math.Round(qty_RT, 1)).ToString() + "%", rdr2["LOSS_HRS"].ToString(), (Math.Round(loss_hrs3 * 100, 1)).ToString() + "%", (Math.Round(PL, 1)).ToString() + "%", rdr2["COMENTS"].ToString(), rdr2["FORECAST"].ToString(), UP_qtyplan2.ToString(), PE_qtyact2.ToString(), k.ToString(), UP_hrsplan.ToString(), PE_hrsact2.ToString() };
                        object[] rows = new object[] { row1 };
                        foreach (string[] rowArray in rows)
                        {
                            Reports_Grd.Rows.Add(rowArray);
                        }
                    }
                    if (c == 0)
                    {
                        MessageBox.Show("Record Not Found");
                    }

                    rdr2.Close();
                }
                #endregion
                else if (shift == "ALL")
                {
                    string query_all = "select * from Tbl_Work_Plan AS TWP JOIN Tbl_Production_Entry AS TPE  ON TWP.WPNO=TPE.WPNO where TPE.DATE between '" + dt + "' and '" + dt10 + "' and TPE.LINE='" + line + "'";
                    SqlDataReader rdr_all = Utilities.executeQuery(query_all);
                    if (rdr_all.Read())
                    {
                        string _squery3 = "select TPE.MCS,TPE.COMENTS,TWP.FORECAST,TPE.SHIFT,TWP.PART_NAME,TPE.PROCESS_NO,TPE.PARTNO_MODEL,TPE.CUST,sum(CAST(TWP.QTY_PLAN AS DECIMAL(10,2))) as QTY_PLAN,sum(CAST(TWP.HRS_PLAN AS DECIMAL(10,2))) as HRS_PLAN,sum(CAST(TWP.UPH_PLAN AS DECIMAL(10,2))) as UPH_PLAN,sum(CAST(TPE.PLAN_QTY AS DECIMAL(10,2))) as PLAN_QTY,sum(CAST(TPE.HRS_ACT AS DECIMAL(10,2))) as HRS_ACT,sum(CAST(TPE.QTY_ACT AS DECIMAL(10,2))) as QTY_ACT,sum(CAST(TPE.REJECTION_QTY AS DECIMAL(10,2))) as REJECTION_QTY,sum(CAST(TPE.LOSS_HRS AS DECIMAL(10,2))) as LOSS_HRS,sum(CAST(TPE.PLAN_HRS AS DECIMAL(10,2))) as PLAN_HRS from Tbl_Work_Plan AS TWP JOIN Tbl_Production_Entry AS TPE  ON TWP.WPNO=TPE.WPNO where TPE.DATE between '" + dt + "' and '" + dt10 + "' and TPE.LINE='" + line + "' group by TPE.SHIFT,TPE.MCS,TPE.CUST,TPE.PARTNO_MODEL,TPE.PROCESS_NO,TWP.PART_NAME,TPE.COMENTS,TWP.FORECAST order by TPE.MCS";
                        //_squery2 = "select * from Tbl_Work_Plan AS TWP JOIN Tbl_Production_Entry AS TPE  ON TWP.WPNO=TPE.WPNO where TPE.DATE between '" + dt + "' and '" + dt10 + "' and TPE.LINE='" + line + "'";
                        rdr2 = Utilities.executeQuery(_squery3);
                        int c = -1;
                        while (rdr2.Read())
                        {
                            c++;
                            Utilities.NEW_MCS = rdr2["MCS"].ToString();
                            if (rdr2["SHIFT"].ToString() == "SHIFT 1")
                            {
                                DateTime d_t = new DateTime();
                                string date_wp = rdr_all["DATE"].ToString();
                                d_t = Convert.ToDateTime(date_wp);
                                string date = d_t.ToString("dd-MM-yyyy");

                                string zero = "0";
                                //WP Data's 
                                if (rdr2["UPH_PLAN"].ToString() == "")
                                {
                                    UP_uphplan = Convert.ToDecimal(zero);
                                }
                                else
                                {
                                    UP_uphplan = Convert.ToDecimal(rdr2["UPH_PLAN"].ToString());
                                }
                                if (rdr2["HRS_PLAN"].ToString() == "")
                                {
                                    UP_hrsplan = Convert.ToDecimal(zero);
                                }
                                else
                                {
                                    UP_hrsplan = Convert.ToDecimal(rdr2["HRS_PLAN"]);
                                }
                                if (rdr2["QTY_PLAN"].ToString() == "")
                                {
                                    UP_qtyplan1 = Convert.ToDecimal(zero);
                                }
                                else
                                {
                                    UP_qtyplan1 = Convert.ToDecimal(rdr2["QTY_PLAN"]);
                                }

                                //PE Data's 
                                if (rdr2["PLAN_HRS"].ToString() == "")
                                {
                                    PE_uphact = Convert.ToDecimal(zero);
                                }
                                else
                                {
                                    PE_uphact = Convert.ToDecimal(rdr2["PLAN_HRS"]);
                                }
                                if (rdr2["HRS_ACT"].ToString() == "")
                                {
                                    PE_hrsact = Convert.ToDecimal(zero);
                                }
                                else
                                {
                                    PE_hrsact = Convert.ToDecimal(rdr2["HRS_ACT"]);
                                }
                                if (rdr2["QTY_ACT"].ToString() == "")
                                {
                                    PE_qtyact1 = Convert.ToDecimal(zero);
                                }
                                else
                                {
                                    PE_qtyact1 = Convert.ToDecimal(rdr2["QTY_ACT"]);
                                }

                                if (UP_uphplan != 0)
                                {
                                    uph_RT = PE_uphact / UP_uphplan * 100;
                                }
                                else
                                {
                                    uph_RT = 0;
                                }
                                if (UP_hrsplan != 0)
                                {
                                    hrs_RT = PE_hrsact / UP_hrsplan * 100;
                                }
                                else
                                {
                                    hrs_RT = 0;
                                }
                                if (UP_qtyplan1 != 0)
                                {
                                    qty_RT = PE_qtyact1 / UP_qtyplan1 * 100;
                                }
                                else
                                {
                                    qty_RT = 0;
                                }

                                //Loss% values
                                if (rdr2["LOSS_HRS"].ToString() == "")
                                {
                                    loss_hrs1 = Convert.ToDecimal(zero);
                                }
                                else
                                {
                                    loss_hrs1 = (Convert.ToDecimal(rdr2["LOSS_HRS"])) * UP_uphplan;
                                }
                                decimal loss_hrs2 = UP_uphplan * UP_hrsplan;
                                if (loss_hrs2 != 0)
                                {
                                    loss_hrs3 = loss_hrs1 / loss_hrs2;
                                }
                                else
                                {
                                    loss_hrs3 = 0;
                                }

                                //PROD LOSS%
                                PL = 100 - (Math.Round(qty_RT, 1) + (Math.Round(loss_hrs3 * 100, 1)));
                                if (PE_hrsact != 0)
                                {
                                    k = (PE_qtyact1 / PE_hrsact);
                                }
                                else
                                {
                                    k = 0;
                                }

                                decimal test = Convert.ToDecimal((100 * 6.3) / 6.3);
                                //string[] row1 = new string[] { c.ToString(), rdr2["MCS"].ToString(), rdr2["CUST"].ToString(), rdr2["PARTNO_MODEL"].ToString(), rdr2["PROCESS_NO"].ToString(), rdr2["PART_NAME"].ToString(), UP_uphplan.ToString(), PE_uphact.ToString(), (Math.Round(uph_RT, 1)).ToString() + "%", UP_hrsplan.ToString(), PE_hrsact.ToString(), (Math.Round(hrs_RT, 1)).ToString() + "%", UP_qtyplan.ToString(), PE_qtyact.ToString(), (Math.Round(qty_RT, 1)).ToString() + "%", rdr2["LOSS_HRS"].ToString(), (Math.Round(loss_hrs3 * 100, 1)).ToString() + "%", (Math.Round(PL, 1)).ToString() + "%", rdr2["COMENTS"].ToString(), "", "", "", "", "", "", "", "", "", "", "", "", "", rdr2["FORECAST"].ToString(), UP_qtyplan.ToString(), PE_qtyact.ToString(), k.ToString(), UP_hrsplan.ToString(), PE_hrsact.ToString() };
                                //object[] rows = new object[] { row1 };
                                //foreach (string[] rowArray in rows)
                                //{
                                //    Reports_Grd.Rows.Add(rowArray);
                                //}

                            }
                            if (rdr2["SHIFT"].ToString() == "SHIFT 2")
                            {
                                DateTime d_t = new DateTime();
                                string date_wp = rdr_all["DATE"].ToString();
                                d_t = Convert.ToDateTime(date_wp);
                                string date = d_t.ToString("dd-MM-yyyy");
                                string zero = "0";

                                //WP Data's 
                                if (rdr2["UPH_PLAN"].ToString() == "")
                                {
                                    UP_uphplan = Convert.ToDecimal(zero);
                                }
                                else
                                {
                                    UP_uphplan = Convert.ToDecimal(rdr2["UPH_PLAN"].ToString());
                                }
                                if (rdr2["HRS_PLAN"].ToString() == "")
                                {
                                    UP_hrsplan = Convert.ToDecimal(zero);
                                }
                                else
                                {
                                    UP_hrsplan = Convert.ToDecimal(rdr2["HRS_PLAN"]);
                                }
                                if (rdr2["QTY_PLAN"].ToString() == "")
                                {
                                    UP_qtyplan2 = Convert.ToDecimal(zero);
                                }
                                else
                                {
                                    UP_qtyplan2 = Convert.ToDecimal(rdr2["QTY_PLAN"]);
                                }

                                //PE Data's 
                                if (rdr2["PLAN_HRS"].ToString() == "")
                                {
                                    PE_uphact = Convert.ToDecimal(zero);
                                }
                                else
                                {
                                    PE_uphact = Convert.ToDecimal(rdr2["PLAN_HRS"]);
                                }
                                if (rdr2["HRS_ACT"].ToString() == "")
                                {
                                    PE_hrsact2 = Convert.ToDecimal(zero);
                                }
                                else
                                {
                                    PE_hrsact2 = Convert.ToDecimal(rdr2["HRS_ACT"]);
                                }
                                if (rdr2["QTY_ACT"].ToString() == "")
                                {
                                    PE_qtyact2 = Convert.ToDecimal(zero);
                                }
                                else
                                {
                                    PE_qtyact2 = Convert.ToDecimal(rdr2["QTY_ACT"]);
                                }


                                ////WP Data's 
                                //decimal UP_uphplan = Convert.ToDecimal(rdr2["UPH_PLAN"]);
                                //decimal UP_hrsplan = Convert.ToDecimal(rdr2["HRS_PLAN"]);
                                //decimal UP_qtyplan = Convert.ToDecimal(rdr2["QTY_PLAN"]);

                                ////PE Data's 
                                //decimal PE_uphact = Convert.ToDecimal(rdr2["PLAN_HRS"]);
                                //decimal PE_hrsact = Convert.ToDecimal(rdr2["HRS_ACT"]);
                                //decimal PE_qtyact = Convert.ToDecimal(rdr2["QTY_ACT"]);


                                if (UP_uphplan != 0)
                                {
                                    uph_RT = PE_uphact / UP_uphplan * 100;
                                }
                                else
                                {
                                    uph_RT = 0;
                                }
                                if (UP_hrsplan != 0)
                                {
                                    hrs_RT = PE_hrsact2 / UP_hrsplan * 100;
                                }
                                else
                                {
                                    hrs_RT = 0;
                                }
                                if (UP_qtyplan2 != 0)
                                {
                                    qty_RT = PE_qtyact2 / UP_qtyplan2 * 100;
                                }
                                else
                                {
                                    qty_RT = 0;
                                }

                                //Loss% values
                                if (rdr2["LOSS_HRS"].ToString() == "")
                                {
                                    loss_hrs1 = Convert.ToDecimal(zero);
                                }
                                else
                                {
                                    loss_hrs1 = (Convert.ToDecimal(rdr2["LOSS_HRS"])) * UP_uphplan;
                                }
                                decimal loss_hrs2 = UP_uphplan * UP_hrsplan;

                                if (loss_hrs2 != 0)
                                {
                                    loss_hrs3 = loss_hrs1 / loss_hrs2;
                                }
                                else
                                {
                                    loss_hrs3 = 0;
                                }

                                //PROD LOSS%
                                PL2 = 100 - (Math.Round(qty_RT, 1) + (Math.Round(loss_hrs3 * 100, 1)));
                                if (PE_hrsact2 != 0)
                                {
                                    k = (PE_qtyact2 / PE_hrsact2);
                                }
                                else
                                {
                                    k = 0;
                                }
                                

                            }
                            int count = 0;
                            if (c == 0)
                            {
                                if (rdr2["SHIFT"].ToString() == "SHIFT 1")
                                {

                                    string qry = "select COUNT(distinct(TPE.SHIFT)) as cnt from Tbl_Work_Plan AS TWP JOIN Tbl_Production_Entry AS TPE  ON TWP.WPNO=TPE.WPNO where TWP.PART_NAME='" + rdr2["PART_NAME"].ToString() + "' and TPE.PROCESS_NO='" + rdr2["PROCESS_NO"].ToString() + "' and TPE.PARTNO_MODEL='" + rdr2["PARTNO_MODEL"].ToString() + "' and TPE.CUST='" + rdr2["CUST"].ToString() + "' and TPE.MCS='" + rdr2["MCS"].ToString() + "' and TPE.DATE between '" + dt + "' and '" + dt10 + "' and TPE.LINE='" + line + "'";
                                    SqlDataReader rdr = Utilities.executeQuery(qry);
                                    if (rdr.Read())
                                    {
                                        count = Convert.ToInt32(rdr["cnt"].ToString());
                                    }
                                    if (count == 1)
                                    {
                                        string[] row1 = new string[] { (Reports_Grd.Rows.Count + 1).ToString(), rdr2["MCS"].ToString(), rdr2["CUST"].ToString(), rdr2["PARTNO_MODEL"].ToString(), rdr2["PROCESS_NO"].ToString(), rdr2["PART_NAME"].ToString(), UP_uphplan.ToString(), PE_uphact.ToString(), (Math.Round(uph_RT, 1)).ToString() + "%", UP_hrsplan.ToString(), PE_hrsact.ToString(), (Math.Round(hrs_RT, 1)).ToString() + "%", UP_qtyplan1.ToString(), PE_qtyact1.ToString(), (Math.Round(qty_RT, 1)).ToString() + "%", rdr2["LOSS_HRS"].ToString(), (Math.Round(loss_hrs3 * 100, 1)).ToString() + "%", (Math.Round(PL, 1)).ToString() + "%", rdr2["COMENTS"].ToString(), "", "", "", "", "", "", "", "", "", "", "", "", "", rdr2["FORECAST"].ToString(), UP_qtyplan1.ToString(), PE_qtyact1.ToString(), k.ToString(), UP_hrsplan.ToString(), PE_hrsact.ToString() };
                                        object[] rows = new object[] { row1 };
                                        foreach (string[] rowArray in rows)
                                        {
                                            Reports_Grd.Rows.Add(rowArray);
                                        }
                                    }
                                }
                                else if (rdr2["SHIFT"].ToString() == "SHIFT 2")
                                {

                                    string qry = "select COUNT(distinct(TPE.SHIFT)) as cnt from Tbl_Work_Plan AS TWP JOIN Tbl_Production_Entry AS TPE  ON TWP.WPNO=TPE.WPNO where TWP.PART_NAME='" + rdr2["PART_NAME"].ToString() + "' and TPE.PROCESS_NO='" + rdr2["PROCESS_NO"].ToString() + "' and TPE.PARTNO_MODEL='" + rdr2["PARTNO_MODEL"].ToString() + "' and TPE.CUST='" + rdr2["CUST"].ToString() + "' and TPE.MCS='" + rdr2["MCS"].ToString() + "' and TPE.DATE between '" + dt + "' and '" + dt10 + "' and TPE.LINE='" + line + "'";
                                    SqlDataReader rdr = Utilities.executeQuery(qry);
                                    if (rdr.Read())
                                    {
                                        count = Convert.ToInt32(rdr["cnt"].ToString());
                                    }
                                    if (count == 1)
                                    {
                                        string[] row1 = new string[] { (Reports_Grd.Rows.Count + 1).ToString(), rdr2["MCS"].ToString(), rdr2["CUST"].ToString(), rdr2["PARTNO_MODEL"].ToString(), rdr2["PROCESS_NO"].ToString(), rdr2["PART_NAME"].ToString(), "", "", "", "", "", "", "", "", "", "", "", "", "", UP_uphplan.ToString(), PE_uphact.ToString(), (Math.Round(uph_RT, 1)).ToString() + "%", UP_hrsplan.ToString(), PE_hrsact2.ToString(), (Math.Round(hrs_RT, 1)).ToString() + "%", UP_qtyplan2.ToString(), PE_qtyact2.ToString(), (Math.Round(qty_RT, 1)).ToString() + "%", rdr2["LOSS_HRS"].ToString(), (Math.Round(loss_hrs3 * 100, 1)).ToString() + "%", (Math.Round(PL, 1)).ToString() + "%", rdr2["COMENTS"].ToString(), rdr2["FORECAST"].ToString(), UP_qtyplan2.ToString(), PE_qtyact2.ToString(), k.ToString(), UP_hrsplan.ToString(), PE_hrsact2.ToString() };
                                        object[] rows = new object[] { row1 };
                                        foreach (string[] rowArray in rows)
                                        {
                                            Reports_Grd.Rows.Add(rowArray);
                                        }
                                    }
                                }
                            }
                            else if (Utilities.OLD_MCS == Utilities.NEW_MCS)
                            {
                                string[] row1 = new string[] { (Reports_Grd.Rows.Count + 1).ToString(), rdr2["MCS"].ToString(), rdr2["CUST"].ToString(), rdr2["PARTNO_MODEL"].ToString(), rdr2["PROCESS_NO"].ToString(), rdr2["PART_NAME"].ToString(), UP_uphplan.ToString(), PE_uphact.ToString(), (Math.Round(uph_RT, 1)).ToString() + "%", UP_hrsplan.ToString(), PE_hrsact.ToString(), (Math.Round(hrs_RT, 1)).ToString() + "%", UP_qtyplan1.ToString(), PE_qtyact1.ToString(), (Math.Round(qty_RT, 1)).ToString() + "%", rdr2["LOSS_HRS"].ToString(), (Math.Round(loss_hrs3 * 100, 1)).ToString() + "%", (Math.Round(PL, 1)).ToString() + "%", rdr2["COMENTS"].ToString(), UP_uphplan.ToString(), PE_uphact.ToString(), (Math.Round(uph_RT, 1)).ToString() + "%", UP_hrsplan.ToString(), PE_hrsact.ToString(), (Math.Round(hrs_RT, 1)).ToString() + "%", UP_qtyplan2.ToString(), PE_qtyact2.ToString(), (Math.Round(qty_RT, 1)).ToString() + "%", rdr2["LOSS_HRS"].ToString(), (Math.Round(loss_hrs3 * 100, 1)).ToString() + "%", (Math.Round(PL2, 1)).ToString() + "%", rdr2["COMENTS"].ToString(), rdr2["FORECAST"].ToString(), (UP_qtyplan1+ UP_qtyplan2).ToString(), (PE_qtyact1+ PE_qtyact2).ToString(), k.ToString(), UP_hrsplan.ToString(), PE_hrsact.ToString() };
                                object[] rows = new object[] { row1 };
                                foreach (string[] rowArray in rows)
                                {
                                    Reports_Grd.Rows.Add(rowArray);
                                }
                            }
                            else if (rdr2["SHIFT"].ToString() == "SHIFT 1")
                            {
                                
                                string qry = "select COUNT(distinct(TPE.SHIFT)) as cnt from Tbl_Work_Plan AS TWP JOIN Tbl_Production_Entry AS TPE  ON TWP.WPNO=TPE.WPNO where TWP.PART_NAME='" + rdr2["PART_NAME"].ToString() + "' and TPE.PROCESS_NO='" + rdr2["PROCESS_NO"].ToString() + "' and TPE.PARTNO_MODEL='" + rdr2["PARTNO_MODEL"].ToString() + "' and TPE.CUST='" + rdr2["CUST"].ToString() + "' and TPE.MCS='" + rdr2["MCS"].ToString() + "' and TPE.DATE between '" + dt + "' and '" + dt10 + "' and TPE.LINE='" + line + "'";
                                SqlDataReader rdr = Utilities.executeQuery(qry);
                                if(rdr.Read())
                                {
                                    count = Convert.ToInt32(rdr["cnt"].ToString());
                                }
                                rdr.Close();
                                if (count == 1)
                                {
                                    string[] row1 = new string[] { (Reports_Grd.Rows.Count + 1).ToString(), rdr2["MCS"].ToString(), rdr2["CUST"].ToString(), rdr2["PARTNO_MODEL"].ToString(), rdr2["PROCESS_NO"].ToString(), rdr2["PART_NAME"].ToString(), UP_uphplan.ToString(), PE_uphact.ToString(), (Math.Round(uph_RT, 1)).ToString() + "%", UP_hrsplan.ToString(), PE_hrsact.ToString(), (Math.Round(hrs_RT, 1)).ToString() + "%", UP_qtyplan1.ToString(), PE_qtyact1.ToString(), (Math.Round(qty_RT, 1)).ToString() + "%", rdr2["LOSS_HRS"].ToString(), (Math.Round(loss_hrs3 * 100, 1)).ToString() + "%", (Math.Round(PL, 1)).ToString() + "%", rdr2["COMENTS"].ToString(), "", "", "", "", "", "", "", "", "", "", "", "", "", rdr2["FORECAST"].ToString(), UP_qtyplan1.ToString(), PE_qtyact1.ToString(), k.ToString(), UP_hrsplan.ToString(), PE_hrsact.ToString() };
                                    object[] rows = new object[] { row1 };
                                    foreach (string[] rowArray in rows)
                                    {
                                        Reports_Grd.Rows.Add(rowArray);
                                    }
                                }
                            }
                            else if (rdr2["SHIFT"].ToString() == "SHIFT 2")
                            {
                                string qry = "select COUNT(distinct(TPE.SHIFT)) as cnt from Tbl_Work_Plan AS TWP JOIN Tbl_Production_Entry AS TPE  ON TWP.WPNO=TPE.WPNO where TWP.PART_NAME='" + rdr2["PART_NAME"].ToString() + "' and TPE.PROCESS_NO='" + rdr2["PROCESS_NO"].ToString() + "' and TPE.PARTNO_MODEL='" + rdr2["PARTNO_MODEL"].ToString() + "' and TPE.CUST='" + rdr2["CUST"].ToString() + "' and TPE.MCS='" + rdr2["MCS"].ToString() + "' and TPE.DATE between '" + dt + "' and '" + dt10 + "' and TPE.LINE='" + line + "'";
                                SqlDataReader rdr = Utilities.executeQuery(qry);
                                if (rdr.Read())
                                {
                                    count = Convert.ToInt32(rdr["cnt"].ToString());
                                }
                                rdr.Close();
                                if (count == 1)
                                {
                                    string[] row1 = new string[] { (Reports_Grd.Rows.Count + 1).ToString(), rdr2["MCS"].ToString(), rdr2["CUST"].ToString(), rdr2["PARTNO_MODEL"].ToString(), rdr2["PROCESS_NO"].ToString(), rdr2["PART_NAME"].ToString(), "", "", "", "", "", "", "", "", "", "", "", "", "", UP_uphplan.ToString(), PE_uphact.ToString(), (Math.Round(uph_RT, 1)).ToString() + "%", UP_hrsplan.ToString(), PE_hrsact2.ToString(), (Math.Round(hrs_RT, 1)).ToString() + "%", UP_qtyplan2.ToString(), PE_qtyact2.ToString(), (Math.Round(qty_RT, 1)).ToString() + "%", rdr2["LOSS_HRS"].ToString(), (Math.Round(loss_hrs3 * 100, 1)).ToString() + "%", (Math.Round(PL, 1)).ToString() + "%", rdr2["COMENTS"].ToString(), rdr2["FORECAST"].ToString(), UP_qtyplan2.ToString(), PE_qtyact2.ToString(), k.ToString(), UP_hrsplan.ToString(), PE_hrsact2.ToString() };
                                    object[] rows = new object[] { row1 };
                                    foreach (string[] rowArray in rows)
                                    {
                                        Reports_Grd.Rows.Add(rowArray);
                                    }
                                }
                            }
                            Utilities.OLD_MCS = rdr2["MCS"].ToString();
                        }
                        rdr2.Close();
                        //string con_str = ConfigurationSettings.AppSettings["strcon"].ToString();
                        //SqlDataAdapter sda = new SqlDataAdapter(_squery2, con_str);
                        //DataTable dat = new DataTable();
                        //sda.Fill(dat);
                        //if (dat.Rows.Count > 0)
                        //{
                        //    foreach (DataRow dtRow in dat.Rows)
                        //    {

                        //        if (rdr2["SHIFT"].ToString() == "SHIFT 1")
                        //        {
                        //            if (PE_hrsact_S1 != 0)
                        //            {
                        //                v = PE_qtyact_S1 / PE_hrsact_S1;
                        //            }
                        //            else
                        //            {
                        //                v = 0;
                        //            }
                        //            string[] row1 = new string[] { ce.ToString(), rdr2["MCS"].ToString(), rdr_all["CUST"].ToString(), rdr_all["PARTNO_MODEL"].ToString(), rdr_all["PROCESS_NO"].ToString(), rdr_all["PART_NAME"].ToString(), UP_uphplan_S1.ToString(), PE_uphact_S1.ToString(), (Math.Round(uph_RT_S1)).ToString() + "%", UP_hrsplan_S1.ToString(), PE_hrsact_S1.ToString(), (Math.Round(hrs_RT_S1, 1)).ToString() + "%", UP_qtyplan_S1.ToString(), PE_qtyact_S1.ToString(), (Math.Round(qty_RT_S1, 1)).ToString() + "%", rdr2["LOSS_HRS"].ToString(), (Math.Round(loss_hrs3_S1 * 100, 1)).ToString() + "%", (Math.Round(PL_S1, 1)).ToString() + "%", rdr2["COMENTS"].ToString(), "", "", "", "", "", "", "", "", "", "", "", "", "", rdr2["FORECAST"].ToString(), UP_qtyplan_S1.ToString(), PE_qtyact_S1.ToString(), v.ToString(), UP_hrsplan_S1.ToString(), PE_hrsact_S1.ToString() };
                        //            object[] rows = new object[] { row1 };
                        //            foreach (string[] rowArray in rows)
                        //            {
                        //                Reports_Grd.Rows.Add(rowArray);
                        //            }
                        //        }
                        //        else if (rdr2["SHIFT"].ToString() == "SHIFT 2")
                        //        {
                        //            if (PE_hrsact_S2 != 0)
                        //            {
                        //                v = (PE_qtyact_S2 / PE_hrsact_S2);
                        //            }
                        //            else
                        //            {
                        //                v = 0;
                        //            }
                        //            string[] row1 = new string[] { c.ToString(), rdr_all["MCS"].ToString(), rdr_all["CUST"].ToString(), rdr_all["PARTNO_MODEL"].ToString(), rdr_all["PROCESS_NO"].ToString(), rdr_all["PART_NAME"].ToString(), "", "", "", "", "", "", "", "", "", "", "", "", "", UP_uphplan_S2.ToString(), PE_uphact_S2.ToString(), (Math.Round(uph_RT_S2, 1)).ToString() + "%", UP_hrsplan_S2.ToString(), PE_hrsact_S2.ToString(), (Math.Round(hrs_RT_S2, 1)).ToString() + "%", UP_qtyplan_S2.ToString(), PE_qtyact_S2.ToString(), (Math.Round(qty_RT_S2, 1)).ToString() + "%", rdr2["LOSS_HRS"].ToString(), (Math.Round(loss_hrs3_S2 * 100, 1)).ToString() + "%", (Math.Round(PL_S2)).ToString() + "%", rdr2["COMENTS"].ToString(), rdr2["FORECAST"].ToString(), UP_qtyplan_S2.ToString(), PE_qtyact_S2.ToString(), v.ToString(), UP_hrsplan_S2.ToString(), PE_hrsact_S2.ToString() };
                        //            object[] rows = new object[] { row1 };
                        //            foreach (string[] rowArray in rows)
                        //            {
                        //                Reports_Grd.Rows.Add(rowArray);
                        //            }
                        //        }
                        //        else
                        //        {
                        //            //if (PE_hrsact_S2 != 0)
                        //            //{
                        //            //    v = (PE_qtyact_S2 / PE_hrsact_S2);
                        //            //}
                        //            //else
                        //            //{
                        //            //    v = 0;
                        //            //}
                        //            //v = (PE_qtyact_S2 / PE_hrsact_S2);
                        //            string[] row1 = new string[] { c.ToString(), rdr2["MCS"].ToString(), rdr2["CUST"].ToString(), rdr2["PARTNO_MODEL"].ToString(), rdr2["PROCESS_NO"].ToString(), rdr2["PART_NAME"].ToString(), UP_uphplan_S1.ToString(), PE_uphact_S1.ToString(), (Math.Round(uph_RT_S1, 1)).ToString() + "%", UP_hrsplan_S1.ToString(), PE_hrsact_S1.ToString(), (Math.Round(hrs_RT_S1, 1)).ToString() + "%", UP_qtyplan_S1.ToString(), PE_qtyact_S1.ToString(), (Math.Round(qty_RT_S1, 1)).ToString() + "%", rdr2["LOSS_HRS"].ToString(), (Math.Round(loss_hrs3_S1 * 100, 1)).ToString() + "%", (Math.Round(PL_S1, 1)).ToString() + "%", rdr2["COMENTS"].ToString(), UP_uphplan_S2.ToString(), PE_uphact_S2.ToString(), (Math.Round(uph_RT_S2, 1)).ToString() + "%", UP_hrsplan_S2.ToString(), PE_hrsact_S2.ToString(), (Math.Round(hrs_RT_S2, 1)).ToString() + "%", UP_qtyplan_S2.ToString(), PE_qtyact_S2.ToString(), (Math.Round(qty_RT_S2, 1)).ToString() + "%", rdr2["LOSS_HRS"].ToString(), (Math.Round(loss_hrs3_S2 * 100, 1)).ToString() + "%", (Math.Round(PL_S2, 1)).ToString() + "%", rdr2["COMENTS"].ToString(), rdr2["FORECAST"].ToString(), UP_qtyplan_S2.ToString(), PE_qtyact_S2.ToString(), v.ToString(), UP_hrsplan_S2.ToString(), PE_hrsact_S2.ToString() };
                        //            object[] rows = new object[] { row1 };
                        //            foreach (string[] rowArray in rows)
                        //            {
                        //                Reports_Grd.Rows.Add(rowArray);
                        //            }
                        //        }
                        //    }
                        //    rdr_all.Close();
                        //}

                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        public void clear()
        {
            Line_cmb.Text = "Select Line";
            shift_cmb.Text = "Select Shift";
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
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;

                MessageBox.Show("Exception Occured while releasing object " + ex.ToString(), "QRS Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            finally
            {
                GC.Collect();
            }
        }
        private void Exp_btn_Click(object sender, EventArgs e)
        {
            try
            {
                //Excel.Application xlApp;
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;

                Excel.Application application = new Excel.Application();
                //xlApp = new Excel.Application();
                xlWorkBook = application.Workbooks.Add(misValue);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);


                for (int i = 1; i < Reports_Grd.Columns.Count + 1; i++)
                {
                    xlWorkSheet.Cells[1, i] = Reports_Grd.Columns[i - 1].HeaderText;
                    xlWorkSheet.Cells[1, i].Font.Bold = true;
                    xlWorkSheet.Cells[1, i].Style.HorizontalAlignment = HorizontalAlignment.Center;

                }

                for (int i = 0; i <= Reports_Grd.Rows.Count - 1; i++)
                {
                    for (int j = 0; j <= Reports_Grd.Columns.Count - 1; j++)
                    {
                        xlWorkSheet.Cells[i + 2, j + 1] = Reports_Grd.Rows[i].Cells[j].Value.ToString();
                    }
                }


                string saveDirectory = @"D:\P3CReports\";

                if (!Directory.Exists(saveDirectory))
                {
                    Directory.CreateDirectory(saveDirectory);
                }


                string savePath = saveDirectory + "P3CReport_" + DateTime.Now.ToString("dd-MM-yyyy HH-mm-ss") + ".xls";
                xlWorkBook.SaveAs(savePath, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);

                xlWorkBook.Close(true, misValue, misValue);
                application.Quit();

                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(application);


                MessageBox.Show("Excel file created , you can find the file " + savePath, "YSI Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reports_Grd.Rows.Clear();
            }
            catch (Exception ex)
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            WorkPlan wp=new WorkPlan();
            ProductionEntry pde=new ProductionEntry();
            Reports rp=new Reports();
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
    }
}
