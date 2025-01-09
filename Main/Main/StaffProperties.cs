using Microsoft.VisualBasic.ApplicationServices;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Main
{
    public partial class StaffProperties : Form
    {
        public StaffProperties(string username)
        {
            InitializeComponent();
            LoadCinemaData();
            LoadRoleData();
            LoadGenderData();

        }
        private void LoadGenderData()
        {
            genderCB.Items.Add("Male");
            genderCB.Items.Add("Female");
            genderCB.SelectedIndex = 0; // Chọn mục đầu tiên (Male) làm mặc định, nếu muốn
        }
        private DataTable GetCinemaData()
        {
            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                string query = "SELECT id, Name FROM Theater";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    DataTable dataTable = new DataTable();
                    dataTable.Load(command.ExecuteReader());
                    return dataTable;
                }
            }
        }

        private DataTable GetRoleData()
        {
            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                string query = "SELECT id, Role_Name FROM Role";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    DataTable dataTable = new DataTable();
                    dataTable.Load(command.ExecuteReader());
                    return dataTable;
                }
            }
        }

        private void LoadCinemaData()
        {
            DataTable cinemaDataTable = GetCinemaData();
            cinemaidCb.DataSource = cinemaDataTable;
            cinemaidCb.DisplayMember = "Name";
            cinemaidCb.ValueMember = "id";
        }

        private void LoadRoleData()
        {
            DataTable roleDataTable = GetRoleData();
            RoleCB.DataSource = roleDataTable;
            RoleCB.DisplayMember = "Role_Name";
            RoleCB.ValueMember = "id";
        }

        private void lbClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thoát trang ? ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                this.Close();
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

        private void AddUserType(string staffid, string roleID)
        {
            // Kiểm tra xem UserID và RoleID có hợp lệ không
            if (!string.IsNullOrEmpty(staffid) && !string.IsNullOrEmpty(roleID))
            {
                // Thực hiện truy vấn INSERT vào bảng StaffRole
                string insertQuery = "INSERT INTO StaffRole (StaffID, RoleID) VALUES (@StaffID, @RoleID)";

                // Kết nối đến cơ sở dữ liệu
                using (SqlConnection connection = Connection.GetSqlConnection())
                {
                    // Mở kết nối
                    connection.Open();

                    // Tạo đối tượng SqlCommand
                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        // Thêm các tham số vào câu lệnh SQL
                        command.Parameters.AddWithValue("@StaffID", staffid);
                        command.Parameters.AddWithValue("@RoleID", roleID);

                        // Thực thi truy vấn INSERT
                        int rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public bool checkAccount(string acc)
        {
            // Kiểm tra độ dài chuỗi
            if (acc.Length < 6 || acc.Length > 24)
            {
                return false;
            }

            // Kiểm tra chuỗi theo biểu thức chính quy
            return Regex.IsMatch(acc, "^[a-zA-Z0-9]{6,24}$");

        }

        public bool checkEmail(string em)
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

        private string GetNextStaffID()
        {
            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                connection.Open();
                int numericPart = 1;
                string nextStaffID = "NV" + numericPart.ToString("D4"); // Bắt đầu với NV0001

                // Kiểm tra tính duy nhất của StaffID mới
                while (true)
                {
                    // Tạo câu truy vấn an toàn
                    string query = "SELECT COUNT(*) FROM Staff WHERE StaffID = @StaffID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Đặt tham số cho truy vấn SQL
                        command.Parameters.AddWithValue("@StaffID", nextStaffID);
                        // Kiểm tra xem StaffID mới đã tồn tại trong cơ sở dữ liệu chưa
                        int count = (int)command.ExecuteScalar();
                        // Nếu đã tồn tại, tăng numericPart lên 1 và kiểm tra lại
                        if (count > 0)
                        {
                            numericPart++;
                            nextStaffID = "NV" + numericPart.ToString("D4"); // Cập nhật StaffID mới
                        }
                        else
                        {
                            break; // StaffID mới là duy nhất, thoát khỏi vòng lặp
                        }
                    }
                }

                return nextStaffID;
            }
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
            // Lấy thông tin từ các control trên form
            string fullname = tbName.Text;
            string phonenum = tbPhoneNumber.Text;
            string email = tbEmail.Text;
            string username = tbUsername.Text;
            string password = tbPassword.Text;
            string confirm = confirmpass.Text;
            string hashedPassword = PasswordHasher.HashPassword(password);
            DateTime birthDate = birthdateDTP.Value;
            string gender = genderCB.SelectedItem.ToString();

            string selectedRoleName = RoleCB.Text;
            string roleNameID = GetIDFromDatabase(selectedRoleName, "Role", "Role_Name", "id");
            string rolename = GetRoleNameFromDatabase(roleNameID);
            string selectedCinemaName = cinemaidCb.Text;

            string CinemaID = GetIDFromDatabase(selectedCinemaName, "Theater", "Name", "id");

            string staffID = GetNextStaffID();

            if (picPhoto.Tag == null || fullname == "" || phonenum == "" || email == "" || username == "" || password == "" || confirm == "" || gender == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin và tải ảnh đại diện!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (password != confirm)
            {
                MessageBox.Show("Mật khẩu không trùng khớp !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra tính hợp lệ của email
            if (!checkEmail(email))
            {
                MessageBox.Show("Email không hợp lệ! Vui lòng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (CheckEmailExists(email))
            {
                MessageBox.Show("Email đã tồn tại trong cơ sở dữ liệu! Vui lòng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra tính hợp lệ của tên đăng nhập
            if (!checkAccount(username))
            {
                MessageBox.Show("Tên đăng nhập không hợp lệ! Vui lòng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (CheckUsernameExists(username))
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại trong cơ sở dữ liệu! Vui lòng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra tính hợp lệ của mật khẩu
            if (!checkAccount(password))
            {
                MessageBox.Show("Mật khẩu không hợp lệ! Vui lòng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Tiến hành thêm thông tin người dùng vào cơ sở dữ liệu
            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                string staffQuery = @"
            INSERT INTO [Staff] (StaffID, Name, Username, Password, Email, PhoneNumber, BirthDate, Gender, StartingDate, Role, IsDeleted, Image, CinemaID)
            VALUES (@StaffID, @Name, @Username, @Password, @Email, @PhoneNumber, @BirthDate, @Gender, @StartingDate, @Role, @IsDeleted, @Image, @CinemaID);
            SELECT SCOPE_IDENTITY();";

                using (SqlCommand staffCommand = new SqlCommand(staffQuery, connection))
                {
                    connection.Open();
                    // Thêm các tham số vào command
                    staffCommand.Parameters.AddWithValue("@StaffID", staffID);
                    staffCommand.Parameters.AddWithValue("@Name", fullname);
                    staffCommand.Parameters.AddWithValue("@Username", username);
                    staffCommand.Parameters.AddWithValue("@Password", hashedPassword);
                    staffCommand.Parameters.AddWithValue("@Email", email);
                    staffCommand.Parameters.AddWithValue("@PhoneNumber", phonenum);
                    staffCommand.Parameters.AddWithValue("@BirthDate", birthDate);
                    staffCommand.Parameters.AddWithValue("@Gender", gender);
                    staffCommand.Parameters.AddWithValue("@StartingDate", DateTime.Now);
                    staffCommand.Parameters.AddWithValue("@Role", rolename);
                    staffCommand.Parameters.AddWithValue("@IsDeleted", false);

                    staffCommand.Parameters.AddWithValue("@Image", picPhoto.Tag);

                    staffCommand.Parameters.AddWithValue("@CinemaID", CinemaID);

                    int rowsAffected = staffCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Thêm nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        AddUserType(staffID, roleNameID);
                        // Thông báo cho form cha (StaffForm) rằng đã thêm thành công
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("Thêm nhân viên không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
