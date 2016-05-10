using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;

namespace AdminGRU
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
            //Prófa tengingu við gagnagrunn
            try
            {
                connection.TengingVidGagnagrunn();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        //tenging við Connection Klasa
        Connection connection = new Connection();

        //LOAD
        private void login_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtbx_login_username;
        }

        //BTN login
        private void btn_login_Click(object sender, EventArgs e)
        {
            string login_username = txtbx_login_username.Text;
            string login_password = txtbx_login_password.Text;

            if (login_username == "" || login_password == "")
            {
                MessageBox.Show("Please enter your credentials to login");
            }
            else
            {
                if (connection.Authenticate_username(login_username) == false)
                {
                    MessageBox.Show("Username doesnt exist");
                }
                else
                {
                    if (connection.Authenticate_password(login_username, login_password) == true)
                    {
                        //tenging við adalform
                        Adalform adalform = new Adalform();
                        adalform.Pass_username_to_adalform = login_username;
                        this.Hide();
                        adalform.Show();

                    }
                    else
                    {
                        MessageBox.Show("Incorrect password!");
                    }
                }
            }
        }


        //Forgot credentials link
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tabControl1.SelectedIndex = 1;
            linkLabelRecoveryFailed.Hide();
            labelRecoveryFailure.Hide();
            labelRecovery1.Show();
            labelRecovery2.Show();
            txtbx_recovery_email.Show();
            txtbx_recovery_username.Show();
            txtbx_recovery_email.Clear();
            txtbx_recovery_username.Clear();
            txtbx_recovery_username.Focus();
            btn_login_recovery.Show();
            labelRecoverySuccess.Hide();
            linkLabelRecovery_Back.Show();
            linkLabelRecovery_back1.Hide();
        }


        //send recovery email
        private void btn_login_recovery_Click(object sender, EventArgs e)
        {
            try
            {
                string recovery_username = txtbx_recovery_username.Text;
                string recovery_email = txtbx_recovery_email.Text;


                if (connection.Recovery_verification(recovery_username, recovery_email) == true)
                {
                    var fromAddress = new MailAddress("csgojunglebets@gmail.com", "CSGOJungle");
                    var toAddress = new MailAddress(recovery_email.ToString(), "To name");
                    const string fromPassword = "Junglebets";
                    const string subject = "CSGOJungle account recovery";
                    string body = "You requested a CSGOJungle account recovery. Ignore this email if you did not make this request.\nUsername: " + recovery_email + ".\n\nPassword: " + recovery_email + ".\n\nHave a nice day!\nCSGOJungle team.";

                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                    };

                    using (var message = new MailMessage(fromAddress, toAddress)
                    {
                        Subject = subject,
                        Body = body
                    })
                    {
                        smtp.Send(message);
                    }

                    labelRecovery1.Hide();
                    labelRecovery2.Hide();
                    txtbx_recovery_email.Hide();
                    txtbx_recovery_username.Hide();
                    btn_login_recovery.Hide();
                    labelRecoverySuccess.Show();
                    linkLabelRecovery_Back.Hide();
                    linkLabelRecovery_back1.Show();
                }
                else
                {
                    labelRecovery1.Hide();
                    labelRecovery2.Hide();
                    txtbx_recovery_email.Hide();
                    txtbx_recovery_username.Hide();
                    btn_login_recovery.Hide();
                    labelRecoveryFailure.Show();
                    linkLabelRecoveryFailed.Show();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter your username and email.");
            }
        }

        //Recovery failed - Try again
        private void linkLabelRecoveryFailed_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabelRecoveryFailed.Hide();
            labelRecoveryFailure.Hide();
            labelRecovery1.Show();
            labelRecovery2.Show();
            txtbx_recovery_email.Show();
            txtbx_recovery_username.Show();
            txtbx_recovery_email.Clear();
            txtbx_recovery_username.Clear();
            txtbx_recovery_username.Focus();
            btn_login_recovery.Show();
        }

        //Recovery - Back button
        private void linkLabelRecovery_back1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        //Recovery - Back button
        private void linkLabelRecovery_Back_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        //Keypress event - Enter on login
        private void txtbx_login_password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btn_login.PerformClick();
            }
        }

        //Keypress event - Enter on login
        private void txtbx_login_username_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btn_login.PerformClick();
            }
        }

        //Keypress event
        private void txtbx_recovery_username_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Enter - to login
            if (e.KeyChar == (char)Keys.Enter)
            {
                btn_login_recovery.PerformClick();
            }
            //ESC - to go back
            if (e.KeyChar == (char)Keys.Escape)
            {
                tabControl1.SelectedIndex = 0;
            }
        }

        //Keypress event
        private void txtbx_recovery_email_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Enter - to login
            if (e.KeyChar == (char)Keys.Enter)
            {
                btn_login_recovery.PerformClick();
            }
            //ESC - to go back
            if (e.KeyChar == (char)Keys.Escape)
            {
                tabControl1.SelectedIndex = 0;
            }
        }

        //ENTER EVENT - Color changes
        private void txtbx_recovery_username_Enter(object sender, EventArgs e)
        {
            txtbx_recovery_username.BackColor = Color.LightGray;
            txtbx_recovery_username.ForeColor = Color.Black;
        }

        //LEAVE EVENT - Color changes
        private void txtbx_recovery_username_Leave(object sender, EventArgs e)
        {
            txtbx_recovery_username.BackColor = Color.Gray;
            txtbx_recovery_username.ForeColor = Color.White;
        }

        //ENTER EVENT - Color changes
        private void txtbx_recovery_email_Enter(object sender, EventArgs e)
        {
            txtbx_recovery_email.BackColor = Color.LightGray;
            txtbx_recovery_email.ForeColor = Color.Black;
        }
        //LEAVE EVENT - Color changes
        private void txtbx_recovery_email_Leave(object sender, EventArgs e)
        {
            txtbx_recovery_email.BackColor = Color.Gray;
            txtbx_recovery_email.ForeColor = Color.White;
        }
        //ENTER EVENT - Color changes
        private void txtbx_login_username_Enter(object sender, EventArgs e)
        {
            txtbx_login_username.BackColor = Color.LightGray;
            txtbx_login_username.ForeColor = Color.Black;
        }
        //LEAVE EVENT - Color changes
        private void txtbx_login_username_Leave(object sender, EventArgs e)
        {
            txtbx_login_username.BackColor = Color.Gray;
            txtbx_login_username.ForeColor = Color.White;
        }
        //ENTER EVENT - Color changes
        private void txtbx_login_password_Enter(object sender, EventArgs e)
        {
            txtbx_login_password.BackColor = Color.LightGray;
            txtbx_login_password.ForeColor = Color.Black;
        }
        //LEAVE EVENT - Color changes
        private void txtbx_login_password_Leave(object sender, EventArgs e)
        {
            txtbx_login_password.BackColor = Color.Gray;
            txtbx_login_password.ForeColor = Color.White;
        }
    }
}
