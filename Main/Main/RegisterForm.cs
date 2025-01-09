using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Security.Cryptography;


namespace Main
{
    public partial class RegisterForm : Form
    {

        private List<string> imagePaths = new List<string>
{
    @"C:\Users\asus\Downloads\Cinema Finale\Poster\1.jpg",
    @"C:\Users\asus\Downloads\Cinema Finale\Poster\2.jpg",
    @"C:\Users\asus\Downloads\Cinema Finale\Poster\3.jpg",
    @"C:\Users\asus\Downloads\Cinema Finale\Poster\4.jpg",
    @"C:\Users\asus\Downloads\Cinema Finale\Poster\5.png",
    @"C:\Users\asus\Downloads\Cinema Finale\Poster\6.jpg",
};
        public RegisterForm()
        {
            InitializeComponent();
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
        }

        private Random random = new Random();

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Chọn một chỉ số ngẫu nhiên từ 0 đến số lượng phần tử trong danh sách - 1
            int randomIndex = random.Next(0, imagePaths.Count);

            // Hiển thị ảnh tại chỉ số ngẫu nhiên được chọn
            pictureBox1.ImageLocation = imagePaths[randomIndex];
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            // Gán ảnh đầu tiên từ danh sách vào pictureBox1
            pictureBox1.ImageLocation = imagePaths[0];

            // Bắt đầu timer1
            timer1.Start();
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
            string query = "SELECT COUNT(*) FROM Customer WHERE Username = @Username";
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
            string query = "SELECT COUNT(*) FROM Customer WHERE Email = @Email";
            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Email", email);
                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string userName = tbUsername.Text;
            string email = tbEmail.Text;
            string passWord = tbPassword.Text;
            string confirmPassword = tbConfirmPassword.Text;

            // Kiểm tra tính hợp lệ của tên đăng nhập
            if (!checkAccount(userName))
            {
                MessageBox.Show("Vui lòng nhập Tên đăng nhập của bạn! (Dài từ 6 - 24 ký tự.) (Chỉ chấp nhận: a-z, A-Z, 0 - 9)");
                return;
            }

            if (CheckUsernameExists(userName))
            {
                MessageBox.Show("Tên đăng nhập của bạn đã được đăng ký! Vui lòng kiểm tra lại Tên đăng nhập của bạn!");
                return;
            }

            /*     // Kiểm tra xem tên đăng nhập đã tồn tại chưa
                 if (modified.Accounts("Select * from Customer where Username = '" + userName + "'").Count != 0)
                 {
                     MessageBox.Show("Tên đăng nhập của bạn đã được đăng ký! Vui lòng kiểm tra lại Tên đăng nhập của bạn!");
                     return;
                 }*/

            // Kiểm tra tính hợp lệ của email
            if (!checkEmail(email))
            {
                MessageBox.Show("Vui lòng nhập Email của bạn! (Bao gồm @gmail.com)");
                return;
            }

            if (CheckEmailExists(email))
            {
                MessageBox.Show("Email của bạn đã được đăng ký! Vui lòng kiểm tra lại Email của bạn!");
                return;
            }

            /*      // Kiểm tra xem email đã tồn tại chưa
                  if (modified.Accounts("Select * from Customer where Email = '" + email + "'").Count != 0)
                  {
                      MessageBox.Show("Email của bạn đã được đăng ký! Vui lòng kiểm tra lại Email của bạn!");
                      return;
                  }*/


            // Kiểm tra tính hợp lệ của mật khẩu
            if (!checkAccount(passWord))
            {
                MessageBox.Show("Vui lòng nhập Mật khẩu của bạn! (Dài từ 6 - 24 ký tự.) (Chỉ chấp nhận: a-z, A-Z, 0 - 9)");
                return;
            }

            // Kiểm tra xem mật khẩu xác nhận có khớp với mật khẩu đã nhập không
            if (confirmPassword != passWord)
            {
                MessageBox.Show("Vui lòng kiểm tra lại Mật khẩu xác nhận của bạn!");
                return;
            }

          

           

            // Thực hiện thêm mới tài khoản vào cơ sở dữ liệu
            try
            {
                string query = "INSERT INTO Customer (Name, PhoneNumber, CreatedAt, Email,isDeleted, Username, Password, Photo) VALUES (@Name, @PhoneNumber, @CreatedAt, @Email,@isDeleted,  @UserName, @Password ,@Photo)";
                using (SqlConnection connection = Connection.GetSqlConnection()) // Sử dụng using để tự động giải phóng tài nguyên kết nối
                {
                    connection.Open(); // Mở kết nối
                    SqlCommand command = new SqlCommand(query, connection); // Truyền đối tượng kết nối vào constructor của SqlCommand
                    command.Parameters.AddWithValue("@Name", "");
                    command.Parameters.AddWithValue("@PhoneNumber", DBNull.Value);
                    command.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@isDeleted", DBNull.Value);
                    command.Parameters.AddWithValue("@UserName", userName);
                    command.Parameters.AddWithValue("@Password", passWord);
                    command.Parameters.AddWithValue("@Photo", DBNull.Value);

                    command.ExecuteNonQuery(); // Thực thi câu lệnh SQL
                }

                if (MessageBox.Show("Đăng ký thành công! Bạn có muốn đăng nhập ngay bây giờ không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi đăng ký tài khoản của bạn. Vui lòng thử lại.\n" + ex.Message);
            }
        }


        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    builder.Append(hashBytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        private void cbShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (cbShowPassword.Checked)
            {
                tbPassword.PasswordChar = '\0';
                tbConfirmPassword.PasswordChar = '\0';
            }
            else
            {
                tbPassword.PasswordChar = '*';
                tbConfirmPassword.PasswordChar = '*';
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbUsername.Text = "";
            tbPassword.Text = "";
            tbConfirmPassword.Text = "";
            tbEmail.Text = "";
        }

        private void lbBackToLogin_Click(object sender, EventArgs e)
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
    }
}
