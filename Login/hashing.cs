using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Windows.Input;
using System.Diagnostics;
using System.Windows;

namespace Pac_Man.Login
{
    internal class hashing
    {
        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
        SHA512 sha = SHA512.Create();

        private string pw;
        private string salt;

        private byte[] hash;

        public string setPW(string x)
        {
            pw = x;
            connectSQL();
            getSalt();
            return computeHash();
        }

        private void connectSQL()
        {
            builder.DataSource = "FDEU - 131\\SQLEXPRESS";
            builder.UserID = "sa";
            builder.Password = "applesauce/2";
            builder.InitialCatalog = "salt"; 
        }

        private void getSalt()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    string sql = "SELECT salt FROM dbo.Table_1";

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

            Debug.WriteLine(salt);
        }

        private string computeHash()
        {
            hash = sha.ComputeHash(Encoding.UTF8.GetBytes(pw + salt));
            var sb = new StringBuilder(hash.Length * 2);

            foreach (byte b in hash)
            {
                sb.Append(b.ToString("X2"));
            }

            return sb.ToString();
        }

    }
}
