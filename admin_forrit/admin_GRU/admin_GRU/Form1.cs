using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace admin_GRU
{
    public partial class Form1 : Form
    {
        //Tenging við database klasann
        admin_GRU.Connection gagnagrunnur = new admin_GRU.Connection();

        public Form1()
        {
            InitializeComponent();

            //Prófa tengingu við gagnagrunn
            try
            {
                gagnagrunnur.TengingVidGagnagrunn();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        //LOAD
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadLeikir();
        }


        //Þessi aðferð refreashar datagridviewið til að upplýsingarnar séu alltaf up-to date
        public void LoadLeikir()
        {
            //listinn sem er lesinn úr gagnagrunninum
            List<string> linur = new List<string>();

            try
            {
                dataGridLeikir.Rows.Clear();
                dataGridLeikir.Refresh();
                linur = gagnagrunnur.LesaLeiki();
                string[] data;
                int tala = 0;
                foreach (string lin in linur)
                {
                    dataGridLeikir.Rows.Add();
                    data = lin.Split(':');
                    dataGridLeikir.Rows[tala].Cells[0].Value = data[0];
                    dataGridLeikir.Rows[tala].Cells[1].Value = data[1];
                    dataGridLeikir.Rows[tala].Cells[2].Value = data[2];
                    dataGridLeikir.Rows[tala].Cells[3].Value = data[3];
                    dataGridLeikir.Rows[tala].Cells[4].Value = data[4];
                    this.dataGridLeikir.ColumnHeadersHeight = 25;
                    tala++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


    }
}
