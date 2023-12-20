using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pac_Man.Settings_etc
{
    internal class Settings
    {
        #region Vars

        private double volume;
        private string saveState;

        #endregion

        #region Constructors

        public Settings()
        {
            //var volume = new System.Windows.Media.MediaPlayer();
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
            return "";
        }

        private void writeToDataBase()
        {

        }

        private void getFromDataBase()
        {

        }

        #endregion
    }
}
