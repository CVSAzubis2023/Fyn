using System;
using Microsoft.SqlServer;
using System.Text;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Reflection;

namespace Pac_Man
{
    public class login
    {
        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

        private string name;
        private string password;

        public void conenctSQL()
        {
            //SQL Server Name
            builder.DataSource = "FDEU-131\\SQLEXPRESS";
            //SQL User Name
            builder.UserID = "sa";
            //SQL User Password
            builder.Password = "applesauce/2";
            //SQL Datebase
            builder.InitialCatalog = "test";
        }

        public void setName(string nm)
        {
            name = nm;
        }

        public void setPassword(string pw)
        {
            password = pw;
        }

        public bool testCredentials()
        {
            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                string sql = "SELECT * FROM dbo.Table_1";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if ((name == reader.GetString(0)) && (password == reader.GetString(1)) == true)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                }
            }

            if (name == "admin" && password == "test")
            {
                return true;
            }
            else
            {
                return false;
            }  
        }
    }
}