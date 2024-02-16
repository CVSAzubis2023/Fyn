using Pac_Man.Settings_etc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Pac_Man.Windows
{
    /// <summary>
    /// Interaktionslogik für Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
        myaccount myacc = new myaccount();
        Settings settings;

        private string name;
        private string password;

        public Register()
        {
            InitializeComponent();

            DataContext = new Viewmodel();
            settings = new Settings(name);
        }

        public bool getInfo()
        {
            myacc.setName(name);
            Debug.WriteLine(name);
            myacc.setPassword(password);

            myacc.connectSQL();

            if(myacc.setInfo() == true)
            {
                Debug.WriteLine("Info setzten");
                setInfo();
                return true;
            }
            else 
            {
                return false;
            }
        }

        public void setInfo() 
        {
            YourName.Text = myacc.getName();
            YourPassword.Text = myacc.getPassword();
            TimesPlayed.Text = myacc.getTimesPlayed();
            YourLatestScore.Text = myacc.getLastScore();
            YourHighscore.Text = myacc.getHighScore();
            OverallPlayTime.Text = myacc.getPlayTime();
        }

        public void setDetails(string nameInput, string passwordInput)
        {
            name = nameInput;
            password = passwordInput;
        }

        private void ButtonYourAccount_Click(object sender, RoutedEventArgs e)
        {
            InfoYourAccount.Visibility = Visibility.Visible;
            InfoYourAccount.Focusable = true;

            InfoSettings.Visibility = Visibility.Hidden;
            InfoSettings.Focusable = false;

            Headline.Text = "Your Account";
        }

        private void ButtonSettings_Click(object sender, RoutedEventArgs e)
        {
            InfoYourAccount.Visibility = Visibility.Hidden;
            InfoYourAccount.Focusable = false;

            InfoSettings.Visibility = Visibility.Visible;
            InfoSettings.Focusable = true;

            Headline.Text = "Settings";

            settings.getSave();
        }

        private void ButtonRegister_Click(object sender, RoutedEventArgs e)
        {
            string browser = "https://github.com/CVSAzubis2023/Fyn";
            try
            {
                System.Diagnostics.Process.Start(browser);
            }
            catch
            {
                MessageBox.Show("Coudnt start a browser!");
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            double value;
            value = VolumeSlider.Value;
            Debug.WriteLine(value);
            settings.setVolume(value);
        }

        private void CmbBoxSaving_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (CmbBoxSaving.SelectedItem)
            {
                case "Save":
                    settings.setSave("save");
                    Debug.WriteLine("Save");
                    break;
                case "Dont Save":
                    settings.setSave("dontSave");
                    Debug.WriteLine("Dont Save");
                    break;
                default:
                    break;
            }
        }

        private void CmbBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (CmbBox.SelectedItem)
            {
                case "Einfach":
                    Debug.WriteLine("Einfach");
                    break;
                case "Normal":
                    Debug.WriteLine("Normal");
                    break;
                case "Schwer":
                    Debug.WriteLine("Schwer");
                    break;
                case "Experte":
                    Debug.WriteLine("Experte");
                    break;
            }
        }

        private void ButtonSaveChanges_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
