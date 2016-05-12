using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
//Hávar Sigurðarson
//6.5.2016
namespace AdminGRU
{
    class Connection
    {
        //hvar serverinn er hýstur
        private string server;
        //nafnið á gagnagrunninum
        private string database;
        //MySQL notandanafnið
        private string uid;
        //MySQL password
        private string password;
        //inniheldur tengistrenginn sem tengir við databaseinn
        string tengistrengur;
        //inniheldur fyrirspurnina sem við ætlum að senda að hverju sinni
        string fyrirspurn = null;

        //þetta opnar tengingu við gagnagrunninn
        MySqlConnection SQLtenging;
        //þetta framkvæmir SQL fyrirspurnina
        MySqlCommand nySQLskipun;
        //lesari sem les úr SQL gagnagrunninum
        MySqlDataReader SQLlesari;

        /*þessi aðferð tengir notandan við gagnagrunninn */
        public void TengingVidGagnagrunn()
        {

            server = "tsuts.tskoli.is"; //"10.200.10.24";
            database = "gru_h9_gru";
            uid = "GRU_H9";
            password = "mypassword";

            tengistrengur = "server=" + server + ";userid=" + uid + ";password=" + password + ";database=" + database;
            SQLtenging = new MySqlConnection(tengistrengur);
        }


