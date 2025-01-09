using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main
{
    public partial class MiniProducts : UserControl
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Number { get; set; }

        // Các phương thức để thiết lập dữ liệu
        public void SetData(string name, int price, int number)
        {
            Name = name;
            Price = price;
            Number = number;

            // Cập nhật giao diện người dùng sau khi thiết lập dữ liệu
            lblProductName.Text = name;
            lblPrice.Text = string.Format("{0}đ", price);
            lblQuantity.Text = number.ToString();

        }
        public MiniProducts()
        {
            InitializeComponent();
            lblQuantity.ValueChanged += lblNumber_ValueChanged;
        }
        public void LimitNumber()
        {
            lblQuantity.Maximum = Convert.ToDecimal(lblQuantity.Text);
        }
        private bool isFirstClick = true;
        public void DefaultNumber()
        {
            if (isFirstClick)
            {
                lblQuantity.Text = 1.ToString();
                isFirstClick = false;
            }
            else
            {
                lblQuantity.Text = GetNumber().ToString();
            }
        }
        public void SetProductImage(Image image)
        {
            pictureBox.Image = image;
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
            return (int)lblQuantity.Value;
        }
        public event EventHandler ValueChanged;
        public delegate void MiniProductsDeletedEventHandler(object sender, EventArgs e);

        // Định nghĩa sự kiện dựa trên delegate
        public event MiniProductsDeletedEventHandler MiniProductsDeleted;
        private void lblNumber_ValueChanged(object sender, EventArgs e)
        {
            ValueChanged?.Invoke(this, EventArgs.Empty);
        }

        private void lblNumber_Click(object sender, EventArgs e)
        {

        }
        private void btnX_Click(object sender, EventArgs e)
        {
            MiniProductsDeleted?.Invoke(this, EventArgs.Empty);
        }
        public event KeyEventHandler KeyDownEvent;
        private void lblNumber_KeyDown(object sender, KeyEventArgs e)
        {
            KeyDownEvent?.Invoke(this, e);
        }
        public decimal GetCurrentNumericValue()
        {
            return lblQuantity.Value;
        }
        public void ResetValues()
        {
            lblQuantity.Value = 0;
        }
        public string GetProductName()
        {
            return lblProductName.Text;
        }
        public void IncreaseQuantity(int quantity)
        {
            decimal total = lblQuantity.Value + quantity;

            // Kiểm tra nếu tổng vượt quá giới hạn Maximum
            if (total > lblQuantity.Maximum)
            {
                // Nếu tổng vượt quá giới hạn, đặt giá trị mới của NumericUpDown là giới hạn Maximum
                lblQuantity.Value = lblQuantity.Maximum;
            }
            else
            {
                // Nếu tổng không vượt quá giới hạn, thực hiện phép cộng bình thường
                lblQuantity.Value += quantity;
            }
        }
        public int GetQuantity()
        {
            return (int)lblQuantity.Value;
        }

    }
}
