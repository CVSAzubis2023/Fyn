using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Pac_Man
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private login login = new login();

        public MainWindow()
        {
            InitializeComponent();
            login.conenctSQL();
            TextBlockHeadLine.Text = "Login";
        }

        private void ButtonClose_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ButtonMinimize_OnClick(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void ButtonToggleSize_OnClick(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;
            }
            else
            {
                this.WindowState = WindowState.Normal;
            }
        }
        
        private void LoginButton_OnClick(object sender, RoutedEventArgs e)
        {
            login.setPassword(PwBox.Password.ToString());
            login.setName(TextBoxName.Text.ToString());
            if (login.testCredentials() == true)
            {
                Debug.WriteLine("Worked");
                Game game = new Game();
                game.Show();
            }
            else
            {
                Debug.WriteLine("Didnt work");
            }
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}