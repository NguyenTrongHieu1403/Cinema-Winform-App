using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static Main.ShowtimeManager;

namespace Main
{
    public partial class AddShowtime : Form
    {
        private int RoomID;
        private int CinemaID;
        public AddShowtime(int roomId, int Cinemaid)
        {
            InitializeComponent();
            this.RoomID = roomId;
            this.CinemaID = Cinemaid;
        }

        private int GetMovieId(string movieName)
        {
            int movieId = -1; // Mặc định trả về -1 nếu không thành công

            try
            {
                using (SqlConnection connection = Connection.GetSqlConnection())
                {
                    connection.Open();

                    string movieQuery = @"
                        SELECT Id 
                        FROM Movie 
                        WHERE DisplayName = @MovieName";

                    using (SqlCommand command = new SqlCommand(movieQuery, connection))
                    {
                        command.Parameters.AddWithValue("@MovieName", movieName);

                        object result = command.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            movieId = Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return movieId;
        }

        private void AddShowtime_Load(object sender, EventArgs e)
        {
            LoadMovies();
            LoadRooms();
        }

        public class MovieItem
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public MovieItem(int id, string name)
            {
                Id = id;
                Name = name;
            }

            public override string ToString()
            {
                return Name;
            }
        }

        private void LoadMovies()
        {
            try
            {
                using (SqlConnection connection = Connection.GetSqlConnection())
                {
                    connection.Open();

                    string query = "SELECT id, DisplayName FROM Movie";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int movieId = reader.GetInt32(reader.GetOrdinal("Id"));
                            string movieName = reader.GetString(reader.GetOrdinal("DisplayName"));
                            moviecb.Items.Add(new MovieItem(movieId, movieName));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRooms()
        {
            try
            {
                using (SqlConnection connection = Connection.GetSqlConnection())
                {
                    connection.Open();

                    string query = "SELECT RoomName FROM Room WHERE TheaterID = @CinemaID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CinemaID", CinemaID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string roomName = reader.GetString(reader.GetOrdinal("RoomName"));
                                roomcb.Items.Add(roomName);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private string ConvertToHHMMSS(int durationInMinutes)
        {
            TimeSpan time = TimeSpan.FromMinutes(durationInMinutes);
            return time.ToString(@"hh\:mm\:ss");
        }
        private bool IsDuplicateShowtime(int roomId, TimeSpan startTime, DateTime showDate)
        {
            bool isDuplicate = false;

            try
            {
                // Lấy đối tượng phim được chọn từ ComboBox Movie
                MovieItem selectedMovie = (MovieItem)moviecb.SelectedItem;

                // Kiểm tra xem đối tượng có null không
                if (selectedMovie == null)
                {
                    MessageBox.Show("Vui lòng chọn phim.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return true;
                }

                // Lấy độ dài của phim từ cơ sở dữ liệu
                int movieDuration = GetMovieDuration(selectedMovie.Id);

                // Tính toán thời gian kết thúc của suất chiếu mới
                TimeSpan endTime = startTime.Add(TimeSpan.FromMinutes(movieDuration));
                if (endTime.TotalHours > 24)
                {
                    // Nếu thời gian kết thúc vượt quá 24 giờ, hiển thị thông báo lỗi và thoát
                    MessageBox.Show("Thời gian kết thúc vượt quá giới hạn của một ngày.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return true; // Trả về true để đánh dấu là có lỗi xảy ra
                }

                using (SqlConnection connection = Connection.GetSqlConnection())
                {
                    connection.Open();

                    string query = @"
        SELECT COUNT(*)
        FROM Showtime s
        INNER JOIN ShowtimeSetting ss ON s.ShowtimeSettingID = ss.Id
        WHERE ss.RoomID = @RoomID 
        AND CAST(s.StartTime AS TIME) >= CAST(@StartTime AS TIME)
        AND CAST(s.StartTime AS TIME) <= CAST(@EndTime AS TIME)
        AND CONVERT(date, ss.ShowDate) = CONVERT(date, @ShowDate)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@RoomID", roomId);
                        command.Parameters.AddWithValue("@StartTime", startTime);
                        command.Parameters.AddWithValue("@EndTime", endTime);
                        command.Parameters.AddWithValue("@ShowDate", showDate);

                        int count = (int)command.ExecuteScalar();
                        isDuplicate = count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi:" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return isDuplicate;
        }

        private TimeSpan GetPreviousShowEndTime(int roomId, DateTime showDate)
        {
            TimeSpan previousEndTime = TimeSpan.Zero;

            try
            {
                using (SqlConnection connection = Connection.GetSqlConnection())
                {
                    connection.Open();

                    string query = @"
        SELECT TOP 1 s.EndTime
        FROM Showtime s
        INNER JOIN ShowtimeSetting ss ON s.ShowtimeSettingID = ss.Id
        WHERE ss.RoomID = @RoomID 
        AND ss.ShowDate < @ShowDate
        ORDER BY ss.ShowDate DESC";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@RoomID", roomId);
                        command.Parameters.AddWithValue("@ShowDate", showDate);

                        object result = command.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            previousEndTime = (TimeSpan)result;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi:" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return previousEndTime;
        }



        private int GetMovieDuration(int movieId)
        {
            int movieDuration = 0; // Giá trị mặc định

            try
            {
                using (SqlConnection connection = Connection.GetSqlConnection())
                {
                    connection.Open();

                    string query = "SELECT Duration FROM Movie WHERE Id = @MovieId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MovieId", movieId);
                        object result = command.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            movieDuration = Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi:" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return movieDuration;
        }







        private void btnSave_Click(object sender, EventArgs e)
        {
            // Lấy giá trị của đối tượng được chọn trong ComboBox Movie
            MovieItem selectedMovie = (MovieItem)moviecb.SelectedItem;
            int movieId = selectedMovie.Id;
            string movieName = selectedMovie.Name;

            // Lấy giá trị từ các control trên form
            string st = stname.Text;
            string price = pricetb.Text;

            // Kiểm tra giá trị không được null
            if (selectedMovie == null || string.IsNullOrEmpty(st) || string.IsNullOrEmpty(price))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra giá phải là kiểu int
            if (!int.TryParse(price, out int priceInt))
            {
                MessageBox.Show("Giá phải là một số nguyên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Gán giá trị cho biến startTime từ control thời gian trên form
            TimeSpan startTime;
            if (!TimeSpan.TryParseExact(stname.Text, "hh\\:mm\\:ss", CultureInfo.InvariantCulture, out startTime))
            {
                MessageBox.Show("Thời gian không hợp lệ. Vui lòng nhập lại theo định dạng HH:mm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Xác định ngày muốn kiểm tra sự trùng lặp suất chiếu
            DateTime currentDate = StartTime.Value; // Giả sử có một DateTimePicker tên là showDatePicker

            // Tham số roomId cần được cung cấp từ nơi gọi hàm
            int roomId = RoomID;

            // Gọi hàm IsDuplicateShowtime để kiểm tra sự trùng lặp
            if (IsDuplicateShowtime(roomId, startTime, currentDate))
            {
                MessageBox.Show("Suất chiếu đã tồn tại cho phòng, thời gian và ngày này. Vui lòng chọn thời gian khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            TimeSpan timeSpan;


            // Lưu vào cơ sở dữ liệu
            try
            {
                using (SqlConnection connection = Connection.GetSqlConnection())
                {
                    connection.Open();

                    // Truy vấn để chèn giá trị mới vào bảng ShowtimeSetting và lấy Id của nó
                    string showtimeSettingQuery = @"
                INSERT INTO ShowtimeSetting (ShowDate, RoomID) 
                VALUES (@ShowDate, @RoomID);
                SELECT SCOPE_IDENTITY();";

                    int showtimeSettingId;

                    using (SqlCommand command = new SqlCommand(showtimeSettingQuery, connection))
                    {
                        command.Parameters.AddWithValue("@ShowDate", currentDate);
                        command.Parameters.AddWithValue("@RoomID", RoomID);
                        showtimeSettingId = Convert.ToInt32(command.ExecuteScalar());
                    }

                    // Truy vấn để chèn giá trị mới vào bảng Showtime
                    string showtimeQuery = @"
                INSERT INTO Showtime (StartTime, ShowtimeSettingID, MovieID, TicketPrice) 
                VALUES (@StartTime, @ShowtimeSettingID, @MovieID, @TicketPrice)";

                    using (SqlCommand command = new SqlCommand(showtimeQuery, connection))
                    {
                        command.Parameters.AddWithValue("@StartTime", startTime);
                        command.Parameters.AddWithValue("@ShowtimeSettingID", showtimeSettingId);
                        command.Parameters.AddWithValue("@MovieID", movieId);
                        command.Parameters.AddWithValue("@TicketPrice", priceInt);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Thêm suất chiếu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // Clear các control sau khi thêm thành công
                            stname.Clear();
                            pricetb.Clear();
                        }
                        else
                        {
                            MessageBox.Show("Thêm suất chiếu không thành công.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi:" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        private int GetShowtimeSettingId(DateTime showDate, int roomId)
        {
            int showtimeSettingId = -1; // Mặc định trả về -1 nếu không thành công

            try
            {
                using (SqlConnection connection = Connection.GetSqlConnection())
                {
                    connection.Open();

                    string showtimeSettingQuery = @"
                        SELECT ShowtimeSettingID 
                        FROM ShowtimeSetting 
                        WHERE ShowDate = @ShowDate AND RoomID = @RoomID";

                    using (SqlCommand command = new SqlCommand(showtimeSettingQuery, connection))
                    {
                        command.Parameters.AddWithValue("@ShowDate", showDate);
                        command.Parameters.AddWithValue("@RoomID", roomId);

                        object result = command.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            showtimeSettingId = Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }


            return showtimeSettingId;
        }

        private void lbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}