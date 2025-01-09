using Google.Apis.Admin.Directory.directory_v1.Data;
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

namespace Main
{
    public partial class MovieManager : Form
    {
        private const string placeholderText = "Tìm kiếm...";

        public MovieManager()
        {
            InitializeComponent();
            InitializePlaceholder();

        }
        private void InitializePlaceholder()
        {
            guna2TextBox1.Text = placeholderText;
            guna2TextBox1.ForeColor = Color.Gray;
        }

        private void LoadMovieDataIntoGridView()
        {
            // Clear old data from the DataGridView
            guna2DataGridView1.Rows.Clear();

            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                // Open connection
                connection.Open();

                // Query to get data from Movie and Genre tables
                string query = @"
                SELECT m.MovieID, m.DisplayName AS Movie_Name, m.Country, m.Director, 
                       m.GenreID AS GenreID, m.Duration
                FROM Movie m
                WHERE m.IsDeleted = 0";

                // Create SqlCommand object
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Execute the query and retrieve data
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Read each row of data and add to the DataGridView
                        while (reader.Read())
                        {
                            // Get values from columns in the table
                            string movieID = reader["MovieID"].ToString();
                            string movieName = reader["Movie_Name"].ToString();
                            string country = reader["Country"].ToString();
                            string director = reader["Director"].ToString();
                            string genreID = reader["GenreID"].ToString();
                            int duration = Convert.ToInt32(reader["Duration"]);

                            // Get genre name using genre ID
                            string genreName = GetGenreNameByGenreID(genreID);

                            // Add data to DataGridView with only the columns needed to display
                            guna2DataGridView1.Rows.Add(movieID, movieName, country, director, genreName, duration);
                        }
                    }
                }
            }
        }

        private string GetGenreNameByGenreID(string genreID)
        {
            string genreName = ""; // Khởi tạo giá trị mặc định là rỗng

            // Kết nối đến cơ sở dữ liệu
            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                // Mở kết nối
                connection.Open();

                // Kiểm tra xem genreID có tồn tại trong cơ sở dữ liệu không
                string checkExistQuery = "SELECT COUNT(*) FROM Genre WHERE id = @GenreID";
                using (SqlCommand checkExistCommand = new SqlCommand(checkExistQuery, connection))
                {
                    checkExistCommand.Parameters.AddWithValue("@GenreID", genreID);
                    int count = (int)checkExistCommand.ExecuteScalar();
                    if (count > 0)
                    {
                        // Nếu genreID tồn tại, thực hiện truy vấn để lấy genreName
                        string query = "SELECT GenreName FROM Genre WHERE id = @GenreID";

                        // Tạo đối tượng SqlCommand
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            // Thêm tham số cho GenreID vào truy vấn
                            command.Parameters.AddWithValue("@GenreID", genreID);

                            // Thực thi truy vấn và lấy giá trị GenreName
                            object result = command.ExecuteScalar();

                            // Kiểm tra kết quả trả về, nếu không null thì gán giá trị vào biến genreName
                            if (result != null)
                            {
                                genreName = result.ToString();
                            }
                        }
                    }
                }
            }

            return genreName;
        }



        private void addMovie_Click(object sender, EventArgs e)
        {
            AddMovie staffpro = new AddMovie();
            DialogResult result = staffpro.ShowDialog();

            // Kiểm tra kết quả trả về từ form StaffProperties
            if (result == DialogResult.OK)
            {
                // Nếu thêm nhân viên thành công, cập nhật lại dữ liệu
                LoadMovieDataIntoGridView();
            }
        }

        private void MovieManager_Load(object sender, EventArgs e)
        {
            LoadMovieDataIntoGridView();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == Column1.Index)
            {
                // Lấy ID của phim từ dòng được chọn
                string movieID = guna2DataGridView1.Rows[e.RowIndex].Cells["ID"].Value.ToString();

                // Chuyển đến form chỉnh sửa phim và truyền ID vào constructor
                EditMovie editMovieForm = new EditMovie(movieID);
                editMovieForm.ShowDialog();

                // Cập nhật lại dữ liệu sau khi chỉnh sửa
                LoadMovieDataIntoGridView();
            }
            else if (e.RowIndex >= 0 && e.ColumnIndex == Column2.Index)
            {
                // Xử lý sự kiện xóa phim
                string movieID = guna2DataGridView1.Rows[e.RowIndex].Cells["ID"].Value.ToString();
                string movieName = guna2DataGridView1.Rows[e.RowIndex].Cells["Movie_Name"].Value.ToString();

                // Hiển thị hộp thoại xác nhận
                DialogResult result = MessageBox.Show($"Bạn có muốn xóa phim '{movieName}' không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Nếu người dùng chọn Yes, thực hiện xóa phim
                    DeleteMovie(movieID);
                }
            }
        }
        private void DeleteMovie(string movieID)
        {
            // Cập nhật trường IsDeleted thành 1 cho phim có ID tương ứng
            string deleteMovieQuery = "UPDATE Movie SET IsDeleted = 1 WHERE ID = @MovieID";

            // Kết nối đến cơ sở dữ liệu và thực thi truy vấn
            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                connection.Open();

                // Cập nhật trường IsDeleted
                using (SqlCommand command = new SqlCommand(deleteMovieQuery, connection))
                {
                    command.Parameters.AddWithValue("@MovieID", movieID);
                    int rowsAffected = command.ExecuteNonQuery();
                }
            }

            // Hiển thị thông báo sau khi cập nhật trường IsDeleted
            MessageBox.Show("Đã đánh dấu phim đã bị xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadMovieDataIntoGridView();
        }


        private void guna2TextBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(guna2TextBox1.Text))
            {
                InitializePlaceholder();
            }
        }
        private void SearchAndDisplayResults(string searchText)
        {
            // Clear old data from the DataGridView
            guna2DataGridView1.Rows.Clear();

            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                // Open connection
                connection.Open();

                // Query to search for movies based on the provided search text
                string query = @"
                    SELECT m.MovieID, m.DisplayName AS Movie_Name, m.Country, m.Director, 
                           m.GenreID AS GenreID, m.Duration
                    FROM Movie m
                    INNER JOIN Genre g ON m.GenreID = g.id
                    WHERE m.IsDeleted = 0
                      AND (m.DisplayName LIKE @SearchText OR m.MovieID LIKE @SearchText
                           OR m.Country LIKE @SearchText
                           OR m.Director LIKE @SearchText
                           OR g.GenreName LIKE @SearchText)"; // Thêm điều kiện tìm kiếm cho Genre

                // Create SqlCommand object
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add search text parameter
                    command.Parameters.AddWithValue("@SearchText", "%" + searchText + "%");

                    // Execute the query and retrieve data
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Read each row of data and add to the DataGridView
                        while (reader.Read())
                        {
                            // Get values from columns in the table
                            string movieID = reader["MovieID"].ToString();
                            string movieName = reader["Movie_Name"].ToString();
                            string country = reader["Country"].ToString();
                            string director = reader["Director"].ToString();
                            string genreID = reader["GenreID"].ToString();
                            int duration = Convert.ToInt32(reader["Duration"]);

                            // Get genre name using genre ID
                            string genreName = GetGenreNameByGenreID(genreID);

                            // Add data to DataGridView with only the columns needed to display
                            guna2DataGridView1.Rows.Add(movieID, movieName, country, director, genreName, duration);
                        }
                    }
                }
            }
        }


        private void guna2TextBox1_Enter(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text == placeholderText)
            {
                guna2TextBox1.Text = "";
                guna2TextBox1.ForeColor = Color.Black;
            }
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text != placeholderText)
            {
                string searchText = guna2TextBox1.Text.Trim();

                if (string.IsNullOrEmpty(searchText))
                {
                    LoadMovieDataIntoGridView();
                }
                else
                {
                    SearchAndDisplayResults(searchText);
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
    }
}
