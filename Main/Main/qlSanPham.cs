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
using System.Windows.Forms;

namespace Main
{
    public partial class qlSanPham : Form
    {
        private string Username;
        private QlProducts currentProduct;
        private string selectedImagePath;
        private int productsPerPage = 5;
        private List<Product> allProducts;
        private List<Product> foodProducts;
        private List<Product> drinkProducts;
        private List<QlProducts> qlProducts = new List<QlProducts>();
        private static string connectionString = "Data Source=LAPTOP-96IDN57Q\\LAPTRINH2024;Initial Catalog=DBAA;Integrated Security=True;";
        public qlSanPham(string username)
        {
            InitializeComponent();
            LoadProducts();
            DisplayAllProducts();
            comboBox1.SelectedItem = "Tất Cả";
            panels = new List<Panel> { panelThem, panelEdit, panelNhapHang };
            HideAllPanels();
            this.Username = username;
        }
        private List<Panel> panels;




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









        private void ShowPanel(Panel panel)
        {
            if (panel == panelEdit)
            {
                panel.Location = new Point(351, 80);
            }
            else if (panel == panelNhapHang)
            {
                panel.Location = new Point(376, 82);
            }
            else if (panel == panelThem)
            {
                panel.Location = new Point(296, 78);
            }

            panel.Visible = true;
            UpdateCursorClip();
        }
        private void HidePanel(Panel panel)
        {
            panel.Visible = false;
            UpdateCursorClip();
        }
        private void HideAllPanels()
        {
            foreach (var panel in panels)
            {
                panel.Visible = false;
            }
            UpdateCursorClip();
        }
        private void UpdateCursorClip()
        {
            var visiblePanel = panels.FirstOrDefault(p => p.Visible);
            if (visiblePanel != null)
            {
                Cursor.Clip = visiblePanel.RectangleToScreen(visiblePanel.ClientRectangle);
            }
            else
            {
                Cursor.Clip = Rectangle.Empty;
            }
        }
        public class Product
        {
            public string Name { get; set; }
            public int Price { get; set; }
            public string ImagePath { get; set; }
            public int Quantity { get; set; }
            public string ProductType { get; set; }

