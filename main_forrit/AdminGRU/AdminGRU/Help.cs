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
using System.Runtime.InteropServices;

namespace AdminGRU
{
    public partial class Help : Form
    {
        public Help()
        {
            InitializeComponent();
        }
        //Dót til að færa formið
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        //ERROR OBJECT
        ErrorProvider errorpro = new ErrorProvider();

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
                if (txtbx_help_name.Text == "")
                {
                    errorpro.SetError(txtbx_help_name, "Please enter your name");
                    txtbx_help_name.BackColor = Color.LightCoral;
                }
                else if(txtbx_help_email.Text == "")
                {
                    errorpro.SetError(txtbx_help_email, "Please enter your email");
                    txtbx_help_email.BackColor = Color.LightCoral;
                }
                else if(richtxtbx_help_message.Text == "")
                {
                    errorpro.SetError(richtxtbx_help_message, "Please include a message");
                    richtxtbx_help_message.BackColor = Color.LightCoral;
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
                txtbx_help_email.Hide();
                txtbx_help_name.Hide();
                label_help_email.Hide();
                label_help_1.Hide();
                label_help_2.Hide();
                label_help_3.Hide();
                label_help_4.Hide();
                label_help_succesful.Show();
                btn_send_message.Hide();
                richtxtbx_help_message.Hide();
                label_help_failure.Show();
                linkLabel_retry.Show();
                linkLabel_retry_1.Show();
                throw;
            }
        }

        //LINK RETRY
        private void linkLabel_retry_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtbx_help_email.Show();
            txtbx_help_name.Show();
            label_help_email.Show();
            label_help_1.Show();
            label_help_2.Show();
            label_help_3.Show();
            label_help_4.Show();
            label_help_succesful.Show();
            btn_send_message.Show();
            richtxtbx_help_message.Show();
            label_help_failure.Hide();
            linkLabel_retry.Hide();
            linkLabel_retry_1.Hide();
        }

        //HOVER COLOR
        private void linkLabel_Help_Exit_app_MouseHover(object sender, EventArgs e)
        {
            linkLabel_Help_Exit_app.LinkColor = Color.ForestGreen;
        }
        //HOVER COLOR
        private void linkLabel_Help_Exit_app_MouseLeave(object sender, EventArgs e)
        {
            linkLabel_Help_Exit_app.LinkColor = Color.White;
        }

        //Færir formið
        private void panel_dragform_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        //ENTER - REMOVE RED AND ERROR
        private void txtbx_help_name_Enter(object sender, EventArgs e)
        {
            txtbx_help_name.BackColor = Color.Gray;
            errorpro.SetError(txtbx_help_name, "");
        }
        //ENTER - REMOVE RED AND ERROR
        private void txtbx_help_email_TextChanged(object sender, EventArgs e)
        {
            txtbx_help_email.BackColor = Color.Gray;
            errorpro.SetError(txtbx_help_email, "");
        }
        //ENTER - REMOVE RED AND ERROR
        private void richtxtbx_help_message_Enter(object sender, EventArgs e)
        {
            richtxtbx_help_message.BackColor = Color.Gray;
            errorpro.SetError(richtxtbx_help_message, "");
        }
    }
}
