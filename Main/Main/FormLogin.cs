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




namespace Main
{
    public partial class FormLogin : Form
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


        private int currentImageIndex = 0;



        public FormLogin()
        {
            InitializeComponent();
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
        }

        public static class Session
        {
            public static string Username { get; set; }
            public static DateTime LastLoginTime { get; set; }
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thoát chương trình ? ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void cbShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (cbShowPassword.Checked)
            {
                tbPassword.PasswordChar = '\0';
            }
            else
            {
                tbPassword.PasswordChar = '*';
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbUsername.Text = "";
            tbPassword.Text = "";
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
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = tbUsername.Text;
            string passWord = tbPassword.Text;
            int cinemaID = 0; // Khai báo cinemaID và gán giá trị mặc định

            // Kiểm tra nếu userName hoặc passWord có chứa ký tự trống
            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(passWord))
            {
                MessageBox.Show("Hãy nhập đầy đủ tên tài khoản và mật khẩu !");
                return; // Dừng xử lý tiếp theo
            }

            string hashedPassword = PasswordHasher.HashPassword(passWord);
            string query = "SELECT * FROM Staff WHERE Username = @Username AND Password = @Password";

            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", userName);
                    command.Parameters.AddWithValue("@Password", hashedPassword);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            // Code xử lý đăng nhập thành công giống như trước

                            while (reader.Read())
                            {
                                int roleId = Convert.ToInt32(reader["Role"]); // Lấy giá trị của cột Role

                                // Kiểm tra vai trò của nhân viên và chuyển đến các form tương ứng
                                if (roleId == 1) // Manger
                                {
                                    MessageBox.Show("Đăng nhập thành công !");
                                    cinemaID = GetCinemaIDFromStaff(userName); // Lấy cinemaID
                                    HomeCinema managerForm = new HomeCinema(userName, cinemaID);
                                    managerForm.Show();
                                    this.Hide();
                                }
                                else if (roleId == 2 || roleId == 3) // Nhân viên thường
                                {
                                    MessageBox.Show("Đăng nhập thành công !");
                                    cinemaID = GetCinemaIDFromStaff(userName); // Lấy cinemaID
                                    CinemaSaleHome employeeForm = new CinemaSaleHome(userName, cinemaID);
                                    employeeForm.Show();
                                    this.Hide();
                                }
                                // Thêm các điều kiện khác nếu có các vai trò khác
                            }
                        }
                        else
                        {
                            MessageBox.Show("Tên tài khoản hoặc mật khẩu không đúng !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
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



        // Trong class FormLogin

        private int GetCinemaIDFromStaff(string username)
        {
            int cinemaID = -1; // Giá trị mặc định nếu không tìm thấy

            string query = "SELECT CinemaID FROM Staff WHERE Username = @Username";

            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    connection.Open();

                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        // Ép kiểu giá trị trả về từ ExecuteScalar về kiểu dữ liệu của CinemaID (vd: int)
                        cinemaID = Convert.ToInt32(result);
                    }
                }
            }

            return cinemaID;
        }

        private void lbForgotPassword_Click(object sender, EventArgs e)
        {
            ForgotPass forgot = new ForgotPass();
            this.Hide();
            forgot.ShowDialog();
            this.Show();
        }
    }
}
