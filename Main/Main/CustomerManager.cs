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
    public partial class CustomerManager : Form
    {
        private const string placeholderText = "Tìm kiếm...";

        public CustomerManager()
        {
            InitializeComponent();
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

                // Truy vấn để lấy dữ liệu từ bảng Customer
                string query = @"
            SELECT CustomerID, Name, PhoneNumber, CONVERT(varchar, CreatedAt, 23) AS CreatedAt, Email
            FROM Customer
            WHERE IsDeleted = 0"; // Chỉ lấy những khách hàng chưa bị xóa

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
                            string customerID = reader["CustomerID"].ToString();
                            string name = reader["Name"].ToString();
                            string phoneNumber = reader["PhoneNumber"].ToString();
                            string email = reader["Email"].ToString();
                            string createdAt = reader["CreatedAt"].ToString(); // Đảm bảo chuyển đổi an toàn từ kiểu dữ liệu SQL sang kiểu string

                            // Thêm dữ liệu vào DataGridView chỉ với các cột cần hiển thị
                            guna2DataGridView1.Rows.Add(customerID, name, phoneNumber, email, createdAt);
                        }
                    }
                }
            }
        }



        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == Column1.Index)
            {
                string customerID = guna2DataGridView1.Rows[e.RowIndex].Cells["ID"].Value.ToString();

                EditCustomer editCustomerForm = new EditCustomer(customerID);
                editCustomerForm.ShowDialog();

                LoadUserDataIntoGridView();
            }
            else if (e.RowIndex >= 0 && e.ColumnIndex == Column2.Index)
            {
                string customerID = guna2DataGridView1.Rows[e.RowIndex].Cells["ID"].Value.ToString();
                string name = guna2DataGridView1.Rows[e.RowIndex].Cells["CustomerName"].Value.ToString();

                DialogResult result = MessageBox.Show($"Bạn có muốn xóa khách hàng '{name}' không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    DeleteCustomer(customerID);
                }
            }
        }

        private void DeleteCustomer(string CustomerID)
        {
            // Cập nhật trường IsDeleted thành 1 cho phim có ID tương ứng
            string deleteMovieQuery = "UPDATE Customer SET IsDeleted = 1 WHERE CustomerID = @CustomerID";

            // Kết nối đến cơ sở dữ liệu và thực thi truy vấn
            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                connection.Open();

                // Cập nhật trường IsDeleted
                using (SqlCommand command = new SqlCommand(deleteMovieQuery, connection))
                {
                    command.Parameters.AddWithValue("@CustomerID", CustomerID);
                    int rowsAffected = command.ExecuteNonQuery();
                }
            }

            // Hiển thị thông báo sau khi cập nhật trường IsDeleted
            MessageBox.Show("Đã đánh dấu khách hàng đã bị xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadUserDataIntoGridView();
        }
        private void CustomerManager_Load(object sender, EventArgs e)
        {
            LoadUserDataIntoGridView();
            LoadYearsAndMonthsIntoComboBoxes();
        }

        private void guna2TextBox1_Click(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text == placeholderText)
            {
                guna2TextBox1.Text = "";
                guna2TextBox1.ForeColor = Color.Black;
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

        private void guna2TextBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(guna2TextBox1.Text))
            {
                InitializePlaceholder();
            }
        }


        private void SearchAndDisplayResults(string searchText)
        {
            // Clear old data from the DataGridView
            guna2DataGridView1.Rows.Clear();

            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                // Open connection
                connection.Open();

                // Query to search for customers based on the provided search text
                string query = @"
            SELECT CustomerID, Name, PhoneNumber, CONVERT(varchar, CreatedAt, 23) AS CreatedAt, Email
            FROM Customer
            WHERE CustomerID LIKE @SearchText OR Name LIKE @SearchText OR PhoneNumber LIKE @SearchText OR Email LIKE @SearchText";

                // Create SqlCommand object
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add search text parameter
                    command.Parameters.AddWithValue("@SearchText", "%" + searchText + "%");

                    // Execute the query and retrieve data
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Read each row of data and add to the DataGridView
                        while (reader.Read())
                        {
                            // Get values from columns in the table
                            string customerID = reader["CustomerID"].ToString();
                            string name = reader["Name"].ToString();
                            string phoneNumber = reader["PhoneNumber"].ToString();
                            string createdAt = reader["CreatedAt"].ToString();
                            string email = reader["Email"].ToString();

                            // Add data to DataGridView with only the columns needed to display
                            guna2DataGridView1.Rows.Add(customerID, name, phoneNumber, email, createdAt);
                        }
                    }
                }
            }
        }
        private void LoadYearsAndMonthsIntoComboBoxes()
        {
            List<int> years = new List<int>();
            List<int> months = new List<int>();

            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                connection.Open();

                string query = "SELECT DISTINCT YEAR(CreatedAt) AS Year, MONTH(CreatedAt) AS Month FROM Customer";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int year = Convert.ToInt32(reader["Year"]);
                            int month = Convert.ToInt32(reader["Month"]);

                            if (!years.Contains(year))
                            {
                                years.Add(year);
                            }

                            if (!months.Contains(month))
                            {
                                months.Add(month);
                            }
                        }
                    }
                }
            }

            // Đổ dữ liệu vào ComboBox của năm
            foreach (int year in years)
            {
                comboBoxYear.Items.Add(year);
            }

            // Đổ dữ liệu vào ComboBox của tháng từ 1 đến 12
            for (int i = 1; i <= 12; i++)
            {
                comboBoxMonth.Items.Add(i);
            }
        }



        private void guna2ComboBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchByYearAndMonth();
        }

        private void comboBoxMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchByYearAndMonth();
        }
        private void SearchByYearAndMonth()
        {
            // Kiểm tra xem có mục nào được chọn trong ComboBox không
            if (comboBoxYear.SelectedItem != null && comboBoxMonth.SelectedItem != null)
            {
                // Lấy năm và tháng được chọn từ ComboBoxes
                int selectedYear = (int)comboBoxYear.SelectedItem;
                int selectedMonth = (int)comboBoxMonth.SelectedItem;

                using (SqlConnection connection = Connection.GetSqlConnection())
                {
                    connection.Open();

                    // Query để lấy dữ liệu dựa trên năm và tháng được chọn
                    string query = @"
                SELECT CustomerID, Name, PhoneNumber, CONVERT(varchar, CreatedAt, 23) AS CreatedAt, Email
                FROM Customer
                WHERE YEAR(CreatedAt) = @Year AND MONTH(CreatedAt) = @Month";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Thêm các tham số cho năm và tháng
                        command.Parameters.AddWithValue("@Year", selectedYear);
                        command.Parameters.AddWithValue("@Month", selectedMonth);

                        // Thực thi truy vấn và hiển thị kết quả
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            guna2DataGridView1.Rows.Clear(); // Xóa dữ liệu cũ trước khi hiển thị kết quả mới

                            while (reader.Read())
                            {
                                string customerID = reader["CustomerID"].ToString();
                                string name = reader["Name"].ToString();
                                string phoneNumber = reader["PhoneNumber"].ToString();
                                string createdAt = reader["CreatedAt"].ToString();
                                string email = reader["Email"].ToString();

                                guna2DataGridView1.Rows.Add(customerID, name, phoneNumber, email, createdAt);
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn năm và tháng trước khi tìm kiếm.");
            }
        }



    }
}
