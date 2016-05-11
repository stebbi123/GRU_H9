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
    }
}
