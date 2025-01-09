using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Windows.Forms;




namespace Main
{
    public partial class EditUser : Form
    {
        private int userID;
        public event EventHandler DataUpdated;
     

        public EditUser(int userID)
        {
            InitializeComponent();
            this.userID = userID;
        }
        private string GetUserRoleName(int userID)
        {
            string roleName = "";
            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                connection.Open();

                // Truy vấn UserType để lấy RoleID dựa trên UserID
                string userTypeQuery = "SELECT RoleID FROM UserType WHERE UserID = @UserID";
                using (SqlCommand userTypeCommand = new SqlCommand(userTypeQuery, connection))
                {
                    userTypeCommand.Parameters.AddWithValue("@UserID", userID);

                    // Thực hiện truy vấn và đọc giá trị RoleID
                    object roleIDResult = userTypeCommand.ExecuteScalar();
                    if (roleIDResult != null)
                    {
                        int roleID = Convert.ToInt32(roleIDResult);

                        // Truy vấn Role để lấy Role_Name dựa trên RoleID
                        string roleQuery = "SELECT Role_Name FROM Role WHERE RoleID = @RoleID";
                        using (SqlCommand roleCommand = new SqlCommand(roleQuery, connection))
                        {
                            roleCommand.Parameters.AddWithValue("@RoleID", roleID);
                            object roleNameResult = roleCommand.ExecuteScalar();
                            if (roleNameResult != null)
                            {
                                roleName = roleNameResult.ToString();
                            }
                        }
                    }
                }
            }
            return roleName;
        }

