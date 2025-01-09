using Google.Apis.Admin.Directory.directory_v1.Data;
using Guna.UI2.WinForms.Suite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace Main
{
    public partial class EditMovie : Form
    {
        private string MovieID;

        public EditMovie(string movieID)
        {
            InitializeComponent();
            MovieID = movieID;
        }

        private string GetGenreNameByGenreID(int genreID)
        {
            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                connection.Open();
                string query = "SELECT GenreName FROM Genre WHERE ID = @GenreID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@GenreID", genreID);
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        return result.ToString();
                    }
                }
            }
            return null;
        }



        private void EditMovie_Load(object sender, EventArgs e)
        {
            // Khởi tạo kết nối và command
            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                // Mở kết nối
                connection.Open();

                string query = @"
    SELECT m.DisplayName AS Movie_Name, m.Country, m.Director, 
           m.GenreID AS GenreID, m.Duration, m.ReleaseYear, m.Description, m.Image, m.Age_Required
    FROM Movie m
    WHERE m.MovieID = @MovieID";


                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Thêm tham số @MovieID vào command
                    command.Parameters.AddWithValue("@MovieID", MovieID);

                    // Thực thi truy vấn và đọc dữ liệu
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Kiểm tra xem có dữ liệu được trả về không
                        if (reader.Read())
                        {
                            // Đổ dữ liệu từ SqlDataReader vào các control trên form
                            tbName.Text = reader["Movie_Name"].ToString();
                            tbdirec.Text = reader["Director"].ToString();
                            tbYear.Text = reader["ReleaseYear"].ToString();
                            tbDuration.Text = reader["Duration"].ToString();
                            DescriptionTb.Text = reader["Description"].ToString();
                            string imagePath = reader["Image"].ToString();

                            // Load ảnh từ đường dẫn và gán cho PictureBox
                            if (!string.IsNullOrEmpty(imagePath))
                            {
                                picPhoto.Image = Image.FromFile(imagePath);
                                picPhoto.Tag = imagePath; // Lưu đường dẫn ảnh
                            }


                            // Load dữ liệu vào các ComboBox
                            LoadGenres(); // Call this method to populate the genre ComboBox
                            LoadCountries();
                            LoadAgeRestrictions();

                            // Lấy giá trị GenreID, Country và AgeRequired từ SqlDataReader
                            string genreID = reader["GenreID"].ToString();
                            string country = reader["Country"].ToString();
                            string ageRestriction = reader["Age_Required"].ToString();

                            // Chọn các mục tương ứng trong các ComboBox
                            SetSelectedValue(countrycb, country);
                            SetSelectedValue(age_recb, ageRestriction);

                            // Load dữ liệu vào ComboBox Genre từ bảng Genre
                            LoadGenres();

                            // Sau khi ComboBox Genre đã được load, tìm tên thể loại từ ID và thiết lập giá trị đã chọn
                            string genreName = GetGenreNameByGenreID(genreID);
                            SetSelectedValue(genrecb, genreName);
                        }
                        else
                        {
                            System.Windows.MessageBox.Show("Không tìm thấy thông tin phim!");
                        }
                    }
                }
            }
        }

        private string GetNextMovieID()
        {
            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                connection.Open();
                int numericPart = 1;
                string nextMovieID = "MV" + numericPart.ToString("D4"); // Bắt đầu với MV0001

                // Kiểm tra tính duy nhất của MovieID mới
                while (true)
                {
                    // Tạo câu truy vấn an toàn
                    string query = "SELECT COUNT(*) FROM Movie WHERE MovieID = @MovieID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Đặt tham số cho truy vấn SQL
                        command.Parameters.AddWithValue("@MovieID", nextMovieID);
                        // Kiểm tra xem MovieID mới đã tồn tại trong cơ sở dữ liệu chưa
                        int count = (int)command.ExecuteScalar();
                        // Nếu đã tồn tại, tăng numericPart lên 1 và kiểm tra lại
                        if (count > 0)
                        {
                            numericPart++;
                            nextMovieID = "MV" + numericPart.ToString("D4"); // Cập nhật MovieID mới
                        }
                        else
                        {
                            break; // MovieID mới là duy nhất, thoát khỏi vòng lặp
                        }
                    }
                }

                return nextMovieID;
            }
        }



        // Phương thức để lấy tên thể loại từ ID thể loại
        private string GetGenreNameByGenreID(string genreID)
        {
            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                connection.Open();
                string query = "SELECT GenreName FROM Genre WHERE ID = @GenreID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@GenreID", genreID);
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        return result.ToString();
                    }
                }
            }
            return null;
        }
        // Hàm thiết lập giá trị đã chọn cho ComboBox
        private void SetSelectedValue(ComboBox comboBox, string value)
        {
            for (int i = 0; i < comboBox.Items.Count; i++)
            {
                if (comboBox.Items[i].ToString() == value)
                {
                    comboBox.SelectedIndex = i;
                    break;
                }
            }
        }


        // Hàm load thể loại phim vào combobox
        private void LoadGenres()
        {
            genrecb.Items.Clear();
            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                connection.Open();
                string query = "SELECT GenreName FROM Genre";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            genrecb.Items.Add(reader["GenreName"].ToString());
                        }
                    }
                }
            }
        }

        // Hàm load quốc gia vào combobox
        private void LoadCountries()
        {
            countrycb.Items.Clear();
            countrycb.Items.AddRange(new string[] { "VN", "ENG", "KR", "TQ" }); // Thêm các quốc gia mẫu
        }

        // Hàm load độ tuổi vào combobox
        private void LoadAgeRestrictions()
        {
            age_recb.Items.Clear();
            age_recb.Items.AddRange(new string[] { "13+", "16+", "18+", "K+", "P+" }); // Thêm các độ tuổi mẫu
        }







        private void btnPhoto_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files (*.jpg, *.jpeg, *.png, *.gif, *.bmp)|*.jpg; *.jpeg; *.png; *.gif; *.bmp|All files (*.*)|*.*";
                openFileDialog.Title = "Choose an image";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedImagePath = openFileDialog.FileName;
                    picPhoto.Image = Image.FromFile(selectedImagePath);

                    // Lưu đường dẫn ảnh đã chọn
                    picPhoto.Tag = selectedImagePath;
                }
            }
        }
        private int GetGenreIDByGenreName(string genreName)
        {
            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                connection.Open();
                string query = "SELECT ID FROM Genre WHERE GenreName = @GenreName";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@GenreName", genreName);
                    object result = command.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out int genreID))
                    {
                        return genreID;
                    }
                }
            }
            return -1; // Trả về -1 nếu không tìm thấy GenreID tương ứng với tên thể loại
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có ảnh được chọn không
            if (picPhoto.Tag == null)
            {
                System.Windows.MessageBox.Show("Vui lòng tải ảnh!");
                return; // Dừng việc lưu nếu không có ảnh được chọn
            }

            // Lấy các giá trị từ các điều khiển đầu vào
            string avatar = picPhoto.Tag.ToString();
            string movieName = tbName.Text.Trim();
            string director = tbdirec.Text.Trim();
            string genreName = genrecb.SelectedItem != null ? genrecb.SelectedItem.ToString() : ""; // Kiểm tra xem có mục được chọn không
            string country = countrycb.SelectedItem != null ? countrycb.SelectedItem.ToString() : ""; // Kiểm tra xem có mục được chọn không
            string ageRestriction = age_recb.SelectedItem != null ? age_recb.SelectedItem.ToString() : ""; // Kiểm tra xem có mục được chọn không
            string description = DescriptionTb.Text.Trim();
            string durationText = tbDuration.Text.Trim();
            string releaseYearText = tbYear.Text.Trim();
            DateTime today = DateTime.Now;



            // Kiểm tra xem các trường có bị null hoặc khoảng trắng hay không
            if (string.IsNullOrWhiteSpace(movieName) || string.IsNullOrWhiteSpace(director) ||
                string.IsNullOrWhiteSpace(genreName) || string.IsNullOrWhiteSpace(country) ||
                string.IsNullOrWhiteSpace(ageRestriction) || string.IsNullOrWhiteSpace(description) ||
                string.IsNullOrWhiteSpace(durationText) || string.IsNullOrWhiteSpace(releaseYearText))
            {
                System.Windows.MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
                return; // Dừng việc lưu nếu có trường nào bị null hoặc khoảng trắng
            }

            // Chuyển đổi duration và releaseYear sang kiểu số nguyên
            if (!int.TryParse(durationText, out int duration) || !int.TryParse(releaseYearText, out int releaseYear))
            {
                System.Windows.MessageBox.Show("Vui lòng nhập thời lượng và năm phát hành hợp lệ!");
                return; // Dừng việc lưu nếu thời lượng hoặc năm phát hành không hợp lệ
            }
            // Kiểm tra xem năm phát hành có phù hợp không
            if (releaseYear < today.Year)
            {
                System.Windows.MessageBox.Show("Năm phát hành phải từ năm hiện tại trở đi!");
                return; // Dừng việc lưu nếu năm phát hành không hợp lệ
            }

            // Lấy GenreID từ tên thể loại
            int genreID = GetGenreIDByGenreName(genreName);

            // Lưu thông tin cập nhật vào cơ sở dữ liệu
            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                connection.Open();
                string query = @"
            UPDATE Movie 
            SET DisplayName = @DisplayName, 
                Duration = @Duration, 
                Country = @Country, 
                Description = @Description, 
                ReleaseYear = @ReleaseYear, 
                GenreID = @GenreID, 
                Director = @Director, 
                Age_Required = @Age_Required,
                Image = @Image
            WHERE MovieID = @MovieID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DisplayName", movieName);
                    command.Parameters.AddWithValue("@Duration", duration);
                    command.Parameters.AddWithValue("@Country", country);
                    command.Parameters.AddWithValue("@Description", description);
                    command.Parameters.AddWithValue("@ReleaseYear", releaseYear);
                    command.Parameters.AddWithValue("@GenreID", genreID);
                    command.Parameters.AddWithValue("@Director", director);
                    command.Parameters.AddWithValue("@Age_Required", ageRestriction);
                    command.Parameters.AddWithValue("@Image", avatar);
                    command.Parameters.AddWithValue("@MovieID", MovieID);
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        System.Windows.MessageBox.Show("Cập nhật thông tin phim thành công!");
                        // Thông báo cho form cha (StaffForm) rằng đã cập nhật thành công
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Cập nhật thông tin phim không thành công!");
                    }
                }
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
    }
}