using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    internal class Modified
    {

        public Modified()
        {
        }
        SqlCommand sqlCommand; //Try vấn các câu lệnh Insert, Update, Delete , ...
        SqlDataReader dataReader; //Đọc dữ liệu trong bảng
        public List<Account> Accounts(string query) //Check Tài khoản 
        {
            List<Account> accounts = new List<Account>();
            using (SqlConnection sqlConnection = Connection.GetSqlConnection())
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                dataReader = sqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    accounts.Add(new Account(dataReader.GetString(0), dataReader.GetString(1)));
                }
                sqlConnection.Close();
            }
            return accounts;
        }



        /*public List<Seat> Seats (string query)
        {
            List <Seat> seats = new List<Seat>();
            using (SqlConnection sqlConnection = Connection.GetSqlConnection())
            {
                sqlConnection.Open();
            }
        }*/

        /*public List<EditFilm> Films(string query)
        {
            List<EditFilm> films = new List<EditFilm>();
            using (SqlConnection sqlConnection = Connection.GetSqlConnection())
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                dataReader = sqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    *//* string vnName = dataReader.GetString(0);
                     string endName = dataReader.GetString(1);
                     int age = dataReader.GetInt32(2);
                     string genre = dataReader.GetString(3);
                     int duration = dataReader.GetInt32(4);
                     string img = dataReader.GetString(5);
                     string sustance = dataReader.GetString(6);
                     DateTime date = dataReader.GetDateTime(7);
                     string country = dataReader.GetString(8);
                     string trailer = dataReader.GetString(9);
                     string author = dataReader.GetString(10);
                     string actor = dataReader.GetString(11);

                     float vote = (float)dataReader.GetDouble(12);
                     films.Add(new EditFilm(vnName, endName, age, genre, duration, img, sustance, date, country, trailer, author, actor, vote));
                     *//*
                    films.Add(new EditFilm(
                        dataReader.GetString(0), // VnName
                        dataReader.GetString(1), // EndName
                        dataReader.GetInt32(2),  // Age
                        dataReader.GetString(3), // Genre
                        dataReader.GetInt32(4),  // Duration
                        dataReader.GetString(5), // Img
                        dataReader.GetString(6), // Sustance
                        dataReader.GetDateTime(7), // Date
                        dataReader.GetString(8), // Country
                        dataReader.GetString(9), // Trailer
                        dataReader.GetString(10), // Author
                        dataReader.GetString(11), // Actor
                        (float)dataReader.GetDouble(12) // Vote
                    ));

                }
                sqlConnection.Close();
            }
            return films;
        }*/




        public void Command(string query, string userName)//Đăng ký tài khoản ( Insert ) ...
        {
            using (SqlConnection sqlConnection = Connection.GetSqlConnection())
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.ExecuteNonQuery();// Thực thi câu truy vấn
                sqlConnection.Close();
            }
        }

        internal void Command(string query)
        {
            throw new NotImplementedException();
        }
    }
}


    
