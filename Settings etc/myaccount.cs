using System;
using Microsoft.SqlServer;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pac_Man.Settings_etc
{
    internal class myaccount
    {
        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

        private string name;
        private string password;
        private int timesplayed;
        private int lastscore;
        private int highscore;
        private double playtime;

        private int amount;

        #region Get

        public string getName()
        {
            return name;
        }

        public string getPassword()
        {
            return password;
        }

        public int getTimesPlayed()
        {
            return timesplayed;
        }

        public int getLastScore()
        {
            return lastscore;
        }

        public int getHighScore()
        {
            return highscore;
        }

        public double getPlayTime()
        {
            return playtime;
        }

        #endregion

        private void setInfo()
        {
            connectSQL();

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                string sqlCount = "SELECT COUNT(*) FROM dbo.Table_1";

                using (SqlCommand cmad = new SqlCommand(sqlCount, connection))
                {
                    connection.Open();

                    SqlDataReader rd = cmad.ExecuteReader();

                    while (rd.Read())
                    {
                        amount = rd.GetInt32(0);
                    }
                }
            }

            try {
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    //Get Name
                    string sqlname = "SELECT FROM";
                    using (SqlCommand command = new SqlCommand(sqlname, connection)) 
                    { 
                        connection.Open();
                    }

                    //Get Password
                    string sqlpassword = "SELECT FROM";
                    using (SqlCommand command = new SqlCommand(sqlpassword, connection))
                    {
                        connection.Open();
                    }

                    //Get Timesplayed
                    string sqltimesplayed = "SELECT FROM";
                    using (SqlCommand command = new SqlCommand(sqltimesplayed, connection))
                    {
                        connection.Open();
                    }

                    //Get Lastscore
                    string sqllastscore = "SELECT FROM";
                    using (SqlCommand command = new SqlCommand(sqllastscore, connection))
                    {
                        connection.Open();
                    }

                    //Get Playtime
                    string sqlplaytime = "SELECT FROM";
                    using (SqlCommand command = new SqlCommand(sqlplaytime, connection))
                    {
                        connection.Open();
                    }

                }
            }
            catch
            {

            }
        }

        private void connectSQL()
        {
            builder.DataSource = "FDEU-131\\SQLEXPRESS";
            builder.UserID = "sa";
            builder.Password = "applesauce/2";
            builder.InitialCatalog = "Test";
        }
    }
}
