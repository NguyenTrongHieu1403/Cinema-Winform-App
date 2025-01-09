using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Text.RegularExpressions;

namespace Main
{
    public partial class ForgotPass : Form
    {
        public ForgotPass()
        {
            InitializeComponent();
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
        }

        private int currentImageIndex = 0;

        private Random random = new Random(); // Tạo một đối tượng Random ở mức độ lớp
        private List<string> imagePaths = new List<string>
{
    @"C:\Users\asus\Downloads\Cinema Finale\Poster\1.jpg",
    @"C:\Users\asus\Downloads\Cinema Finale\Poster\2.jpg",
    @"C:\Users\asus\Downloads\Cinema Finale\Poster\3.jpg",
    @"C:\Users\asus\Downloads\Cinema Finale\Poster\4.jpg",
    @"C:\Users\asus\Downloads\Cinema Finale\Poster\5.png",
    @"C:\Users\asus\Downloads\Cinema Finale\Poster\6.jpg",
};

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


        public bool checkEmail(string em)//Check Email
        {
            return Regex.IsMatch(em, @"^[\w-\.]{3,20}@gmail.com(.vn|)$");
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

        // Tạo mật khẩu ngẫu nhiên
        private string GenerateRandomPassword()
        {
            // Tạo một chuỗi mật khẩu ngẫu nhiên
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, 8)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void UpdatePassword(string email, string hashedPassword)
        {
            string query = "UPDATE Staff SET Password = @Password WHERE Email = @Email";
            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Password", hashedPassword);
                command.Parameters.AddWithValue("@Email", email);
                command.ExecuteNonQuery();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = tbEmail.Text;
            // Kiểm tra tính hợp lệ của email
            if (!checkEmail(email))
            {
                MessageBox.Show("Vui lòng nhập Email của bạn! (Bao gồm @gmail.com)");
                return;
            }

            if (!CheckEmailExists(email))
            {
                MessageBox.Show("Email của bạn chưa được đăng ký! Vui lòng kiểm tra lại Email của bạn!");
                return;
            }

            try
            {
                string newpass = GenerateRandomPassword();
                string hashedpass = PasswordHasher.HashPassword(newpass);
                UpdatePassword(email, hashedpass);
                tbPassword.Text = newpass;
            }

            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi trong quá trình tạo mật khẩu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbEmail.Text = "";
            tbPassword.Text = "";
        }

        private void lbForgotPassword_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thoát chương trình ? ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Chọn một chỉ số ngẫu nhiên từ 0 đến số lượng phần tử trong danh sách - 1
            int randomIndex = random.Next(0, imagePaths.Count);

            // Hiển thị ảnh tại chỉ số ngẫu nhiên được chọn
            pictureBox1.ImageLocation = imagePaths[randomIndex];
        }

        private void ForgotPass_Load(object sender, EventArgs e)
        {
            // Gán ảnh đầu tiên từ danh sách vào pictureBox1
            pictureBox1.ImageLocation = imagePaths[0];

            // Bắt đầu timer1
            timer1.Start();
        }
    }

}
