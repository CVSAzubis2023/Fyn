using System;
using Microsoft.SqlServer;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.Remoting.Messaging;
using System.Xaml;
using System.Windows;

namespace Pac_Man.Settings_etc
{
    internal class myaccount
    {
        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

        private string nameInput;
        private string passwordInput;

        private string name = null;
        private string password = null;
        private string timesplayed = null;
        private string lastscore = null;
        private string highscore = null;
        private double playtime = -1;

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

        public string getTimesPlayed()
        {
            return timesplayed;
        }

        public string getLastScore()
        {
            return lastscore;
        }

        public string getHighScore()
        {
            return highscore;
        }

        public double getPlayTime()
        {
            return playtime;
        }

        #endregion

        #region Set

        public void setName(string Name)
        {
            nameInput = Name;
        }

        public void setPassword(string Password)
        {
            passwordInput = Password;
        }

        #endregion

        public void connectSQL()
        {
            builder.DataSource = "FDEU-131\\SQLEXPRESS";
            builder.UserID = "sa";
            builder.Password = "applesauce/2";
            builder.InitialCatalog = "Test";
        }

        public bool setInfo()
        {
            Debug.WriteLine("Getting Info");

            try {
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    //Get Password
                    string sqlpassword = "SELECT Password FROM dbo.Table_1 WHERE Name = '" + name + "'";

                    /*using (SqlCommand command = new SqlCommand(sqlpassword, connection))
                    {
                        connection.Open();

                        SqlDataReader rd = command.ExecuteReader();
                            
                        rd.Read();
                        password = rd.GetString(0);

                        Debug.WriteLine("Passwort: " + password);

                        connection.Close();
                    }
                    */

                    //Get Timesplayed
                    string sqltimesplayed = "SELECT Timesplayed FROM dbo.Table_1 WHERE Name = '" + name + "'";

                    using (SqlCommand command = new SqlCommand(sqltimesplayed, connection))
                    {
                        connection.Open();
                        SqlDataReader rd = command.ExecuteReader();

                        rd.Read();
                        timesplayed = rd.GetString(0);

                        Debug.WriteLine("Timesplayed: " + timesplayed);

                        connection.Close();
                    }

                    //Get Lastscore
                    string sqllastscore = "SELECT Score FROM dbo.Table_1 WHERE Name = '" + name + "'";
                    using (SqlCommand command = new SqlCommand(sqllastscore, connection))
                    {
                        connection.Open();
                        SqlDataReader rd = command.ExecuteReader();

                        rd.Read();
                        lastscore = rd.GetString(0);

                        Debug.WriteLine("Last Score: " + lastscore);

                        connection.Close();
                    }

                    //Get Playtime
                    string sqlplaytime = "SELECT Playtime FROM dbo.Table_1 WHERE Name = '" + name + "'";
                    using (SqlCommand command = new SqlCommand(sqlplaytime, connection))
                    {
                        connection.Open();
                        SqlDataReader rd = command.ExecuteReader();

                        rd.Read();
                        playtime = rd.GetDouble(0);

                        Debug.WriteLine("Playtime: " + playtime);

                        connection.Close();
                    }

                    if (name != null && password != null && timesplayed != null && lastscore != null && highscore != null && playtime != -1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            
            catch
            {
                return false;
            }
        } 
    }
}
