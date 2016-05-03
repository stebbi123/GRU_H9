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
    public partial class Adalform : Form
    {
        //Tenging við database klasann
        admin_GRU.Connection gagnagrunnur = new admin_GRU.Connection();

        public Adalform()
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
            LoadNotendur();
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
                    data = lin.Split('#');
                    dataGridLeikir.Rows[tala].Cells[0].Value = data[0];
                    dataGridLeikir.Rows[tala].Cells[1].Value = data[1];
                    dataGridLeikir.Rows[tala].Cells[2].Value = data[2];
                    dataGridLeikir.Rows[tala].Cells[3].Value = data[3];
                    dataGridLeikir.Rows[tala].Cells[4].Value = data[4];
                    dataGridLeikir.Rows[tala].Cells[5].Value = data[5];
                    this.dataGridLeikir.ColumnHeadersHeight = 25;
                    tala++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        //Loadar notendur
        public void LoadNotendur()
        {
            //listinn sem er lesinn úr gagnagrunninum
            List<string> linur = new List<string>();

            try
            {
                dataGridNotendur.Rows.Clear();
                dataGridNotendur.Refresh();
                linur = gagnagrunnur.LesaNotendur();
                string[] data;
                int tala = 0;
                foreach (string lin in linur)
                {
                    dataGridNotendur.Rows.Add();
                    data = lin.Split('#');
                    dataGridNotendur.Rows[tala].Cells[0].Value = data[0];
                    dataGridNotendur.Rows[tala].Cells[1].Value = data[1];
                    dataGridNotendur.Rows[tala].Cells[2].Value = data[2];
                    dataGridNotendur.Rows[tala].Cells[3].Value = data[3];
                    this.dataGridNotendur.ColumnHeadersHeight = 25;
                    tala++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        //BTN LEIKIR SKRÁ
        private void btn_leikir_skra_Click(object sender, EventArgs e)
        {
            string leikir_skra_lid = txtbx_leikir_skra_lid.Text;
            string leikir_skra_date = dateTime_leikir_skra.Text;
            string leikir_skra_time = txtbx_leikir_skra_time.Text;
            string leikir_skra_bo = txtbx_leikir_skra_bo.Text;
            string leikir_skra_ridill = txtbx_leikir_skra_ridill.Text;

            gagnagrunnur.AddNewLeikir(leikir_skra_lid, leikir_skra_date, leikir_skra_time, leikir_skra_bo, leikir_skra_ridill);
            LoadLeikir();
            txtbx_leikir_skra_lid.Clear();
            txtbx_leikir_skra_bo.Clear();
            txtbx_leikir_skra_ridill.Clear();
            txtbx_leikir_skra_time.Clear();
        }

        private void dataGridLeikir_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridLeikir.SelectedRows.Count <= 0)//ef engir dalkar eru valdir, gerist ekkert
            {
                return;
            }
            else
            {
                try
                {
                    if (dataGridLeikir.SelectedRows[0].Cells[0].Value.ToString() != null)
                    {
                         txtbx_leikir_update_lid.Text = dataGridLeikir.SelectedRows[0].Cells[1].Value.ToString();
                    }
                    if (dataGridLeikir.SelectedRows[0].Cells[2].Value.ToString() != null)
                    {
                        txtbx_leikir_update_time.Text = dataGridLeikir.SelectedRows[0].Cells[3].Value.ToString();
                    }
                    if (dataGridLeikir.SelectedRows[0].Cells[3].Value.ToString() != null)
                    {
                       txtbx_leikir_update_bo.Text = dataGridLeikir.SelectedRows[0].Cells[4].Value.ToString();
                    }
                    if (dataGridLeikir.SelectedRows[0].Cells[4].Value.ToString() != null)
                    {
                       txtbx_leikir_update_ridill.Text = dataGridLeikir.SelectedRows[0].Cells[5].Value.ToString();
                    }

                }
                catch (Exception)
                {
                    txtbx_leikir_update_lid.Text = null;
                    dateTime_leikir_update.Text = null;
                    txtbx_leikir_update_time.Text = null;
                    txtbx_leikir_update_bo.Text = null;
                    txtbx_leikir_update_ridill.Text = null;
                    txtbx_leikir_update_winner.Text = null;

                }
            }
        }
    }
}