        //Athugar hvort tenging sé opin
        private bool OpenConnection()
        {
            try
            {
                SQLtenging.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
        }

        //Authenticate - Tékkar hvort username sé til í gagnagrunninum og skilar true/false
        public bool Authenticate_username(string username)
        {
            bool username_exists = false;
            string reader_output = "";
            if (OpenConnection() == true)
            {
                fyrirspurn = "SELECT username FROM program_notendur WHERE username = '" + username + "';";
                nySQLskipun = new MySqlCommand(fyrirspurn, SQLtenging);

                //fær til sín feedback frá gagnagrunninum
                SQLlesari = nySQLskipun.ExecuteReader();

                while (SQLlesari.Read())
                {
                    for (int i = 0; i < SQLlesari.FieldCount; i++)
                    {
                        reader_output = (SQLlesari.GetValue(i).ToString());
                    }
                }
                CloseConnection();
            }

            if (reader_output == username)
            {
                username_exists = true;
            }
            else
            {
                username_exists = false;
            }
            return username_exists;
        }

        //Authenticate - Tékkar hvort password passi usernamei
        public bool Authenticate_password(string username, string password)
        {
            bool correct_password = false;
            string reader_output = "";
            if (OpenConnection() == true)
            {
                fyrirspurn = "SELECT password FROM program_notendur WHERE username = '" + username + "';";
                nySQLskipun = new MySqlCommand(fyrirspurn, SQLtenging);

                //fær til sín feedback frá gagnagrunninum
                SQLlesari = nySQLskipun.ExecuteReader();

                while (SQLlesari.Read())
                {
                    for (int i = 0; i < SQLlesari.FieldCount; i++)
                    {
                        reader_output = (SQLlesari.GetValue(i).ToString());
                    }
                }
                CloseConnection();
            }

            if (reader_output == password)
            {
                correct_password = true;
            }
            else
            {
                correct_password = false;
            }
            return correct_password;
        }

        //Recovery - does username and email match??
        public bool Recovery_verification(string username, string email)
        {
            bool matching = false;
            string reader_output = "";
            if (OpenConnection() == true)
            {
                fyrirspurn = "SELECT email FROM program_notendur WHERE username = '" + username + "';";
                nySQLskipun = new MySqlCommand(fyrirspurn, SQLtenging);

                //fær til sín feedback frá gagnagrunninum
                SQLlesari = nySQLskipun.ExecuteReader();

                while (SQLlesari.Read())
                {
                    for (int i = 0; i < SQLlesari.FieldCount; i++)
                    {
                        reader_output = (SQLlesari.GetValue(i).ToString());
                    }
                }
                CloseConnection();
            }

            if (reader_output == email)
            {
                matching = true;
            }
            else
            {
                matching = false;
            }
            return matching;
        }

        //ADD MATCH
        public void AddNewLeikir(string lid1, string lid2, string date, string time, string bo, string ridill)
        {
            try
            {
                //tékka hvort tenging við gagnagrunninn sé ekki pottþétt opin
                if (OpenConnection() == true)
                {
                    //Set lid1 og lid2 saman í streng(Bæti " v " við)
                    string lid1lid2 = lid1 + " v " + lid2;

                    //bý til fyrirspurnina sem er svo send í gagnagrunninn
                    fyrirspurn = "INSERT INTO leikir (lid1_lid2, date, time, bo, ridill) VALUES ('" + lid1lid2 + "','" + date + "','" + time + "','" + bo + "','" + ridill + "');";

                    //nySQLskipun er "constructor" og executar skipunina
                    nySQLskipun = new MySqlCommand(fyrirspurn, SQLtenging);
                    nySQLskipun.ExecuteNonQuery();

                    //loka tengingu
                    CloseConnection();
                }
            }
            catch (Exception)
            {
                CloseConnection();
                throw;
            }
        }

        //ADD USER
        public void AddNewNotandi(string user, string password, string email, string balance)
        {
            try
            {
                //tékka hvort tenging við gagnagrunninn sé ekki pottþétt opin
                if (OpenConnection() == true)
                {
                    //bý til fyrirspurnina sem er svo send í gagnagrunninn
                    fyrirspurn = "INSERT INTO notendur (user, password, email, balance) VALUES ('" + user + "','" + password + "','" + email + "'," + balance + ");";

                    //nySQLskipun er "constructor" og executar skipunina
                    nySQLskipun = new MySqlCommand(fyrirspurn, SQLtenging);
                    nySQLskipun.ExecuteNonQuery();

                    //loka tengingu
                    CloseConnection();
                }
            }
            catch (Exception)
            {
                CloseConnection();
                throw;
            }
        }

        //ADD CLIENT USER
        public void AddNewClientUser(string user, string password, string email)
        {
            try
            {
                //tékka hvort tenging við gagnagrunninn sé ekki pottþétt opin
                if (OpenConnection() == true)
                {
                    //bý til fyrirspurnina sem er svo send í gagnagrunninn
                    fyrirspurn = "INSERT INTO program_notendur (username, password, email) VALUES ('" + user + "','" + password + "','" + email + "');";

                    //nySQLskipun er "constructor" og executar skipunina
                    nySQLskipun = new MySqlCommand(fyrirspurn, SQLtenging);
                    nySQLskipun.ExecuteNonQuery();

                    //loka tengingu
                    CloseConnection();
                }
            }
            catch (Exception)
            {
                CloseConnection();
                throw;
            }
        }

        //UPDATE MATCH
        public void UpdateLeikir(string lid1, string lid2, string date, string time, string bo, string ridill, int id, string winner)
        {
            try
            {
                //tékka hvort tenging við gagnagrunninn sé ekki pottþétt opin
                if (OpenConnection() == true)
                {
                    //Set lid1 og lid2 saman í streng(Bæti " v " við)
                    string lid1lid2 = lid1 + " v " + lid2;

                    //bý til fyrirspurnina sem er svo send í gagnagrunninn
                    fyrirspurn = "UPDATE leikir SET lid1_lid2 = '" + lid1lid2 + "', date='" + date + "', time='" + time + "', bo='" + bo + "', ridill='" + ridill + "', winner= '" + winner + "'  where ID='" + id + "'";

                    //nySQLskipun er "constructor" og executar skipunina
                    nySQLskipun = new MySqlCommand(fyrirspurn, SQLtenging);
                    nySQLskipun.ExecuteNonQuery();

                    //loka tengingu
                    CloseConnection();
                }
            }
            catch (Exception)
            {
                CloseConnection();
                throw;
            }

        }

        //UPDATE USER
        public void UpdateNotendur(string user, string password, string email, string balance)
        {
            try
            {
                //tékka hvort tenging við gagnagrunninn sé ekki pottþétt opin
                if (OpenConnection() == true)
                {
                    //bý til fyrirspurnina sem er svo send í gagnagrunninn
                    fyrirspurn = "UPDATE notendur SET user = '" + user + "', password='" + password + "', email='" + email + "', balance=" + balance + " where user='" + user + "'";

                    //nySQLskipun er "constructor" og executar skipunina
                    nySQLskipun = new MySqlCommand(fyrirspurn, SQLtenging);
                    nySQLskipun.ExecuteNonQuery();

                    //loka tengingu
                    CloseConnection();
                }
            }
            catch (Exception)
            {
                CloseConnection();
                throw;
            }
        }

        //DELETE USER
        public void DeleteUser(string user)
        {
            if (OpenConnection() == true)
            {
                fyrirspurn = "DELETE FROM notendur WHERE user='" + user + "'";
                nySQLskipun = new MySqlCommand(fyrirspurn, SQLtenging);
                nySQLskipun.ExecuteNonQuery();
                CloseConnection();
            }
        }

        //DELETE BET
        public void DeleteBet(string betid)
        {
            if (OpenConnection() == true)
            {
                fyrirspurn = "DELETE FROM leikir_has_bets WHERE ID='" + betid + "'";
                nySQLskipun = new MySqlCommand(fyrirspurn, SQLtenging);
                nySQLskipun.ExecuteNonQuery();
                CloseConnection();
            }
        }

        //DELETE MATCH
        public void DeleteMatch(string id)
        {
            if (OpenConnection() == true)
            {
                fyrirspurn = "DELETE FROM leikir WHERE id='" + id + "'";
                nySQLskipun = new MySqlCommand(fyrirspurn, SQLtenging);
                nySQLskipun.ExecuteNonQuery();
                CloseConnection();
            }
        }

        //LESA LEIKI ÚR DATABASE
        public List<string> LesaLeiki()
        {
            List<string> faerslur = new List<string>();
            string line = null;
            if (OpenConnection() == true)
            {
                fyrirspurn = "SELECT ID, lid1_lid2, date, time, bo, ridill, winner FROM leikir";
                nySQLskipun = new MySqlCommand(fyrirspurn, SQLtenging);

                //fær til sín feedback frá gagnagrunninum
                SQLlesari = nySQLskipun.ExecuteReader();

                while (SQLlesari.Read())
                {
                    for (int i = 0; i < SQLlesari.FieldCount; i++)
                    {
                        line += (SQLlesari.GetValue(i).ToString()) + "#";
                    }

                    faerslur.Add(line);
                    line = null;
                }
                CloseConnection();
                return faerslur;
            }
            return faerslur;
        }

        //LESA NOTENDUR ÚR DATABASE
        public List<string> LesaNotendur()
        {
            List<string> faerslur = new List<string>();
            string line = null;
            if (OpenConnection() == true)
            {
                fyrirspurn = "SELECT user, password, email, balance FROM notendur";
                nySQLskipun = new MySqlCommand(fyrirspurn, SQLtenging);

                //fær til sín feedback frá gagnagrunninum
                SQLlesari = nySQLskipun.ExecuteReader();

                while (SQLlesari.Read())
                {
                    for (int i = 0; i < SQLlesari.FieldCount; i++)
                    {
                        line += (SQLlesari.GetValue(i).ToString()) + "#";
                    }

                    faerslur.Add(line);
                    line = null;
                }
                CloseConnection();
                return faerslur;
            }
            return faerslur;
        }

        //LESA BETS ÚR DATABASE
        public List<string> LesaBets()
        {
            List<string> faerslur = new List<string>();
            string line = null;
            if (OpenConnection() == true)
            {
                fyrirspurn = "SELECT ID, notendur_user, leikir_ID, bet, OneTwo FROM leikir_has_bets";
                nySQLskipun = new MySqlCommand(fyrirspurn, SQLtenging);

                //fær til sín feedback frá gagnagrunninum
                SQLlesari = nySQLskipun.ExecuteReader();

                while (SQLlesari.Read())
                {
                    for (int i = 0; i < SQLlesari.FieldCount; i++)
                    {
                        line += (SQLlesari.GetValue(i).ToString()) + "#";
                    }

                    faerslur.Add(line);
                    line = null;
                }
                CloseConnection();
                return faerslur;
            }
            return faerslur;
        }

        //LESA BETS BY USER
        public List<string> LesaBetsByUser(string username)
        {
            List<string> faerslur = new List<string>();
            string line = null;
            if (OpenConnection() == true)
            {

                fyrirspurn = "SELECT ID, notendur_user, leikir_ID, bet, OneTwo FROM leikir_has_bets WHERE notendur_user = '" + username + "'";
                nySQLskipun = new MySqlCommand(fyrirspurn, SQLtenging);

                //fær til sín feedback frá gagnagrunninum
                SQLlesari = nySQLskipun.ExecuteReader();

                while (SQLlesari.Read())
                {
                    for (int i = 0; i < SQLlesari.FieldCount; i++)
                    {
                        line += (SQLlesari.GetValue(i).ToString()) + "#";
                    }

                    faerslur.Add(line);
                    line = null;
                }
                CloseConnection();
                return faerslur;
            }
            return faerslur;
        }

        //Finnur info um ákveðinn leik
        public string[] FinnaInfoUmLeik(string ID)
        {
            string[] gogn = new string[8];
            if (OpenConnection() == true)
            {
                fyrirspurn = "SELECT ID, lid1_lid2, date, time, bo, ridill, winner FROM leikir where ID ='" + ID + "'";
                nySQLskipun = new MySqlCommand(fyrirspurn, SQLtenging);
                SQLlesari = nySQLskipun.ExecuteReader();
                while (SQLlesari.Read())
                {
                    gogn[0] = SQLlesari.GetValue(0).ToString();
                    gogn[1] = SQLlesari.GetValue(1).ToString();
                    gogn[2] = SQLlesari.GetValue(2).ToString();
                    gogn[3] = SQLlesari.GetValue(3).ToString();
                    gogn[4] = SQLlesari.GetValue(4).ToString();
                    gogn[5] = SQLlesari.GetValue(5).ToString();
                    gogn[6] = SQLlesari.GetValue(6).ToString();
                    gogn[7] = SQLlesari.GetValue(7).ToString();
                    gogn[8] = SQLlesari.GetValue(8).ToString();
                }
                SQLlesari.Close();
                CloseConnection();
                return gogn;
            }
            return gogn;
        }
        //Reynir að loka tengingunni
        private bool CloseConnection()
        {
            try
            {
                SQLtenging.Close();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
