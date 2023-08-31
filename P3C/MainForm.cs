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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
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
        }
        public void Log_in(string name)
        {
            SqlDataReader rdr1 = null;
            string _squery1 = "";
            _squery1 = "select PRIVILEGE from USER_MASTER where USER_NAME='"+ name + "'";
            rdr1 = Utilities.executeQuery(_squery1);
            if(rdr1.Read())
            {
                if(rdr1["PRIVILEGE"].ToString()=="1,0,0")
                {
                    workPlanToolStripMenuItem.Enabled = true;
                    productionEntryToolStripMenuItem.Enabled = false;
                    reportsToolStripMenuItem.Enabled = false;
                }
                else if (rdr1["PRIVILEGE"].ToString() == "0,1,0")
                {
                    workPlanToolStripMenuItem.Enabled = false;
                    productionEntryToolStripMenuItem.Enabled = true;
                    reportsToolStripMenuItem.Enabled = false;
                }
                else if (rdr1["PRIVILEGE"].ToString() == "1,1,0")
                {
                    workPlanToolStripMenuItem.Enabled = true;
                    productionEntryToolStripMenuItem.Enabled = true;
                    reportsToolStripMenuItem.Enabled = false;
                }
                else if (rdr1["PRIVILEGE"].ToString() == "1,0,1")
                {
                    workPlanToolStripMenuItem.Enabled = true;
                    productionEntryToolStripMenuItem.Enabled = false;
                    reportsToolStripMenuItem.Enabled = true;
                }
                else if (rdr1["PRIVILEGE"].ToString() == "1,1,1")
                {
                    workPlanToolStripMenuItem.Enabled = true;
                    productionEntryToolStripMenuItem.Enabled = true;
                    reportsToolStripMenuItem.Enabled = true;
                }
                else if (rdr1["PRIVILEGE"].ToString() == "0,1,1")
                {
                    workPlanToolStripMenuItem.Enabled = false;
                    productionEntryToolStripMenuItem.Enabled = true;
                    reportsToolStripMenuItem.Enabled = true;
                }
                else if (rdr1["PRIVILEGE"].ToString() == "0,0,1")
                {
                    workPlanToolStripMenuItem.Enabled = false;
                    productionEntryToolStripMenuItem.Enabled = false;
                    reportsToolStripMenuItem.Enabled = true;
                }
            }
            rdr1.Close();
        }

        private void workPlanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                if (Application.OpenForms[i].Name == "WorkPlan")
                {
                    Application.OpenForms[i].Close();
                }
            }
            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                if (Application.OpenForms[i].Name == "Reports")
                {
                    Application.OpenForms[i].Close();
                }
            }
            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                if (Application.OpenForms[i].Name == "ProductionEntry")
                {
                    Application.OpenForms[i].Close();
                }
            }

            WorkPlan objForm = new WorkPlan();
            objForm.ShowDialog();


            //bool found = false;

            //FormCollection fc = Application.OpenForms;
            //foreach (Form f in fc)
            //{
            //    // does the form text match our sender 
            //    if (f.Name == "WorkPlan")
            //    {
            //        f.BringToFront();
            //        found = true;
            //        break;
            //    }
            //}

            //// if we did not find a form matching the sender
            //if (!found)
            //{
            //    WorkPlan frm = new WorkPlan();
            //    frm.Show();
            //    //frm.MdiParent = this;
            //}
        }

        private void productionEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                if (Application.OpenForms[i].Name == "WorkPlan")
                {
                    Application.OpenForms[i].Close();
                }
            }
            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                if (Application.OpenForms[i].Name == "Reports")
                {
                    Application.OpenForms[i].Close();
                }
            }
            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                if (Application.OpenForms[i].Name == "ProductionEntry")
                {
                    Application.OpenForms[i].Close();
                }
            }

            ProductionEntry objForm = new ProductionEntry();
            objForm.ShowDialog();

            //bool found = false;

            //FormCollection fc = Application.OpenForms;
            //foreach (Form f in fc)
            //{
            //    // does the form text match our sender 
            //    if (f.Name == "Production Entry")
            //    {
            //        f.BringToFront();
            //        found = true;
            //        break;
            //    }
            //}

            //// if we did not find a form matching the sender
            //if (!found)
            //{
            //    ProductionEntry frm = new ProductionEntry();
            //    frm.Show();
            //    //frm.MdiParent = this;
            //}
        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                if (Application.OpenForms[i].Name == "WorkPlan")
                {
                    Application.OpenForms[i].Close();
                }
            }
            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                if (Application.OpenForms[i].Name == "Reports")
                {
                    Application.OpenForms[i].Close();
                }
            }
            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                if (Application.OpenForms[i].Name == "ProductionEntry")
                {
                    Application.OpenForms[i].Close();
                }
            }

            Reports objForm = new Reports();
            objForm.ShowDialog();
            //bool found = false;

            //FormCollection fc = Application.OpenForms;
            //foreach (Form f in fc)
            //{
            //    // does the form text match our sender 
            //    if (f.Name == "Reports")
            //    {
            //        f.BringToFront();
            //        found = true;
            //        break;
            //    }
            //}

            //// if we did not find a form matching the sender
            //if (!found)
            //{
            //    Reports frm = new Reports();
            //    frm.Show();
            //    //frm.MdiParent = this;
            //}
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
