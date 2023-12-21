using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Collections.Specialized;

namespace Pac_Man.Settings_etc
{
    internal class Settings
    {
        #region Vars & Objects

        private double volume;
        private string saveState;
        private string difficulty;
        private string requester;

        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

        #endregion

        #region Constructors

        public Settings(string requester)
        {
            //var volume = new System.Windows.Media.MediaPlayer();
            connectSQL();
            this.requester = requester;
        }

        #endregion

        #region Methods

        public void setVolume(double value)
        {
            volume = value;
        } 
        
        public double getVolume()
        {
            return volume;
        }

        public void setSave(string value)
        {
            saveState = value;
            if (writeToDataBase("saveState"))
            {
                return;
            }
        }

        public string getSave()
        {
            if (saveState == null)
            {
                getFromDataBase("saveState");
                return saveState;
            }
            else
            {
                return saveState;
            }
        }

        public void setDifficulty(string value)
        {
            difficulty = value;
            if (writeToDataBase("difficulty"))
            {
                return;
            }
            else
            {
                throw new Exception();
            }
        }

        public string getDifficulty()
        {
            return difficulty;
        }

        #endregion

        #region SQL

        private bool writeToDataBase(string commandRequester)
        {
            string command;

            if (commandRequester == "saveState")
            {
                command = "INSERT INTO dbo.Table_1 savestate VALUES (@value) WHERE Name = '" + requester + "'";
            }
            else if (commandRequester == "volume")
            {
                command = "INSERT INTO dbo.Table_1 volume VALUES (@value) WHERE Name = '" + requester + "'";
            }
            else if (commandRequester == "difficulty")
            {
                command = "INSERT INTO dbo.Table_1 difficulty VALUES (@value) WHERE Name = '" + requester + "'";
            }
            else
            {
                throw new NotImplementedException("You are trying to write into something that doesnt exist in the database");
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(command, connection))
                    {
                        switch (commandRequester)
                        {
                            case "saveState":
                                cmd.Parameters.Add("@value", System.Data.SqlDbType.NVarChar).Value = saveState;
                                break;
                            case "volume":
                                cmd.Parameters.Add("@value", System.Data.SqlDbType.Float).Value = volume;
                                break;
                            case "difficulty":
                                cmd.Parameters.Add("@value", System.Data.SqlDbType.NVarChar).Value = difficulty;
                                break;
                            default:
                                throw new NotImplementedException();
                        }

                        connection.Open();

                        cmd.ExecuteNonQuery();

                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            return true;
        }

        private void getFromDataBase(string commandRequester)
        {
            if (commandRequester == "saveState")
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                    {
                        string command = "";

                        using (SqlCommand cmd = new SqlCommand(command, connection))
                        {
                            connection.Open();

                            using (SqlDataReader rd = cmd.ExecuteReader())
                            {
                                rd.Read();
                                saveState = rd.GetString(0);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }
            else if (commandRequester == "volume")
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                    {
                        string command = "";

                        using (SqlCommand cmd = new SqlCommand(command, connection))
                        {
                            connection.Open();

                            using (SqlDataReader rd = cmd.ExecuteReader())
                            {
                                rd.Read();
                                volume = rd.GetDouble(0);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }
            else if (commandRequester == "difficulty")
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                    {
                        string command = "";

                        using (SqlCommand cmd = new SqlCommand(command, connection))
                        {
                            connection.Open();
                            using (SqlDataReader rd = cmd.ExecuteReader())
                            {
                                difficulty = rd.GetString(0);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }
            else
            {
                throw new NotImplementedException("Requester does not exist in Database, please check!");
            }
        }

        private void connectSQL()
        {
            builder.DataSource = "FDEU-131\\SQLEXPRESS";
            builder.UserID = "sa";
            builder.Password = "applesauce/2";
            builder.InitialCatalog = "Test";
        }

        #endregion

        public Exception()
        {

        }
    }
}