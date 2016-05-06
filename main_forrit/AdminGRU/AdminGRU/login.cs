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
                        Adalform adalform = new Adalform();
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
        }


        //send recovery email
        private void btn_login_recovery_Click(object sender, EventArgs e)
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

                MessageBox.Show("Mail sent!");
            }
            else
            {
                MessageBox.Show("didnt work =(");
            }
        }
    }
}
