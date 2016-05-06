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
    public partial class Adalform : Form
    {
        public Adalform()
        {
            InitializeComponent();
        }

        login loginform = new login();
        Adalform adalform = new Adalform();

        private void Adalform_Load(object sender, EventArgs e)
        {
            loginform = new login();
            loginform.Show();
            this.Hide();
            loginform.Focus();
        }
    }
}
