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
    public partial class AddMovie : Form
    {
        public AddMovie()
        {
            InitializeComponent();
            PopulateComboBoxes();
            PopulateGenresComboBox();
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có ảnh được chọn không
            if (picPhoto.Tag == null)
            {
                MessageBox.Show("Vui lòng tải ảnh!");
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

            string movieId = GetNextMovieID();
            DateTime today = DateTime.Now;

            // Kiểm tra xem các trường có bị null hoặc khoảng trắng hay không
            if (string.IsNullOrWhiteSpace(movieName) || string.IsNullOrWhiteSpace(director) ||
                string.IsNullOrWhiteSpace(genreName) || string.IsNullOrWhiteSpace(country) ||
                string.IsNullOrWhiteSpace(ageRestriction) || string.IsNullOrWhiteSpace(description) ||
                string.IsNullOrWhiteSpace(durationText) || string.IsNullOrWhiteSpace(releaseYearText))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
                return; // Dừng việc lưu nếu có trường nào bị null hoặc khoảng trắng
            }

            // Chuyển đổi duration và releaseYear sang kiểu số nguyên
            if (!int.TryParse(durationText, out int duration) || !int.TryParse(releaseYearText, out int releaseYear))
            {
                MessageBox.Show("Vui lòng nhập thời lượng và năm phát hành hợp lệ!");
                return; // Dừng việc lưu nếu thời lượng hoặc năm phát hành không hợp lệ
            }
            // Kiểm tra xem năm phát hành có phù hợp không
            if (releaseYear < today.Year)
            {
                MessageBox.Show("Năm phát hành phải từ năm hiện tại trở đi!");
                return; // Dừng việc lưu nếu năm phát hành không hợp lệ
            }


            // Lấy GenreID từ tên thể loại
            int genreID = GetGenreIDByGenreName(genreName);

            // Lưu thông tin vào cơ sở dữ liệu
            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                connection.Open();
                string query = "INSERT INTO Movie (MovieID, DisplayName, Duration, Country, Description, ReleaseYear, GenreID, Director, IsDeleted, Age_Required, Image) VALUES (@MovieID, @DisplayName, @Duration, @Country, @Description, @ReleaseYear, @GenreID, @Director, @IsDeleted, @Age_Required, @Image)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MovieID", movieId);
                    command.Parameters.AddWithValue("@DisplayName", movieName);
                    command.Parameters.AddWithValue("@Duration", duration);
                    command.Parameters.AddWithValue("@Country", country);
                    command.Parameters.AddWithValue("@Description", description);
                    command.Parameters.AddWithValue("@ReleaseYear", releaseYear);
                    command.Parameters.AddWithValue("@GenreID", genreID);
                    command.Parameters.AddWithValue("@Director", director);
                    command.Parameters.AddWithValue("@IsDeleted", false);
                    command.Parameters.AddWithValue("@Age_Required", ageRestriction);
                    command.Parameters.AddWithValue("@Image", avatar);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Thêm phim thành công!");
                        // Thông báo cho form cha (StaffForm) rằng đã thêm thành công
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("Thêm phim không thành công!");
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

        private void PopulateGenresComboBox()
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
        private int GetGenreIDByGenreName(string genreName)
        {
            int genreID = 0; // Khởi tạo giá trị mặc định là 0 (hoặc giá trị mặc định khác tùy vào yêu cầu của bạn)
            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                connection.Open();
                string query = "SELECT id FROM Genre WHERE GenreName = @GenreName";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@GenreName", genreName);
                    object result = command.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out genreID))
                    {
                        // Chuyển đổi thành công
                    }
                }
            }
            return genreID;
        }

        private void PopulateComboBoxes()
        {
            // Thêm các quốc gia vào ComboBox countrycb
            countrycb.Items.AddRange(new string[] { "Việt Nam", "Mỹ", "Hàn Quốc", "Trung Quốc","Đài Loan", "Nhật Bản" });

            // Thêm độ tuổi vào ComboBox age_recb
            age_recb.Items.AddRange(new string[] { "13+", "16+", "18+", "K+", "P+" });
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
