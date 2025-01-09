    using Guna.UI2.WinForms;
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
    using static Main.ShowtimeManager;


namespace Main
{
    public partial class ShowtimeManager : Form
    {
        private const string placeholderText = "Tìm kiếm...";

        int Cinemaid;

        public ShowtimeManager(int CinemaID)
        {
            InitializeComponent();
            Cinemaid = CinemaID;
            InitializePlaceholder();

        }
        private void InitializePlaceholder()
        {
            guna2TextBox1.Text = placeholderText;
            guna2TextBox1.ForeColor = Color.Gray;
        }
        private void LoadRooms()
        {
            try
            {
                // Khởi tạo danh sách các phòng
                List<Room> rooms = new List<Room>();

                // Kết nối đến cơ sở dữ liệu
                using (SqlConnection connection = Connection.GetSqlConnection())
                {
                    connection.Open();

                    // Truy vấn để lấy danh sách các phòng dựa trên CinemaID
                    string query = "SELECT id, RoomName FROM Room WHERE TheaterID = @CinemaID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Thêm tham số cho CinemaID
                        command.Parameters.AddWithValue("@CinemaID", Cinemaid);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // Đọc dữ liệu từ SqlDataReader và thêm vào danh sách phòng
                            while (reader.Read())
                            {
                                int roomId = Convert.ToInt32(reader["id"]);
                                string roomName = reader["RoomName"].ToString();
                                rooms.Add(new Room(roomId, roomName));
                            }
                        }
                    }
                }

