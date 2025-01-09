/*using Google.Apis.Admin.Directory.directory_v1.Data;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Guna.UI2.WinForms;
*/

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
using FontAwesome.Sharp;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace Main
{
    public partial class editstaff : Form
    {

        private string StaffID;
        public editstaff(string StaffID)
        {
            InitializeComponent();
            this.StaffID = StaffID;
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
                string query = $"SELECT {nameColumnName} FROM {tableName} WHERE {idColumnName} = @id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Thêm tham số cho ID
                    command.Parameters.AddWithValue("@id", selectedID);

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



        private void passcheckb_CheckedChanged(object sender, EventArgs e)
        {
            if (passcheckb.Checked)
            {
                tbPassword.PasswordChar = '\0';
                confirmpass.PasswordChar = '\0';
            }
            else
            {
                tbPassword.PasswordChar = '*';
                confirmpass.PasswordChar = '*';
            }
        }














        private void editstaff_Load(object sender, EventArgs e)
        {
            // Khóa lại các textbox Username và Email
            tbUsername.ReadOnly = true;
            tbEmail.ReadOnly = true;

            // Khởi tạo kết nối và command
            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                // Mở kết nối
                connection.Open();

                // Truy vấn SQL để lấy thông tin từ bảng Staff dựa trên StaffID từ biến thành viên
                string query = @"
            SELECT s.*, c.Name
            FROM Staff s
            INNER JOIN Theater c ON s.CinemaID = c.id
            WHERE s.StaffID = @StaffID"; // Thêm tham số @StaffID vào câu lệnh SQL

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Thêm tham số @StaffID vào command
                    command.Parameters.AddWithValue("@StaffID", StaffID);

                    // Thực thi truy vấn và đọc dữ liệu
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Kiểm tra xem có dữ liệu được trả về không
                        if (reader.Read())
                        {
                            // Đổ dữ liệu từ SqlDataReader vào các combobox
                            string name = reader["Name"].ToString();
                            string phoneNumber = reader["PhoneNumber"].ToString();
                            string email = reader["Email"].ToString();
                            string username = reader["Username"].ToString();
/*                            string password = reader["Password"].ToString();
*/                            string gender = reader["Gender"].ToString();
                            string avatarPath = reader["Image"].ToString();
                            string cinemaID = reader["CinemaID"].ToString();
                            string rol = reader["Role"].ToString();

                            // Gọi hàm GetNameFromDatabase để lấy tên của Cinema từ ID
                            string cinemaName = GetNameFromDatabase(cinemaID, "Theater", "id", "Name");

                            // Gọi hàm GetUserRoleName để lấy Role_Name
                            string role = GetUserRoleName(StaffID);

                            // Gán dữ liệu vào các control trên form
                            tbEmail.Text = email;
                            tbName.Text = name;
                            birthdateDTP.Value = Convert.ToDateTime(reader["BirthDate"]);
                            tbPhoneNumber.Text = phoneNumber;
                            tbUsername.Text = username;
/*                            tbPassword.Text = password;
*/
                            // Gán giá trị cho ComboBox genderCB
                            genderCB.Items.Clear();
                            genderCB.Items.Add("Male");
                            genderCB.Items.Add("Female");
                            genderCB.SelectedItem = gender;

                            LoadRoles(role); // Thêm role vào ComboBox Role

                            // Gán giá trị cho ComboBox cinemaidCb
                            LoadCinemas(cinemaName);

                            // Kiểm tra và gán đường dẫn ảnh vào PictureBox
                            if (!string.IsNullOrEmpty(avatarPath))
                            {
                                picPhoto.ImageLocation = avatarPath;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy thông tin nhân viên!");
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
                string query = "SELECT Name FROM Theater";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string cinema = reader["Name"].ToString();
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
        public bool CheckAccount(string acc)
        {
            // Kiểm tra độ dài chuỗi
            if (acc.Length < 6 || acc.Length > 24)
            {
                return false;
            }

            // Kiểm tra chuỗi theo biểu thức chính quy
            return Regex.IsMatch(acc, "^[a-zA-Z0-9]{6,24}$");

        }

        public bool CheckEmail(string em)
        {
            // Kiểm tra định dạng email và độ dài không quá 50 ký tự
            return Regex.IsMatch(em, @"^[A-Za-z0-9._%+-]{3,50}@gmail.com$");
        }


        Modified modified = new Modified();
        private bool CheckUsernameExists(string username)
        {
            string query = "SELECT COUNT(*) FROM Staff WHERE Username = @Username";
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
            string query = "SELECT COUNT(*) FROM Staff WHERE Email = @Email";
            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Email", email);
                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }

        private void UpdateStaffRole(string staffID, string roleID)
        {
            // Kiểm tra xem StaffID và RoleID có hợp lệ không
            if (!string.IsNullOrEmpty(staffID) && !string.IsNullOrEmpty(roleID))
            {
                // Thực hiện truy vấn UPDATE vào bảng StaffRole
                string updateQuery = "UPDATE StaffRole SET RoleID = @RoleID WHERE StaffID = @StaffID";

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
                        command.Parameters.AddWithValue("@StaffID", staffID);

                        // Thực thi truy vấn UPDATE
                        int rowsAffected = command.ExecuteNonQuery();
                    }
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



        private string GetRoleNameFromDatabase(string roleID)
        {
            string roleName = "";

            // Kết nối đến cơ sở dữ liệu
            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                // Mở kết nối
                connection.Open();

                // Truy vấn để lấy RoleName dựa trên RoleID được chọn
                string query = "SELECT Role_Name FROM Role WHERE id = @RoleID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Thêm tham số cho RoleID
                    command.Parameters.AddWithValue("@RoleID", roleID);

                    // Thực thi truy vấn và lấy RoleName
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        roleName = result.ToString();
                    }
                }
            }

            return roleName;
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy thông tin từ các control trên form
                string fullname = tbName.Text;
                string phonenum = tbPhoneNumber.Text;
                string email = tbEmail.Text;
                string username = tbUsername.Text;
                string password = tbPassword.Text;
                string confirm = confirmpass.Text;
                DateTime birthDate = birthdateDTP.Value;
                string gender = genderCB.SelectedItem != null ? genderCB.SelectedItem.ToString() : string.Empty;
                string selectedRoleName = RoleCB.SelectedItem != null ? RoleCB.SelectedItem.ToString() : string.Empty;
                string selectedCinemaName = cinemaidCb.SelectedItem != null ? cinemaidCb.SelectedItem.ToString() : string.Empty;

                // Kiểm tra tính hợp lệ của email và tên đăng nhập
                if (!CheckEmail(email))
                {
                    MessageBox.Show("Vui lòng nhập Email của bạn! (Bao gồm @gmail.com)");
                    return;
                }

                if (!CheckAccount(username))
                {
                    MessageBox.Show("Vui lòng nhập Tên đăng nhập của bạn! (Dài từ 6 - 24 ký tự.) (Chỉ chấp nhận: a-z, A-Z, 0 - 9)");
                    return;
                }

                // Kiểm tra tính hợp lệ của mật khẩu (nếu được nhập)
                if (!string.IsNullOrEmpty(password) && (!CheckAccount(password) || password != confirm))
                {
                    MessageBox.Show("Vui lòng nhập Mật khẩu của bạn và đảm bảo rằng Mật khẩu và Xác nhận mật khẩu trùng khớp! (Dài từ 6 - 24 ký tự.) (Chỉ chấp nhận: a-z, A-Z, 0 - 9)");
                    return;
                }

                // Lấy ID của vai trò và rạp chiếu phim từ cơ sở dữ liệu
                string roleNameID = !string.IsNullOrEmpty(selectedRoleName) ? GetIDFromDatabase(selectedRoleName, "Role", "Role_Name", "id") : string.Empty;
                string CinemaID = !string.IsNullOrEmpty(selectedCinemaName) ? GetIDFromDatabase(selectedCinemaName, "Theater", "Name", "id") : string.Empty;


                if (string.IsNullOrEmpty(fullname) || string.IsNullOrEmpty(phonenum))
                {
                    MessageBox.Show("Dữ liệu bị trống !");
                    return;
                }


                // Tiến hành cập nhật thông tin người dùng trong cơ sở dữ liệu
                using (SqlConnection connection = Connection.GetSqlConnection())
                {
                    string updateQuery = @"
UPDATE [Staff] SET 
Name = @Name,
Username = @Username,
Email = @Email,
PhoneNumber = @PhoneNumber,
BirthDate = @BirthDate,
Gender = @Gender,
Role = @Role,
CinemaID = @CinemaID";

                    // Thêm cập nhật mật khẩu vào truy vấn nếu được nhập
                    if (!string.IsNullOrEmpty(password))
                    {
                        updateQuery += ", Password = @Password";
                    }

                    updateQuery += " WHERE StaffID = @StaffID";

                    using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                    {
                        connection.Open();
                        // Thêm các tham số vào command
                        updateCommand.Parameters.AddWithValue("@Name", fullname);
                        updateCommand.Parameters.AddWithValue("@Username", username);
                        updateCommand.Parameters.AddWithValue("@Email", email);
                        updateCommand.Parameters.AddWithValue("@PhoneNumber", phonenum);
                        updateCommand.Parameters.AddWithValue("@BirthDate", birthDate);
                        updateCommand.Parameters.AddWithValue("@Gender", gender);
                        updateCommand.Parameters.AddWithValue("@Role", roleNameID);
                        updateCommand.Parameters.AddWithValue("@CinemaID", CinemaID);
                        updateCommand.Parameters.AddWithValue("@StaffID", StaffID);

                        // Thêm tham số cho mật khẩu nếu được nhập
                        if (!string.IsNullOrEmpty(password))
                        {
                            updateCommand.Parameters.AddWithValue("@Password", PasswordHasher.HashPassword(password));
                        }

                        int rowsAffected = updateCommand.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Cập nhật thông tin nhân viên thành công!");
                            // Thông báo cho form cha (StaffForm) rằng đã cập nhật thành công
                            this.DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            MessageBox.Show("Cập nhật thông tin nhân viên không thành công!");
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                // Log detailed SQL exception
                MessageBox.Show("Lỗi khi thực hiện truy vấn SQL: " + ex.Message);
            }
            catch (Exception ex)
            {
                // Log general exception
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }









        private string GetUserRoleName(string StaffID)
        {
            string roleName = "";
            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                connection.Open();

                // Truy vấn UserType để lấy RoleID dựa trên UserID
                string userTypeQuery = "SELECT RoleID FROM StaffRole WHERE StaffID = @StaffID";
                using (SqlCommand userTypeCommand = new SqlCommand(userTypeQuery, connection))
                {
                    userTypeCommand.Parameters.AddWithValue("@StaffID", StaffID);

                    // Thực hiện truy vấn và đọc giá trị RoleID
                    object roleIDResult = userTypeCommand.ExecuteScalar();
                    if (roleIDResult != null)
                    {
                        int roleID = Convert.ToInt32(roleIDResult);

                        // Truy vấn Role để lấy Role_Name dựa trên RoleID
                        string roleQuery = "SELECT Role_Name FROM Role WHERE id = @id";
                        using (SqlCommand roleCommand = new SqlCommand(roleQuery, connection))
                        {
                            roleCommand.Parameters.AddWithValue("@id", roleID);
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

    }
}

