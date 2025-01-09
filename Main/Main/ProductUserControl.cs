using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using static Main.FormSanPham;

namespace Main
{
    public partial class ProductUserControl : UserControl
    {
        public event EventHandler AddButtonClicked;
        private List<Product> allProducts;

        // Khai báo một biến Panel để lưu trữ tham chiếu đến panelHienThiSP

        // Constructor không tham số
        public ProductUserControl(string type)
        {
            InitializeComponent();
            ProductType = type;
        }
        public event EventHandler ProductClicked;

        private void OnProductClicked(EventArgs e)
        {
            ProductClicked?.Invoke(this, e);
        }
        private void ProductUserControl_Click(object sender, EventArgs e)
        {
            OnProductClicked(EventArgs.Empty);
        }
        public void SetProductImage(string imagePath)
        {
            if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
            {
                pictureBox.Image = Image.FromFile(imagePath);
            }
            else
            {
                pictureBox.Image = null;
            }
        }
        public Image GetProductImage()
        {
            return pictureBox.Image;
        }
        public void SetProductName(string name)
        {
            lblProductName.Text = name;
        }

        public void SetPrice(int price)
        {
            lblPrice.Text = string.Format("{0}đ", price);
        }
        public void SetQuantity(int number)
        {
            lblQuantity.Text = number.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
        }
        public string GetProductName()
        {
            return lblProductName.Text;
        }
        private string productType;

        public string ProductType
        {
            get { return productType; }
            set { productType = value; }
        }
        public int GetPrice()
        {
            int price;
            if (int.TryParse(lblPrice.Text.Replace("đ", ""), out price))
            {
                return price;
            }
            else
            {
                return 0;
            }
        }
        public int GetQuantity()
        {
            int number;
            if (int.TryParse(lblQuantity.Text, out number))
            {
                return number;
            }
            else
            {
                return 0;
            }
        }
        public void PicTureBoxClick(EventHandler handler)
        {
            pictureBox.Click += handler;
        }
        public void btnAddClick(EventHandler handler)
        {
            btnAdd.Click += handler;
        }
        private void ProductUserControl_Load(object sender, EventArgs e)
        {

        }

        private void lblProductName_MouseEnter(object sender, EventArgs e)
        {
            lblProductName.ForeColor = Color.Cyan;
        }

        private void lblProductName_MouseLeave(object sender, EventArgs e)
        {
            lblProductName.ForeColor= Color.Black;
        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            label2.ForeColor = Color.Cyan;
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label2.ForeColor= Color.Black;
        }

        private void lblNumber_MouseEnter(object sender, EventArgs e)
        {
            lblQuantity.ForeColor = Color.Cyan;
        }

        private void lblNumber_MouseLeave(object sender, EventArgs e)
        {
            lblQuantity.ForeColor= Color.Black;
        }

        private void lblPrice_MouseEnter(object sender, EventArgs e)
        {
            lblPrice.ForeColor = Color.Cyan;
        }

        private void lblPrice_MouseLeave(object sender, EventArgs e)
        {
            lblPrice.ForeColor = Color.Black;
        }
    }
}