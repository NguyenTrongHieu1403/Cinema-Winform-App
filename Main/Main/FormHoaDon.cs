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
using static Main.ParentForm;

namespace Main
{
    public partial class FormHoaDon : Form
    {
        private string Username;
        private Movie selectedMovie;
        private DateTime timeOfPurchase;
        private int giaVe;
        private string roomNumber;
        private List<MiniProducts> selectedProducts = new List<MiniProducts>();
        private string connectionString = "Data Source=LAPTOP-96IDN57Q\\LAPTRINH2024;Initial Catalog=CinemaDBAW;Integrated Security=True;";
        public FormHoaDon(Movie movie, string username, DateTime timeOfPurchase, string roomNumber, List<MiniProducts> selectedProducts = null)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            DisplaySelectedSeats();

            this.selectedMovie = movie;
            this.timeOfPurchase = timeOfPurchase;
            this.roomNumber = roomNumber;
            this.Username = username;

            if (selectedProducts != null)
            {
                // Lưu danh sách các MiniProducts
                this.selectedProducts = selectedProducts;

                // Hiển thị thông tin sản phẩm
                DisplaySelectedProducts();
            }
            DisplayReceipt();
            TinhTong();
        }


        private string GetStaffIdByUsername(string username)
        {
            string staffId = "";

            // Query to retrieve StaffID based on username
            string query = "SELECT StaffID FROM Staff WHERE Username = @Username";

            // Establish a connection to the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Create a command with the SQL query
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters to the command
                    command.Parameters.AddWithValue("@Username", username);

                    try
                    {
                        // Open the database connection
                        connection.Open();

                        // Execute the command and retrieve the StaffID
                        object result = command.ExecuteScalar();

                        // Check if the result is not null
                        if (result != null)
                        {
                            // Convert the result to a string
                            staffId = result.ToString();

                            // StaffID successfully retrieved
                            return staffId;
                        }
                        else
                        {
                            // No StaffID found for the given username
                            MessageBox.Show("StaffID not found for the given username.");
                            return null; // Return null instead of -1
                        }
                    }
                    catch (SqlException ex)
                    {
                        // Handle any SQL exceptions
                        MessageBox.Show("SQL error: " + ex.Message);
                        return null; // Return null instead of -1
                    }
                    catch (Exception ex)
                    {
                        // Handle any other exceptions
                        MessageBox.Show("An error occurred: " + ex.Message);
                        return null; // Return null instead of -1
                    }
                }
            }
        }




        private void DisplaySelectedProducts()
        {
            int startY = 12;

            // Duyệt qua từng MiniProducts trong danh sách và hiển thị thông tin sản phẩm
            foreach (MiniProducts miniProducts in selectedProducts)
            {
                Label lblProductName = new Label();
                lblProductName.Text = "Tên sản phẩm: " + miniProducts.GetProductName();
                lblProductName.Font = new Font(lblProductName.Font, FontStyle.Bold); // Đặt in đậm
                lblProductName.ForeColor = Color.Red;
                lblProductName.Font = new Font(lblProductName.Font.FontFamily, 14); // Đặt kích thước font
                lblProductName.Location = new Point(0, startY);
                lblProductName.AutoSize = true;

                Label lblPrice = new Label();
                lblPrice.Text = "Giá: " + miniProducts.GetPrice() + " đ";
                lblPrice.Font = new Font(lblProductName.Font, FontStyle.Bold); // Đặt in đậm
                lblPrice.ForeColor = Color.Red;
                lblPrice.Font = new Font(lblProductName.Font.FontFamily, 13); // Đặt kích thước font
                lblPrice.Location = new Point(385, startY);
                lblPrice.AutoSize = true;

                Label lblQuantity = new Label();
                lblQuantity.Text = "Số lượng: " + miniProducts.GetQuantity();
                lblQuantity.Font = new Font(lblProductName.Font, FontStyle.Bold); // Đặt in đậm
                lblQuantity.ForeColor = Color.Red;
                lblQuantity.Font = new Font(lblProductName.Font.FontFamily, 13); // Đặt kích thước font
                lblQuantity.Location = new Point(240, startY);
                lblQuantity.AutoSize = true;

                // Thêm các Label vào PanelHoaDon
                panelHT.Controls.Add(lblProductName);
                panelHT.Controls.Add(lblPrice);
                panelHT.Controls.Add(lblQuantity);

                // Cập nhật vị trí y cho sản phẩm tiếp theo
                startY += 25;
            }
        }
        public FormHoaDon()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        private void DisplaySelectedSeats()
        {
            string seatsString = string.Join(",", SharedData.SelectedSeats);
            listBoxVe.Items.Add(seatsString);
        }
        private void TinhTong()
        {
            int tongSanPham;
            int.TryParse(lblGiaSanPham.Text.Replace("đ", ""), out tongSanPham);
            int tongGiaVe;
            int.TryParse(lblGiaVe.Text.Replace("đ", ""), out tongGiaVe);
            int Tong = tongGiaVe + tongSanPham;
            lblTongKet.Text = Tong.ToString() + "đ";

        }
        private void DisplayReceipt()
        {
            lblMovieName.Text = ShareData.MovieName;
            lblTimeOfPurchase.Text = ShareData.TimeOfPurchase.ToString("dd/MM/yyyy HH:mm:ss");
            lblGiaVe.Text = ShareData.TongGiaVe.ToString() + "đ"; // Thay thế lblGiaVe.Text bằng ShareData.GiaVe
            lblTicketPrice.Text = ShareData.Gia1Ve.ToString() + "đ"; // Thay thế lblGiaVe.Text bằng ShareData.GiaVe
            lblRoomNumber.Text = ShareData.RoomNumber;
            lblGiaSanPham.Text = ShareData.TongSanPham.ToString() + "đ";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                // Ẩn TextBox1
                textBox1.Visible = false;
                textBox2.Visible = false;
                textBox3.Visible = false;
                label12.Visible = false;
                label13.Visible = false;
                label14.Visible = false;
            }
            else
            {
                // Hiển thị TextBox1 nếu CheckBox không được check
                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                label12.Visible = true;
                label13.Visible = true;
                label14.Visible = true;
            }
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            // Kiểm tra các TextBox không được để trống nếu chúng đang hiển thị
            if ((textBox1.Visible && string.IsNullOrWhiteSpace(textBox1.Text)) ||
        (textBox2.Visible && string.IsNullOrWhiteSpace(textBox2.Text)) ||
        (textBox3.Visible && string.IsNullOrWhiteSpace(textBox3.Text)))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin vào các trường.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Kiểm tra nếu người dùng đã chọn vào ô CheckBox (khách vãng lai)
            if (checkBox1.Checked)
            {
                try
                {
                    // Mở kết nối đến cơ sở dữ liệu
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        // Bắt đầu một giao dịch để đảm bảo tính toàn vẹn dữ liệu
                        using (SqlTransaction transaction = connection.BeginTransaction())
                        {
                            try
                            {
                                string Staffid = GetStaffIdByUsername(Username);

                                // Chèn dữ liệu vào bảng Bill (không chèn dữ liệu vào bảng Customer)
                                string insertBillQuery = @"
                            INSERT INTO Bill (TotalPrice,StaffID)
                            VALUES (@TotalPrice,@StaffID);";

                                using (SqlCommand billCommand = new SqlCommand(insertBillQuery, connection, transaction))
                                {
                                    string tongKetText = lblTongKet.Text;

                                    // Loại bỏ dấu phẩy và ký tự "đ" từ chuỗi
                                    tongKetText = tongKetText.Replace(",", "").Replace("đ", "");

                                    // Chuyển đổi chuỗi thành số nguyên
                                    int totalPrice = 0;
                                    if (int.TryParse(tongKetText, out totalPrice))
                                    {
                                        billCommand.Parameters.AddWithValue("@TotalPrice", totalPrice);
                                    }

                                    billCommand.Parameters.AddWithValue("@StaffID", Staffid);

                                    // Thực thi câu lệnh SQL
                                    billCommand.ExecuteNonQuery();
                                }

                                // Commit transaction nếu không có lỗi xảy ra
                                transaction.Commit();

                                // Hiển thị thông báo thành công
                                MessageBox.Show("Hoàn tất !", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            catch (Exception ex)
                            {
                                // Rollback transaction nếu có lỗi xảy ra
                                transaction.Rollback();

                                // Hiển thị thông báo lỗi
                                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Hiển thị thông báo lỗi nếu có lỗi xảy ra ngoài giao dịch
                    MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    // Mở kết nối đến cơ sở dữ liệu
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        // Bắt đầu một giao dịch để đảm bảo tính toàn vẹn dữ liệu
                        using (SqlTransaction transaction = connection.BeginTransaction())
                        {
                            try
                            {
                                // Chèn dữ liệu vào bảng Customer
                                string insertCustomerQuery = @"
                        INSERT INTO Customer (Name, PhoneNumber, Email, IsDeleted)
                        VALUES (@Name, @PhoneNumber, @Email, 'False');
                        SELECT SCOPE_IDENTITY();";

                                int customerId;

                                using (SqlCommand customerCommand = new SqlCommand(insertCustomerQuery, connection, transaction))
                                {
                                    customerCommand.Parameters.AddWithValue("@Name", textBox1.Text);
                                    customerCommand.Parameters.AddWithValue("@PhoneNumber", textBox2.Text);
                                    customerCommand.Parameters.AddWithValue("@Email", textBox3.Text); // Assuming textBox3 is for Email

                                    // Thực hiện câu lệnh INSERT và lấy CustomerID của khách hàng vừa thêm vào
                                    customerId = Convert.ToInt32(customerCommand.ExecuteScalar());
                                }

                                string Staffid = GetStaffIdByUsername(Username);
                                // Chèn dữ liệu vào bảng Bill
                                string insertBillQuery = @"
                        INSERT INTO Bill (CustomerID, TotalPrice,StaffID)
                        VALUES (@CustomerID, @TotalPrice,@StaffID);";

                                using (SqlCommand billCommand = new SqlCommand(insertBillQuery, connection, transaction))
                                {
                                    billCommand.Parameters.AddWithValue("@CustomerID", customerId);
                                    billCommand.Parameters.AddWithValue("@StaffID", Staffid);


                                    string tongKetText = lblTongKet.Text;

                                    // Loại bỏ dấu phẩy và ký tự "đ" từ chuỗi
                                    tongKetText = tongKetText.Replace(",", "").Replace("đ", "");

                                    // Chuyển đổi chuỗi thành số nguyên
                                    int totalPrice = 0;
                                    if (int.TryParse(tongKetText, out totalPrice))
                                    {
                                        billCommand.Parameters.AddWithValue("@TotalPrice", totalPrice);
                                    }

                                    // Thực thi câu lệnh SQL
                                    billCommand.ExecuteNonQuery();
                                }

                                // Commit transaction nếu không có lỗi xảy ra
                                transaction.Commit();

                                // Hiển thị thông báo thành công
                                MessageBox.Show("Hoàn tất !", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            catch (Exception ex)
                            {
                                // Rollback transaction nếu có lỗi xảy ra
                                transaction.Rollback();

                                // Hiển thị thông báo lỗi
                                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Hiển thị thông báo lỗi nếu có lỗi xảy ra ngoài giao dịch
                    MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // Xóa nội dung của các TextBox sau khi lưu dữ liệu thành công
                if (textBox1.Visible) textBox1.Text = "";
                if (textBox2.Visible) textBox2.Text = "";
                if (textBox3.Visible) textBox3.Text = "";
            }




        }
    }
}
