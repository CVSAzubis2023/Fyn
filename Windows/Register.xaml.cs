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

        void createPlayer()
        {
            /*
                Connect to sql server
                Insert into
                    User with name, password hash, rest should be set to 0
                close connection
             */
        }

        bool checkInput()
        {
            /*
                Check if the input Name is a valid string
                check if the password is a valid string an can be turned into a byte array
                return true/false
             */

            return false;
        }

        private void RegisterNow_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonYourAccount_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonSettings_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonRegister_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
