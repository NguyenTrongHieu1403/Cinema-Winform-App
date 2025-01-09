using System;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Main
{
    public partial class EditCustomer : Form
    {
        private string CustomerID;

        public EditCustomer(string customerID)
        {
            InitializeComponent();
            CustomerID = customerID;
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

        public bool CheckEmail(string em)
        {
            // Kiểm tra định dạng email và độ dài không quá 50 ký tự
            return Regex.IsMatch(em, @"^[A-Za-z0-9._%+-]{3,50}@gmail.com$");
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string name = tbName.Text;
                string phoneNumber = tbphone.Text;
                string newEmail = tbEmail.Text;



                // Khởi tạo kết nối và command
                using (SqlConnection connection = Connection.GetSqlConnection())
                {
                    // Mở kết nối
                    connection.Open();

                    // Lấy email hiện tại từ cơ sở dữ liệu
                    string currentEmail = GetCurrentEmail();

                    // Kiểm tra xem email mới có khác với email hiện tại không
                    if (newEmail != currentEmail)
                    {
                        // Kiểm tra email hợp lệ
                        if (!CheckEmail(newEmail))
                        {
                            MessageBox.Show("Email không hợp lệ! Vui lòng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Kiểm tra sự tồn tại của email trong cơ sở dữ liệu
                        if (CheckEmailExists(newEmail))
                        {
                            MessageBox.Show("Email đã tồn tại trong cơ sở dữ liệu! Vui lòng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    string cusname = tbName.Text;
                    string cusphone = tbphone.Text;
                    string cusemail = tbEmail.Text;

                    if (cusname == null || cusphone == null || cusemail == null)
                    {
                        MessageBox.Show("Dữ liệu không được bỏ trống !");
                        return;
                    }

                    // Câu lệnh SQL UPDATE để cập nhật thông tin của khách hàng
                    string query = @"
                UPDATE Customer 
                SET Name = @Name, 
                    PhoneNumber = @PhoneNumber, 
                    Email = @Email
                WHERE CustomerID = @CustomerID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Thêm các tham số cho câu lệnh SQL UPDATE
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                        command.Parameters.AddWithValue("@Email", newEmail);
                        command.Parameters.AddWithValue("@CustomerID", CustomerID);

                        // Thực thi câu lệnh SQL UPDATE
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Dữ liệu khách hàng đã được cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Đóng form chỉnh sửa khi cập nhật thành công
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Không có dữ liệu nào được cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi khi cập nhật dữ liệu khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Hàm để lấy email hiện tại từ cơ sở dữ liệu
        private string GetCurrentEmail()
        {
            string currentEmail = "";

            try
            {
                // Khởi tạo kết nối và command
                using (SqlConnection connection = Connection.GetSqlConnection())
                {
                    // Mở kết nối
                    connection.Open();

                    string query = @"
                SELECT Email
                FROM Customer
                WHERE CustomerID = @CustomerID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CustomerID", CustomerID);
                        currentEmail = (string)command.ExecuteScalar();
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi khi truy cập cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return currentEmail;
        }


        private void LoadDataCustomer()
        {
            try
            {
                // Khởi tạo kết nối và command
                using (SqlConnection connection = Connection.GetSqlConnection())
                {
                    // Mở kết nối
                    connection.Open();

                    string query = @"
            SELECT s.*
            FROM Customer s
            WHERE s.CustomerID = @CustomerID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CustomerID", CustomerID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string name = reader["Name"].ToString();
                                string phoneNumber = reader["PhoneNumber"].ToString();
                                string email = reader["Email"].ToString();

                                // Gán dữ liệu vào các control trên form
                                tbName.Text = name;
                                tbphone.Text = phoneNumber;
                                tbEmail.Text = email;

                                // Load dữ liệu vào các ComboBox khác nếu cần
                            }
                            else
                            {
                                MessageBox.Show("Không tìm thấy thông tin khách hàng!");
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi khi truy cập cơ sở dữ liệu: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void EditCustomer_Load(object sender, EventArgs e)
        {
            LoadDataCustomer();
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