            public Product(string name, int price, string imagePath, int quantity, string productType)
            {
                Name = name;
                Price = price;
                ImagePath = imagePath;
                Quantity = quantity;
                ProductType = productType;
            }
        }
        private void LoadAllProducts()
        {
            allProducts = new List<Product>();
            allProducts.AddRange(foodProducts);
            allProducts.AddRange(drinkProducts);
        }
        private void LoadProducts()
        {
            string query = "SELECT Product_Name, Price, Image, Quantity, Category, IsDeleted FROM Product WHERE IsDeleted = 'False'";

            allProducts = new List<Product>();
            foodProducts = new List<Product>();
            drinkProducts = new List<Product>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string name = reader["Product_Name"].ToString();
                            int price = Convert.ToInt32(reader["Price"]);
                            string imagePath = reader["Image"].ToString();
                            int quantity = Convert.ToInt32(reader["Quantity"]);
                            string category = reader["Category"].ToString();

                            Product newProduct = new Product(name, price, imagePath, quantity, category);
                            allProducts.Add(newProduct);

                            if (category == "Food")
                            {
                                newProduct.ProductType = "Đồ Ăn";
                                foodProducts.Add(newProduct);
                            }
                            else if (category == "Drink")
                            {
                                newProduct.ProductType = "Đồ Uống";
                                drinkProducts.Add(newProduct);
                            }
                        }
                    }
                }
            }
        }
        private void DisplayProducts(List<Product> products)
        {
            foreach (QlProducts panel in qlProducts)
            {
                panel.Dispose();
            }
            qlProducts.Clear();

            int paddingBetweenProductUserControls = 10;
            int productUserControlWidth = (panelSanPham.Width - (productsPerPage + 1) * paddingBetweenProductUserControls) / productsPerPage;
            int productUserControlHeight = 190;

            int rows = (products.Count + productsPerPage - 1) / productsPerPage;

            int x, y;

            for (int row = 0; row < rows; row++)
            {
                y = paddingBetweenProductUserControls + row * (productUserControlHeight + paddingBetweenProductUserControls);

                for (int col = 0; col < productsPerPage; col++)
                {
                    int index = row * productsPerPage + col;
                    if (index >= products.Count)
                        break;

                    x = paddingBetweenProductUserControls + col * (productUserControlWidth + paddingBetweenProductUserControls);

                    Product product = products[index];
                    QlProducts productUserControl = new QlProducts(product.ProductType);
                    productUserControl.SetProductImage(product.ImagePath);
                    productUserControl.SetProductName(product.Name);
                    productUserControl.SetPrice(product.Price);
                    productUserControl.SetNumber(product.Quantity);
                    productUserControl.Size = new Size(productUserControlWidth, productUserControlHeight);
                    productUserControl.Location = new Point(x, y);
                    panelSanPham.Controls.Add(productUserControl);
                    qlProducts.Add(productUserControl);
                    productUserControl.QlProductsDeleted += DeleteQlProducts;
                    productUserControl.EditButtonClicked += QlProducts_EditButtonClicked;
                }
            }
        }
        private void UpdateProductInDatabase(string oldName, string newName, int newPrice, string newImagePath, string productType)
        {
            string query = "UPDATE Product SET Product_Name = @NewName, Price = @NewPrice, Image = @NewImagePath WHERE Product_Name = @OldName AND Category = @ProductType";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@OldName", oldName);
                    command.Parameters.AddWithValue("@NewName", newName);
                    command.Parameters.AddWithValue("@NewPrice", newPrice);
                    command.Parameters.AddWithValue("@NewImagePath", newImagePath);
                    command.Parameters.AddWithValue("@ProductType", productType == "Đồ Ăn" ? "Food" : "Drink");

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Đã cập nhật sản phẩm thành công.");
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Lỗi khi cập nhật sản phẩm: " + ex.Message);
                    }
                }
            }
        }
        private void QlProducts_EditButtonClicked(object sender, ProductEditEventArgs e)
        {
            currentProduct = sender as QlProducts;
            txtEditName.Text = e.ProductName;
            currentProduct.Name = e.ProductName;
            txtEditPrice.Text = e.ProductPrice.ToString();
            pictureBox3.Image = Image.FromFile(e.ImagePath);
            selectedImagePath = e.ImagePath;
            ShowPanel(panelEdit);
        }
        private void DisplayFoodProducts()
        {
            DisplayProducts(foodProducts);
        }

        private void DisplayAllProducts()
        {
            DisplayProducts(allProducts);
        }

        private void DisplayDrinkProducts()
        {
            DisplayProducts(drinkProducts);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Đồ Ăn")
            {
                DisplayFoodProducts();
            }
            if (comboBox1.SelectedItem.ToString() == "Đồ Uống")
            {
                DisplayDrinkProducts();
            }
            if (comboBox1.SelectedItem.ToString() == "Tất Cả")
            {
                DisplayAllProducts();
            }
        }
        private string RemoveAccents(string input)
        {
            string normalizedString = input.Normalize(NormalizationForm.FormD);
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string result = regex.Replace(normalizedString, string.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
            return result.ToLower();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string searchKeyword = RemoveAccents(textBox1.Text.Trim().ToLower());

            if (comboBox1.SelectedItem.ToString() == "Đồ Ăn")
            {
                SearchProductByName(searchKeyword, foodProducts);
            }
            else if (comboBox1.SelectedItem.ToString() == "Đồ Uống")
            {
                SearchProductByName(searchKeyword, drinkProducts);
            }
            else if (comboBox1.SelectedItem.ToString() == "Tất Cả")
            {
                SearchProductByName(searchKeyword, allProducts);
            }
        }
        private List<Product> SearchProductsByName(string searchKeyword, List<Product> products)
        {
            List<Product> searchResults = new List<Product>();

            foreach (Product product in products)
            {
                string productName = RemoveAccents(product.Name.ToLower());
                string normalizedKeyword = RemoveAccents(searchKeyword.ToLower());

                if (productName.Contains(normalizedKeyword))
                {
                    searchResults.Add(product);
                }
            }

            return searchResults;
        }
        private void SearchProductByName(string searchKeyword, List<Product> products)
        {
            // Tìm kiếm sản phẩm theo tên trong danh sách sản phẩm cụ thể
            List<Product> searchResults = SearchProductsByName(searchKeyword, products);

            // Hiển thị kết quả tìm kiếm
            DisplayProducts(searchResults);
        }
        private void InsertFoodProduct()
        {
            string name = txtNameT.Text;
            string loai = txtLoai.Text;
            int price = int.Parse(txtPrice.Text);
            string imagePath = pictureBox1.ImageLocation;

            // Xác định giá trị của Category dựa trên giá trị của loai
            string category = (loai == "Đồ Ăn") ? "Food" : (loai == "Đồ Uống") ? "Drink" : "";

            if (string.IsNullOrEmpty(category))
            {
                MessageBox.Show("Loại sản phẩm không hợp lệ.");
                return;
            }

            string query = "INSERT INTO Product (Product_Name, Price, Image, Quantity, Category, IsDeleted) VALUES (@Product_Name, @Price, @Image, @Quantity, @Category, @IsDeleted)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Product_Name", name);
                    command.Parameters.AddWithValue("@Price", price);
                    command.Parameters.AddWithValue("@Image", imagePath);
                    command.Parameters.AddWithValue("@Quantity", 0); // Đặt giá trị mặc định là 0 cho Quantity
                    command.Parameters.AddWithValue("@Category", category);
                    command.Parameters.AddWithValue("@IsDeleted", "False"); // Đặt giá trị mặc định là "False" cho IsDeleted

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Đã thêm sản phẩm thành công.");
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Lỗi khi thêm sản phẩm: " + ex.Message);
                    }
                }
            }
        }
        private void iconButton1_Click(object sender, EventArgs e)
        {
            ShowPanel(panelThem);
        }
        private bool IsInteger(string text)
        {
            int result;
            return int.TryParse(text, out result);
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu txtPrice không phải là số nguyên
            if (!IsInteger(txtPrice.Text))
            {
                MessageBox.Show("Price phải là số nguyên.");
                return;
            }
            else
            {
                InsertFoodProduct();
                LoadProducts();
                DisplayProducts(allProducts);
                txtNameT.Text = "";
                txtLoai.Text = "";
                txtPrice.Text = "";

                // Xóa ảnh trong PictureBox
                pictureBox1.Image = null;
            }
            HidePanel(panelThem);
        }
        private void DeleteQlProducts(object sender, EventArgs e)
        {
            QlProducts productControl = sender as QlProducts;
            string name = productControl.GetProductName();
            string productType = productControl.ProductType;

            // Hiển thị hộp thoại xác nhận
            DialogResult result = MessageBox.Show("Bạn có thật sự muốn xóa sản phẩm này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                string query = "UPDATE Product SET IsDeleted = 'True' WHERE Product_Name = @Name AND Category = @ProductType";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@ProductType", productType == "Đồ Ăn" ? "Food" : "Drink");

                        try
                        {
                            connection.Open();
                            command.ExecuteNonQuery();
                            MessageBox.Show("Đã chuyển sản phẩm vào thùng rác thành công.");
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show("Lỗi khi chuyển sản phẩm vào thùng rác: " + ex.Message);
                        }
                    }
                }

                LoadProducts();
                DisplayAllProducts();
            }
            else
            {
                // Người dùng đã chọn No, không thực hiện chuyển đổi giá trị IsDeleted
                MessageBox.Show("Hủy bỏ việc chuyển sản phẩm vào thùng rác.");
            }
        }
        private void btnHuySP_Click(object sender, EventArgs e)
        {
            HidePanel(panelThem);
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            Cursor.Clip = Rectangle.Empty;

            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp",
                Title = "Chọn ảnh"
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Lấy đường dẫn đến tệp ảnh được chọn
                string imagePath = openFileDialog1.FileName;

                // Hiển thị ảnh trong PictureBox1
                pictureBox1.Image = Image.FromFile(imagePath);

                // Lưu đường dẫn ảnh để sử dụng khi lưu vào cơ sở dữ liệu
                pictureBox1.ImageLocation = imagePath;
            }

            // Đặt lại giới hạn con trỏ chuột
            UpdateCursorClip();
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            Cursor.Clip = Rectangle.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedImagePath = openFileDialog.FileName;
                    pictureBox3.Image = Image.FromFile(selectedImagePath);
                }
            }
            // Đặt lại giới hạn con trỏ chuột
            UpdateCursorClip();
        }

        private void btnCancelEdit_Click(object sender, EventArgs e)
        {
            HidePanel(panelEdit);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (currentProduct != null)
            {
                string oldName = currentProduct.Name;
                string newName = txtEditName.Text;
                int newPrice = int.Parse(txtEditPrice.Text);
                string newImagePath = selectedImagePath;
                string productType = currentProduct.ProductType;

                UpdateProductInDatabase(oldName, newName, newPrice, newImagePath, productType);
                currentProduct = null;
            }

            HidePanel(panelEdit);
            LoadProducts();
            DisplayAllProducts();
        }
        private void PopulateComboBoxWithProductNames()
        {
            txtNameN.Items.Clear(); // Clear existing items

            foreach (var product in allProducts)
            {
                txtNameN.Items.Add(new ProductComboBoxItem(product.Name, product.ImagePath));
            }
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            LoadAllProducts();

            // Populate the ComboBox with product names
            PopulateComboBoxWithProductNames();

            // Display the panel
            ShowPanel(panelNhapHang);
        }
        public class ProductComboBoxItem
        {
            public string Name { get; set; }
            public string ImagePath { get; set; }

            public ProductComboBoxItem(string name, string imagePath)
            {
                Name = name;
                ImagePath = imagePath;
            }

            public override string ToString()
            {
                return Name; // This ensures the ComboBox displays the product name
            }
        }

        private void txtNameN_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtNameN.SelectedItem is ProductComboBoxItem selectedItem)
            {
                // Display the image in a PictureBox (pictureBoxProductImage)
                pictureBox2.Image = Image.FromFile(selectedItem.ImagePath);
            }
        }
        private void UpdateProductQuantity(string productName, int additionalQuantity)
        {
            string tableName = "Product"; // Tên bảng cố định là Product

            string updateQuery = $"UPDATE {tableName} SET Quantity = Quantity + @AdditionalQuantity WHERE Product_Name = @Product_Name";
            string selectQuery = $"SELECT Quantity FROM {tableName} WHERE Product_Name = @Product_Name";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand selectCommand = new SqlCommand(selectQuery, connection))
                    {
                        selectCommand.Parameters.AddWithValue("@Product_Name", productName);

                        object result = selectCommand.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int currentQuantity))
                        {
                            using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                            {
                                updateCommand.Parameters.AddWithValue("@AdditionalQuantity", additionalQuantity);
                                updateCommand.Parameters.AddWithValue("@Product_Name", productName);

                                int rowsAffected = updateCommand.ExecuteNonQuery();
                                if (rowsAffected > 0)
                                {
                                    Cursor.Clip = Rectangle.Empty;
                                    MessageBox.Show("Nhập hàng thành công.");
                                }
                                else
                                {
                                    MessageBox.Show("Nhập hàng thất bại.");
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Product not found or quantity retrieval failed.");
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Database error: " + ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }
        private int GetProductId(string productName)
        {
            int productId = -1;
            string query = "SELECT Id FROM Product WHERE Product_Name = @Product_Name";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Product_Name", productName);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            productId = reader.GetInt32(0);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error retrieving product ID: " + ex.Message);
                    }
                }
            }
            return productId;
        }

        private void SaveProductReceipt(int productId, int quantity, decimal importPrice, string staffId)
        {
            string query = "INSERT INTO ProductReceipt (ProductID, Quantity, ImportPrice,StaffID) VALUES (@ProductID, @Quantity, @ImportPrice,@StaffID)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProductID", productId);
                    command.Parameters.AddWithValue("@Quantity", quantity);
                    command.Parameters.AddWithValue("@ImportPrice", importPrice);
                    command.Parameters.AddWithValue("@StaffID", staffId);


                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error saving product receipt: " + ex.Message);
                    }
                }
            }
        }
        private decimal GetCurrentPrice(int productId)
        {
            decimal currentPrice = 0;
            string query = "SELECT Price FROM Product WHERE Id = @ProductId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProductId", productId);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            currentPrice = reader.GetDecimal(0);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error retrieving product price: " + ex.Message);
                    }
                }
            }
            return currentPrice;
        }
        private void btnNhap_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNameN.Text) || string.IsNullOrEmpty(txtnhapQuantity.Text) || string.IsNullOrEmpty(txtnhapPrice.Text))
            {
                MessageBox.Show("Không để trống các thông tin");
                return;
            }

            string selectedProductName = txtNameN.SelectedItem.ToString();
            int additionalQuantity;
            decimal importPrice;

            // Validate the input values
            if (int.TryParse(txtnhapQuantity.Text, out additionalQuantity) && decimal.TryParse(txtnhapPrice.Text, out importPrice))
            {
                int productId = GetProductId(selectedProductName);
                if (productId != -1)
                {
                    decimal currentPrice = GetCurrentPrice(productId);

                    if (importPrice > currentPrice)
                    {
                        MessageBox.Show("Giá nhập cao hơn giá hiện tại của sản phẩm.");
                        return;
                    }

                    string staffId = GetStaffIdByUsername(Username);

                    UpdateProductQuantity(selectedProductName, additionalQuantity);
                    SaveProductReceipt(productId, additionalQuantity, importPrice,staffId);
                    HidePanel(panelNhapHang);
                }
                else
                {
                    MessageBox.Show("Error: Product not found.");
                }
            }
            else
            {
                MessageBox.Show("Please enter valid quantity and price.");
            }

            // Clear input fields and reset UI
            txtNameN.Text = "";
            txtnhapQuantity.Text = "";
            txtnhapPrice.Text = "";
            pictureBox2.Image = null;
            LoadProducts();
            DisplayAllProducts();
            UpdateCursorClip();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            HidePanel(panelNhapHang);
        }

        private void qlSanPham_MouseMove(object sender, MouseEventArgs e)
        {
            var visiblePanel = panels.FirstOrDefault(p => p.Visible);
            if (visiblePanel != null)
            {
                var panelBounds = visiblePanel.RectangleToScreen(visiblePanel.ClientRectangle);
                if (!panelBounds.Contains(Cursor.Position))
                {
                    Cursor.Position = new Point(
                        Math.Max(panelBounds.Left, Math.Min(Cursor.Position.X, panelBounds.Right)),
                        Math.Max(panelBounds.Top, Math.Min(Cursor.Position.Y, panelBounds.Bottom))
                    );
                }
            }
        }
    }
}
