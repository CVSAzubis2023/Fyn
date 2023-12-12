using Microsoft.Win32;
using Pac_Man.Windows;
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
        //private log log = new log();
        
        public MainWindow()
        {
            InitializeComponent();
            login.conenctSQL();
            //log.createLog();

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
                //log.updateLog("Login succesfull, starting game");
                Game game = new Game(TextBoxName.Text);
                game.Show();
                this.Close();
            }
            else{
                MessageBox.Show("Wrong Creds");
            }
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            login.setName(TextBoxName.Text.ToString());
            login.setPassword(PwBox.Password.ToString());
            if (login.testCredentials() == true)
            {
                Register register = new Register();
                register.setDetails(TextBoxName.Text.ToString(), PwBox.Password.ToString());

                if (true/*register.getInfo() == true*/)
                {
                    register.Show();
                    this.Close();
                }
                
            }
            else
            {
                MessageBoxButton buttons = MessageBoxButton.YesNo;

                string message = "Error while logging in, do you want to register?";
                string caption = "Error while logging in";

                var result = MessageBox.Show(message, caption, buttons);

                switch (result)
                {
                    case MessageBoxResult.Yes:
                        string browser = "https://github.com/CVSAzubis2023/Fyn";
                        try
                        {
                            System.Diagnostics.Process.Start(browser);
                        }
                        catch
                        {
                            MessageBox.Show("Coudnt start a browser!");
                        }
                        break;
                    case MessageBoxResult.No:
                        break;
                }
            }
        }

        private void NoLoginPlay_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Work in Progress!");
            //gameNoLogin game = new gameNoLogin();
            //game.Show();
            //this.Close();
        }
    }
}