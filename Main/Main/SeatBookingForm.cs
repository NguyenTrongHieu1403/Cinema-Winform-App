using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static Main.ParentForm;

namespace Main
{
    public partial class SeatBookingForm : Form
    {
        private string Username;
        public SeatBookingForm(string username)
        {
            InitializeComponent();

            // Lưu thông tin về phim được chọn, thời gian mua vé và giá vé vào các biến instance
            this.selectedMovie = movie;
            this.timeOfPurchase = timeOfPurchase;
            this.roomNumber = roomNumber;
            this.
            // Lưu RoomNumber vào biến instance roomNumber
            selectedMovie = movie;
            this.Username = username;
        }
        private DateTime timeOfPurchase;
        // Phương thức để trả về thông tin về phim, thời gian mua vé và giá vé
        public (Movie, DateTime, string) GetBookingInfo()
        {
            return (selectedMovie, timeOfPurchase, roomNumber);
        }
        private List<Button> seats = new List<Button>();
        private string roomNumber; // Thêm biến để lưu số phòng

        public SeatBookingForm(ParentForm.Movie movie, DateTime timeOfPurchase, string roomNumber)
        {
            InitializeComponent();
            selectedMovie = movie;
            this.roomNumber = roomNumber; // Lưu số phòng
            DisplayMovieInfo();
            CreateSeats();
        }

        public SeatBookingForm(Movie movie)
        {
            InitializeComponent();
            selectedMovie = movie;
            this.StartPosition = FormStartPosition.CenterScreen;
            DisplayMovieInfo();
            CreateSeats();
        }

        private Movie selectedMovie;
        private Movie movie;
        private void DisplayMovieInfo()
        {
            string imagePath = selectedMovie.ImagePath;
            pictureBox1.Image = Image.FromFile(imagePath);
            lblMovieName.Text = selectedMovie.DisplayName;
            lblMovieStyle.Text = selectedMovie.GenreName;
            lblMovieRating.Text = selectedMovie.ReleaseYear.ToString();
            lblTotalSeats.Text = selectedMovie.SeatQuantity.ToString();
            lblgia1Ve.Text = selectedMovie.TicketPrice.ToString();
            lblRoomNumber.Text = selectedMovie.RoomName;
        }

        private void CreateSeats()
        {
            int numberOfSeats = selectedMovie.SeatQuantity; // Số lượng ghế dựa trên số phòng

            int seatsPerRow = 10; // Số ghế mỗi hàng
            int firstAndLastSeatSpacing = 30; // Khoảng cách giữa 2 ghế đầu và 2 ghế cuối mỗi hàng
            int secondAndThirdSeatSpacing = 10; // Khoảng cách giữa ghế số 2 và số 3

            int seatWidth = 60;
            int seatHeight = 60;
            int spacing = 5;

            int rows = numberOfSeats / seatsPerRow;

            char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

            // Lấy trạng thái ghế từ cơ sở dữ liệu
            Dictionary<string, bool> seatStatus = GetSeatStatusFromDatabase(selectedMovie.DisplayName);

            for (int row = 0; row < rows; row++)
            {
                for (int seat = 0; seat < seatsPerRow; seat++)
                {
                    Button btnSeat = new Button();

                    string seatName = $"{alphabet[row]}{(seat + 1)}";
                    btnSeat.Text = seatName;

                    btnSeat.Size = new Size(seatWidth, seatHeight);

                    int x;
                    if (seat == 0)
                    {
                        x = firstAndLastSeatSpacing;
                    }
                    else if (seat == 1)
                    {
                        x = firstAndLastSeatSpacing + seatWidth + secondAndThirdSeatSpacing;
                    }
                    else if (seat >= seatsPerRow - 2)
                    {
                        x = (seat - 2) * (seatWidth + spacing) + firstAndLastSeatSpacing * 2 + seatWidth * 2 + secondAndThirdSeatSpacing * 2 + spacing * 2;
                    }
                    else
                    {
                        x = (seat - 1) * (seatWidth + spacing) + firstAndLastSeatSpacing * 2 + seatWidth + secondAndThirdSeatSpacing;
                    }

                    int y = row * (seatHeight + spacing);
                    btnSeat.Location = new Point(x, y);
                    btnSeat.Click += BtnSeat_Click;

                    // Kiểm tra trạng thái ghế và cập nhật màu sắc
                    if (seatStatus.ContainsKey(seatName) && seatStatus[seatName])
                    {
                        btnSeat.BackColor = Color.Gray;
                    }

                    panelSeats.Controls.Add(btnSeat);
                    seats.Add(btnSeat);
                }
            }
            UpdateSeatLabels();
        }
        private void UpdateSeatLabels()
        {
            int totalSeats, bookedSeats, emptySeats;
            CountSeats(out totalSeats, out bookedSeats, out emptySeats);

            lblTotalSeats.Text = $"{totalSeats}";
            lblBookedSeats.Text = $"{bookedSeats}";
            lblEmptySeats.Text = $"{emptySeats}";
        }

