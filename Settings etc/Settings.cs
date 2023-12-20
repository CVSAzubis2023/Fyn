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

namespace Pac_Man.Settings_etc
{
    internal class Settings
    {
        #region Vars & Objects

        private double volume;
        private string saveState;
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
        }

        public string getSave()
        {
            if (saveState == null)
            {
                getFromDataBase(saveState);
                return "";
            }
            else
            {
                return saveState;
            }
        }

        #endregion

        #region SQL

        private bool writeToDataBase(string commandRequester)
        {
            return true;
        }

        private void getFromDataBase(string commandRequester)
        {
            switch (commandRequester)
            {
                case "":
                    break;
                case "a":
                    break;
                default:
                    break;
            }

            try
            {

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

        #endregion
    }
}