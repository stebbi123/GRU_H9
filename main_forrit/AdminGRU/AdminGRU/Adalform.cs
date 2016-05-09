using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

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
        //Tooltip object
        ToolTip tooltip = new ToolTip();
        //Login object
        login log = new login();
        //Nota þetta til að passa username sem notandi loggaði sig inn með til Adalformsins(Fyrir labelið "you are signed in as...")
        public string Pass_username_to_adalform { get; set; }

        //LOAD
        private void Adalform_Load(object sender, EventArgs e)
        {
            //Sækir upplýisngar
            LoadLeikir();

            //Setur tooltip drasl
            tabPageLeikir.ToolTipText = "Here you can add upcomming matches or update past ones. Winners of matches are registered here aswell.";
            tabPageNotendur.ToolTipText = "Here you can add new users or update information about current users.";
            tabPageBets.ToolTipText = "Here you can view and update bets that users have placed on certain matches.";

            //Setur label "you are signed in as"
            label_signed_in_as.Text = Pass_username_to_adalform;
            //Z-Index fyrir datagrid
            dataGridLeikir.BringToFront();
            dataGridNotendur.BringToFront();
            dataGridBets.BringToFront();
        }

        //LABEL - SHOW TIME
        private void timer_clock_Tick(object sender, EventArgs e)
        {
            label_date_and_time.Text = DateTime.Now.ToString();
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

        //PictureBox - Logoff - Hover
        private void pictureBoxLogoff_MouseHover(object sender, EventArgs e)
        {
            pictureBoxLogoff.Image = Image.FromFile("../Debug/logoffhover.png");

            tooltip.SetToolTip(pictureBoxLogoff, "Logout of CS:GO Jungle");

        }

        //PictureBox - Logoff - Leave
        private void pictureBoxLogoff_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxLogoff.Image = Image.FromFile("../Debug/logoff.png");
        }

        //Hover - tooltip
        private void pictureBoxCSGOJungle_MouseHover(object sender, EventArgs e)
        {
            tooltip.SetToolTip(pictureBoxCSGOJungle, "Welcome to the CS:GO Jungle admin environment!");
        }

        //BTN - Skrá leik
        private void btn_leikir_skra_Click(object sender, EventArgs e)
        {
            try
            {
                string leikir_skra_lid = txtbx_leikir_skra_lid.Text;
                string leikir_skra_lid2 = txtbx_leikir_skra_lid2.Text;
                string leikir_skra_date = dateTime_leikir_skra.Text;
                string leikir_skra_time = txtbx_leikir_skra_time.Text;
                string leikir_skra_bo = txtbx_leikir_skra_bo.Text;
                string leikir_skra_ridill = txtbx_leikir_skra_ridill.Text;

                connection.AddNewLeikir(leikir_skra_lid, leikir_skra_lid2, leikir_skra_date, leikir_skra_time, leikir_skra_bo, leikir_skra_ridill);
            }
            catch (Exception)
            {
                MessageBox.Show("Error registering match info. Check your connection and try again.");
            }
            LoadLeikir();
            txtbx_leikir_skra_lid.Clear();
            txtbx_leikir_skra_lid2.Clear();
            txtbx_leikir_skra_bo.Clear();
            txtbx_leikir_skra_ridill.Clear();
            txtbx_leikir_skra_time.Clear();
        }

        //BTN - Update leik
        private void btn_leikir_update_Click(object sender, EventArgs e)
        {
            try
            {
                int leikir_update_id = Convert.ToInt32(txtbx_leikir_update_ID.Text);
                string leikir_update_lid = txtbx_leikir_update_lid.Text;
                string leikir_update_lid2 = txtbx_leikir_update_lid2.Text;
                string leikir_update_date = dateTime_leikir_update.Text;
                string leikir_update_time = txtbx_leikir_update_time.Text;
                string leikir_update_bo = txtbx_leikir_update_bo.Text;
                string leikir_update_ridill = txtbx_leikir_update_ridill.Text;

                connection.UpdateLeikir(leikir_update_lid, leikir_update_lid2, leikir_update_date, leikir_update_time, leikir_update_bo, leikir_update_ridill, leikir_update_id);
                LoadLeikir();
            }
            catch (Exception)
            {
                MessageBox.Show("Error updating match info. Check your connection and try again.");
            }
            LoadLeikir();
            txtbx_leikir_skra_lid.Clear();
            txtbx_leikir_skra_lid2.Clear();
            txtbx_leikir_skra_bo.Clear();
            txtbx_leikir_skra_ridill.Clear();
            txtbx_leikir_skra_time.Clear();
        }

        //SELECTION CHANGED - MATCHES
        private void dataGridLeikir_SelectionChanged_1(object sender, EventArgs e)
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
                        //Sækir orðið til að splitta
                        string word_to_split = dataGridLeikir.SelectedRows[0].Cells[1].Value.ToString();
                        //Splittar því á " v " með Regex
                        string[] both_teams = Regex.Split(word_to_split, " v ");

                        //Setur splittaða strengin í rétt textbox
                        txtbx_leikir_update_lid.Text = both_teams[0];
                        txtbx_leikir_update_lid2.Text = both_teams[1];
                        //ID txtbox
                        txtbx_leikir_update_ID.Text = dataGridLeikir.SelectedRows[0].Cells[0].Value.ToString();


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

        //LOGOFF
        private void pictureBoxLogoff_Click(object sender, EventArgs e)
        {
            this.Hide();
            log.Show();
        }

        //PicBox Click - NEW MATCH
        private void pictureBox_add_match_Click(object sender, EventArgs e)
        {
            tabControlMatches.SelectedIndex = 1;
        }

        //PicBox Click - UPDATE MATCH
        private void pictureBox_update_match_Click(object sender, EventArgs e)
        {
            tabControlMatches.SelectedIndex = 2;
        }

        //PicBox Click - DELETE MATCH
        private void pictureBox_delete_match_Click(object sender, EventArgs e)
        {
            tabControlMatches.SelectedIndex = 3;
        }

        //PicBox Click - NEW USER
        private void pictureBox_add_user_Click(object sender, EventArgs e)
        {
            tabControlNotendur.SelectedIndex = 1;
        }

        //PicBox Click - UPDATE USER
        private void pictureBox_update_user_Click(object sender, EventArgs e)
        {
            tabControlNotendur.SelectedIndex = 2;
        }

        //PicBox Click - DELETE USER
        private void pictureBox_delete_user_Click(object sender, EventArgs e)
        {
            tabControlNotendur.SelectedIndex = 3;
        }

        //LinkLabel - BACK
        private void linkLabel_Matches_Back_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tabControlMatches.SelectedIndex = 0;
        }

        //LinkLabel - BACK
        private void linkLabel_Matches_Back1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tabControlMatches.SelectedIndex = 0;
        }

        //LinkLabel - BACK
        private void linkLabel_Matches_Back2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tabControlMatches.SelectedIndex = 0;
        }

        //LinkLabel - BACK
        private void linkLabel_Users_Back_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tabControlNotendur.SelectedIndex = 0;
        }

        //LinkLabel - BACK
        private void linkLabel_Users_Back1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tabControlNotendur.SelectedIndex = 0;
        }

        //LinkLabel - BACK
        private void linkLabel_Users_Back2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tabControlNotendur.SelectedIndex = 0;
        }

        //HOVER - NEW MATCH
        private void pictureBox_add_match_MouseHover(object sender, EventArgs e)
        {
            pictureBox_add_match.Image = Image.FromFile("../Debug/button_new_hover.png");

            tooltip.SetToolTip(pictureBox_add_match, "Create a new match.");
        }

        //HOVER LEAVE - ADD MATCH
        private void pictureBox_add_match_MouseLeave(object sender, EventArgs e)
        {
            pictureBox_add_match.Image = Image.FromFile("../Debug/button_new.png");
        }

        //HOVER - UPDATE MATCH
        private void pictureBox_update_match_MouseHover(object sender, EventArgs e)
        {
            pictureBox_update_match.Image = Image.FromFile("../Debug/button_update_hover.png");

            tooltip.SetToolTip(pictureBox_update_match, "Update information about a match.");
        }

        //HOVER LEAVE - UPDATE MATCH
        private void pictureBox_update_match_MouseLeave(object sender, EventArgs e)
        {
            pictureBox_update_match.Image = Image.FromFile("../Debug/button_update.png");
        }

        //HOVER - DELETE MATCH
        private void pictureBox_delete_match_MouseHover(object sender, EventArgs e)
        {
            pictureBox_delete_match.Image = Image.FromFile("../Debug/button_delete_hover.png");

            tooltip.SetToolTip(pictureBox_delete_match, "Delete a match.");
        }

        //HOVER LEAVE - DELETE MATCH
        private void pictureBox_delete_match_MouseLeave(object sender, EventArgs e)
        {
            pictureBox_delete_match.Image = Image.FromFile("../Debug/button_delete.png");
        }


    }
}