        private void CountSeats(out int totalSeats, out int bookedSeats, out int emptySeats)
        {
            totalSeats = seats.Count;
            bookedSeats = 0;
            emptySeats = 0;

            foreach (Button btnSeat in seats)
            {
                if (btnSeat.BackColor == Color.Gray)
                {
                    bookedSeats++;
                }
                else if (btnSeat.BackColor == SystemColors.Control) // Assuming Green is the color for available seats
                {
                    emptySeats++;
                }
            }
        }
        private string connectionString = "Data Source=LAPTOP-96IDN57Q\\LAPTRINH2024;Initial Catalog=CinemaDBAW;Integrated Security=True;";
        private Dictionary<string, bool> GetSeatStatusFromDatabase(string movieName)
        {
            Dictionary<string, bool> seatStatus = new Dictionary<string, bool>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT s.SeatNumber, ss.Status
            FROM Seat s
            INNER JOIN SeatSetting ss ON s.id = ss.SeatID
            INNER JOIN ShowTime st ON ss.ShowtimeID = st.id
            INNER JOIN Movie m ON st.MovieID = m.id
            WHERE m.DisplayName = @DisplayName";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DisplayName", movieName);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string seatNumber = reader["SeatNumber"].ToString();
                        bool status = Convert.ToBoolean(reader["Status"]);
                        seatStatus[seatNumber] = status;
                    }
                }
            }

            return seatStatus;
        }
        private void SaveSeatBookingToDatabase(string movieName, string seatName, string roomName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    string insertSeatQuery = @"
                INSERT INTO Seat (SeatNumber, RoomID) 
                VALUES (@SeatNumber, (SELECT id FROM Room WHERE RoomName = @RoomName));
                SELECT SCOPE_IDENTITY();";

                    string insertSeatSettingQuery = @"
                INSERT INTO SeatSetting (SeatID, ShowtimeID, Status) 
                VALUES (@SeatID, @ShowtimeID, 'True');";

                    // Lấy ShowtimeID từ bảng ShowTime
                    int showtimeID;
                    string getShowtimeIDQuery = @"
                SELECT id
                FROM ShowTime
                WHERE MovieID = (SELECT id FROM Movie WHERE DisplayName = @DisplayName)";
                    using (SqlCommand showtimeIDCommand = new SqlCommand(getShowtimeIDQuery, connection, transaction))
                    {
                        showtimeIDCommand.Parameters.AddWithValue("@DisplayName", movieName);
                        showtimeID = Convert.ToInt32(showtimeIDCommand.ExecuteScalar());
                    }

                    // Thêm dữ liệu vào bảng Seat
                    using (SqlCommand command = new SqlCommand(insertSeatQuery, connection, transaction))
                    {
                        command.Parameters.AddWithValue("@SeatNumber", seatName);
                        command.Parameters.AddWithValue("@RoomName", roomName);

                        // Thực hiện câu lệnh INSERT và lấy SeatID của ghế vừa thêm vào
                        int seatID = Convert.ToInt32(command.ExecuteScalar());

                        // Thêm dữ liệu vào bảng SeatSetting với SeatID mới và trạng thái "True"
                        using (SqlCommand insertSettingCommand = new SqlCommand(insertSeatSettingQuery, connection, transaction))
                        {
                            insertSettingCommand.Parameters.AddWithValue("@SeatID", seatID);
                            insertSettingCommand.Parameters.AddWithValue("@ShowtimeID", showtimeID);
                            insertSettingCommand.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi nếu cần thiết
                    Console.WriteLine("Error: " + ex.Message);
                    transaction.Rollback();
                }
            }
        }
        private void BtnSeat_Click(object sender, EventArgs e)
        {
            Button btnSeat = (Button)sender;

            // Kiểm tra nếu ghế đã được đặt
            if (btnSeat.BackColor == Color.Gray)
            {
                // Hiển thị một cảnh báo
                MessageBox.Show("Ghế này đã được đặt!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Không thực hiện hành động tiếp theo
            }
            int currentGiaVe;
            if (!int.TryParse(lblGiaVe.Text.Replace(" đ", ""), out currentGiaVe))
            {
                // Xử lý nếu không thể chuyển đổi thành công
                MessageBox.Show("Lỗi: Không thể chuyển đổi giá vé thành số nguyên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Thay đổi màu sắc của ghế khi được chọn
            if (btnSeat.BackColor == Color.Red)
            {
                btnSeat.BackColor = SystemColors.Control; // Trả lại màu mặc định
                                                          // Trừ giá vé khi bỏ chọn ghế
                lblGiaVe.Text = (currentGiaVe - selectedMovie.TicketPrice) + " đ";
            }
            else
            {
                btnSeat.BackColor = Color.Red; // Màu sắc khi chọn ghế
                                               // Cộng giá vé khi chọn ghế
                lblGiaVe.Text = (currentGiaVe + selectedMovie.TicketPrice) + " đ";
            }
        }
        // Hàm để trả về số lượng ghế dựa trên số phòng
        private int GetTongGiaVe()
        {
            // Lấy tổng giá vé từ label TongGiaVe
            int tongGiaVe;
            if (!int.TryParse(lblGiaVe.Text.Replace(" đ", ""), out tongGiaVe))
            {
                // Xử lý nếu không thể chuyển đổi thành công
                MessageBox.Show("Lỗi: Không thể chuyển đổi tổng giá vé thành số nguyên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return tongGiaVe;
        }
        private int GetGia1Ve()
        {
            // Lấy tổng giá vé từ label TongGiaVe
            int gia1Ve;
            if (!int.TryParse(lblgia1Ve.Text.Replace(" đ", ""), out gia1Ve))
            {
                // Xử lý nếu không thể chuyển đổi thành công
                MessageBox.Show("Lỗi: Không thể chuyển đổi tổng giá vé thành số nguyên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return gia1Ve;
        }
        private string GetNumberRoom()
        {
            return lblRoomNumber.Text;
        }
        private void btnBook_Click(object sender, EventArgs e)
        {
            ShareData.MovieName = selectedMovie.DisplayName;
            ShareData.TimeOfPurchase = DateTime.Now;
            ShareData.Gia1Ve = GetGia1Ve();
            ShareData.TongGiaVe = GetTongGiaVe();
            ShareData.RoomNumber = GetNumberRoom();

            bool seatSelected = false;

            // Kiểm tra xem có ghế nào được chọn không
            foreach (Button btnSeat in seats)
            {
                if (btnSeat.BackColor == Color.Red)
                {
                    seatSelected = true;
                    // Thay đổi màu của ghế đã chọn thành màu Silver
                    btnSeat.BackColor = Color.Gray;
                    // Thêm ghế đã chọn vào danh sách ghế đã chọn
                    SharedData.SelectedSeats.Add(btnSeat.Text);
                    // Lưu ghế đã đặt vào cơ sở dữ liệu
                    SaveSeatBookingToDatabase(selectedMovie.DisplayName, btnSeat.Text, ShareData.RoomNumber);
                }
            }

            if (!seatSelected)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một ghế trước khi đặt vé!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Không thực hiện hành động tiếp theo nếu không có ghế nào được chọn
            }

            // Hiển thị thông báo xác nhận
            MessageBox.Show("Đặt vé thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Đặt vé thành công, sau đó mở form sản phẩm
            FormSanPham formSanPham = new FormSanPham(Username);
            formSanPham.ShowDialog();
            this.Close();
        }
        private void lblMovieName_Click(object sender, EventArgs e)
        {

        }
    }
}