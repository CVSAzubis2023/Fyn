﻿using System;
using Microsoft.SqlServer;
using System.Text;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Reflection;
using System.Windows;
using System.Diagnostics;

namespace Pac_Man
{
    public class login
    {
        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

        private string name;
        private string password;
        private int amount;

        public void conenctSQL()
        {
            //SQL Server Name
            builder.DataSource = "FDEU-131\\SQLEXPRESS";
            //SQL User Name
            builder.UserID = "sa";
            //SQL User Password
            builder.Password = "applesauce/2";
            //SQL Datebase
            builder.InitialCatalog = "Test";
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
            getCount();
            Debug.WriteLine(amount);

            string[,] test = new string[amount,amount];

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                string sql = "SELECT * FROM dbo.Table_1 WHERE Name AND Password";
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

                            if (((name == reader.GetString(0)) && (password == reader.GetString(1)) == true))
                            {
                                return true;
                            }
                        }
                        
                        MessageBox.Show("Wrong Credentials");
                        return false;
                    }
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
                }
            }
        }
    }
}