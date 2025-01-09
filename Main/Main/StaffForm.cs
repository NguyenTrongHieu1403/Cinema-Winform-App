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

namespace Main
{
    public partial class StaffForm : Form
    {
        private string username;
        private const string placeholderText = "Tìm kiếm...";
        public StaffForm(string username)
        {
            InitializeComponent();
            this.username = username;
            InitializePlaceholder();

        }
        private void InitializePlaceholder()
        {
            guna2TextBox1.Text = placeholderText;
            guna2TextBox1.ForeColor = Color.Gray;
        }

        private void LoadUserDataIntoGridView()
        {
            // Xóa dữ liệu cũ trong DataGridView nếu có
            guna2DataGridView1.Rows.Clear();

            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                // Mở kết nối
                connection.Open();

                // Truy vấn để lấy dữ liệu từ bảng Staff và Role thông qua StaffRole, lọc những nhân viên không bị đánh dấu xóa
                string query = @"
SELECT s.StaffID, s.Name, s.Gender, CONVERT(varchar, s.BirthDate, 23) AS BirthDate, 
       s.PhoneNumber AS PhoneNumber, s.Email, 
       r.Role_Name AS RoleName, 
       s.StartingDate
FROM Staff s
JOIN StaffRole sr ON s.StaffID = sr.StaffID
JOIN Role r ON sr.RoleID = r.id
WHERE s.IsDeleted = 0";

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
                            string staffID = reader["StaffID"].ToString();
                            string name = reader["Name"].ToString();
                            string gender = reader["Gender"].ToString();
                            string birthDate = reader["BirthDate"].ToString(); // Đảm bảo chuyển đổi an toàn từ kiểu dữ liệu SQL sang kiểu string
                            string phoneNumber = reader["PhoneNumber"].ToString();
                            string email = reader["Email"].ToString();
                            string roleName = reader["RoleName"].ToString();
                            DateTime startingDate = Convert.ToDateTime(reader["StartingDate"]);

                            // Thêm dữ liệu vào DataGridView chỉ với các cột cần hiển thị
                            guna2DataGridView1.Rows.Add(staffID, name, gender, birthDate,
                                                        phoneNumber, email, roleName,
                                                        startingDate);
                        }
                    }
                }
            }
        }









        private string GetUsernameByStaffID(string staffID)
        {
            string username = ""; // Khởi tạo giá trị mặc định là rỗng

            // Kết nối đến cơ sở dữ liệu
            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                // Mở kết nối
                connection.Open();

                // Kiểm tra xem staffID có tồn tại trong cơ sở dữ liệu không
                string checkExistQuery = "SELECT COUNT(*) FROM Staff WHERE StaffID = @StaffID";
                using (SqlCommand checkExistCommand = new SqlCommand(checkExistQuery, connection))
                {
                    checkExistCommand.Parameters.AddWithValue("@StaffID", staffID);
                    int count = (int)checkExistCommand.ExecuteScalar();
                    if (count > 0)
                    {
                        // Nếu staffID tồn tại, thực hiện truy vấn để lấy username
                        string query = "SELECT Username FROM Staff WHERE StaffID = @StaffID";

                        // Tạo đối tượng SqlCommand
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            // Thêm tham số cho StaffID vào truy vấn
                            command.Parameters.AddWithValue("@StaffID", staffID);

                            // Thực thi truy vấn và lấy giá trị Username
                            object result = command.ExecuteScalar();

                            // Kiểm tra kết quả trả về, nếu không null thì gán giá trị vào biến username
                            if (result != null)
                            {
                                username = result.ToString();
                            }
                        }
                    }
                }
            }

            return username;
        }






        private void SearchAndDisplayResults(string searchText)
        {
            // Xóa dữ liệu cũ trong DataGridView
            guna2DataGridView1.Rows.Clear();
            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                // Mở kết nối
                connection.Open();

                // Truy vấn để lấy dữ liệu từ bảng Staff và Role thông qua StaffRole, lọc những nhân viên không bị đánh dấu xóa
                string query = @"
SELECT s.StaffID, s.Name, s.Gender, CONVERT(varchar, s.BirthDate, 23) AS BirthDate, 
       s.PhoneNumber AS PhoneNumber, s.Email, 
       r.Role_Name AS RoleName, 
       s.StartingDate
FROM Staff s
JOIN StaffRole sr ON s.StaffID = sr.StaffID
JOIN Role r ON sr.RoleID = r.id
WHERE s.IsDeleted = 0
AND (s.StaffID LIKE @SearchText OR s.Name LIKE @SearchText 
     OR s.Gender LIKE @SearchText OR CONVERT(varchar, s.BirthDate, 23) LIKE @SearchText
     OR s.PhoneNumber LIKE @SearchText OR s.Email LIKE @SearchText 
     OR r.Role_Name LIKE @SearchText OR CONVERT(varchar, s.StartingDate, 23) LIKE @SearchText)";

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
                            string staffID = reader["StaffID"].ToString();
                            string name = reader["Name"].ToString();
                            string gender = reader["Gender"].ToString();
                            string birthDate = reader["BirthDate"].ToString(); // Đảm bảo chuyển đổi an toàn từ kiểu dữ liệu SQL sang kiểu string
                            string phoneNumber = reader["PhoneNumber"].ToString();
                            string email = reader["Email"].ToString();
                            string roleName = reader["RoleName"].ToString();
                            DateTime startingDate = Convert.ToDateTime(reader["StartingDate"]);

                            // Thêm dữ liệu vào DataGridView chỉ với các cột cần hiển thị
                            guna2DataGridView1.Rows.Add(staffID, name, gender, birthDate,
                                                        phoneNumber, email, roleName,
                                                        startingDate);
                        }
                    }
                }
            }
        }



        private void SearchAndDisplayResults(DateTime selectedDate)
        {
            // Xóa dữ liệu cũ trong DataGridView
            guna2DataGridView1.Rows.Clear();
            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                // Mở kết nối
                connection.Open();

                // Truy vấn để lấy dữ liệu từ bảng Staff và Role thông qua StaffRole, lọc những nhân viên không bị đánh dấu xóa
                string query = @"
SELECT s.StaffID, s.Name, s.Gender, CONVERT(varchar, s.BirthDate, 23) AS BirthDate, 
       s.PhoneNumber AS PhoneNumber, s.Email, 
       r.Role_Name AS RoleName, 
       s.StartingDate
FROM Staff s
JOIN StaffRole sr ON s.StaffID = sr.StaffID
JOIN Role r ON sr.RoleID = r.id
WHERE s.IsDeleted = 0
AND (CONVERT(date, s.StartingDate) = @SelectedDate OR CONVERT(date, s.BirthDate) = @SelectedDate)";

                // Tạo đối tượng SqlCommand
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Thêm tham số cho ngày được chọn
                    command.Parameters.AddWithValue("@SelectedDate", selectedDate);

                    // Thực thi truy vấn và lấy dữ liệu
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Đọc từng dòng dữ liệu và thêm vào DataGridView
                        while (reader.Read())
                        {
                            // Lấy các giá trị từ cột trong bảng
                            string staffID = reader["StaffID"].ToString();
                            string name = reader["Name"].ToString();
                            string gender = reader["Gender"].ToString();
                            string birthDate = reader["BirthDate"].ToString(); // Đảm bảo chuyển đổi an toàn từ kiểu dữ liệu SQL sang kiểu string
                            string phoneNumber = reader["PhoneNumber"].ToString();
                            string email = reader["Email"].ToString();
                            string roleName = reader["RoleName"].ToString();
                            DateTime startingDate = Convert.ToDateTime(reader["StartingDate"]);

                            // Thêm dữ liệu vào DataGridView chỉ với các cột cần hiển thị
                            guna2DataGridView1.Rows.Add(staffID, name, gender, birthDate,
                                                        phoneNumber, email, roleName,
                                                        startingDate);
                        }
                    }
                }
            }
        }


        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text != placeholderText)
            {
                string searchText = guna2TextBox1.Text.Trim();

                if (string.IsNullOrEmpty(searchText))
                {
                    LoadUserDataIntoGridView();
                }
                else
                {
                    SearchAndDisplayResults(searchText);
                }
            }
        }


        private void DeleteUser(string userID)
        {
            // Cập nhật trường isDeleted thành 1 cho nhân viên có UserID tương ứng
            string deleteUserQuery = "UPDATE Staff SET IsDeleted = 1 WHERE StaffID = @StaffID";

            // Kết nối đến cơ sở dữ liệu và thực thi truy vấn
            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                connection.Open();

                // Cập nhật trường isDeleted
                using (SqlCommand command = new SqlCommand(deleteUserQuery, connection))
                {
                    command.Parameters.AddWithValue("@StaffID", userID);
                    int rowsAffected = command.ExecuteNonQuery();
                }
            }

            // Hiển thị thông báo sau khi cập nhật trường isDeleted
            MessageBox.Show("Đã đánh dấu nhân viên đã bị xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadUserDataIntoGridView();
        }


        private void StaffForm_Load(object sender, EventArgs e)
        {
            LoadUserDataIntoGridView();
            // Đặt các giá trị cho ComboBox
            guna2ComboBox1.Items.Add("BirthDate");
            guna2ComboBox1.Items.Add("StartingDate");
            guna2ComboBox1.SelectedIndex = 0; // Chọn giá trị mặc định

            // Gắn kết sự kiện
            guna2ComboBox1.SelectedIndexChanged += new System.EventHandler(this.guna2ComboBox1_SelectedIndexChanged);
            StartTime.ValueChanged += new System.EventHandler(this.StartTime_ValueChanged);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2TextBox1_Enter(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text == placeholderText)
            {
                guna2TextBox1.Text = "";
                guna2TextBox1.ForeColor = Color.Black;
            }
        }

        private void guna2TextBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(guna2TextBox1.Text))
            {
                InitializePlaceholder();
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            StaffProperties staffpro = new StaffProperties(username);
            DialogResult result = staffpro.ShowDialog();

            // Kiểm tra kết quả trả về từ form StaffProperties
            if (result == DialogResult.OK)
            {
                // Nếu thêm nhân viên thành công, cập nhật lại dữ liệu
                LoadUserDataIntoGridView();
            }
        }



        private void guna2DataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == Column1.Index)
            {
                // Lấy StaffID của dòng được chọn
                string StaffID = guna2DataGridView1.Rows[e.RowIndex].Cells["StaffID"].Value.ToString();



                // Chuyển đến form editstaff và truyền username vào constructor
                editstaff editStaffForm = new editstaff(StaffID);
                editStaffForm.ShowDialog();
                LoadUserDataIntoGridView();
            }
            if (e.ColumnIndex == Column2.Index)
            {
                // Xử lý sự kiện xóa nhân viên
                string staffID = guna2DataGridView1.Rows[e.RowIndex].Cells["StaffID"].Value.ToString();

                // Truy vấn cơ sở dữ liệu để lấy Username tương ứng với StaffID
                string username = GetUsernameByStaffID(staffID);

                // Hiển thị hộp thoại xác nhận
                DialogResult result = MessageBox.Show($"Bạn có muốn xóa nhân viên {username} không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Nếu người dùng chọn Yes, thực hiện đánh dấu nhân viên đã bị xóa
                    DeleteUser(staffID);
                }
            }
        }
        private void PerformSearch()
        {
            // Xóa dữ liệu cũ trong DataGridView
            guna2DataGridView1.Rows.Clear();

            // Lấy giá trị từ DateTimePicker và chỉ lấy phần ngày
            DateTime selectedDate = StartTime.Value.Date;

            // Lấy giá trị cột được chọn từ ComboBox
            string selectedColumn = guna2ComboBox1.SelectedItem.ToString();

            // Gọi hàm tìm kiếm và hiển thị kết quả
            SearchAndDisplayResults(selectedDate, selectedColumn);
        }
        // Hàm tìm kiếm và hiển thị kết quả dựa trên ngày được chọn và cột được chọn
        // Hàm tìm kiếm và hiển thị kết quả dựa trên ngày được chọn và cột được chọn
        private void SearchAndDisplayResults(DateTime selectedDate, string selectedColumn)
        {
            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                // Mở kết nối
                connection.Open();

                // Truy vấn để lấy dữ liệu từ bảng Staff và Role thông qua StaffRole, lọc những nhân viên không bị đánh dấu xóa
                string query = @"
SELECT s.StaffID, s.Name, s.Gender, CONVERT(varchar, s.BirthDate, 23) AS BirthDate, 
       s.PhoneNumber AS PhoneNumber, s.Email, 
       r.Role_Name AS RoleName, 
       s.StartingDate
FROM Staff s
JOIN StaffRole sr ON s.StaffID = sr.StaffID
JOIN Role r ON sr.RoleID = r.id
WHERE s.IsDeleted = 0
AND CONVERT(date, s." + selectedColumn + ") >= @SelectedDate";

                // Tạo đối tượng SqlCommand
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Thêm tham số cho ngày được chọn
                    command.Parameters.AddWithValue("@SelectedDate", selectedDate);

                    // Thực thi truy vấn và lấy dữ liệu
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Đọc từng dòng dữ liệu và thêm vào DataGridView
                        while (reader.Read())
                        {
                            // Lấy các giá trị từ cột trong bảng
                            string staffID = reader["StaffID"].ToString();
                            string name = reader["Name"].ToString();
                            string gender = reader["Gender"].ToString();
                            string birthDate = reader["BirthDate"].ToString(); // Đảm bảo chuyển đổi an toàn từ kiểu dữ liệu SQL sang kiểu string
                            string phoneNumber = reader["PhoneNumber"].ToString();
                            string email = reader["Email"].ToString();
                            string roleName = reader["RoleName"].ToString();
                            DateTime startingDate = Convert.ToDateTime(reader["StartingDate"]);

                            // Thêm dữ liệu vào DataGridView chỉ với các cột cần hiển thị
                            int rowIndex = guna2DataGridView1.Rows.Add(staffID, name, gender, birthDate,
                                                                        phoneNumber, email, roleName,
                                                                        startingDate);


                            // Đặt màu chữ của tiêu đề cột dựa trên cột được chọn
                            foreach (DataGridViewColumn column in guna2DataGridView1.Columns)
                            {
                                column.HeaderCell.Style.ForeColor = Color.Black; // Màu mặc định
                            }

                            int selectedColumnIndex = guna2DataGridView1.Columns[selectedColumn].Index;
                            guna2DataGridView1.Columns[selectedColumnIndex].HeaderCell.Style.ForeColor = Color.Red;

                            // Refresh the DataGridView to ensure the color is applied
                            guna2DataGridView1.Refresh();
                        }
                    }
                }
            }
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            PerformSearch();
        }

        private void StartTime_ValueChanged(object sender, EventArgs e)
        {
            PerformSearch();
        }

        private void guna2TextBox1_Click(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text == placeholderText)
            {
                guna2TextBox1.Text = "";
                guna2TextBox1.ForeColor = Color.Black;
            }
        }
    }
}

