using System;
using Microsoft.SqlServer;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Pac_Man.Login
{
    internal class savingscores
    {
        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

        private string name;

        private int score;
        private int level;
        private int moves;
        private int timesplayed;
        private int highscore;
        private double playtime;

        private string sql = "Nein\\SQLEXPRESS";
        private string user = "sa";
        private string password = "applesauce/2";
        private string database = "Test";

        #region Constructor

        public savingscores(string name, int score, int level, int moves, int timesplayed, int highscore ,double playtime)
        {
            this.name = name;
            this.score = score;
            this.level = level;
            this.moves = moves;
            this.timesplayed = timesplayed;
            this.highscore = highscore;
            this.playtime = playtime;
        }

        #endregion

        public void SQLSetup()
        {
            builder.ConnectionString = sql;
            builder.UserID = user;
            builder.Password = password;
            builder.InitialCatalog = database;
        }

        public bool saveScores()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    string setNewLatestScore = "INSERT INTO dbo.Table_1 (Score, Highscore, Timesplayed, Playtime) VALUES (@score, @highscore, @timesplayed, @playtime) WHERE Name = '" + name + "'";

                    using (SqlCommand cmd = new SqlCommand(setNewLatestScore, connection))
                    {
                        cmd.Parameters.Add("@score", System.Data.SqlDbType.Int).Value = score;
                        cmd.Parameters.Add("@timesplayed", System.Data.SqlDbType.Int).Value = (timesplayed+1);
                        cmd.Parameters.Add("@playtime", System.Data.SqlDbType.Float).Value = playtime;
                        if (score > highscore)
                        {
                            cmd.Parameters.Add("@highscore", System.Data.SqlDbType.Int).Value = score;
                        }

                        connection.Open();

                        cmd.ExecuteNonQuery();

                        connection.Close();
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
