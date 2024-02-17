using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Pac_Man.abstractClasses;

namespace Pac_Man.Settings_etc
{
    public class settingsSql : sqlBase
    {
        #region Vars & Objs

        Dictionary<string, string> sqlCommands = new Dictionary<string, string>();

        private string difficulty;
        private string saveState;
        private double volume;

        #endregion

        #region Get & Set

        public string Difficulty
        {
            get { return difficulty; }
            set { difficulty = value; }
        }

        public string SaveState
        {
            get { return saveState; }
            set { saveState = value; }
        }

        public double Volume
        {
            get { return volume; }
            set { volume = value; }
        }

        #endregion

        #region Constructor

        public settingsSql() 
        {
            sqlCommands.Add("saveState", "INSERT INTO dbo.Table_1 savestate VALUES (@value) WHERE Name = '");
            sqlCommands.Add("difficulty", "");
            sqlCommands.Add("volume", "");
        }

        #endregion

        #region Methods

        public bool write(string command)
        {
            return true;
        }

        public string getInfo(string infoToGet)
        {
            return "";
        }

        public bool initSQL()
        {
            try
            {
                connectSQL();
                if (testConnection())
                {
                    return true;
                }

            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }


        private bool writeToDataBase(string commandRequester)
        {
            else if (commandRequester == "volume")
            {
                command = "INSERT INTO dbo.Table_1 volume VALUES (@value) WHERE Name = '" + requester + "'";
            }
            else if (commandRequester == "difficulty")
            {
                command = "INSERT INTO dbo.Table_1 difficulty VALUES (@value) WHERE Name = '" + requester + "'";
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(base.builder.ConnectionString))
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

        private void getFromDataBaseDifficulty()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    string command = sqlCommands["difficulty"];

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

        private void getFromDataBaseSaveState()
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(base.builder.ConnectionString))
                {
                    string command = sqlCommands["saveState"];

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

        private void getFromDataBaseVolume()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    string command = sqlCommands["volume"];

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

        private void connectSQL()
        {
            builder.DataSource = "FDEU-131\\SQLEXPRESS";
            builder.UserID = "sa";
            builder.Password = "applesauce/2";
            builder.InitialCatalog = "Test";
        }

        private bool testConnection()
        {
            try
            {


                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion
    }
}
