﻿using System;
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
        private void Adalform_Load(object sender, EventArgs e)
        {
            LoadLeikir();
        }

        //Method - Loadar upplýsingar inní Leikir DataGridið
        public void LoadLeikir()
        {
            //listinn sem er lesinn úr gagnagrunninum
            List<string> linur = new List<string>();

            try
            {
                dataGridLeikir.Rows.Clear();
                dataGridLeikir.Refresh();
                linur = connection.LesaLeiki();
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
    }
}
