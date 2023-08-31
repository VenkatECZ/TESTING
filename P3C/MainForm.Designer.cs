namespace P3C
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pc3menu = new System.Windows.Forms.MenuStrip();
            this.workPlanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productionEntryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.pc3menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pc3menu
            // 
            this.pc3menu.BackColor = System.Drawing.Color.SkyBlue;
            this.pc3menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.workPlanToolStripMenuItem,
            this.productionEntryToolStripMenuItem,
            this.reportsToolStripMenuItem});
            this.pc3menu.Location = new System.Drawing.Point(0, 0);
            this.pc3menu.Name = "pc3menu";
            this.pc3menu.Size = new System.Drawing.Size(1370, 46);
            this.pc3menu.TabIndex = 0;
            this.pc3menu.Text = "menuStrip1";
            // 
            // workPlanToolStripMenuItem
            // 
            this.workPlanToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.workPlanToolStripMenuItem.Name = "workPlanToolStripMenuItem";
            this.workPlanToolStripMenuItem.Size = new System.Drawing.Size(202, 42);
            this.workPlanToolStripMenuItem.Text = "WorkPlan";
            this.workPlanToolStripMenuItem.Click += new System.EventHandler(this.workPlanToolStripMenuItem_Click);
            // 
            // productionEntryToolStripMenuItem
            // 
            this.productionEntryToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productionEntryToolStripMenuItem.Name = "productionEntryToolStripMenuItem";
            this.productionEntryToolStripMenuItem.Size = new System.Drawing.Size(333, 42);
            this.productionEntryToolStripMenuItem.Text = "Production Entry";
            this.productionEntryToolStripMenuItem.Click += new System.EventHandler(this.productionEntryToolStripMenuItem_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(169, 42);
            this.reportsToolStripMenuItem.Text = "Reports";
            this.reportsToolStripMenuItem.Click += new System.EventHandler(this.reportsToolStripMenuItem_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.SkyBlue;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.Color.SkyBlue;
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.Location = new System.Drawing.Point(1282, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(33, 37);
            this.button3.TabIndex = 51;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.SkyBlue;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.SkyBlue;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(1331, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(39, 37);
            this.button2.TabIndex = 50;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.ControlBox = false;
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.pc3menu);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Transparent;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.pc3menu;
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.pc3menu.ResumeLayout(false);
            this.pc3menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip pc3menu;
        private System.Windows.Forms.ToolStripMenuItem workPlanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productionEntryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
    }
}