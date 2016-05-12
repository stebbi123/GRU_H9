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
using System.Runtime.InteropServices;

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
        //Error object
        ErrorProvider errorprov = new ErrorProvider();
        //Nota þetta til að passa username sem notandi loggaði sig inn með til Adalformsins(Fyrir labelið "you are signed in as...")
        public string Pass_username_to_adalform { get; set; }
        //Þarf að geyma þetta hérna :P
        string username_to_see_bets;
        string matchid_to_see_matches;
        //Dót til að færa formið
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        //LOAD
        private void Adalform_Load(object sender, EventArgs e)
        {
            //Sækir upplýisngar
            
            LoadLeikir();
            LoadNotendur();
            LoadBets();

            //Setur tooltip drasl
            tabPageLeikir.ToolTipText = "Here you can add upcomming matches or update past ones. Winners of matches are registered here aswell.";
            tabPageNotendur.ToolTipText = "Here you can add new users or update information about current users.";
            tabPageBets.ToolTipText = "Here you can view information about bets that users have placed on certain matches. Or delete them.";
            tabPageAddClient.ToolTipText = "Here you can add new users for the CS:GO Jungle client";

            //Setur label "you are signed in as"
            label_signed_in_as.Text = Pass_username_to_adalform;
            //Z-Index fyrir datagrid
            dataGridLeikir.BringToFront();
            dataGridNotendur.BringToFront();
            dataGridBets.BringToFront();
        }

        //DRAG FORM PANEL
        private void panel_dragform_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        //LINK LABEL - EXIT APPLICATION
        private void linkLabel_Exit_app_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Exit();
        }
        //LINK LABEL - MINIMIZE APPLICATION
        private void linkLabel_Mini_app_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        //LINK LABEL - HELP
        private void linkLabel_Help_app_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Help help = new Help();
            help.Show();
            this.WindowState = FormWindowState.Minimized;
        }
        //PICBOX - LOGOFF APPLICATION
        private void pictureBoxLogoff_Click(object sender, EventArgs e)
        {
            this.Hide();
            log.Show();
        }

        //LABEL - SHOW TIME
        private void timer_clock_Tick(object sender, EventArgs e)
        {
            label_date_and_time.Text = DateTime.Now.ToString();
        }

        //LOAD LEIKIR - INNÍ DATAGRID
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
                    dataGridLeikir.Rows[tala].Cells[6].Value = data[6];
                    this.dataGridLeikir.ColumnHeadersHeight = 25;
                    tala++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            //width stuff
            ColumnID.Width = 75;
            ColumnLid.Width = 200;
            ColumnDate.Width = 135;
            ColumnTime.Width = 85;
            ColumnRidill.Width = 65;
            ColumnBO.Width = 50;

        }
        //LOAD NOTENDUR - INNÍ DATAGRID
        public void LoadNotendur()
        {
            //listinn sem er lesinn úr gagnagrunninum
            List<string> linur = new List<string>();

            try
            {
                dataGridNotendur.Rows.Clear();
                dataGridNotendur.Refresh();
                linur = connection.LesaNotendur();
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

            //Width stuff
            ColumnNotendurUser.Width = 200;
            ColumnNotendurPassword.Width = 200;
            ColumnNotendurEmail.Width = 200;
            ColumnNotendurBalance.Width = 104;
        }
        //LOAD BETS - INNÍ DATAGRID
        public void LoadBets()
        {
            //listinn sem er lesinn úr gagnagrunninum
            List<string> linur = new List<string>();

            try
            {
                dataGridBets.Rows.Clear();
                dataGridBets.Refresh();
                linur = connection.LesaBets();
                string[] data;
                int tala = 0;
                foreach (string lin in linur)
                {
                    dataGridBets.Rows.Add();
                    data = lin.Split('#');
                    dataGridBets.Rows[tala].Cells[0].Value = data[0];
                    dataGridBets.Rows[tala].Cells[1].Value = data[1];
                    dataGridBets.Rows[tala].Cells[2].Value = data[2];
                    dataGridBets.Rows[tala].Cells[3].Value = data[3];
                    dataGridBets.Rows[tala].Cells[4].Value = data[4];
                    this.dataGridBets.ColumnHeadersHeight = 25;
                    tala++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            //set width of columns
            ColumnBetsID.Width = 75;
            ColumnBetsUser.Width = 225;
            ColumnBetsGameID.Width = 150;
            ColumnBetAmmount.Width = 150;
            ColumnBetChoice.Width = 150;
        }
        //LOAD BETS BY USER - INNÍ DATAGRID
        public void LoadBetsByUser()
        {
            //listinn sem er lesinn úr gagnagrunninum
            List<string> linur = new List<string>();

            try
            {
                dataGridBets.Rows.Clear();
                //dataGridBets.Refresh();
                linur = connection.LesaBetsByUser(username_to_see_bets);
                string[] data;
                int tala = 0;
                foreach (string lin in linur)
                {
                    dataGridBets.Rows.Add();
                    data = lin.Split('#');
                    dataGridBets.Rows[tala].Cells[0].Value = data[0];
                    dataGridBets.Rows[tala].Cells[1].Value = data[1];
                    dataGridBets.Rows[tala].Cells[2].Value = data[2];
                    dataGridBets.Rows[tala].Cells[3].Value = data[3];
                    dataGridBets.Rows[tala].Cells[4].Value = data[4];
                    this.dataGridBets.ColumnHeadersHeight = 25;
                    tala++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            //set width of columns
            ColumnBetsID.Width = 75;
            ColumnBetsUser.Width = 225;
            ColumnBetsGameID.Width = 150;
            ColumnBetAmmount.Width = 150;
            ColumnBetChoice.Width = 150;
        }
        //LOAD BETS BY MATCH - INNÍ DATAGRID
        public void LoadBetsByMatch()
        {
            //listinn sem er lesinn úr gagnagrunninum
            List<string> linur = new List<string>();

            try
            {
                dataGridBets.Rows.Clear();
                //dataGridBets.Refresh();
                linur = connection.LesaBetsByMatch(matchid_to_see_matches);
                string[] data;
                int tala = 0;
                foreach (string lin in linur)
                {
                    dataGridBets.Rows.Add();
                    data = lin.Split('#');
                    dataGridBets.Rows[tala].Cells[0].Value = data[0];
                    dataGridBets.Rows[tala].Cells[1].Value = data[1];
                    dataGridBets.Rows[tala].Cells[2].Value = data[2];
                    dataGridBets.Rows[tala].Cells[3].Value = data[3];
                    dataGridBets.Rows[tala].Cells[4].Value = data[4];
                    this.dataGridBets.ColumnHeadersHeight = 25;
                    tala++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            //set width of columns
            ColumnBetsID.Width = 75;
            ColumnBetsUser.Width = 225;
            ColumnBetsGameID.Width = 150;
            ColumnBetAmmount.Width = 150;
            ColumnBetChoice.Width = 150;
        }

        //BTN NEW MATCH
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
        //BTN UPDATE MATCH
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
                string leikir_update_winner = txtbx_leikir_update_winner.Text;

                connection.UpdateLeikir(leikir_update_lid, leikir_update_lid2, leikir_update_date, leikir_update_time, leikir_update_bo, leikir_update_ridill, leikir_update_id, leikir_update_winner);
                LoadLeikir();
            }
            catch (Exception)
            {
                MessageBox.Show("Error updating match info. Check your connection and try again.");
            }
            LoadLeikir();
            txtbx_leikir_update_lid.Clear();
            txtbx_leikir_update_lid2.Clear();
            txtbx_leikir_update_bo.Clear();
            txtbx_leikir_update_ridill.Clear();
            txtbx_leikir_update_time.Clear();
            txtbx_leikir_update_winner.Clear();
        }
        //BTN DELETE MATCH
        private void btn_delete_match_Click(object sender, EventArgs e)
        {
            try
            {
                string match_id_delete = txtbx_matches_delete.Text;
                connection.DeleteMatch(match_id_delete);
                txtbx_matches_delete.Clear();
                LoadLeikir();
            }
            catch (Exception)
            {
                MessageBox.Show("Error deleting match. Check your info and try again");
                throw;
            }
        }
        //BTN NEW USER
        private void btn_notendur_skra_Click(object sender, EventArgs e)
        {
            try
            {
                string notendur_add_user = txtbx_notendur_skra_user.Text;
                string notendur_add_password = txtbx_notendur_skra_password.Text;
                string notendur_add_email = txtbx_notendur_skra_email.Text;
                string notendur_add_balance = txtbx_notendur_skra_balance.Text;

                connection.AddNewNotandi(notendur_add_user, notendur_add_password, notendur_add_email, notendur_add_balance);
                LoadNotendur();
            }
            catch (Exception)
            {
                MessageBox.Show("Error adding new user. Check your connection and try again.");
            }
            LoadNotendur();
            txtbx_notendur_skra_user.Clear();
            txtbx_notendur_skra_password.Clear();
            txtbx_notendur_skra_email.Clear();
            txtbx_notendur_skra_balance.Clear();
        }
        //BTN UPDATE USER
        private void btn_notendur_update_Click(object sender, EventArgs e)
        {
            try
            {
                string notendur_update_user = txtbx_notendur_update_user.Text;
                string notendur_update_password = txtbx_notendur_update_password.Text;
                string notendur_update_email = txtbx_notendur_update_email.Text;
                string notendur_update_balance = txtbx_notendur_update_balance.Text;

                connection.UpdateNotendur(notendur_update_user, notendur_update_password, notendur_update_email, notendur_update_balance);
                LoadNotendur();
            }
            catch (Exception)
            {
                MessageBox.Show("Error updating user. Check your connection and try again.");
            }
            LoadNotendur();
            txtbx_notendur_update_user.Clear();
            txtbx_notendur_update_password.Clear();
            txtbx_notendur_update_email.Clear();
            txtbx_notendur_update_balance.Clear();
        }
        //SELECTION CHANGED - NOTENDUR
        private void dataGridNotendur_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridNotendur.SelectedRows.Count <= 0)//ef engir dalkar eru valdir, gerist ekkert
            {
                return;
            }
            else
            {
                try
                {
                    if (dataGridNotendur.SelectedRows[0].Cells[0].Value.ToString() != null)
                    {
                        txtbx_notendur_update_user.Text = dataGridNotendur.SelectedRows[0].Cells[0].Value.ToString();
                        txtbx_notendur_delete.Text = dataGridNotendur.SelectedRows[0].Cells[0].Value.ToString();
                    }
                    if (dataGridNotendur.SelectedRows[0].Cells[2].Value.ToString() != null)
                    {
                        txtbx_notendur_update_password.Text = dataGridNotendur.SelectedRows[0].Cells[1].Value.ToString();
                    }
                    if (dataGridNotendur.SelectedRows[0].Cells[3].Value.ToString() != null)
                    {
                        txtbx_notendur_update_email.Text = dataGridNotendur.SelectedRows[0].Cells[2].Value.ToString();
                    }
                    if (dataGridNotendur.SelectedRows[0].Cells[4].Value.ToString() != null)
                    {
                        txtbx_notendur_update_balance.Text = dataGridNotendur.SelectedRows[0].Cells[3].Value.ToString();
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
        //BTN DELETE USER
        private void btn_notendur_delete_Click(object sender, EventArgs e)
        {
            try
            {
                string notendur_delete_user = txtbx_notendur_delete.Text;

                connection.DeleteUser(notendur_delete_user);
                LoadNotendur();
            }
            catch (Exception)
            {
                MessageBox.Show("Error deleting user. Check your connection and try again.");
            }
            LoadNotendur();
            txtbx_notendur_delete.Clear();
        }
        //BTN DELETE BET
        private void btn_delete_bet_Click(object sender, EventArgs e)
        {
            try
            {
                string bets_betid = txtbx_delete_bet.Text;

                connection.DeleteBet(bets_betid);
                LoadBets();
            }
            catch (Exception)
            {
                MessageBox.Show("Error deleting bet. Check your connection and try again.");
            }
            LoadBets();
            txtbx_delete_bet.Clear();
        }
        //BTN BETS BY USER
        private void btn_view_bets_by_user_Click(object sender, EventArgs e)
        {
            try
            {
                username_to_see_bets = txtbx_view_bet_by_user.Text;
                connection.LesaBetsByUser(username_to_see_bets);
                LoadBetsByUser();
                btn_view_bets_by_user.Hide();
                btn_back_to_bets.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Error loading bets by user. Check your connection and try again.");
            }
            LoadBetsByUser();
        }
        //BTN GO BACK TO BETS
        private void btn_back_to_bets_Click(object sender, EventArgs e)
        {
            dataGridBets.Rows.Clear();
            LoadBets();
            btn_view_bets_by_user.Show();
            btn_back_to_bets.Hide();
        }
        //BTN VIEW BETS BY MATCH
        private void btn_view_bets_by_match_Click(object sender, EventArgs e)
        {
            try
            {
                matchid_to_see_matches = txtbx_view_bets_by_match.Text;
                connection.LesaBetsByMatch(matchid_to_see_matches);
                LoadBetsByMatch();
                btn_view_bets_by_match.Hide();
                btn_back_to_bets1.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Error loading bets by match. Check your connection and try again.");
            }
            LoadBetsByMatch();
        }
        //BTN BACK TO BETS
        private void btn_back_to_bets1_Click(object sender, EventArgs e)
        {
            dataGridBets.Rows.Clear();
            LoadBets();
            btn_view_bets_by_match.Show();
            btn_back_to_bets1.Hide();
        }
        //BTN ADD CLIENT USER
        private void btn_add_client_user_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtbx_add_client_username.Text == "")
                {
                    errorprov.SetError(txtbx_add_client_username, "Please enter a username");
                    txtbx_add_client_username.BackColor = Color.LightCoral;
                }
                if (txtbx_add_client_password.Text == "")
                {
                    errorprov.SetError(txtbx_add_client_password, "Please enter a password");
                    txtbx_add_client_password.BackColor = Color.LightCoral;
                }
                if (txtbx_add_client_email.Text == "")
                {
                    errorprov.SetError(txtbx_add_client_email, "Please enter an email");
                    txtbx_add_client_email.BackColor = Color.LightCoral;
                }
                else
                {
                    string client_user_username = txtbx_add_client_username.Text;
                    string client_user_password = txtbx_add_client_password.Text;
                    string client_user_email = txtbx_add_client_email.Text;

                    connection.AddNewClientUser(client_user_username, client_user_password, client_user_email);

                    label_client_user_success.Show();
                    label_client_user_success1.Show();
                    txtbx_add_client_email.Clear();
                    txtbx_add_client_password.Clear();
                    txtbx_add_client_username.Clear();
                    txtbx_add_client_username.Hide();
                    txtbx_add_client_password.Hide();
                    txtbx_add_client_email.Hide();
                    label_add_new_client_user.Hide();
                    label_add_new_client_user1.Hide();
                    label_add_new_client_user2.Hide();
                    label_add_new_client_user4.Hide();
                    btn_add_client_user.Hide();
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error registering new user. Check your connection and try again.");
            }
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

        //PicBox - Logoff - Hover
        private void pictureBoxLogoff_MouseHover(object sender, EventArgs e)
        {
            pictureBoxLogoff.Image = Image.FromFile("../Debug/logoff_hover.png");

            tooltip.SetToolTip(pictureBoxLogoff, "Logout of CS:GO Jungle");

        }
        //PicBox - Logoff - Leave
        private void pictureBoxLogoff_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxLogoff.Image = Image.FromFile("../Debug/logoff.png");
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



        //LinkLabel - Exit App - Hover
        private void linkLabel_Exit_app_MouseHover(object sender, EventArgs e)
        {
            linkLabel_Exit_app.LinkColor = Color.ForestGreen;
            tooltip.SetToolTip(linkLabel_Exit_app, "Exit");
        }
        //LinkLabel - Exit App - Leave
        private void linkLabel_Exit_app_MouseLeave(object sender, EventArgs e)
        {
            linkLabel_Exit_app.LinkColor = Color.Ivory;
        }
        //LinkLabel - Mini App - Hover
        private void linkLabel_Mini_app_MouseHover(object sender, EventArgs e)
        {
            linkLabel_Mini_app.LinkColor = Color.ForestGreen;
            tooltip.SetToolTip(linkLabel_Mini_app, "Minimize");
        }
        //LinkLabel - Mini App - Leave
        private void linkLabel_Mini_app_MouseLeave(object sender, EventArgs e)
        {
            linkLabel_Mini_app.LinkColor = Color.Ivory;
        }
        //LinkLabel - Help App - Hover
        private void linkLabel_Help_app_MouseHover(object sender, EventArgs e)
        {
            linkLabel_Help_app.LinkColor = Color.ForestGreen;
            tooltip.SetToolTip(linkLabel_Help_app, "Help");
        }
        //LinkLabel - Help App - Leave
        private void linkLabel_Help_app_MouseLeave(object sender, EventArgs e)
        {
            linkLabel_Help_app.LinkColor = Color.Ivory;
        }
        //Hover - tooltip
        private void pictureBoxCSGOJungle_MouseHover(object sender, EventArgs e)
        {
            tooltip.SetToolTip(pictureBoxCSGOJungle, "Welcome to the CS:GO Jungle admin environment!");
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
        //HOVER - NEW USER
        private void pictureBox_add_user_MouseHover(object sender, EventArgs e)
        {
            pictureBox_add_user.Image = Image.FromFile("../Debug/button_new_hover.png");

            tooltip.SetToolTip(pictureBox_add_match, "Add a user.");
        }
        //HOVER LEAVE - ADD USER
        private void pictureBox_add_user_MouseLeave(object sender, EventArgs e)
        {
            pictureBox_add_user.Image = Image.FromFile("../Debug/button_new.png");
        }
        //HOVER - UPDATE USER
        private void pictureBox_update_user_MouseHover(object sender, EventArgs e)
        {
            pictureBox_update_user.Image = Image.FromFile("../Debug/button_update_hover.png");

            tooltip.SetToolTip(pictureBox_update_user, "Update information about a user.");
        }
        //HOVER LEAVE - UPDATE USER
        private void pictureBox_update_user_MouseLeave(object sender, EventArgs e)
        {
            pictureBox_update_user.Image = Image.FromFile("../Debug/button_update.png");
        }
        //HOVER - DELETE USER
        private void pictureBox_delete_user_MouseHover(object sender, EventArgs e)
        {
            pictureBox_delete_user.Image = Image.FromFile("../Debug/button_delete_hover.png");

            tooltip.SetToolTip(pictureBox_delete_user, "Delete a user.");
        }
        //HOVER LEAVE - DELETE USER
        private void pictureBox_delete_user_MouseLeave(object sender, EventArgs e)
        {
            pictureBox_delete_user.Image = Image.FromFile("../Debug/button_delete.png");
        }
        //FOCUS TABPAGE - CLEAR SOME LABELS
        private void tabPageAddClient_Enter(object sender, EventArgs e)
        {
            label_client_user_success.Hide();
            label_client_user_success1.Hide();
            txtbx_add_client_email.Clear();
            txtbx_add_client_password.Clear();
            txtbx_add_client_username.Clear();
            txtbx_add_client_username.Show();
            txtbx_add_client_password.Show();
            txtbx_add_client_email.Show();
            label_add_new_client_user.Show();
            label_add_new_client_user1.Show();
            label_add_new_client_user2.Show();
            label_add_new_client_user4.Show();
            btn_add_client_user.Show();
        }

        //ENTER EVENT - CLEAR TEXTBOX
        private void txtbx_add_client_password_Enter(object sender, EventArgs e)
        {
            txtbx_add_client_password.BackColor = Color.DarkGray;
            errorprov.SetError(txtbx_add_client_password, "");
        }
        //ENTER EVENT - CLEAR TEXTBOX
        private void txtbx_add_client_username_Enter(object sender, EventArgs e)
        {
            txtbx_add_client_username.BackColor = Color.DarkGray;
            errorprov.SetError(txtbx_add_client_username, "");
        }
        //ENTER EVENT - CLEAR TEXTBOX
        private void txtbx_add_client_email_Enter(object sender, EventArgs e)
        {
            txtbx_add_client_email.BackColor = Color.DarkGray;
            errorprov.SetError(txtbx_add_client_email, "");
        }
    }
}
