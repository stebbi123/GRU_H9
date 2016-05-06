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

        //Setur inní töfluna í gagnagrunninum
        public void AddNewLeikir(string lid1lid2, string date, string time, string bo, string ridill)
        {

            //tékka hvort tenging við gagnagrunninn sé ekki pottþétt opin
            if (OpenConnection() == true)
            {
                //bý til fyrirspurnina sem er svo send í gagnagrunninn
                fyrirspurn = "INSERT INTO leikir (lid1_lid2, date, time, bo, ridill) VALUES ('" + lid1lid2 + "','" + date + "','" + time + "','" + bo + "','" + ridill + "');";

                //nySQLskipun er "constructor" og executar skipunina
                nySQLskipun = new MySqlCommand(fyrirspurn, SQLtenging);
                nySQLskipun.ExecuteNonQuery();

                //loka tengingu
                CloseConnection();
            }
        }

        //Eyðir ákveðinni færslu
        public void Eyda(string id)
        {
            if (OpenConnection() == true)
            {
                fyrirspurn = "DELETE FROM tafla WHERE nafn='" + id + "'";
                nySQLskipun = new MySqlCommand(fyrirspurn, SQLtenging);
                nySQLskipun.ExecuteNonQuery();
                CloseConnection();
            }
        }


        //Uppfærir færslu
        public void Uppfaera(string nafn, string skoli, string afangi, string einingar, string verd)
        {
            if (OpenConnection() == true)
            {
                fyrirspurn = "UPDATE tafla SET nafn='" + nafn + "', skoli='" + skoli + "', afangi='" + afangi + "', einingar='" + einingar + "', verd='" + verd + "' where nafn='" + nafn + "'";
                nySQLskipun = new MySqlCommand(fyrirspurn, SQLtenging);
                nySQLskipun.ExecuteNonQuery();
                CloseConnection();
            }
        }

        //Les úr gagnagrunninum og skilar Lista með öllum færslunum
        public List<string> LesaurSQLtoflu()
        {
            List<string> faerslur = new List<string>();
            string line = null;
            if (OpenConnection() == true)
            {
                fyrirspurn = "SELECT nafn, skoli, afangi, einingar, verd FROM tafla";
                nySQLskipun = new MySqlCommand(fyrirspurn, SQLtenging);

                //fær til sín feedback frá gagnagrunninum
                SQLlesari = nySQLskipun.ExecuteReader();

                while (SQLlesari.Read())
                {
                    for (int i = 0; i < SQLlesari.FieldCount; i++)
                    {
                        line += (SQLlesari.GetValue(i).ToString()) + ":";
                    }

                    faerslur.Add(line);
                    line = null;
                }
                CloseConnection();
                return faerslur;
            }
            return faerslur;
        }

        //Les allt úr Leikir töflunni og skilar svo að DataGrid getur displayað það
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


        //Les allt úr Notendur töflunni og skilar svo að DataGrid getur displayað það
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
