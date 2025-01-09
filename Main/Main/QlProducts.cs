using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Main.qlSanPham;
namespace Main
{
    public partial class QlProducts : UserControl
    {
        public QlProducts(string type)
        {
            InitializeComponent();
            lblPrice.ReadOnly = true;
            ProductType = type; // Gán giá trị cho ProductType khi tạo mới QlProducts
        }
        public string ProductName
        {
            get { return lblName.Text; }
            set { lblName.Text = value; }
        }
        public Image GetProductImage()
        {
            return pictureBox.Image;
        }
        public void SetProductName(string name)
        {
            lblName.Text = name;
        }

        public void SetPrice(int price)
        {
            lblPrice.Text = string.Format("{0}đ", price);
        }
        public void SetNumber(int number)
        {
            lblQuantity.Text = number.ToString();
        }
        public void SetProductImage(string imagePath)
        {
            ProductImagePath = imagePath;
            if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
            {
                pictureBox.Image = Image.FromFile(imagePath);
            }
            else
            {
                pictureBox.Image = null;
            }
        }
        public void PicTureBoxClick(EventHandler handler)
        {
            pictureBox.Click += handler;
        }
        public event EventHandler ProductClicked;

        private void OnProductClicked(EventArgs e)
        {
            ProductClicked?.Invoke(this, e);
        }
        private void QlProducts_Click(object sender, EventArgs e)
        {
            OnProductClicked(EventArgs.Empty);
        }
        public string GetProductName()
        {
            return lblName.Text;
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
        public int GetNumber()
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
        public delegate void QlProductsDeletedEventHandler(object sender, EventArgs e);
        public event QlProductsDeletedEventHandler QlProductsDeleted;
        private void iconButton2_Click(object sender, EventArgs e)
        {
            QlProductsDeleted?.Invoke(this, EventArgs.Empty);
        }
        private string productType;

        public string ProductType
        {
            get { return productType; }
            set { productType = value; }
        }
        public int ProductPrice
        {
            get
            {
                int price;
                if (int.TryParse(lblPrice.Text.Replace("đ", ""), out price))
                {
                    return price;
                }
                return 0;
            }
            set { lblPrice.Text = string.Format("{0}đ", value); }
        }

        public string ProductImagePath { get; private set; }

        public event EventHandler<ProductEditEventArgs> EditButtonClicked;
        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditButtonClicked?.Invoke(this, new ProductEditEventArgs
            {
                ProductName = this.ProductName,
                ProductPrice = this.ProductPrice,
                ImagePath = this.ProductImagePath
            });
        }
    }
    public class ProductEditEventArgs : EventArgs
    {
        public string ProductName { get; set; }
        public int ProductPrice { get; set; }
        public string ImagePath { get; set; }
    }

}
