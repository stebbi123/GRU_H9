using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                    MessageBox.Show("Username exists!");
                }
            }
        }
    }
}
