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

        private string name;
        private string password;

        public Register()
        {
            InitializeComponent();

            DataContext = new Viewmodel();

            getInfo();
        }

        public void getInfo()
        {
            if(myacc.setInfo() == true)
            {
                setInfo();
            }
        }

        public void setInfo() 
        {
            YourName.Text = myacc.getName();
            YourPassword.Text = myacc.getPassword();
            TimesPlayed.Text = myacc.getTimesPlayed();
            YourLatestScore.Text = myacc.getLastScore();
            YourHighscore.Text = myacc.getHighScore();
        }

        public void setDetails(string nameInput, string passwordInput)
        {
            name = nameInput;
            password = passwordInput;
        }

        void connectSQL()
        {
            builder.ConnectionString = "FDEU-131\\SQLEXPRESS";
            builder.UserID = "sa";
            builder.Password = "applesauce/2";
            builder.InitialCatalog = "Test";
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
        }

        private void CmbBoxSaving_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (CmbBoxSaving.SelectedItem)
            {
                case "Save":
                    Debug.WriteLine("Save");
                    break;
                case "Dont Save":
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
                case "Hallo":
                    Debug.WriteLine("Hallo");
                    break;
                case "Blub":
                    Debug.WriteLine("Blub");
                    break;
                case "Blip":
                    Debug.WriteLine("Blip");
                    break;
                case "Blep":
                    Debug.WriteLine("Blep");
                    break;
            }
        }
    }
}
