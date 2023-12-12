using System;
using Microsoft.SqlServer;
using System.Text;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Reflection;
using System.Windows;
using System.Diagnostics;
using Pac_Man.Login;

namespace Pac_Man
{
    public class login
    {
        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
        hashing hash = new hashing();

        private string name;
        private string password;
        private string salt;
        private int amount;

        public void conenctSQL()
        {
            //SQL Server Name
            builder.DataSource = "Nein\\SQLEXPRESS";
            //SQL User Name
            builder.UserID = "sa";
            //SQL User Password
            builder.Password = "applesauce/02";
            //SQL Datebase
            builder.InitialCatalog = "Test";
        }

        public void setName(string nm)
        {
            name = nm;
        }

        public void setPassword(string pw)
        {
            getSalt();

            if (name == "Admin")
            {
                password = pw;
            }

            else
            {
                password = hash.setPW(pw, salt);
            } 
        }

        public bool testCredentials()
        {
            bool nameTest = false;
            bool passwordTest = false;
            int rowNumber1 = 0;
            int rownumber2 = 0;

            if (name == "Admin")
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                    {
                        string sqlCommand = "SELECT Password FROM dbo.Table_1 WHERE Name = '" + name + "'";

                        using (SqlCommand cmd = new SqlCommand(sqlCommand, connection))
                        {
                            connection.Open();

                            using (SqlDataReader rd = cmd.ExecuteReader())
                            {
                                rd.Read();
                                if (rd.GetString(0) == password)
                                {
                                    nameTest = true;
                                    passwordTest = true;
                                }
                                else
                                {
                                    return false;
                                }
                            }

                            connection.Close();
                        }
                    }

                    if (nameTest && passwordTest)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                catch
                {
                    return false;
                }
            }

            else
            {
                getCount();
                getSalt();
                Debug.WriteLine(amount);

                try
                {
                    using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                    {
                        string sql = "SELECT Name FROM dbo.Table_1";
                        Debug.WriteLine(sql);

                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {
                            connection.Open();
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                for (int i = 0; i < amount; i++)
                                {
                                    reader.Read();
                                    Debug.WriteLine(reader.GetString(0));

                                    if (name == reader.GetString(0))
                                    {
                                        nameTest = true;
                                        rowNumber1 = i;
                                    }
                                }
                            }
                            connection.Close();
                        }

                        sql = "SELECT Password FROM dbo.Table_1";
                        Debug.WriteLine(sql);

                        using (SqlCommand cmd = new SqlCommand(sql, connection))
                        {
                            connection.Open();
                            using (SqlDataReader rd = cmd.ExecuteReader())
                            {
                                for (int j = 0; j < amount; j++)
                                {
                                    rd.Read();
                                    Debug.WriteLine(rd.GetString(0));

                                    if (password == rd.GetString(0))
                                    {
                                        passwordTest = true;
                                        rownumber2 = j;
                                    }
                                }
                            }
                            connection.Close();
                        }


                        if (((nameTest == true) && (passwordTest == true)) && (rowNumber1 == rownumber2))
                        {
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Wrong Credentials");
                            return false;
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Couldnt connect to SQL Server, starting without connection!");
                    return true;
                }
            } 
        }

        public void getCount()
        {
            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                string sqlCount = "SELECT COUNT(*) FROM dbo.Table_1";

                using (SqlCommand cmad = new SqlCommand(sqlCount, connection))
                {
                    connection.Open();

                    SqlDataReader rd = cmad.ExecuteReader();

                   while (rd.Read())
                   {
                        amount = rd.GetInt32(0);
                   }

                   connection.Close();
                }
            }
        }

        public void getSalt()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    string sql = "SELECT salt FROM dbo.Table_2";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            reader.Read();

                            salt = reader.GetString(0);
                        }
                        connection.Close();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error while connecting to SQL Server");
            }
        }
    }
}