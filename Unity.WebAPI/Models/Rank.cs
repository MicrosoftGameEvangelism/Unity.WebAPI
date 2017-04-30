using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Unity.WebAPI.Models
{
    public class Rank   
    {
        public Rank() { }
        public Rank(string defaultConnection)
        {
            ConnectionString = defaultConnection;
        }

        public string Nickname { get; set; }
        public int Score { get; set; }
        public string ConnectionString { get; set; }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
        
        public List<Rank> All()
        {
            List<Rank> list = new List<Rank>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand("SELECT * FROM ranktbl ORDER BY SCORE DESC", conn);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Rank()
                        {
                            Nickname = reader.GetString("nickname"),
                            Score = reader.GetInt32("score")
                        });
                    }
                    conn.Close();
                }
            }

            return list;
        }
        public Rank Search(string nickname)
        {
            Rank list = new Rank();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand("SELECT * FROM ranktbl WHERE nickname='"+nickname+"'", conn);
                MySqlDataReader reader = command.ExecuteReader();

                while(reader.Read())
                {
                    list.Nickname = reader.GetString("nickname");
                    list.Score = reader.GetInt32("score");
                }

                conn.Close();
            }
            
            return list;
        }
        public void Insert(string nickname, int score)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand("INSERT ranktbl (nickname, score) VALUES (@nickname, @score)", conn);
                command.Parameters.Add("@nickname", MySqlDbType.String);
                command.Parameters.Add("@score", MySqlDbType.Int32);
                command.Parameters["@nickname"].Value = nickname.ToString();
                command.Parameters["@score"].Value = score;

                command.ExecuteNonQuery();
                conn.Close();
            }
        }   
    }
}
