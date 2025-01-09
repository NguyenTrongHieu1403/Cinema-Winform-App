using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using static Main.ParentForm;

namespace Main
{
    public partial class FormSanPham : Form
    {
        private string Username;
        private int currentPage = 0;
        private int productsPerPage = 4; // Số lượng sản phẩm trên mỗi trang
        private List<Product> allProducts;
        private List<Product> foodProducts;
        private List<Product> drinkProducts;
        private List<ProductUserControl> productUserControls = new List<ProductUserControl>();
        private ProductUserControl productUserControl;
        private static string connectionString = "Data Source=LAPTOP-96IDN57Q\\LAPTRINH2024;Initial Catalog=CinemaDBAW;Integrated Security=True;";
        public FormSanPham(string username)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Controls.Add(productUserControl);
            // Load dữ liệu sản phẩm và hiển thị
            LoadProducts();
            DisplayAllProducts();
            this.Username = username;
        }
        List<MiniProducts> miniProductsList = new List<MiniProducts>();
        int nextYPosition = 0;
        Dictionary<ProductUserControl, MiniProducts> productToMiniMap = new Dictionary<ProductUserControl, MiniProducts>();
        private void lblNumber_ValueChanged(MiniProducts miniProducts)
        {
            UpdateTotalPrice();
        }
        private void SortMiniProducts()
        {
            int newYPosition = 0;

            // Duyệt qua từng MiniProducts trong panel và cập nhật vị trí của chúng
            foreach (Control control in panelHienThiSP.Controls)
            {
                MiniProducts miniProducts = control as MiniProducts;

                // Kiểm tra null và kiểu dữ liệu của control
                if (miniProducts != null)
                {
                    // Cập nhật vị trí y của MiniProducts
                    miniProducts.Location = new Point(0, newYPosition);

                    // Tăng vị trí y cho MiniProducts tiếp theo
                    newYPosition += miniProducts.Height;
                }
                UpdateTotalPrice();
            }
        }
        private void DeleteMiniProducts(object sender, EventArgs e)
        {
            MiniProducts miniProductsToDelete = sender as MiniProducts;

            // Kiểm tra xem MiniProducts có trong panel không
            if (panelHienThiSP.Controls.Contains(miniProductsToDelete))
            {
                // Đặt giá trị của MiniProducts về 0
                miniProductsToDelete.ResetValues();

                // Sắp xếp lại vị trí của các MiniProducts sau khi một MiniProducts bị xóa
                panelHienThiSP.Controls.Remove(miniProductsToDelete);
                SortMiniProducts();

                // Xóa MiniProducts khỏi productToMiniMap
                foreach (var pair in productToMiniMap.ToList())
                {
                    if (pair.Value == miniProductsToDelete)
                    {
                        productToMiniMap.Remove(pair.Key);
                        UpdateTotalPrice();
                    }
                }
                UpdateTotalPrice();
            }
        }
        private void CheckAndRemoveDuplicateMiniProducts()
        {
            // Tạo một danh sách tạm thời để lưu trữ các MiniProducts có giá trị
            List<MiniProducts> tempList = new List<MiniProducts>();

            // Duyệt qua từng MiniProducts trong panel
            foreach (Control control in panelHienThiSP.Controls)
            {
                MiniProducts miniProducts = control as MiniProducts;

                // Kiểm tra xem control có phải là MiniProducts không
                if (miniProducts != null)
                {
                    // Kiểm tra xem MiniProducts đã tồn tại trong danh sách tạm thời chưa
                    bool isExist = tempList.Any(temp => temp.GetProductName() == miniProducts.GetProductName() &&
                                                          temp.GetPrice() == miniProducts.GetPrice());

                    // Nếu MiniProducts đã tồn tại, tăng số lượng của existingMiniProducts và loại bỏ MiniProducts hiện tại
                    if (isExist)
                    {
                        MiniProducts existingMiniProducts = tempList.First(temp => temp.GetProductName() == miniProducts.GetProductName() &&
                                                                                    temp.GetPrice() == miniProducts.GetPrice());

                        // Tăng số lượng của existingMiniProducts bằng số lượng của miniProducts hiện tại
                        existingMiniProducts.IncreaseQuantity(miniProducts.GetQuantity());

                        // Loại bỏ MiniProducts hiện tại
                        panelHienThiSP.Controls.Remove(miniProducts);
                    }
                    else
                    {
                        tempList.Add(miniProducts);
                    }
                }
            }
            UpdateTotalPrice();
        }
        private List<MiniProducts> selectedProducts = new List<MiniProducts>();
        private void ProductUserControl_Click(ProductUserControl productUserControl)
        {
            MiniProducts miniProducts = null;

            // Lấy số lượng từ ProductUserControl
            int number = productUserControl.GetQuantity();

            // Kiểm tra nếu số lượng là 0, hiển thị MessageBox và không thêm sản phẩm
            if (number == 0)
            {
                MessageBox.Show("Sản phẩm đã hết hàng.");
                return;
            }

            // Tiếp tục xử lý như bình thường nếu số lượng khác 0
            if (!productToMiniMap.ContainsKey(productUserControl))
            {
                Image image = productUserControl.GetProductImage();
                string name = productUserControl.GetProductName();
                int price = productUserControl.GetPrice();

                // Khởi tạo MiniProducts và truyền dữ liệu
                miniProducts = new MiniProducts();
                miniProducts.SetData(name, price, number);
                miniProducts.LimitNumber();
                miniProducts.DefaultNumber();
                miniProducts.SetProductImage(image);

                // Thêm MiniProducts vào panel và sắp xếp
                panelHienThiSP.Controls.Add(miniProducts);
                panelHienThiSP.Controls.SetChildIndex(miniProducts, 0);
                CheckAndRemoveDuplicateMiniProducts();
                productToMiniMap.Add(productUserControl, miniProducts);
                miniProducts.ValueChanged += (sender, e) => lblNumber_ValueChanged(miniProducts);
                miniProducts.MiniProductsDeleted += DeleteMiniProducts;
                SortMiniProducts();
                UpdateTotalPrice();
            }
            else
            {
                // Tăng số lượng nếu sản phẩm đã tồn tại
                MiniProducts existingMiniProducts = productToMiniMap[productUserControl];
                existingMiniProducts.IncreaseQuantity(1);
                UpdateTotalPrice();
                SortMiniProducts();
            }

            // Nếu sản phẩm được thêm thành công, thêm vào danh sách các sản phẩm được chọn
            if (miniProducts != null)
            {
                selectedProducts.Add(miniProducts);
            }
        }
        private void UpdateTotalPrice()
        {
            int totalPrice = 0;

            // Duyệt qua các MiniProducts trong panelHienThiSP
            foreach (Control control in panelHienThiSP.Controls)
            {
                MiniProducts miniProducts = control as MiniProducts;

                // Kiểm tra xem control có phải là MiniProducts không
                if (miniProducts != null)
                {
                    int pricePerItem = miniProducts.GetPrice();
                    int quantity = miniProducts.GetQuantity();
                    totalPrice += pricePerItem * quantity;
                }
            }

            // Hiển thị tổng giá trên lblThanhTien
            lblThanhTien.Text = $"{totalPrice}đ";
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

        private void button1_Click(object sender, EventArgs e)
        {
            DisplayAllProducts();
        }

        private void btnDoAn_Click(object sender, EventArgs e)
        {
            DisplayFoodProducts();
        }

        private void btnDoUong_Click(object sender, EventArgs e)
        {
            DisplayDrinkProducts();
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
        private void DisplayFoodProducts()
        {
            DisplayProducts(foodProducts);
            SortMiniProducts();
        }

        private void DisplayAllProducts()
        {
            DisplayProducts(allProducts);
            SortMiniProducts();
        }

        private void DisplayDrinkProducts()
        {
            DisplayProducts(drinkProducts);
            SortMiniProducts();
        }
        private void DisplayProducts(List<Product> products)
        {
            foreach (ProductUserControl panel in productUserControls)
            {
                panel.Dispose();
            }
            productUserControls.Clear();

            int paddingBetweenProductUserControls = 10;
            int productUserControlWidth = (panelSanPham.Width - (productsPerPage + 1) * paddingBetweenProductUserControls) / productsPerPage;
            int productUserControlHeight = 233;

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
                    ProductUserControl productUserControl = new ProductUserControl(product.ProductType);
                    productUserControl.SetProductImage(product.ImagePath);
                    productUserControl.SetProductName(product.Name);
                    productUserControl.SetPrice(product.Price);
                    productUserControl.SetQuantity(product.Quantity);
                    productUserControl.Size = new Size(productUserControlWidth, productUserControlHeight);
                    productUserControl.Location = new Point(x, y);
                    panelSanPham.Controls.Add(productUserControl);
                    productUserControls.Add(productUserControl);
                    productUserControl.Click += (sender, e) => ProductUserControl_Click(productUserControl);
                    productUserControl.btnAddClick((sender, e) => ProductUserControl_Click(productUserControl));
                    productUserControl.PicTureBoxClick((sender, e) => ProductUserControl_Click(productUserControl));
                }
            }
            UpdateTotalPrice();
        }
        private int GetTongSanPham()
        {
            // Lấy tổng giá vé từ label TongGiaVe
            int tongSanPham;
            if (!int.TryParse(lblThanhTien.Text.Replace("đ", ""), out tongSanPham))
            {
                // Xử lý nếu không thể chuyển đổi thành công
                MessageBox.Show("Lỗi: Không thể chuyển đổi tổng giá vé thành số nguyên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return tongSanPham;
        }
        private void SubtractQuantityFromDatabase(string productName, int quantityToSubtract)
        {
            string query = "UPDATE Product SET Quantity = Quantity - @QuantityToSubtract WHERE Product_Name = @ProductName";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@QuantityToSubtract", quantityToSubtract);
                    command.Parameters.AddWithValue("@ProductName", productName);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error subtracting quantity: " + ex.Message);
                    }
                }
            }
        }
        private void XoaTatCaMiniProducts()
        {
            // Xóa toàn bộ các MiniProducts từ panelHienThiSP
            panelHienThiSP.Controls.Clear();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (selectedProducts.Count == 0)
            {
                MessageBox.Show("Không có sản phẩm nào được chọn.");
            }

            XoaTatCaMiniProducts();
            ShareData.TongSanPham = GetTongSanPham();
            SeatBookingForm seatBookingForm = new SeatBookingForm(Username);

            // Sau khi SeatBookingForm được đóng, kiểm tra xem liệu người dùng đã hoàn thành hành động không
            (Movie selectedMovie, DateTime timeOfPurchase, string roomNumber) = seatBookingForm.GetBookingInfo();

            // Lặp qua các sản phẩm đã chọn để trừ số lượng từ cơ sở dữ liệu
            foreach (MiniProducts miniProducts in selectedProducts)
            {
                string productName = miniProducts.GetProductName();
                int quantityToSubtract = miniProducts.GetQuantity();

                // Trừ số lượng từ cơ sở dữ liệu
                SubtractQuantityFromDatabase(productName, quantityToSubtract);
            }
            LoadProducts();
            DisplayAllProducts();
            // Sử dụng thông tin này để tạo FormHoaDon
            FormHoaDon formHoaDon = new FormHoaDon(selectedMovie, Username, timeOfPurchase, roomNumber, selectedProducts);
            formHoaDon.ShowDialog();
            this.Close();
        }

    }
}