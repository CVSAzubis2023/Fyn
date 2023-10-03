using System;
using Microsoft.SqlServer;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace Pac_Man.Login
{
    internal class savingscores
    {
        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

        private int score;
        private int level;
        private int moves;

        private string sql = "FDEU-131\\SQLEXPRESS";
        private string user = "sa";
        private string password = "applesauce/2";
        private string database = "Test";

        private string player;
        private int line;

        private int amount;


        public void setScore(int x)
        {
            score = x;
        }

        public void setLevel(int x) 
        { 
            level = x;
        }

        public void setMoves(int x)
        {
            moves = x;
        }
        
        public void setLine(int x)
        {
            line = x;
        }

        public void setPlayer(string Name)
        {
            player = Name;
        }

        public void SQLSetup()
        {
            builder.ConnectionString = sql;
            builder.UserID = user;
            builder.Password = password;
            builder.InitialCatalog = database;
        }

        public void connectSQL()
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    string commandSQL = "SELECT Name FROM dbo.TABLE_1";
                    using (SqlCommand command = new SqlCommand(commandSQL, connection))
                    {
                        connection.Open();
                        using (SqlDataReader rd = command.ExecuteReader())
                        {
                            for (int i = 0;i < amount; i++)
                            {
                                rd.Read();
                                if (player == rd.GetString(0))
                                {
                                    line = i;
                                }
                            }
                        }
                    }
                }
            }
            catch
            {

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

        private void saveScores()
        {

        }
    }
}
