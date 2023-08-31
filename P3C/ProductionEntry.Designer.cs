namespace P3C
{
    partial class ProductionEntry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductionEntry));
            this.ProdEnt_dt = new System.Windows.Forms.DateTimePicker();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Line_cmb = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.shift_cmb = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.wp_txt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ProductionEntry_grd = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.save_btn = new System.Windows.Forms.Button();
            this.search_btn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ProductionEntry_grd)).BeginInit();
            this.SuspendLayout();
            // 
            // ProdEnt_dt
            // 
            this.ProdEnt_dt.CalendarFont = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProdEnt_dt.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProdEnt_dt.Location = new System.Drawing.Point(86, 156);
            this.ProdEnt_dt.Name = "ProdEnt_dt";
            this.ProdEnt_dt.Size = new System.Drawing.Size(272, 33);
            this.ProdEnt_dt.TabIndex = 0;
            this.ProdEnt_dt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ProdEnt_dt_KeyPress);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.SkyBlue;
            this.textBox1.Font = new System.Drawing.Font("Verdana", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(24, 55);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(1320, 50);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "PRODUCTION ENTRY";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Line_cmb
            // 
            this.Line_cmb.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Line_cmb.FormattingEnabled = true;
            this.Line_cmb.Location = new System.Drawing.Point(431, 157);
            this.Line_cmb.Name = "Line_cmb";
            this.Line_cmb.Size = new System.Drawing.Size(161, 33);
            this.Line_cmb.TabIndex = 1;
            this.Line_cmb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Line_cmb_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(360, 161);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "LINE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "DATE";
            // 
            // shift_cmb
            // 
            this.shift_cmb.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shift_cmb.FormattingEnabled = true;
            this.shift_cmb.Items.AddRange(new object[] {
            "SHIFT 1",
            "SHIFT 2",
            "SHIFT 3"});
            this.shift_cmb.Location = new System.Drawing.Point(683, 157);
            this.shift_cmb.Name = "shift_cmb";
            this.shift_cmb.Size = new System.Drawing.Size(162, 33);
            this.shift_cmb.TabIndex = 2;
            this.shift_cmb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.shift_cmb_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(596, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 25);
            this.label3.TabIndex = 7;
            this.label3.Text = "SHIFT";
            // 
            // wp_txt
            // 
            this.wp_txt.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wp_txt.Location = new System.Drawing.Point(942, 156);
            this.wp_txt.Name = "wp_txt";
            this.wp_txt.Size = new System.Drawing.Size(261, 33);
            this.wp_txt.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(847, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 25);
            this.label4.TabIndex = 9;
            this.label4.Text = "WP NO";
            // 
            // ProductionEntry_grd
            // 
            this.ProductionEntry_grd.AllowUserToAddRows = false;
            this.ProductionEntry_grd.AllowUserToDeleteRows = false;
            this.ProductionEntry_grd.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.ProductionEntry_grd.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.ProductionEntry_grd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProductionEntry_grd.Location = new System.Drawing.Point(12, 236);
            this.ProductionEntry_grd.Name = "ProductionEntry_grd";
            this.ProductionEntry_grd.Size = new System.Drawing.Size(1332, 430);
            this.ProductionEntry_grd.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(813, 669);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(550, 38);
            this.label5.TabIndex = 41;
            this.label5.Text = "Powered by Ecosoft Zolutions";
            // 
            // save_btn
            // 
            this.save_btn.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.save_btn.Location = new System.Drawing.Point(1221, 196);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(123, 34);
            this.save_btn.TabIndex = 5;
            this.save_btn.Text = "SAVE";
            this.save_btn.UseVisualStyleBackColor = true;
            this.save_btn.Click += new System.EventHandler(this.save_btn_Click_1);
            // 
            // search_btn
            // 
            this.search_btn.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search_btn.Location = new System.Drawing.Point(1220, 154);
            this.search_btn.Name = "search_btn";
            this.search_btn.Size = new System.Drawing.Size(124, 34);
            this.search_btn.TabIndex = 4;
            this.search_btn.Text = "SEARCH";
            this.search_btn.UseVisualStyleBackColor = true;
            this.search_btn.Click += new System.EventHandler(this.search_btn_Click_1);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.SystemColors.Control;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(1305, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(39, 37);
            this.button2.TabIndex = 46;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.SystemColors.Control;
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.Location = new System.Drawing.Point(1256, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(33, 37);
            this.button3.TabIndex = 47;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // ProductionEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 709);
            this.ControlBox = false;
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.save_btn);
            this.Controls.Add(this.search_btn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ProductionEntry_grd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.wp_txt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.shift_cmb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Line_cmb);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.ProdEnt_dt);
            this.Name = "ProductionEntry";
            this.Load += new System.EventHandler(this.ProductionEntry_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ProductionEntry_grd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker ProdEnt_dt;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox Line_cmb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox shift_cmb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox wp_txt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView ProductionEntry_grd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button save_btn;
        private System.Windows.Forms.Button search_btn;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}