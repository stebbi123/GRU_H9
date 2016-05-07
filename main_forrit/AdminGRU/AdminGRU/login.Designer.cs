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
            this.labelLoginUsername = new System.Windows.Forms.Label();
            this.labelLoginPassword = new System.Windows.Forms.Label();
            this.btn_login = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageLogin = new System.Windows.Forms.TabPage();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.tabPageRecovery = new System.Windows.Forms.TabPage();
            this.labelRecoveryFailure = new System.Windows.Forms.Label();
            this.linkLabelRecoveryFailed = new System.Windows.Forms.LinkLabel();
            this.linkLabelRecovery_back1 = new System.Windows.Forms.LinkLabel();
            this.linkLabelRecovery_Back = new System.Windows.Forms.LinkLabel();
            this.labelRecoverySuccess = new System.Windows.Forms.Label();
            this.btn_login_recovery = new System.Windows.Forms.Button();
            this.txtbx_recovery_email = new System.Windows.Forms.TextBox();
            this.labelRecovery2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtbx_recovery_username = new System.Windows.Forms.TextBox();
            this.labelRecovery1 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPageLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.tabPageRecovery.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtbx_login_username
            // 
            this.txtbx_login_username.BackColor = System.Drawing.Color.OldLace;
            this.txtbx_login_username.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtbx_login_username.Location = new System.Drawing.Point(86, 255);
            this.txtbx_login_username.Name = "txtbx_login_username";
            this.txtbx_login_username.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtbx_login_username.Size = new System.Drawing.Size(148, 20);
            this.txtbx_login_username.TabIndex = 0;
            this.txtbx_login_username.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbx_login_username_KeyPress);
            // 
            // txtbx_login_password
            // 
            this.txtbx_login_password.BackColor = System.Drawing.Color.OldLace;
            this.txtbx_login_password.Location = new System.Drawing.Point(86, 303);
            this.txtbx_login_password.Name = "txtbx_login_password";
            this.txtbx_login_password.PasswordChar = '*';
            this.txtbx_login_password.Size = new System.Drawing.Size(148, 20);
            this.txtbx_login_password.TabIndex = 1;
            this.txtbx_login_password.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbx_login_password_KeyPress);
            // 
            // labelLoginUsername
            // 
            this.labelLoginUsername.AutoSize = true;
            this.labelLoginUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.labelLoginUsername.Location = new System.Drawing.Point(83, 239);
            this.labelLoginUsername.Name = "labelLoginUsername";
            this.labelLoginUsername.Size = new System.Drawing.Size(73, 17);
            this.labelLoginUsername.TabIndex = 2;
            this.labelLoginUsername.Text = "Username";
            // 
            // labelLoginPassword
            // 
            this.labelLoginPassword.AutoSize = true;
            this.labelLoginPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.labelLoginPassword.Location = new System.Drawing.Point(83, 287);
            this.labelLoginPassword.Name = "labelLoginPassword";
            this.labelLoginPassword.Size = new System.Drawing.Size(69, 17);
            this.labelLoginPassword.TabIndex = 3;
            this.labelLoginPassword.Text = "Password";
            // 
            // btn_login
            // 
            this.btn_login.BackColor = System.Drawing.Color.ForestGreen;
            this.btn_login.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_login.FlatAppearance.BorderSize = 2;
            this.btn_login.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_login.Font = new System.Drawing.Font("Sitka Small", 10F);
            this.btn_login.ForeColor = System.Drawing.Color.White;
            this.btn_login.Location = new System.Drawing.Point(86, 338);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(148, 28);
            this.btn_login.TabIndex = 7;
            this.btn_login.Text = "Login";
            this.btn_login.UseVisualStyleBackColor = false;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabel1.LinkColor = System.Drawing.Color.Ivory;
            this.linkLabel1.Location = new System.Drawing.Point(101, 369);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(120, 13);
            this.linkLabel1.TabIndex = 8;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Forgot your credentials?";
            this.linkLabel1.VisitedLinkColor = System.Drawing.Color.Ivory;
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
            this.tabPageLogin.Controls.Add(this.labelLoginUsername);
            this.tabPageLogin.Controls.Add(this.labelLoginPassword);
            this.tabPageLogin.Location = new System.Drawing.Point(4, 22);
            this.tabPageLogin.Name = "tabPageLogin";
            this.tabPageLogin.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLogin.Size = new System.Drawing.Size(321, 393);
            this.tabPageLogin.TabIndex = 0;
            this.tabPageLogin.Text = "tabLogin";
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
            // tabPageRecovery
            // 
            this.tabPageRecovery.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.tabPageRecovery.Controls.Add(this.labelRecoveryFailure);
            this.tabPageRecovery.Controls.Add(this.linkLabelRecoveryFailed);
            this.tabPageRecovery.Controls.Add(this.linkLabelRecovery_back1);
            this.tabPageRecovery.Controls.Add(this.linkLabelRecovery_Back);
            this.tabPageRecovery.Controls.Add(this.labelRecoverySuccess);
            this.tabPageRecovery.Controls.Add(this.btn_login_recovery);
            this.tabPageRecovery.Controls.Add(this.txtbx_recovery_email);
            this.tabPageRecovery.Controls.Add(this.labelRecovery2);
            this.tabPageRecovery.Controls.Add(this.pictureBox1);
            this.tabPageRecovery.Controls.Add(this.label4);
            this.tabPageRecovery.Controls.Add(this.txtbx_recovery_username);
            this.tabPageRecovery.Controls.Add(this.labelRecovery1);
            this.tabPageRecovery.Location = new System.Drawing.Point(4, 22);
            this.tabPageRecovery.Name = "tabPageRecovery";
            this.tabPageRecovery.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRecovery.Size = new System.Drawing.Size(321, 393);
            this.tabPageRecovery.TabIndex = 1;
            this.tabPageRecovery.Text = "tabRecovery";
            // 
            // labelRecoveryFailure
            // 
            this.labelRecoveryFailure.AutoSize = true;
            this.labelRecoveryFailure.Font = new System.Drawing.Font("Palatino Linotype", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRecoveryFailure.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelRecoveryFailure.Location = new System.Drawing.Point(58, 273);
            this.labelRecoveryFailure.Name = "labelRecoveryFailure";
            this.labelRecoveryFailure.Size = new System.Drawing.Size(209, 36);
            this.labelRecoveryFailure.TabIndex = 18;
            this.labelRecoveryFailure.Text = "No match found";
            this.labelRecoveryFailure.Visible = false;
            // 
            // linkLabelRecoveryFailed
            // 
            this.linkLabelRecoveryFailed.AutoSize = true;
            this.linkLabelRecoveryFailed.Font = new System.Drawing.Font("Palatino Linotype", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelRecoveryFailed.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabelRecoveryFailed.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.linkLabelRecoveryFailed.Location = new System.Drawing.Point(95, 314);
            this.linkLabelRecoveryFailed.Name = "linkLabelRecoveryFailed";
            this.linkLabelRecoveryFailed.Size = new System.Drawing.Size(138, 36);
            this.linkLabelRecoveryFailed.TabIndex = 17;
            this.linkLabelRecoveryFailed.TabStop = true;
            this.linkLabelRecoveryFailed.Text = "Try again?";
            this.linkLabelRecoveryFailed.Visible = false;
            this.linkLabelRecoveryFailed.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.linkLabelRecoveryFailed.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelRecoveryFailed_LinkClicked);
            // 
            // linkLabelRecovery_back1
            // 
            this.linkLabelRecovery_back1.AutoSize = true;
            this.linkLabelRecovery_back1.Font = new System.Drawing.Font("Wingdings 3", 30.25F);
            this.linkLabelRecovery_back1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabelRecovery_back1.LinkColor = System.Drawing.Color.ForestGreen;
            this.linkLabelRecovery_back1.Location = new System.Drawing.Point(124, 328);
            this.linkLabelRecovery_back1.Name = "linkLabelRecovery_back1";
            this.linkLabelRecovery_back1.Size = new System.Drawing.Size(59, 47);
            this.linkLabelRecovery_back1.TabIndex = 16;
            this.linkLabelRecovery_back1.TabStop = true;
            this.linkLabelRecovery_back1.Text = "\\";
            this.linkLabelRecovery_back1.Visible = false;
            this.linkLabelRecovery_back1.VisitedLinkColor = System.Drawing.Color.ForestGreen;
            this.linkLabelRecovery_back1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelRecovery_back1_LinkClicked);
            // 
            // linkLabelRecovery_Back
            // 
            this.linkLabelRecovery_Back.AutoSize = true;
            this.linkLabelRecovery_Back.Font = new System.Drawing.Font("Wingdings 3", 30.25F);
            this.linkLabelRecovery_Back.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabelRecovery_Back.LinkColor = System.Drawing.Color.ForestGreen;
            this.linkLabelRecovery_Back.Location = new System.Drawing.Point(6, 6);
            this.linkLabelRecovery_Back.Name = "linkLabelRecovery_Back";
            this.linkLabelRecovery_Back.Size = new System.Drawing.Size(59, 47);
            this.linkLabelRecovery_Back.TabIndex = 15;
            this.linkLabelRecovery_Back.TabStop = true;
            this.linkLabelRecovery_Back.Text = "\\";
            this.linkLabelRecovery_Back.VisitedLinkColor = System.Drawing.Color.ForestGreen;
            this.linkLabelRecovery_Back.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelRecovery_Back_LinkClicked);
            // 
            // labelRecoverySuccess
            // 
            this.labelRecoverySuccess.AutoSize = true;
            this.labelRecoverySuccess.BackColor = System.Drawing.Color.Transparent;
            this.labelRecoverySuccess.Font = new System.Drawing.Font("Palatino Linotype", 19F);
            this.labelRecoverySuccess.ForeColor = System.Drawing.Color.Chartreuse;
            this.labelRecoverySuccess.Location = new System.Drawing.Point(30, 276);
            this.labelRecoverySuccess.Name = "labelRecoverySuccess";
            this.labelRecoverySuccess.Size = new System.Drawing.Size(273, 35);
            this.labelRecoverySuccess.TabIndex = 14;
            this.labelRecoverySuccess.Text = "Email sent succesfully!";
            this.labelRecoverySuccess.Visible = false;
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
            // txtbx_recovery_email
            // 
            this.txtbx_recovery_email.Location = new System.Drawing.Point(132, 305);
            this.txtbx_recovery_email.Name = "txtbx_recovery_email";
            this.txtbx_recovery_email.Size = new System.Drawing.Size(135, 20);
            this.txtbx_recovery_email.TabIndex = 12;
            this.txtbx_recovery_email.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbx_recovery_email_KeyPress);
            // 
            // labelRecovery2
            // 
            this.labelRecovery2.AutoSize = true;
            this.labelRecovery2.Location = new System.Drawing.Point(57, 308);
            this.labelRecovery2.Name = "labelRecovery2";
            this.labelRecovery2.Size = new System.Drawing.Size(32, 13);
            this.labelRecovery2.TabIndex = 11;
            this.labelRecovery2.Text = "Email";
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
            // txtbx_recovery_username
            // 
            this.txtbx_recovery_username.Location = new System.Drawing.Point(132, 273);
            this.txtbx_recovery_username.Name = "txtbx_recovery_username";
            this.txtbx_recovery_username.Size = new System.Drawing.Size(135, 20);
            this.txtbx_recovery_username.TabIndex = 1;
            this.txtbx_recovery_username.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbx_recovery_username_KeyPress);
            // 
            // labelRecovery1
            // 
            this.labelRecovery1.AutoSize = true;
            this.labelRecovery1.Location = new System.Drawing.Point(57, 276);
            this.labelRecovery1.Name = "labelRecovery1";
            this.labelRecovery1.Size = new System.Drawing.Size(55, 13);
            this.labelRecovery1.TabIndex = 0;
            this.labelRecovery1.Text = "Username";
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
            this.Load += new System.EventHandler(this.login_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPageLogin.ResumeLayout(false);
            this.tabPageLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.tabPageRecovery.ResumeLayout(false);
            this.tabPageRecovery.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtbx_login_username;
        private System.Windows.Forms.TextBox txtbx_login_password;
        private System.Windows.Forms.Label labelLoginUsername;
        private System.Windows.Forms.Label labelLoginPassword;
        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageLogin;
        private System.Windows.Forms.TabPage tabPageRecovery;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtbx_recovery_username;
        private System.Windows.Forms.Label labelRecovery1;
        private System.Windows.Forms.Button btn_login_recovery;
        private System.Windows.Forms.TextBox txtbx_recovery_email;
        private System.Windows.Forms.Label labelRecovery2;
        private System.Windows.Forms.Label labelRecoverySuccess;
        private System.Windows.Forms.LinkLabel linkLabelRecovery_Back;
        private System.Windows.Forms.LinkLabel linkLabelRecovery_back1;
        private System.Windows.Forms.LinkLabel linkLabelRecoveryFailed;
        private System.Windows.Forms.Label labelRecoveryFailure;
    }
}

