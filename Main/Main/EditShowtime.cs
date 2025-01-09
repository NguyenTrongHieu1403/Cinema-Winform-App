using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using static Main.ShowtimeManager;

namespace Main
{
    public partial class EditShowtime : Form
    {
        private int RoomID;
        private int CinemaID;
        private int ShowtimeID;

        public EditShowtime(int showtimeID, int roomID, int cinemaID)
        {
            InitializeComponent();
            this.ShowtimeID = showtimeID;
            this.CinemaID = cinemaID;
            this.RoomID = roomID;
        }

        private void EditShowtime_Load(object sender, EventArgs e)
        {
            LoadMovies();
            LoadRooms();
            LoadShowtimeDetails();
        }

        private void LoadMovies()
        {
            try
            {
                using (SqlConnection connection = Connection.GetSqlConnection())
                {
                    connection.Open();

                    string query = "SELECT Id, DisplayName FROM Movie";

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

                    string query = "SELECT Id, RoomName FROM Room WHERE TheaterID = @CinemaID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CinemaID", CinemaID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int roomId = reader.GetInt32(reader.GetOrdinal("Id"));
                                string roomName = reader.GetString(reader.GetOrdinal("RoomName"));
                                roomcb.Items.Add(new RoomItem(roomId, roomName)); // Thêm Id vào RoomItem
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

        private void LoadShowtimeDetails()
        {
            try
            {
                using (SqlConnection connection = Connection.GetSqlConnection())
                {
                    connection.Open();

                    string query = @"
                SELECT st.MovieID, st.StartTime AS ShowStartTime, st.TicketPrice, m.DisplayName AS MovieName, r.RoomName, ss.ShowDate
                FROM Showtime st
                JOIN Movie m ON st.MovieID = m.Id
                JOIN ShowtimeSetting ss ON st.ShowtimeSettingID = ss.Id
                JOIN Room r ON ss.RoomID = r.Id
                WHERE st.Id = @ShowtimeID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ShowtimeID", ShowtimeID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                DateTime showDate = reader.GetDateTime(reader.GetOrdinal("ShowDate"));
                                TimeSpan startTime = reader.GetTimeSpan(reader.GetOrdinal("ShowStartTime")); // Thay đổi tên trường
                                decimal ticketPrice = reader.GetDecimal(reader.GetOrdinal("TicketPrice"));
                                string movieName = reader.GetString(reader.GetOrdinal("MovieName"));
                                string roomName = reader.GetString(reader.GetOrdinal("RoomName"));

                                // Hiển thị thông tin
                                StartTime.Value = showDate.Add(startTime); // Cập nhật giá trị cho DateTimePicker
                                pricetb.Text = ticketPrice.ToString("F2");
                                stname.Text = startTime.ToString();

                                // Set selected movie name in moviecb
                                foreach (var item in moviecb.Items)
                                {
                                    if (item is MovieItem movieItem && movieItem.Name == movieName)
                                    {
                                        moviecb.SelectedItem = movieItem;
                                        break;
                                    }
                                }

                                // Set selected room name in roomcb
                                foreach (var item in roomcb.Items)
                                {
                                    if (item is RoomItem roomItem && roomItem.Name == roomName)
                                    {
                                        roomcb.SelectedItem = roomItem;
                                        break;
                                    }
                                }
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Lấy các giá trị từ các điều khiển đầu vào
            DateTime showDateTime = StartTime.Value;
            DateTime showDate = showDateTime.Date;
            TimeSpan startTime = showDateTime.TimeOfDay;

            decimal ticketPrice;
            if (!decimal.TryParse(pricetb.Text, out ticketPrice))
            {
                MessageBox.Show("Vui lòng nhập giá vé hợp lệ!");
                return;
            }

            if (moviecb.SelectedItem == null || roomcb.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn phim và phòng!");
                return;
            }

            int movieId = ((MovieItem)moviecb.SelectedItem).Id;
            int roomId = ((RoomItem)roomcb.SelectedItem).Id;

            // Lưu thông tin vào cơ sở dữ liệu
            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                connection.Open();
                string query = @"
                    UPDATE Showtime
                    SET MovieID = @MovieID, StartTime = @StartTime, TicketPrice = @TicketPrice
                    WHERE Id = @ShowtimeID;

                    UPDATE ShowtimeSetting
                    SET ShowDate = @ShowDate, RoomID = @RoomID
                    WHERE ShowtimeID = @ShowtimeID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MovieID", movieId);
                    command.Parameters.AddWithValue("@StartTime", startTime);
                    command.Parameters.AddWithValue("@TicketPrice", ticketPrice);
                    command.Parameters.AddWithValue("@ShowDate", showDate);
                    command.Parameters.AddWithValue("@RoomID", roomId);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Chỉnh sửa suất chiếu thành công!");
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("Chỉnh sửa suất chiếu không thành công!");
                    }
                }
            }
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

        public class RoomItem
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public RoomItem(int id, string name)
            {
                Id = id;
                Name = name;
            }

            public override string ToString()
            {
                return Name;
            }
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            // Lấy các giá trị từ các điều khiển đầu vào
            DateTime showDateTime = StartTime.Value;
            DateTime showDate = showDateTime.Date;
            TimeSpan startTime = showDateTime.TimeOfDay;

            decimal ticketPrice;
            if (!decimal.TryParse(pricetb.Text, out ticketPrice))
            {
                MessageBox.Show("Vui lòng nhập giá vé hợp lệ!");
                return;
            }

            if (moviecb.SelectedItem == null || roomcb.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn phim và phòng!");
                return;
            }

            int movieId = ((MovieItem)moviecb.SelectedItem).Id;
            int roomId = ((RoomItem)roomcb.SelectedItem).Id;

            // Lưu thông tin vào cơ sở dữ liệu
            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                connection.Open();
                string query = @"
            UPDATE Showtime
            SET MovieID = @MovieID, StartTime = @StartTime, TicketPrice = @TicketPrice
            WHERE Id = @ShowtimeID;

            UPDATE ShowtimeSetting
            SET ShowDate = @ShowDate, RoomID = @RoomID
            WHERE Id = (SELECT ShowtimeSettingID FROM Showtime WHERE Id = @ShowtimeID)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ShowtimeID", ShowtimeID);
                    command.Parameters.AddWithValue("@MovieID", movieId);
                    command.Parameters.AddWithValue("@StartTime", startTime);
                    command.Parameters.AddWithValue("@TicketPrice", ticketPrice);
                    command.Parameters.AddWithValue("@ShowDate", showDate);
                    command.Parameters.AddWithValue("@RoomID", roomId);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Chỉnh sửa suất chiếu thành công!");
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("Chỉnh sửa suất chiếu không thành công!");
                    }
                }
            }
        }
        private void DeleteShowtime(int showtimeID)
        {
            // Xác nhận xóa từ người dùng
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa suất chiếu này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return; // Người dùng đã chọn không, không cần xóa
            }

            // Truy vấn SQL để xóa suất chiếu
            string deleteShowtimeQuery = "DELETE FROM Showtime WHERE Id = @ShowtimeID";

            try
            {
                // Kết nối đến cơ sở dữ liệu và thực thi truy vấn
                using (SqlConnection connection = Connection.GetSqlConnection())
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(deleteShowtimeQuery, connection))
                    {
                        command.Parameters.AddWithValue("@ShowtimeID", showtimeID);
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            // Hiển thị thông báo sau khi xóa thành công
                            MessageBox.Show("Suất chiếu đã được xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // Điều hướng hoặc reload dữ liệu nếu cần
                            // Ví dụ: ReloadShowtimeData();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy suất chiếu để xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DeleteShowtime(ShowtimeID);
            this.Close();
        }
    }
}


