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
    public partial class Help : Form
    {
        public Help()
        {
            InitializeComponent();
        }

        //LINK LABEL - EXIT
        private void linkLabel_Help_Exit_app_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
        }


        //BTN SEND MESSAGE
        private void btn_send_message_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtbx_help_name.Text == "" || txtbx_help_email.Text == "" && richtxtbx_help_message.Text == "")
                {
                    MessageBox.Show("Please enter your name and email. And forget the message ;)");
                }
                else
                {
                    string username = txtbx_help_name.Text;
                    string email = txtbx_help_email.Text;
                    string message_tosend = richtxtbx_help_message.Text;

                    var fromAddress = new MailAddress("csgojunglebets@gmail.com", "CSGOJungle");
                    var toAddress = new MailAddress("onyth23@gmail.com", "To name");
                    const string fromPassword = "Junglebets";
                    const string subject = "CSGOJungle Ticket";
                    string body = "A user of the CS:GO Jungle client has sent a message through our ticket system. \n\nName: " + username + "\nEmail: " + email + "\n\n\"" + message_tosend + "\"";

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

                    txtbx_help_email.Hide();
                    txtbx_help_name.Hide();
                    label_help_email.Hide();
                    label_help_1.Hide();
                    label_help_2.Hide();
                    label_help_3.Hide();
                    label_help_4.Hide();
                    label_help_succesful.Show();
                    btn_send_message.Hide();
                    label_help_check.Show();
                    richtxtbx_help_message.Hide();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
                throw;
            }
        }
    }
}
