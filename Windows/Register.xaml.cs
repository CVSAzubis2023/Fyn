using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

        public Register()
        {
            InitializeComponent();
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

            InfoRegister.Visibility = Visibility.Hidden;
            InfoRegister.Focusable = false;

            Headline.Text = "Your Account";
        }

        private void ButtonSettings_Click(object sender, RoutedEventArgs e)
        {
            InfoYourAccount.Visibility = Visibility.Hidden;
            InfoYourAccount.Focusable = false;

            InfoSettings.Visibility = Visibility.Visible;
            InfoSettings.Focusable = true;

            InfoRegister.Visibility = Visibility.Hidden;
            InfoRegister.Focusable = false;

            Headline.Text = "Settings";
        }

        private void ButtonRegister_Click(object sender, RoutedEventArgs e)
        {
            InfoYourAccount.Visibility = Visibility.Hidden;
            InfoYourAccount.Focusable = false;

            InfoSettings.Visibility = Visibility.Hidden;
            InfoSettings.Focusable = false;

            InfoRegister.Visibility = Visibility.Visible;
            InfoRegister.Focusable = true;

            Headline.Text = "Register";
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
    }
}
