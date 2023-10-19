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

        public string setPW(string x, string y)
        {
            pw = x;
            salt = y;
            return computeHash();
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