        private void EditUser_Load(object sender, EventArgs e)
        {
            // Khởi tạo kết nối đến cơ sở dữ liệu
            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                connection.Open();
                // Truy vấn để lấy dữ liệu người dùng dựa trên userID
                string query = @"
        SELECT u.*, c.Cinema_Name
        FROM Users u
        INNER JOIN Cinema c ON u.CinemaID = c.CinemaID
        WHERE u.UserID = @UserID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", userID);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Lấy dữ liệu từ cơ sở dữ liệu
                            string name = reader["Full_Name"].ToString();
                            string phoneNumber = reader["Phone_Number"].ToString();
                            string email = reader["Email"].ToString();
                            string username = reader["Username"].ToString();
                            string password = reader["Password"].ToString();
                            string address = reader["Address"].ToString();
                            string cinemaID = reader["CinemaID"].ToString();
                            string gender = reader["Gender"].ToString();
                            string avatarPath = reader["Avatar"].ToString();

                            // Gọi hàm GetNameFromDatabase để lấy tên của Cinema từ ID
                            string cinemaName = GetNameFromDatabase(cinemaID, "Cinema", "CinemaID", "Cinema_Name");

                            // Gọi hàm GetUserRoleName để lấy Role_Name
                            string role = GetUserRoleName(userID);

                            // Gán dữ liệu vào các control trên form
                            tbName.Text = name;
                            tbPhoneNumber.Text = phoneNumber;
                            tbEmail.Text = email;
                            tbUsername.Text = username;
                            tbPassword.Text = password;
                            tbaddress.Text = address;
                            gendermale.Checked = (gender == "Male"); // Check RadioButton nếu là Male
                            genderfemale.Checked = (gender == "Female"); // Check RadioButton nếu là Female

                            // Gán giá trị cho ComboBox RoleCB
                            LoadRoles(role);

                            // Gán giá trị cho ComboBox cinemaidCb
                            LoadCinemas(cinemaName);

                            // Kiểm tra và gán đường dẫn ảnh vào PictureBox
                            if (!string.IsNullOrEmpty(avatarPath))
                            {
                                picPhoto.ImageLocation = avatarPath;
                            }
                        }
                    }
                }
            }
        }

        private void LoadRoles(string selectedRole)
        {
            // Xóa tất cả các mục trong ComboBox RoleCB
            RoleCB.Items.Clear();

            // Khởi tạo kết nối đến cơ sở dữ liệu
            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                connection.Open();
                // Truy vấn để lấy tất cả các vai trò từ bảng Role
                string query = "SELECT Role_Name FROM Role";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string role = reader["Role_Name"].ToString();
                            // Thêm vai trò vào ComboBox
                            RoleCB.Items.Add(role);
                        }
                    }
                }
            }

            // Thiết lập giá trị mặc định cho ComboBox RoleCB
            if (!string.IsNullOrEmpty(selectedRole) && RoleCB.Items.Contains(selectedRole))
            {
                RoleCB.SelectedItem = selectedRole;
            }
            else
            {
                RoleCB.SelectedIndex = 0; // Nếu không có giá trị mặc định, chọn mục đầu tiên
            }
        }

        private void LoadCinemas(string selectedCinema)
        {
            // Xóa tất cả các mục trong ComboBox cinemaidCb
            cinemaidCb.Items.Clear();

            // Khởi tạo kết nối đến cơ sở dữ liệu
            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                connection.Open();
                // Truy vấn để lấy tất cả các rạp chiếu phim từ bảng Cinema
                string query = "SELECT Cinema_Name FROM Cinema";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string cinema = reader["Cinema_Name"].ToString();
                            // Thêm rạp chiếu phim vào ComboBox
                            cinemaidCb.Items.Add(cinema);
                        }
                    }
                }
            }

            // Thiết lập giá trị mặc định cho ComboBox cinemaidCb
            if (!string.IsNullOrEmpty(selectedCinema) && cinemaidCb.Items.Contains(selectedCinema))
            {
                cinemaidCb.SelectedItem = selectedCinema;
            }
            else
            {
                cinemaidCb.SelectedIndex = 0; // Nếu không có giá trị mặc định, chọn mục đầu tiên
            }
        }



        private string GetNameFromDatabase(string selectedID, string tableName, string idColumnName, string nameColumnName)
        {
            string selectedName = "";

            // Kết nối đến cơ sở dữ liệu
            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                // Mở kết nối
                connection.Open();

                // Truy vấn để lấy tên dựa trên ID được chọn
                string query = $"SELECT {nameColumnName} FROM {tableName} WHERE {idColumnName} = @ID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Thêm tham số cho ID
                    command.Parameters.AddWithValue("@ID", selectedID);

                    // Thực thi truy vấn và lấy giá trị tên
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        selectedName = result.ToString();
                    }
                }
            }

            return selectedName;
        }



        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lbClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }











        public bool checkAccount(string acc)//Check Tài khoản , mật khẩu
        {
            return Regex.IsMatch(acc, "^[a-zA-Z0-9]{6,24}$");
        }

        public bool checkEmail(string em)//Check Email
        {
            return Regex.IsMatch(em, @"^[\w-\.]{3,20}@gmail.com(.vn|)$");
        }

        Modified modified = new Modified();
        private bool CheckUsernameExists(string username)
        {
            string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username";
            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);
                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }
        private bool CheckEmailExists(string email)
        {
            string query = "SELECT COUNT(*) FROM Users WHERE Email = @Email";
            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Email", email);
                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
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



        private string GetIDFromDatabase(string selectedName, string tableName, string nameColumnName, string idColumnName)
        {
            string selectedID = "";

            // Kết nối đến cơ sở dữ liệu
            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                // Mở kết nối
                connection.Open();

                // Truy vấn để lấy ID dựa trên tên được chọn
                string query = $"SELECT {idColumnName} FROM {tableName} WHERE {nameColumnName} = @Name";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Thêm tham số cho tên
                    command.Parameters.AddWithValue("@Name", selectedName);

                    // Thực thi truy vấn và lấy giá trị ID
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        selectedID = result.ToString();
                    }
                }
            }

            return selectedID;
        }



        private void AddUserType(string userid, string roleid)
        {
            // Kiểm tra xem UserID và RoleID có hợp lệ không
            if (!string.IsNullOrEmpty(userid) && !string.IsNullOrEmpty(roleid))
            {
                // Thực hiện truy vấn INSERT vào bảng UserType
                string insertQuery = "INSERT INTO UserType (UserID, RoleID) VALUES (@UserID, @RoleID)";

                // Kết nối đến cơ sở dữ liệu
                using (SqlConnection connection = Connection.GetSqlConnection())
                {
                    // Mở kết nối
                    connection.Open();

                    // Tạo đối tượng SqlCommand
                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        // Thêm các tham số vào câu lệnh SQL
                        command.Parameters.AddWithValue("@UserID", userid);
                        command.Parameters.AddWithValue("@RoleID", roleid);

                        // Thực thi truy vấn INSERT
                        int rowsAffected = command.ExecuteNonQuery();


                    }
                }
            }

        }

        private void UpdateUserType(string userID, string roleID)
        {
            // Kiểm tra xem UserID và RoleID có hợp lệ không
            if (!string.IsNullOrEmpty(userID) && !string.IsNullOrEmpty(roleID))
            {
                // Thực hiện truy vấn UPDATE trong bảng UserType
                string updateQuery = "UPDATE UserType SET RoleID = @RoleID WHERE UserID = @UserID";

                // Kết nối đến cơ sở dữ liệu
                using (SqlConnection connection = Connection.GetSqlConnection())
                {
                    // Mở kết nối
                    connection.Open();

                    // Tạo đối tượng SqlCommand
                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        // Thêm các tham số vào câu lệnh SQL
                        command.Parameters.AddWithValue("@RoleID", roleID);
                        command.Parameters.AddWithValue("@UserID", userID);

                        // Thực thi truy vấn UPDATE
                        int rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Lấy thông tin từ các control trên form
            string fullname = tbName.Text;
            string phonenum = tbPhoneNumber.Text;
            string password = tbPassword.Text;
            string hashedPassword = PasswordHasher.HashPassword(password);

            string address = tbaddress.Text;
            bool isMale = gendermale.Checked;
            string gender = isMale ? "Male" : "Female";
            string avatar = picPhoto.ImageLocation;
            string selectedRoleName = RoleCB.Text;
            string roleNameID = GetIDFromDatabase(selectedRoleName, "Role", "Role_Name", "RoleID");

            string selectedCinemaName = cinemaidCb.Text;
            string CinemaID = GetIDFromDatabase(selectedCinemaName, "Cinema", "Cinema_Name", "CinemaID");

            // Kiểm tra thông tin nhập liệu
            if (string.IsNullOrWhiteSpace(fullname) || string.IsNullOrWhiteSpace(phonenum) || string.IsNullOrWhiteSpace(address))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            // Kiểm tra mật khẩu có khớp với mật khẩu hiện tại không
            bool isPasswordChanged = true;
            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                string query = "SELECT Password FROM Users WHERE UserID = @UserID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@UserID", this.userID);
                    string currentPassword = command.ExecuteScalar()?.ToString();
                    if (currentPassword != null && password == currentPassword)
                    {
                        // Nếu mật khẩu nhập vào giống với mật khẩu hiện tại, không cần băm lại
                        hashedPassword = currentPassword;
                        isPasswordChanged = false;
                    }
                }
            }

            // Kiểm tra hình ảnh
            if (string.IsNullOrWhiteSpace(avatar))
            {
                MessageBox.Show("Vui lòng chọn hình ảnh!");
                return;
            }

            // Tiến hành cập nhật thông tin người dùng vào cơ sở dữ liệu
            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                string userQuery = @"
    UPDATE [Users] 
    SET Full_Name = @Full_Name, 
        Phone_Number = @PhoneNumber, 
        Address = @Address, 
        CinemaID = @CinemaID, 
        Avatar = @Avatar, ";

                // Nếu mật khẩu đã thay đổi, thêm cập nhật mật khẩu vào truy vấn
                if (isPasswordChanged)
                {
                    userQuery += "Password = @Password, ";
                }

                userQuery += "Gender = @Gender WHERE UserID = @UserID";

                using (SqlCommand userCommand = new SqlCommand(userQuery, connection))
                {
                    connection.Open();
                    // Thêm các tham số vào command
                    userCommand.Parameters.AddWithValue("@Full_Name", fullname);
                    userCommand.Parameters.AddWithValue("@PhoneNumber", phonenum);
                    userCommand.Parameters.AddWithValue("@Address", address);
                    userCommand.Parameters.AddWithValue("@CinemaID", CinemaID);
                    userCommand.Parameters.AddWithValue("@Gender", gender);
                    userCommand.Parameters.AddWithValue("@UserID", this.userID); // Sử dụng userID của lớp EditUser
                    userCommand.Parameters.AddWithValue("@Avatar", avatar); // Thêm đường dẫn ảnh vào tham số này

                    // Nếu mật khẩu đã thay đổi, thêm tham số cho mật khẩu
                    if (isPasswordChanged)
                    {
                        userCommand.Parameters.AddWithValue("@Password", hashedPassword);
                    }

                    int rowsAffected = userCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        UpdateUserType(this.userID.ToString(), roleNameID);
                        MessageBox.Show("Chỉnh sửa thông tin người dùng thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Chỉnh sửa thông tin người dùng không thành công!");
                    }
                }
            }
        }


        public class PasswordHasher
        {
            public static string HashPassword(string password)
            {
                using (SHA256 sha256Hash = SHA256.Create())
                {
                    // ComputeHash - returns byte array
                    byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                    // Convert byte array to a string
                    StringBuilder builder = new StringBuilder();
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        builder.Append(bytes[i].ToString("x2"));
                    }
                    return builder.ToString();
                }
            }
        }

        private void btnPhoto_Click_1(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files (*.jpg, *.jpeg, *.png, *.gif, *.bmp)|*.jpg; *.jpeg; *.png; *.gif; *.bmp|All files (*.*)|*.*";
                openFileDialog.Title = "Choose an image";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedImagePath = openFileDialog.FileName;
                    picPhoto.Image = Image.FromFile(selectedImagePath);

                    // Update the ImageLocation property
                    picPhoto.ImageLocation = selectedImagePath;
                }
            }
        }
    }
}