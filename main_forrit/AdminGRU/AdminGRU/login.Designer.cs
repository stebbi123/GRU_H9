namespace AdminGRU
{
    partial class login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(login));
            this.txtbx_login_username = new System.Windows.Forms.TextBox();
            this.txtbx_login_password = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_login = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageLogin = new System.Windows.Forms.TabPage();
            this.tabPageRecovery = new System.Windows.Forms.TabPage();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtbx_recovery_username = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtbx_recovery_email = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_login_recovery = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPageLogin.SuspendLayout();
            this.tabPageRecovery.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtbx_login_username
            // 
            this.txtbx_login_username.Location = new System.Drawing.Point(86, 240);
            this.txtbx_login_username.Name = "txtbx_login_username";
            this.txtbx_login_username.Size = new System.Drawing.Size(148, 20);
            this.txtbx_login_username.TabIndex = 0;
            // 
            // txtbx_login_password
            // 
            this.txtbx_login_password.Location = new System.Drawing.Point(86, 285);
            this.txtbx_login_password.Name = "txtbx_login_password";
            this.txtbx_login_password.PasswordChar = '*';
            this.txtbx_login_password.Size = new System.Drawing.Size(148, 20);
            this.txtbx_login_password.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(83, 224);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(83, 269);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password";
            // 
            // btn_login
            // 
            this.btn_login.BackColor = System.Drawing.Color.ForestGreen;
            this.btn_login.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_login.FlatAppearance.BorderSize = 2;
            this.btn_login.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_login.ForeColor = System.Drawing.Color.White;
            this.btn_login.Location = new System.Drawing.Point(86, 321);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(148, 26);
            this.btn_login.TabIndex = 7;
            this.btn_login.Text = "Login";
            this.btn_login.UseVisualStyleBackColor = false;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(99, 361);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(120, 13);
            this.linkLabel1.TabIndex = 8;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Forgot your credentials?";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageLogin);
            this.tabControl1.Controls.Add(this.tabPageRecovery);
            this.tabControl1.Location = new System.Drawing.Point(-7, -23);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(329, 419);
            this.tabControl1.TabIndex = 9;
            // 
            // tabPageLogin
            // 
            this.tabPageLogin.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.tabPageLogin.Controls.Add(this.pictureBoxLogo);
            this.tabPageLogin.Controls.Add(this.txtbx_login_username);
            this.tabPageLogin.Controls.Add(this.linkLabel1);
            this.tabPageLogin.Controls.Add(this.txtbx_login_password);
            this.tabPageLogin.Controls.Add(this.btn_login);
            this.tabPageLogin.Controls.Add(this.label1);
            this.tabPageLogin.Controls.Add(this.label2);
            this.tabPageLogin.Location = new System.Drawing.Point(4, 22);
            this.tabPageLogin.Name = "tabPageLogin";
            this.tabPageLogin.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLogin.Size = new System.Drawing.Size(321, 393);
            this.tabPageLogin.TabIndex = 0;
            this.tabPageLogin.Text = "tabLogin";
            // 
            // tabPageRecovery
            // 
            this.tabPageRecovery.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.tabPageRecovery.Controls.Add(this.btn_login_recovery);
            this.tabPageRecovery.Controls.Add(this.txtbx_recovery_email);
            this.tabPageRecovery.Controls.Add(this.label5);
            this.tabPageRecovery.Controls.Add(this.pictureBox1);
            this.tabPageRecovery.Controls.Add(this.label4);
            this.tabPageRecovery.Controls.Add(this.txtbx_recovery_username);
            this.tabPageRecovery.Controls.Add(this.label3);
            this.tabPageRecovery.Location = new System.Drawing.Point(4, 22);
            this.tabPageRecovery.Name = "tabPageRecovery";
            this.tabPageRecovery.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRecovery.Size = new System.Drawing.Size(321, 393);
            this.tabPageRecovery.TabIndex = 1;
            this.tabPageRecovery.Text = "tabRecovery";
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLogo.Image")));
            this.pictureBoxLogo.Location = new System.Drawing.Point(15, 6);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(295, 215);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxLogo.TabIndex = 9;
            this.pictureBoxLogo.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 276);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Username";
            // 
            // txtbx_recovery_username
            // 
            this.txtbx_recovery_username.Location = new System.Drawing.Point(132, 273);
            this.txtbx_recovery_username.Name = "txtbx_recovery_username";
            this.txtbx_recovery_username.Size = new System.Drawing.Size(135, 20);
            this.txtbx_recovery_username.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Exostencil", 22.25F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(30, 224);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(266, 36);
            this.label4.TabIndex = 2;
            this.label4.Text = "Account recovery";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(15, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(295, 215);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // txtbx_recovery_email
            // 
            this.txtbx_recovery_email.Location = new System.Drawing.Point(132, 305);
            this.txtbx_recovery_email.Name = "txtbx_recovery_email";
            this.txtbx_recovery_email.Size = new System.Drawing.Size(135, 20);
            this.txtbx_recovery_email.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(57, 308);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Email";
            // 
            // btn_login_recovery
            // 
            this.btn_login_recovery.BackColor = System.Drawing.Color.ForestGreen;
            this.btn_login_recovery.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_login_recovery.FlatAppearance.BorderSize = 2;
            this.btn_login_recovery.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_login_recovery.ForeColor = System.Drawing.Color.White;
            this.btn_login_recovery.Location = new System.Drawing.Point(87, 353);
            this.btn_login_recovery.Name = "btn_login_recovery";
            this.btn_login_recovery.Size = new System.Drawing.Size(148, 26);
            this.btn_login_recovery.TabIndex = 13;
            this.btn_login_recovery.Text = "Recover";
            this.btn_login_recovery.UseVisualStyleBackColor = false;
            this.btn_login_recovery.Click += new System.EventHandler(this.btn_login_recovery_Click);
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 390);
            this.Controls.Add(this.tabControl1);
            this.Name = "login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CSGO Jungle";
            this.tabControl1.ResumeLayout(false);
            this.tabPageLogin.ResumeLayout(false);
            this.tabPageLogin.PerformLayout();
            this.tabPageRecovery.ResumeLayout(false);
            this.tabPageRecovery.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtbx_login_username;
        private System.Windows.Forms.TextBox txtbx_login_password;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageLogin;
        private System.Windows.Forms.TabPage tabPageRecovery;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtbx_recovery_username;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_login_recovery;
        private System.Windows.Forms.TextBox txtbx_recovery_email;
        private System.Windows.Forms.Label label5;
    }
}

