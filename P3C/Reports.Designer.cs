namespace P3C
{
    partial class Reports
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Reports));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Reports_Grd = new System.Windows.Forms.DataGridView();
            this.search_btn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.shift_cmb = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Line_cmb = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ProdEnt_dt = new System.Windows.Forms.DateTimePicker();
            this.Exp_btn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.ProdEnt_To_dt = new System.Windows.Forms.DateTimePicker();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Reports_Grd)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.SkyBlue;
            this.textBox1.Font = new System.Drawing.Font("Verdana", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(0, 1);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(1369, 50);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "REPORTS";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Reports_Grd
            // 
            this.Reports_Grd.AllowUserToAddRows = false;
            this.Reports_Grd.AllowUserToDeleteRows = false;
            this.Reports_Grd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Reports_Grd.Location = new System.Drawing.Point(5, 177);
            this.Reports_Grd.Name = "Reports_Grd";
            this.Reports_Grd.ReadOnly = true;
            this.Reports_Grd.Size = new System.Drawing.Size(1364, 517);
            this.Reports_Grd.TabIndex = 3;
            // 
            // search_btn
            // 
            this.search_btn.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search_btn.Location = new System.Drawing.Point(1067, 137);
            this.search_btn.Name = "search_btn";
            this.search_btn.Size = new System.Drawing.Size(124, 34);
            this.search_btn.TabIndex = 15;
            this.search_btn.Text = "SEARCH";
            this.search_btn.UseVisualStyleBackColor = true;
            this.search_btn.Click += new System.EventHandler(this.search_btn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1094, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 25);
            this.label3.TabIndex = 17;
            this.label3.Text = "SHIFT";
            // 
            // shift_cmb
            // 
            this.shift_cmb.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shift_cmb.FormattingEnabled = true;
            this.shift_cmb.Items.AddRange(new object[] {
            "SHIFT 1",
            "SHIFT 2",
            "SHIFT 3",
            "ALL"});
            this.shift_cmb.Location = new System.Drawing.Point(1181, 75);
            this.shift_cmb.Name = "shift_cmb";
            this.shift_cmb.Size = new System.Drawing.Size(162, 33);
            this.shift_cmb.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 25);
            this.label2.TabIndex = 16;
            this.label2.Text = "FROM DATE";
            // 
            // Line_cmb
            // 
            this.Line_cmb.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Line_cmb.FormattingEnabled = true;
            this.Line_cmb.Location = new System.Drawing.Point(929, 75);
            this.Line_cmb.Name = "Line_cmb";
            this.Line_cmb.Size = new System.Drawing.Size(161, 33);
            this.Line_cmb.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(858, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 25);
            this.label1.TabIndex = 14;
            this.label1.Text = "LINE";
            // 
            // ProdEnt_dt
            // 
            this.ProdEnt_dt.CalendarFont = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProdEnt_dt.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProdEnt_dt.Location = new System.Drawing.Point(166, 78);
            this.ProdEnt_dt.Name = "ProdEnt_dt";
            this.ProdEnt_dt.Size = new System.Drawing.Size(272, 33);
            this.ProdEnt_dt.TabIndex = 0;
            // 
            // Exp_btn
            // 
            this.Exp_btn.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Exp_btn.Location = new System.Drawing.Point(1219, 137);
            this.Exp_btn.Name = "Exp_btn";
            this.Exp_btn.Size = new System.Drawing.Size(124, 34);
            this.Exp_btn.TabIndex = 19;
            this.Exp_btn.Text = "EXPORT";
            this.Exp_btn.UseVisualStyleBackColor = true;
            this.Exp_btn.Click += new System.EventHandler(this.Exp_btn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(455, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 25);
            this.label4.TabIndex = 21;
            this.label4.Text = "TO DATE";
            // 
            // ProdEnt_To_dt
            // 
            this.ProdEnt_To_dt.CalendarFont = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProdEnt_To_dt.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProdEnt_To_dt.Location = new System.Drawing.Point(574, 75);
            this.ProdEnt_To_dt.Name = "ProdEnt_To_dt";
            this.ProdEnt_To_dt.Size = new System.Drawing.Size(272, 33);
            this.ProdEnt_To_dt.TabIndex = 1;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.SkyBlue;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.Color.SkyBlue;
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.Location = new System.Drawing.Point(1277, 5);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(33, 37);
            this.button3.TabIndex = 53;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.SkyBlue;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.SkyBlue;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(1326, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(39, 37);
            this.button2.TabIndex = 52;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Reports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1364, 749);
            this.ControlBox = false;
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ProdEnt_To_dt);
            this.Controls.Add(this.Exp_btn);
            this.Controls.Add(this.search_btn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.shift_cmb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Line_cmb);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ProdEnt_dt);
            this.Controls.Add(this.Reports_Grd);
            this.Controls.Add(this.textBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Reports";
            this.Load += new System.EventHandler(this.Reports_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Reports_Grd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView Reports_Grd;
        private System.Windows.Forms.Button search_btn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox shift_cmb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox Line_cmb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker ProdEnt_dt;
        private System.Windows.Forms.Button Exp_btn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker ProdEnt_To_dt;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
    }
}