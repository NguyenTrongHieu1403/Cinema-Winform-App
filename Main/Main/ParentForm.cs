using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Main
{
    public partial class ParentForm : Form
    {
        private string currentSearchName = "";
        private string currentSearchStyle = "";
        private int currentPage = 0;
        private int moviesPerPage = 4; // Số lượng phim trên mỗi trang
        private int totalMovies;
        private List<MoviePanel> moviePanels = new List<MoviePanel>();
        private List<Movie> allMovies;
        private string Username;

        public ParentForm(string username)
        {
            InitializeComponent();
            InitializeGenreComboBox();
            this.StartPosition = FormStartPosition.CenterScreen;
            LoadMoviesFromDatabase();
            totalMovies = allMovies.Count;
            DisplayMovies();
            this.Username = username;
        }

        public class Movie
        {
            public string DisplayName { get; set; }
            public int ReleaseYear { get; set; }
            public int GenreID { get; set; }
            public string GenreName { get; set; }
            public string ImagePath { get; set; }
            public decimal TicketPrice { get; set; }
            public int SeatQuantity { get; set; }
            public string RoomName { get; set; }

            public Movie(string displayName, int releaseYear, int genreID, string genreName, string imagePath, decimal ticketPrice, int seatQuantity, string roomName)
            {
                DisplayName = displayName;
                ReleaseYear = releaseYear;
                GenreID = genreID;
                GenreName = genreName;
                ImagePath = imagePath;
                TicketPrice = ticketPrice;
                SeatQuantity = seatQuantity;
                RoomName = roomName;
            }
        }

        private Dictionary<int, string> LoadGenresFromDatabase()
        {
            string connectionString = "Data Source=LAPTOP-96IDN57Q\\LAPTRINH2024;Initial Catalog=DBAA;Integrated Security=True;";
            string query = "SELECT id, GenreName FROM Genre";

            Dictionary<int, string> genres = new Dictionary<int, string>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(reader.GetOrdinal("id"));
                            string genreName = reader.GetString(reader.GetOrdinal("GenreName"));
                            genres[id] = genreName;
                        }
                    }
                }
            }
            return genres;
        }

        private void InitializeGenreComboBox()
        {
            Dictionary<int, string> genres = LoadGenresFromDatabase();
            comboBoxMovieStyle.Items.Clear();

            foreach (var genre in genres.Values)
            {
                comboBoxMovieStyle.Items.Add(genre);
            }
        }

        private void LoadMoviesFromDatabase()
        {
            try
            {
                // Lấy danh sách thể loại từ cơ sở dữ liệu
                Dictionary<int, string> genres = LoadGenresFromDatabase();

                // Khởi tạo connection string
                string connectionString = "Data Source=LAPTOP-96IDN57Q\\LAPTRINH2024;Initial Catalog=CinemaDBAW;Integrated Security=True;";
                string query = @"
                    SELECT m.DisplayName, m.ReleaseYear, m.GenreID, m.Image, st.TicketPrice, r.SeatQuantity, r.RoomName
                    FROM Movie m
                    INNER JOIN ShowTime st ON m.id = st.MovieID
                    INNER JOIN ShowtimeSetting ss ON st.ShowtimeSettingID = ss.ID
                    INNER JOIN Room r ON ss.RoomID = r.ID";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // Khởi tạo danh sách phim
                            allMovies = new List<Movie>();

                            // Đọc từng dòng dữ liệu và thêm vào danh sách phim
                            while (reader.Read())
                            {
                                string displayName = reader.GetString(reader.GetOrdinal("DisplayName"));
                                int releaseYear = reader.GetInt32(reader.GetOrdinal("ReleaseYear"));
                                int genreID = reader.GetInt32(reader.GetOrdinal("GenreID"));
                                string imagePath = reader.GetString(reader.GetOrdinal("Image")); // Đọc cột Image
                                decimal ticketPrice = reader.GetDecimal(reader.GetOrdinal("TicketPrice")); // Đọc cột TicketPrice
                                int seatQuantity = reader.GetInt32(reader.GetOrdinal("SeatQuantity")); // Đọc cột SeatQuantity
                                string roomName = reader.GetString(reader.GetOrdinal("RoomName")); // Đọc cột RoomName

                                // Lấy tên thể loại từ dictionary
                                string genreName = genres.ContainsKey(genreID) ? genres[genreID] : "Unknown Genre";

                                // Tạo đối tượng phim và thêm vào danh sách
                                allMovies.Add(new Movie(displayName, releaseYear, genreID, genreName, imagePath, ticketPrice, seatQuantity, roomName));
                            }
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("Lỗi cơ sở dữ liệu: " + sqlEx.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayMovies()
        {
            // Xóa các UserControl phim hiện có trong panelMovie
            foreach (MoviePanel panel in moviePanels)
            {
                panel.Dispose();
            }
            moviePanels.Clear();

            int paddingBetweenMoviePanels = 10; // Khoảng cách giữa các MoviePanel
            int moviePanelWidth = (panelMovies.Width - (moviesPerPage + 1) * paddingBetweenMoviePanels) / moviesPerPage; // Tính toán chiều rộng của mỗi MoviePanel
            int moviePanelHeight = 430; // Chiều cao của mỗi MoviePanel, bạn có thể thay đổi nếu cần

            // Hiển thị các UserControl phim trên PanelMovies
            int startIndex = currentPage * moviesPerPage;
            int endIndex = Math.Min(startIndex + moviesPerPage, totalMovies);

            int x = paddingBetweenMoviePanels;
            int y = paddingBetweenMoviePanels;

            for (int i = startIndex; i < endIndex; i++)
            {
                Movie movie = allMovies[i];
                MoviePanel moviePanel = new MoviePanel();
                moviePanel.SetMovieImage(movie.ImagePath);
                moviePanel.SetMovieName(movie.DisplayName);
                moviePanel.SetMovieStyle(movie.GenreName);
                moviePanel.SetMovieRating(movie.ReleaseYear);

                moviePanel.Size = new Size(moviePanelWidth, moviePanelHeight);
                moviePanel.Location = new Point(x, y);

                panelMovies.Controls.Add(moviePanel);
                moviePanels.Add(moviePanel);

                // Thêm sự kiện Click cho UserControl phim
                moviePanel.Click += (sender, e) => MoviePanel_Click(movie);
                moviePanel.RegisterPictureBoxClick((sender, e) => MoviePanel_Click(movie));

                x += moviePanelWidth + paddingBetweenMoviePanels;
            }

            // Cập nhật trạng thái của nút điều hướng
            btnPrevious.Enabled = currentPage > 0;
            btnNext.Enabled = endIndex < totalMovies;
        }

        private void MoviePanel_Click(Movie movie)
        {
            // Hiển thị form đặt ghế khi người dùng nhấp vào một MoviePanel
            ShowSeatBookingForm(movie);
        }

        private void ShowSeatBookingForm(Movie movie)
        {
            SeatBookingForm seatBookingForm = new SeatBookingForm(movie);
            seatBookingForm.ShowDialog();
            this.Close();
        }


        private void comboBoxMovieStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedStyle = comboBoxMovieStyle.SelectedItem.ToString();
            currentSearchStyle = selectedStyle; // Lưu trạng thái tìm kiếm theo thể loại phim
            SearchByStyle(selectedStyle);
        }

        private void SearchByStyle(string style)
        {
            // Xóa các UserControl phim hiện có trong panelMovie
            foreach (MoviePanel panel in moviePanels)
            {
                panel.Dispose();
            }
            moviePanels.Clear();

            int moviesPerRow = 4;
            int paddingBetweenMoviePanels = 10;
            int moviePanelWidth = (panelMovies.Width - (moviesPerRow + 1) * paddingBetweenMoviePanels) / moviesPerRow;
            int moviePanelHeight = 450;

            int x = paddingBetweenMoviePanels;
            int y = paddingBetweenMoviePanels;
            int movieCount = 0;

            foreach (Movie movie in allMovies)
            {
                if (movie.GenreName.ToLower() == style.ToLower())
                {
                    MoviePanel moviePanel = new MoviePanel();
                    moviePanel.SetMovieImage(movie.ImagePath);
                    moviePanel.SetMovieName(movie.DisplayName);
                    moviePanel.SetMovieStyle(movie.GenreName);
                    moviePanel.SetMovieRating(movie.ReleaseYear);

                    moviePanel.Size = new Size(moviePanelWidth, moviePanelHeight);
                    moviePanel.Location = new Point(x, y);

                    panelMovies.Controls.Add(moviePanel);
                    moviePanels.Add(moviePanel);

                    moviePanel.Click += (sender, e) => MoviePanel_Click(movie);
                    moviePanel.RegisterPictureBoxClick((sender, e) => MoviePanel_Click(movie));

                    x += moviePanelWidth + paddingBetweenMoviePanels;
                    movieCount++;

                    if (movieCount % moviesPerRow == 0)
                    {
                        x = paddingBetweenMoviePanels;
                        y += moviePanelHeight + paddingBetweenMoviePanels;
                    }
                }
            }

            // Cập nhật trạng thái của nút điều hướng
            btnPrevious.Enabled = currentPage > 0;
            btnNext.Enabled = moviePanels.Count > moviesPerPage * currentPage + moviesPerPage;
        }

        private string RemoveAccents(string input)
        {
            string normalizedString = input.Normalize(NormalizationForm.FormD);
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string result = regex.Replace(normalizedString, string.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
            return result.ToLower();
        }

        private void textBoxMovieName_TextChanged(object sender, EventArgs e)
        {
            string inputName = RemoveAccents(textBoxMovieName.Text.Trim().ToLower());
            currentSearchName = inputName; // Lưu trạng thái tìm kiếm theo tên phim
            SearchByName(inputName);
        }

        private void SearchByName(string name)
        {
            // Xóa các UserControl phim hiện có trong panelMovie
            foreach (MoviePanel panel in moviePanels)
            {
                panel.Dispose();
            }
            moviePanels.Clear();

            int moviesPerRow = 4;
            int paddingBetweenMoviePanels = 10;
            int moviePanelWidth = (panelMovies.Width - (moviesPerRow + 1) * paddingBetweenMoviePanels) / moviesPerRow;
            int moviePanelHeight = 450;

            int x = paddingBetweenMoviePanels;
            int y = paddingBetweenMoviePanels;
            int movieCount = 0;

            foreach (Movie movie in allMovies)
            {
                string movieNameWithoutAccents = RemoveAccents(movie.DisplayName);
                if (movieNameWithoutAccents.Contains(name))
                {
                    MoviePanel moviePanel = new MoviePanel();
                    moviePanel.SetMovieImage(movie.ImagePath);
                    moviePanel.SetMovieName(movie.DisplayName);
                    moviePanel.SetMovieStyle(movie.GenreName);
                    moviePanel.SetMovieRating(movie.ReleaseYear);

                    moviePanel.Size = new Size(moviePanelWidth, moviePanelHeight);
                    moviePanel.Location = new Point(x, y);

                    panelMovies.Controls.Add(moviePanel);
                    moviePanels.Add(moviePanel);

                    moviePanel.Click += (sender, e) => MoviePanel_Click(movie);
                    moviePanel.RegisterPictureBoxClick((sender, e) => MoviePanel_Click(movie));

                    x += moviePanelWidth + paddingBetweenMoviePanels;
                    movieCount++;

                    if (movieCount % moviesPerRow == 0)
                    {
                        x = paddingBetweenMoviePanels;
                        y += moviePanelHeight + paddingBetweenMoviePanels;
                    }
                }
            }

            // Cập nhật trạng thái của nút điều hướng
            btnPrevious.Enabled = currentPage > 0;
            btnNext.Enabled = moviePanels.Count > moviesPerPage * currentPage + moviesPerPage;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            currentPage++;
            // Sử dụng thông tin tìm kiếm hiện tại để hiển thị kết quả tương ứng
            if (!string.IsNullOrEmpty(currentSearchName))
            {
                SearchByName(currentSearchName);
            }
            else if (!string.IsNullOrEmpty(currentSearchStyle))
            {
                SearchByStyle(currentSearchStyle);
            }
            else
            {
                DisplayMovies(); // Hiển thị phim theo trang thông thường nếu không có tìm kiếm
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            currentPage--;
            if (!string.IsNullOrEmpty(currentSearchName))
            {
                SearchByName(currentSearchName);
            }
            else if (!string.IsNullOrEmpty(currentSearchStyle))
            {
                SearchByStyle(currentSearchStyle);
            }
            else
            {
                DisplayMovies();
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            LoadMoviesFromDatabase();
            DisplayMovies();
        }
    }
}
