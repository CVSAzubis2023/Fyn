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
using System.Reflection.Emit;

namespace Pac_Man.Settings_etc
{
    internal class Settings
    {
        #region Vars & Objects

        private double volume;
        private string saveState;
        private string difficulty;
        private string requester;

        settingsSql settingsSql;

        #endregion

        #region Constructors

        public Settings(string requester)
        {
            //var volume = new System.Windows.Media.MediaPlayer();
            settingsSql = new settingsSql();
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
            if (settingsSql.write("saveState"))
            {
                return;
            }
        }

        public string getSave()
        {
            if (settingsSql.saveState == null)
            {
                settingsSql.getInfo("saveState");
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
            if (settingsSql.write("difficulty"))
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
    }
}