                // Đổ dữ liệu từ danh sách phòng vào ComboBox
                roomcb.DataSource = rooms;
                roomcb.DisplayMember = "RoomName";
                roomcb.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu có
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        private int GetRoomID()
        {
            int roomId = 0;

            // Kết nối đến cơ sở dữ liệu
            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                connection.Open();

                // Truy vấn để lấy RoomID dựa trên CinemaID (ví dụ)
                string query = "SELECT id FROM Room WHERE TheaterID = @CinemaID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Thêm tham số cho CinemaID
                    command.Parameters.AddWithValue("@CinemaID", Cinemaid);

                    // Thực thi truy vấn và lấy giá trị RoomID
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        roomId = Convert.ToInt32(result);
                    }
                }
            }

            return roomId;
        }

        private void ShowtimeManager_Load(object sender, EventArgs e)
        {
            LoadRooms();
            LoadDataGridView(); // Gọi phương thức LoadDataGridView ở đây
        }

        // Định nghĩa class Room để lưu thông tin về phòng
        public class Room
        {
            public int Id { get; set; }
            public string RoomName { get; set; }

            public Room(int id, string roomName)
            {
                Id = id;
                RoomName = roomName;
            }
        }

        private void LoadDataGridView()
        {
            try
            {
                // Khởi tạo DataAdapter và DataTable
                using (SqlConnection connection = Connection.GetSqlConnection())
                {
                    connection.Open();

                    // Truy vấn để lấy thông tin từ bảng Movie, Showtime và Room
                    string query = @"
        SELECT 
            m.DisplayName, 
            m.Country, 
            m.Duration, 
            g.GenreName, 
            s.StartTime,
            s.id
        FROM 
            Movie m
        INNER JOIN 
            Showtime s ON m.id = s.MovieID
        INNER JOIN 
            Genre g ON m.GenreID = g.id
        INNER JOIN
            ShowtimeSetting ss ON s.ShowtimeSettingID = ss.id
        WHERE 
            ss.RoomID = @RoomID
    ";

                    int roomId = GetRoomID(); // Lấy giá trị RoomID
                                              // Tạo DataAdapter và DataTable
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@RoomID", roomId);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Xóa dữ liệu cũ trong DataGridView nếu có
                    guna2DataGridView1.Rows.Clear();

                    // Thêm dữ liệu vào DataGridView
                    foreach (DataRow row in dataTable.Rows)
                    {
                        string id = row["id"].ToString();
                        string movieName = row["DisplayName"].ToString();
                        string country = row["Country"].ToString();
                        int duration = Convert.ToInt32(row["Duration"]);
                        string genre = row["GenreName"].ToString();
                        string startTimeString = row["StartTime"].ToString();
                        TimeSpan startTime = TimeSpan.ParseExact(startTimeString, "hh\\:mm\\:ss", null);

                        // Thêm dữ liệu vào DataGridView
                        guna2DataGridView1.Rows.Add(id, movieName, country, duration, genre, startTime);
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu có
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        // Định nghĩa class MovieShowtime để lưu thông tin về phim, thời gian chiếu và phòng chiếu
        public class MovieShowtime
        {
            public int Id { get; set; }
            public string MovieName { get; set; }
            public string Country { get; set; }
            public int Duration { get; set; }
            public string Genre { get; set; }
            public TimeSpan StartTime { get; set; }

            public MovieShowtime(int id, string movieName, string country, int duration, string genre, TimeSpan startTime)
            {
                Id = id;
                MovieName = movieName;
                Country = country;
                Duration = duration;
                Genre = genre;
                StartTime = startTime;
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            int roomId = GetRoomID();
            // Sử dụng giá trị RoomID ở đây

            AddShowtime staffpro = new AddShowtime(roomId, Cinemaid);
            DialogResult result = staffpro.ShowDialog();

            // Kiểm tra kết quả trả về từ form StaffProperties
            if (result == DialogResult.OK)
            {
                // Nếu thêm nhân viên thành công, cập nhật lại dữ liệu
                LoadDataGridView();
            }
        }

        private void guna2TextBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(guna2TextBox1.Text))
            {
                InitializePlaceholder();
            }
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text != placeholderText)
            {
                string searchText = guna2TextBox1.Text.Trim();

                if (string.IsNullOrEmpty(searchText))
                {
                    LoadDataGridView();
                }
                else
                {
                    Search(searchText);
                }
            }
        }
        private void Search(string searchText)
        {
            // Clear old data from the DataGridView
            guna2DataGridView1.Rows.Clear();

            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                // Open connection
                connection.Open();

                string query = @"
SELECT 
    s.id AS ShowtimeID, 
    m.DisplayName, 
    m.Country, 
    m.Duration, 
    g.GenreName, 
    CONVERT(varchar, s.StartTime, 8) AS StartTime
FROM 
    Movie m
INNER JOIN 
    Showtime s ON m.id = s.MovieID
INNER JOIN 
    Genre g ON m.GenreID = g.id
INNER JOIN
    ShowtimeSetting ss ON s.ShowtimeSettingID = ss.id
WHERE 
    (m.DisplayName LIKE @SearchText OR
    m.Country LIKE @SearchText OR
    g.GenreName LIKE @SearchText OR
    CONVERT(varchar, s.StartTime, 8) LIKE @SearchText)
    AND
    ss.RoomID = @RoomID
";

                // Create SqlCommand object
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add search text parameter
                    command.Parameters.AddWithValue("@SearchText", "%" + searchText + "%");
                    // Add room ID parameter
                    int roomId = GetRoomID();
                    command.Parameters.AddWithValue("@RoomID", roomId);

                    // Execute the query and retrieve data
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Read each row of data and add to the DataGridView
                        while (reader.Read())
                        {
                            // Get values from columns in the table
                            int showtimeID = Convert.ToInt32(reader["ShowtimeID"]);
                            string movieName = reader["DisplayName"].ToString();
                            string country = reader["Country"].ToString();
                            int duration = Convert.ToInt32(reader["Duration"]);
                            string genre = reader["GenreName"].ToString();
                            string startTimeString = reader["StartTime"].ToString();
                            TimeSpan startTime = TimeSpan.ParseExact(startTimeString, "hh\\:mm\\:ss", null);

                            // Add data to DataGridView with only the columns needed to display
                            guna2DataGridView1.Rows.Add(showtimeID, movieName, country, duration, genre, startTime);
                        }
                    }
                }
            }
        }


        private void guna2TextBox1_Click(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text == placeholderText)
            {
                guna2TextBox1.Text = "";
                guna2TextBox1.ForeColor = Color.Black;
            }
        }


        private int GetShowtimeID(int rowIndex)
        {
            int showtimeID = 0;

            try
            {
                // Lấy giá trị RoomID từ dòng được chọn trong DataGridView
                int roomId = Convert.ToInt32(guna2DataGridView1.Rows[rowIndex].Cells["RoomID"].Value);

                // Lấy StartTime từ dòng được chọn trong DataGridView
                string startTime = guna2DataGridView1.Rows[rowIndex].Cells["StartTime"].Value.ToString();

                // Kết nối đến cơ sở dữ liệu và truy vấn để lấy ID của Showtime dựa trên RoomID và StartTime
                // ...

            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu có
                MessageBox.Show("Lỗi: " + ex.Message);
            }

            return showtimeID;
        }


        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == Column1.Index) // Column1 is the Edit button column
            {
                try
                {
                    // Lấy giá trị ShowtimeID từ dòng được chọn trong DataGridView và chuyển đổi nó thành int
                    int showtimeID = Convert.ToInt32(guna2DataGridView1.Rows[e.RowIndex].Cells["ID"].Value);

                    // Lấy giá trị RoomID từ dòng được chọn trong DataGridView (nếu cần thiết)
                    int roomID = GetRoomID();

                    // Truyền ShowtimeID và RoomID sang form EditShowtime
                    EditShowtime editShowtimeForm = new EditShowtime(showtimeID, roomID, Cinemaid);
                    DialogResult result = editShowtimeForm.ShowDialog();

                    // Kiểm tra kết quả trả về từ form EditShowtime
                    if (result == DialogResult.OK)
                    {
                        // Nếu chỉnh sửa thành công, cập nhật lại dữ liệu
                        LoadDataGridView();
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý ngoại lệ nếu có
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

    }
}