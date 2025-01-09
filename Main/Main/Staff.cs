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
    public partial class Staff : Form
    {
        private string username;
        public Staff(string username)
        {
            InitializeComponent();
            this.username = username;

        }
        private void LoadUserDataIntoGridView()
        {
            // Xóa dữ liệu cũ trong DataGridView nếu có
            guna2DataGridView1.Rows.Clear();

            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                // Mở kết nối
                connection.Open();

                // Truy vấn để lấy dữ liệu từ bảng Users và Role thông qua UserType
                string query = @"
            SELECT u.UserID, u.Username, u.Password, u.Email, u.Phone_Number, 
                   u.Avatar, u.Gender, u.Address, u.Full_Name, 
                   r.Role_Name, 
                   u.CinemaID, u.Created_At_Time
            FROM Users u
            JOIN UserType ut ON u.UserID = ut.UserID
            JOIN Role r ON ut.RoleID = r.RoleID";

                // Tạo đối tượng SqlCommand
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Thực thi truy vấn và lấy dữ liệu
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Đọc từng dòng dữ liệu và thêm vào DataGridView
                        while (reader.Read())
                        {
                            // Lấy các giá trị từ cột trong bảng
                            int userID = Convert.ToInt32(reader["UserID"]);
                            string username = reader["Username"].ToString();
                            string password = reader["Password"].ToString();
                            string email = reader["Email"].ToString();
                            string phoneNumber = reader["Phone_Number"].ToString();
                            string avatar = reader["Avatar"].ToString();
                            string gender = reader["Gender"].ToString();
                            string address = reader["Address"].ToString();
                            string fullName = reader["Full_Name"].ToString();
                            string roleName = reader["Role_Name"].ToString();
                            int cinemaID = Convert.ToInt32(reader["CinemaID"]);
                            DateTime createdAt = Convert.ToDateTime(reader["Created_At_Time"]);

                            // Thêm dữ liệu vào DataGridView
                            guna2DataGridView1.Rows.Add(userID, username, password, email, phoneNumber,
                                                    avatar, gender, address, fullName, roleName,
                                                    cinemaID, createdAt);
                        }
                    }
                }
            }
        }


        private void Staff_Shown(object sender, EventArgs e)
        {

        }

        private void Search_Click(object sender, EventArgs e)
        {
            guna2TextBox1.Text = "";
        }

        private void Add_Click(object sender, EventArgs e)
        {
            StaffProperties staffadd = new StaffProperties(username);
            staffadd.ShowDialog();
            LoadUserDataIntoGridView();
        }



        private void Staff_Load(object sender, EventArgs e)
        {
            LoadUserDataIntoGridView();
            try
            {
                using (SqlConnection connection = Connection.GetSqlConnection())
                {
                    connection.Open();

                    string query = "SELECT Avatar, Full_Name FROM Users WHERE Username = @Username";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Đọc dữ liệu từ cột Avatar
                                if (!reader.IsDBNull(0)) // Kiểm tra xem dữ liệu có rỗng không
                                {
                                    string avatarPath = reader.GetString(0);
                                    PicPhoto.ImageLocation = avatarPath; // Đặt ảnh cho PictureBox
                                }

                                // Đọc dữ liệu từ cột Full_Name
                                if (!reader.IsDBNull(1)) // Kiểm tra xem dữ liệu có rỗng không
                                {
                                    string fullName = reader.GetString(1);
                                    Ful_name.Text = fullName; // Đặt tên đầy đủ vào Label
                                }
                            }
                        }
                    }
                }
            }


            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi tải dữ liệu người dùng: " + ex.Message);
            }

        }



        private void Reload_Click(object sender, EventArgs e)
        {
            LoadUserDataIntoGridView();
        }




        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == Column1.Index)
            {
                int userID = Convert.ToInt32(guna2DataGridView1.Rows[e.RowIndex].Cells["UserID"].Value);

                EditUser formEditUser = new EditUser(userID);
                formEditUser.ShowDialog();
                LoadUserDataIntoGridView();
            }
            if (e.ColumnIndex == Column2.Index)
            {
                // Nếu người dùng nhấn vào nút xóa
                int userID = Convert.ToInt32(guna2DataGridView1.Rows[e.RowIndex].Cells["UserID"].Value);
                string username = guna2DataGridView1.Rows[e.RowIndex].Cells["Username"].Value.ToString();

                // Hiển thị hộp thoại xác nhận
                DialogResult result = MessageBox.Show($"Bạn có muốn xóa nhân viên {username} không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Nếu người dùng chọn Yes, thực hiện xóa dữ liệu
                    DeleteUser(userID);
                }
            }
        }

        private void DeleteUser(int userID)
        {
            // Xóa dữ liệu liên quan từ bảng UserType trước
            string deleteUserTypeQuery = "DELETE FROM UserType WHERE UserID = @UserID";

            // Sau đó, xóa dữ liệu từ bảng Users
            string deleteUserQuery = "DELETE FROM Users WHERE UserID = @UserID";

            // Kết nối đến cơ sở dữ liệu và thực thi các truy vấn
            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                connection.Open();

                // Xóa dữ liệu từ bảng UserType
                using (SqlCommand command = new SqlCommand(deleteUserTypeQuery, connection))
                {
                    command.Parameters.AddWithValue("@UserID", userID);
                    int rowsAffected = command.ExecuteNonQuery();
                }

                // Xóa dữ liệu từ bảng Users
                using (SqlCommand command = new SqlCommand(deleteUserQuery, connection))
                {
                    command.Parameters.AddWithValue("@UserID", userID);
                    int rowsAffected = command.ExecuteNonQuery();
                }
            }

            // Hiển thị thông báo sau khi xóa dữ liệu
            MessageBox.Show("Đã xóa nhân viên và dữ liệu liên quan thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadUserDataIntoGridView();
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            FormLogin formLogin = new FormLogin();
            formLogin.Show();
            this.Hide();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            string searchText = guna2TextBox1.Text.Trim();

            // Kiểm tra xem ô tìm kiếm có rỗng không
            if (string.IsNullOrEmpty(searchText))
            {
                // Nếu ô tìm kiếm trống, hiển thị toàn bộ dữ liệu
                LoadUserDataIntoGridView();
            }
            else
            {
                // Nếu ô tìm kiếm không rỗng, thực hiện tìm kiếm
                SearchAndDisplayResults(searchText);
            }
        }



        private void SearchAndDisplayResults(string searchText)
        {
            // Xóa dữ liệu cũ trong DataGridView
            guna2DataGridView1.Rows.Clear();

            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                // Mở kết nối
                connection.Open();

                // Truy vấn để lấy dữ liệu từ bảng Users và Role thông qua UserType
                string query = @"
            SELECT u.UserID, u.Username, u.Password, u.Email, u.Phone_Number, 
                   u.Avatar, u.Gender, u.Address, u.Full_Name, 
                   r.Role_Name, 
                   u.CinemaID, CAST(u.Created_At_Time AS DATE) AS Created_At_Date
            FROM Users u
            JOIN UserType ut ON u.UserID = ut.UserID
            JOIN Role r ON ut.RoleID = r.RoleID
            WHERE u.UserID LIKE @SearchText OR u.Username LIKE @SearchText 
                  OR u.Password LIKE @SearchText OR u.Email LIKE @SearchText 
                  OR u.Phone_Number LIKE @SearchText OR u.Avatar LIKE @SearchText 
                  OR u.Gender LIKE @SearchText OR u.Address LIKE @SearchText 
                  OR u.Full_Name LIKE @SearchText OR r.Role_Name LIKE @SearchText 
                  OR u.CinemaID LIKE @SearchText OR CAST(u.Created_At_Time AS DATE) LIKE @SearchText";

                // Tạo đối tượng SqlCommand
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Thêm tham số cho tìm kiếm
                    command.Parameters.AddWithValue("@SearchText", "%" + searchText + "%");

                    // Thực thi truy vấn và lấy dữ liệu
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Đọc từng dòng dữ liệu và thêm vào DataGridView
                        while (reader.Read())
                        {
                            // Lấy các giá trị từ cột trong bảng
                            int userID = Convert.ToInt32(reader["UserID"]);
                            string username = reader["Username"].ToString();
                            string password = reader["Password"].ToString();
                            string email = reader["Email"].ToString();
                            string phoneNumber = reader["Phone_Number"].ToString();
                            string avatar = reader["Avatar"].ToString();
                            string gender = reader["Gender"].ToString();
                            string address = reader["Address"].ToString();
                            string fullName = reader["Full_Name"].ToString();
                            string roleName = reader["Role_Name"].ToString();
                            int cinemaID = Convert.ToInt32(reader["CinemaID"]);
                            DateTime createdAt = Convert.ToDateTime(reader["Created_At_Date"]);

                            // Thêm dữ liệu vào DataGridView
                            guna2DataGridView1.Rows.Add(userID, username, password, email, phoneNumber,
                                                        avatar, gender, address, fullName, roleName,
                                                        cinemaID, createdAt);
                        }
                    }
                }
            }
        }

        private void StartTime_ValueChange(object sender, EventArgs e)
        {
            // Lấy giá trị ngày bắt đầu và kết thúc
            DateTime startTime = StartTime.Value;
            DateTime endTime = EndTime.Value;

            // Tìm kiếm và hiển thị kết quả
            SearchAndDisplayResults(startTime, endTime);
        }

        private void EndTimeValue_Changed(object sender, EventArgs e)
        {
            // Lấy giá trị ngày bắt đầu và kết thúc
            DateTime startTime = StartTime.Value;
            DateTime endTime = EndTime.Value;

            // Tìm kiếm và hiển thị kết quả
            SearchAndDisplayResults(startTime, endTime);
        }

        private void CreatedDayFilter_ValueChanged(object sender, EventArgs e)
        {
            // Lấy giá trị ngày bắt đầu và kết thúc
            DateTime startTime = StartTime.Value;
            DateTime endTime = EndTime.Value;

            // Tìm kiếm và hiển thị kết quả
            SearchAndDisplayResults(startTime, endTime);
        }

        private void EndTimeFilter_ValueChanged(object sender, EventArgs e)
        {
            // Lấy giá trị ngày bắt đầu và kết thúc
            DateTime startTime = StartTime.Value;
            DateTime endTime = EndTime.Value;

            // Tìm kiếm và hiển thị kết quả
            SearchAndDisplayResults(startTime, endTime);
        }

        private void SearchAndDisplayResults(DateTime startTime, DateTime endTime)
        {
            // Xóa dữ liệu cũ trong DataGridView
            guna2DataGridView1.Rows.Clear();

            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                // Mở kết nối
                connection.Open();

                // Truy vấn để lấy dữ liệu từ bảng Users và Role thông qua UserType
                string query = @"
        SELECT u.UserID, u.Username, u.Password, u.Email, u.Phone_Number, 
               u.Avatar, u.Gender, u.Address, u.Full_Name, 
               r.Role_Name, 
               u.CinemaID, CAST(u.Created_At_Time AS DATE) AS Created_At_Date
        FROM Users u
        JOIN UserType ut ON u.UserID = ut.UserID
        JOIN Role r ON ut.RoleID = r.RoleID
        WHERE CAST(u.Created_At_Time AS DATE) BETWEEN @StartTime AND @EndTime";

                // Tạo đối tượng SqlCommand
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Thêm tham số cho ngày bắt đầu và kết thúc
                    command.Parameters.AddWithValue("@StartTime", startTime);
                    command.Parameters.AddWithValue("@EndTime", endTime);

                    // Thực thi truy vấn và lấy dữ liệu
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Đọc từng dòng dữ liệu và thêm vào DataGridView
                        while (reader.Read())
                        {
                            // Lấy các giá trị từ cột trong bảng
                            int userID = Convert.ToInt32(reader["UserID"]);
                            string username = reader["Username"].ToString();
                            string password = reader["Password"].ToString();
                            string email = reader["Email"].ToString();
                            string phoneNumber = reader["Phone_Number"].ToString();
                            string avatar = reader["Avatar"].ToString();
                            string gender = reader["Gender"].ToString();
                            string address = reader["Address"].ToString();
                            string fullName = reader["Full_Name"].ToString();
                            string roleName = reader["Role_Name"].ToString();
                            int cinemaID = Convert.ToInt32(reader["CinemaID"]);
                            DateTime createdAt = Convert.ToDateTime(reader["Created_At_Date"]);

                            // Thêm dữ liệu vào DataGridView
                            guna2DataGridView1.Rows.Add(userID, username, password, email, phoneNumber,
                                                        avatar, gender, address, fullName, roleName,
                                                        cinemaID, createdAt);
                        }
                    }
                }
            }
        }


    }
}