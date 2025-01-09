using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Main.FormLogin;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Main
{
    public partial class EditProfile : Form
    {
        public EditProfile()
        {
            InitializeComponent();
        }

        private void EditProfile_Load(object sender, EventArgs e)
        {
            // Khóa lại các textbox CreatedAt, Username, và Email
            tbCreatedAt.ReadOnly = true;
            tbUsername.ReadOnly = true;
            tbEmail.ReadOnly = true;

            // Truy vấn SQL để lấy thông tin từ bảng Customer dựa trên Username từ Session
            string query = "SELECT * FROM Customer WHERE Username = @Username";

            // Khởi tạo kết nối và command
            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Thêm tham số @Username vào command
                    command.Parameters.AddWithValue("@Username", FormLogin.Session.Username);

                    // Mở kết nối
                    connection.Open();

                    // Thực thi truy vấn và đọc dữ liệu
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Kiểm tra xem có dữ liệu được trả về không
                        if (reader.Read())
                        {
                            // Đọc dữ liệu từ SqlDataReader và hiển thị lên các TextBox
                            tbEmail.Text = reader["Email"].ToString();
                            tbName.Text = reader["Name"].ToString();
                            tbCreatedAt.Text = reader["CreatedAt"].ToString();
                            tbPhoneNumber.Text = reader["PhoneNumber"].ToString();
                            tbUsername.Text = reader["Username"].ToString();
                            tbPassword.Text = reader["Password"].ToString();

                            // Kiểm tra nếu có đường dẫn ảnh trong cơ sở dữ liệu
                            if (reader["Photo"] != DBNull.Value)
                            {
                                // Lấy đường dẫn ảnh từ cơ sở dữ liệu
                                string photoPath = reader["Photo"].ToString();

                                // Kiểm tra đường dẫn có tồn tại không
                                if (File.Exists(photoPath))
                                {
                                    // Hiển thị hình ảnh trên PictureBox
                                    picPhoto.Image = Image.FromFile(photoPath);
                                }
                                else
                                {
                                    MessageBox.Show("Không tìm thấy đường dẫn hình ảnh!");
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy thông tin người dùng!");
                        }
                    }
                }
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            string Name = tbName.Text;
            string PhoneNumber = tbPhoneNumber.Text;
            string Password = tbPassword.Text;
            string CreatedAt = tbCreatedAt.Text;
            string Username = tbUsername.Text;
            string Email = tbEmail.Text;


            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                string query = "UPDATE Customer SET Name = @Name, PhoneNumber = @PhoneNumber, Password = @Password WHERE Username = @Username";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Thêm tham số @Name, @PhoneNumber, @Password và @Username vào command
                    command.Parameters.AddWithValue("@Name", Name);
                    command.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
                    command.Parameters.AddWithValue("@Password", Password);
                    command.Parameters.AddWithValue("@Username", FormLogin.Session.Username);

                    // Mở kết nối
                    connection.Open();

                    // Thực thi truy vấn UPDATE
                    int rowsAffected = command.ExecuteNonQuery();

                    // Kiểm tra xem có bản ghi nào bị ảnh hưởng hay không
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Cập nhật thông tin thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy thông tin người dùng hoặc không có thông tin nào được cập nhật!");
                    }
                }
            }
        }



        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPhoto_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files (*.jpg, *.jpeg, *.png, *.gif, *.bmp)|*.jpg; *.jpeg; *.png; *.gif; *.bmp|All files (*.*)|*.*";
                openFileDialog.Title = "Choose an image";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Lấy đường dẫn của hình ảnh đã chọn
                    string selectedImagePath = openFileDialog.FileName;

                    // Cập nhật đường dẫn hình ảnh vào cơ sở dữ liệu
                    using (SqlConnection connection = Connection.GetSqlConnection())
                    {
                        string query = "UPDATE Customer SET Photo = @Photo WHERE Username = @Username";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            // Thêm tham số @Photo và @Username vào command
                            command.Parameters.AddWithValue("@Photo", selectedImagePath);
                            command.Parameters.AddWithValue("@Username", FormLogin.Session.Username);

                            // Mở kết nối
                            connection.Open();

                            // Thực thi truy vấn UPDATE
                            int rowsAffected = command.ExecuteNonQuery();

                            // Kiểm tra xem có bản ghi nào bị ảnh hưởng hay không
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Cập nhật hình ảnh thành công!");

                                // Hiển thị hình ảnh trên PictureBox
                                picPhoto.Image = Image.FromFile(selectedImagePath);
                            }
                            else
                            {
                                MessageBox.Show("Không tìm thấy thông tin người dùng hoặc không có thông tin nào được cập nhật!");
                            }
                        }
                    }
                }
            }
        }

        private void lbClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thoát chương trình ? ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
