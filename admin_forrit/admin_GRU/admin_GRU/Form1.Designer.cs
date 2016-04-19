namespace admin_GRU
{
    partial class Form1
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageLeikir = new System.Windows.Forms.TabPage();
            this.tabPageNotendur = new System.Windows.Forms.TabPage();
            this.dataGridLeikir = new System.Windows.Forms.DataGridView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.tabPageBets = new System.Windows.Forms.TabPage();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.ColumnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnRidill = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnWinner = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPageLeikir.SuspendLayout();
            this.tabPageNotendur.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLeikir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPageBets.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageLeikir);
            this.tabControl1.Controls.Add(this.tabPageNotendur);
            this.tabControl1.Controls.Add(this.tabPageBets);
            this.tabControl1.Location = new System.Drawing.Point(3, -1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1054, 650);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageLeikir
            // 
            this.tabPageLeikir.Controls.Add(this.dataGridLeikir);
            this.tabPageLeikir.Location = new System.Drawing.Point(4, 22);
            this.tabPageLeikir.Name = "tabPageLeikir";
            this.tabPageLeikir.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLeikir.Size = new System.Drawing.Size(1046, 624);
            this.tabPageLeikir.TabIndex = 0;
            this.tabPageLeikir.Text = "Leikir";
            this.tabPageLeikir.UseVisualStyleBackColor = true;
            // 
            // tabPageNotendur
            // 
            this.tabPageNotendur.Controls.Add(this.webBrowser1);
            this.tabPageNotendur.Controls.Add(this.dataGridView1);
            this.tabPageNotendur.Location = new System.Drawing.Point(4, 22);
            this.tabPageNotendur.Name = "tabPageNotendur";
            this.tabPageNotendur.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageNotendur.Size = new System.Drawing.Size(1046, 624);
            this.tabPageNotendur.TabIndex = 1;
            this.tabPageNotendur.Text = "Notendur";
            this.tabPageNotendur.UseVisualStyleBackColor = true;
            // 
            // dataGridLeikir
            // 
            this.dataGridLeikir.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridLeikir.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnID,
            this.ColumnLid,
            this.ColumnDate,
            this.ColumnBO,
            this.ColumnRidill,
            this.ColumnWinner});
            this.dataGridLeikir.Location = new System.Drawing.Point(223, 136);
            this.dataGridLeikir.Name = "dataGridLeikir";
            this.dataGridLeikir.Size = new System.Drawing.Size(657, 363);
            this.dataGridLeikir.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(296, 131);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(455, 363);
            this.dataGridView1.TabIndex = 1;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(48, 282);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(20, 20);
            this.webBrowser1.TabIndex = 2;
            // 
            // tabPageBets
            // 
            this.tabPageBets.Controls.Add(this.dataGridView2);
            this.tabPageBets.Location = new System.Drawing.Point(4, 22);
            this.tabPageBets.Name = "tabPageBets";
            this.tabPageBets.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageBets.Size = new System.Drawing.Size(1046, 624);
            this.tabPageBets.TabIndex = 2;
            this.tabPageBets.Text = "Bets";
            this.tabPageBets.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(296, 131);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(455, 363);
            this.dataGridView2.TabIndex = 2;
            // 
            // ColumnID
            // 
            this.ColumnID.HeaderText = "ID";
            this.ColumnID.Name = "ColumnID";
            this.ColumnID.ReadOnly = true;
            // 
            // ColumnLid
            // 
            this.ColumnLid.HeaderText = "Lid";
            this.ColumnLid.Name = "ColumnLid";
            this.ColumnLid.ReadOnly = true;
            // 
            // ColumnDate
            // 
            this.ColumnDate.HeaderText = "Date";
            this.ColumnDate.Name = "ColumnDate";
            this.ColumnDate.ReadOnly = true;
            // 
            // ColumnBO
            // 
            this.ColumnBO.HeaderText = "BO";
            this.ColumnBO.Name = "ColumnBO";
            this.ColumnBO.ReadOnly = true;
            // 
            // ColumnRidill
            // 
            this.ColumnRidill.HeaderText = "Ridill";
            this.ColumnRidill.Name = "ColumnRidill";
            this.ColumnRidill.ReadOnly = true;
            // 
            // ColumnWinner
            // 
            this.ColumnWinner.HeaderText = "Winner";
            this.ColumnWinner.Name = "ColumnWinner";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1058, 648);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPageLeikir.ResumeLayout(false);
            this.tabPageNotendur.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLeikir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPageBets.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageLeikir;
        private System.Windows.Forms.DataGridView dataGridLeikir;
        private System.Windows.Forms.TabPage tabPageNotendur;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabPage tabPageBets;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLid;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnBO;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnRidill;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnWinner;

    }
}

