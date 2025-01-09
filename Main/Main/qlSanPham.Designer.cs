namespace Main
{
    partial class qlSanPham
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelSanPham = new Panel();
            panelEdit = new Panel();
            btnSave = new Button();
            btnCancelEdit = new Button();
            label13 = new Label();
            iconButton4 = new FontAwesome.Sharp.IconButton();
            pictureBox3 = new PictureBox();
            txtEditPrice = new TextBox();
            txtEditName = new TextBox();
            label12 = new Label();
            label10 = new Label();
            label7 = new Label();
            panelNhapHang = new Panel();
            txtNameN = new ComboBox();
            txtnhapQuantity = new TextBox();
            btnNhap = new Button();
            button5 = new Button();
            txtnhapPrice = new TextBox();
            label8 = new Label();
            label9 = new Label();
            pictureBox2 = new PictureBox();
            label11 = new Label();
            panelThem = new Panel();
            iconButton3 = new FontAwesome.Sharp.IconButton();
            btnThem = new Button();
            btnHuySP = new Button();
            label6 = new Label();
            txtPrice = new TextBox();
            label5 = new Label();
            label3 = new Label();
            pictureBox1 = new PictureBox();
            txtLoai = new ComboBox();
            txtNameT = new TextBox();
            label2 = new Label();
            iconButton1 = new FontAwesome.Sharp.IconButton();
            iconButton2 = new FontAwesome.Sharp.IconButton();
            textBox1 = new TextBox();
            label1 = new Label();
            comboBox1 = new ComboBox();
            panelSanPham.SuspendLayout();
            panelEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            panelNhapHang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panelThem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panelSanPham
            // 
            panelSanPham.AutoScroll = true;
            panelSanPham.BorderStyle = BorderStyle.FixedSingle;
            panelSanPham.Controls.Add(panelEdit);
            panelSanPham.Location = new Point(12, 85);
            panelSanPham.Name = "panelSanPham";
            panelSanPham.Size = new Size(1020, 545);
            panelSanPham.TabIndex = 0;
            // 
            // panelEdit
            // 
            panelEdit.BackColor = Color.Silver;
            panelEdit.BorderStyle = BorderStyle.FixedSingle;
            panelEdit.Controls.Add(btnSave);
            panelEdit.Controls.Add(btnCancelEdit);
            panelEdit.Controls.Add(label13);
            panelEdit.Controls.Add(iconButton4);
            panelEdit.Controls.Add(pictureBox3);
            panelEdit.Controls.Add(txtEditPrice);
            panelEdit.Controls.Add(txtEditName);
            panelEdit.Controls.Add(label12);
            panelEdit.Controls.Add(label10);
            panelEdit.Controls.Add(label7);
            panelEdit.Location = new Point(474, 205);
            panelEdit.Name = "panelEdit";
            panelEdit.Size = new Size(249, 303);
            panelEdit.TabIndex = 0;
            panelEdit.Visible = false;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.PeachPuff;
            btnSave.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnSave.Location = new Point(179, 254);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(57, 34);
            btnSave.TabIndex = 18;
            btnSave.Text = "Lưu";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancelEdit
            // 
            btnCancelEdit.BackColor = Color.DarkTurquoise;
            btnCancelEdit.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnCancelEdit.Location = new Point(116, 254);
            btnCancelEdit.Name = "btnCancelEdit";
            btnCancelEdit.Size = new Size(57, 34);
            btnCancelEdit.TabIndex = 17;
            btnCancelEdit.Text = "Hủy";
            btnCancelEdit.UseVisualStyleBackColor = false;
            btnCancelEdit.Click += btnCancelEdit_Click;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(45, 254);
            label13.Name = "label13";
            label13.Size = new Size(62, 15);
            label13.TabIndex = 14;
            label13.Text = "Thêm Ảnh";
            // 
            // iconButton4
            // 
            iconButton4.IconChar = FontAwesome.Sharp.IconChar.Image;
            iconButton4.IconColor = Color.Black;
            iconButton4.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton4.IconSize = 45;
            iconButton4.ImageAlign = ContentAlignment.TopCenter;
            iconButton4.Location = new Point(164, 165);
            iconButton4.Name = "iconButton4";
            iconButton4.Size = new Size(52, 47);
            iconButton4.TabIndex = 14;
            iconButton4.UseVisualStyleBackColor = true;
            iconButton4.Click += iconButton4_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.White;
            pictureBox3.Location = new Point(15, 126);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(129, 115);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 16;
            pictureBox3.TabStop = false;
            // 
            // txtEditPrice
            // 
            txtEditPrice.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtEditPrice.Location = new Point(58, 95);
            txtEditPrice.Name = "txtEditPrice";
            txtEditPrice.Size = new Size(178, 25);
            txtEditPrice.TabIndex = 15;
            // 
            // txtEditName
            // 
            txtEditName.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtEditName.Location = new Point(58, 55);
            txtEditName.Name = "txtEditName";
            txtEditName.Size = new Size(178, 25);
            txtEditName.TabIndex = 15;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label12.Location = new Point(15, 96);
            label12.Name = "label12";
            label12.Size = new Size(35, 20);
            label12.TabIndex = 14;
            label12.Text = "Giá:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label10.Location = new Point(15, 56);
            label10.Name = "label10";
            label10.Size = new Size(37, 20);
            label10.TabIndex = 14;
            label10.Text = "Tên:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(13, 12);
            label7.Name = "label7";
            label7.Size = new Size(154, 30);
            label7.TabIndex = 0;
            label7.Text = "Sửa Sản Phẩm";
            // 
            // panelNhapHang
            // 
            panelNhapHang.BackColor = Color.Silver;
            panelNhapHang.BorderStyle = BorderStyle.FixedSingle;
            panelNhapHang.Controls.Add(txtNameN);
            panelNhapHang.Controls.Add(txtnhapQuantity);
            panelNhapHang.Controls.Add(btnNhap);
            panelNhapHang.Controls.Add(button5);
            panelNhapHang.Controls.Add(txtnhapPrice);
            panelNhapHang.Controls.Add(label8);
            panelNhapHang.Controls.Add(label9);
            panelNhapHang.Controls.Add(pictureBox2);
            panelNhapHang.Controls.Add(label11);
            panelNhapHang.Location = new Point(487, 78);
            panelNhapHang.Name = "panelNhapHang";
            panelNhapHang.Size = new Size(453, 207);
            panelNhapHang.TabIndex = 13;
            panelNhapHang.Visible = false;
            // 
            // txtNameN
            // 
            txtNameN.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtNameN.FormattingEnabled = true;
            txtNameN.Items.AddRange(new object[] { "Đồ Ăn", "Đồ Uống" });
            txtNameN.Location = new Point(103, 19);
            txtNameN.Name = "txtNameN";
            txtNameN.Size = new Size(165, 25);
            txtNameN.TabIndex = 15;
            txtNameN.SelectedIndexChanged += txtNameN_SelectedIndexChanged;
            // 
            // txtnhapQuantity
            // 
            txtnhapQuantity.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtnhapQuantity.Location = new Point(103, 73);
            txtnhapQuantity.Name = "txtnhapQuantity";
            txtnhapQuantity.Size = new Size(165, 25);
            txtnhapQuantity.TabIndex = 13;
            // 
            // btnNhap
            // 
            btnNhap.BackColor = Color.PeachPuff;
            btnNhap.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnNhap.Location = new Point(377, 162);
            btnNhap.Name = "btnNhap";
            btnNhap.Size = new Size(57, 34);
            btnNhap.TabIndex = 12;
            btnNhap.Text = "Thêm";
            btnNhap.UseVisualStyleBackColor = false;
            btnNhap.Click += btnNhap_Click;
            // 
            // button5
            // 
            button5.BackColor = Color.DarkTurquoise;
            button5.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button5.Location = new Point(307, 162);
            button5.Name = "button5";
            button5.Size = new Size(57, 34);
            button5.TabIndex = 11;
            button5.Text = "Hủy";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // txtnhapPrice
            // 
            txtnhapPrice.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtnhapPrice.Location = new Point(103, 131);
            txtnhapPrice.Name = "txtnhapPrice";
            txtnhapPrice.Size = new Size(165, 25);
            txtnhapPrice.TabIndex = 9;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label8.Location = new Point(13, 132);
            label8.Name = "label8";
            label8.Size = new Size(81, 20);
            label8.TabIndex = 7;
            label8.Text = "Giá Nhập :";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label9.Location = new Point(13, 78);
            label9.Name = "label9";
            label9.Size = new Size(77, 20);
            label9.TabIndex = 6;
            label9.Text = "Số Lượng:";
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.White;
            pictureBox2.Location = new Point(274, 9);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(172, 147);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 3;
            pictureBox2.TabStop = false;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label11.Location = new Point(13, 19);
            label11.Name = "label11";
            label11.Size = new Size(37, 20);
            label11.TabIndex = 0;
            label11.Text = "Tên:";
            // 
            // panelThem
            // 
            panelThem.BackColor = Color.Silver;
            panelThem.BorderStyle = BorderStyle.FixedSingle;
            panelThem.Controls.Add(iconButton3);
            panelThem.Controls.Add(btnThem);
            panelThem.Controls.Add(btnHuySP);
            panelThem.Controls.Add(label6);
            panelThem.Controls.Add(txtPrice);
            panelThem.Controls.Add(label5);
            panelThem.Controls.Add(label3);
            panelThem.Controls.Add(pictureBox1);
            panelThem.Controls.Add(txtLoai);
            panelThem.Controls.Add(txtNameT);
            panelThem.Controls.Add(label2);
            panelThem.Location = new Point(197, 78);
            panelThem.Name = "panelThem";
            panelThem.Size = new Size(284, 279);
            panelThem.TabIndex = 0;
            panelThem.Visible = false;
            // 
            // iconButton3
            // 
            iconButton3.IconChar = FontAwesome.Sharp.IconChar.Image;
            iconButton3.IconColor = Color.Black;
            iconButton3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton3.IconSize = 45;
            iconButton3.ImageAlign = ContentAlignment.TopCenter;
            iconButton3.Location = new Point(156, 158);
            iconButton3.Name = "iconButton3";
            iconButton3.Size = new Size(52, 47);
            iconButton3.TabIndex = 13;
            iconButton3.UseVisualStyleBackColor = true;
            iconButton3.Click += iconButton3_Click;
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.PeachPuff;
            btnThem.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnThem.Location = new Point(221, 234);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(57, 34);
            btnThem.TabIndex = 12;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // btnHuySP
            // 
            btnHuySP.BackColor = Color.DarkTurquoise;
            btnHuySP.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnHuySP.Location = new Point(151, 234);
            btnHuySP.Name = "btnHuySP";
            btnHuySP.Size = new Size(57, 34);
            btnHuySP.TabIndex = 11;
            btnHuySP.Text = "Hủy";
            btnHuySP.UseVisualStyleBackColor = false;
            btnHuySP.Click += btnHuySP_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(40, 234);
            label6.Name = "label6";
            label6.Size = new Size(62, 15);
            label6.TabIndex = 10;
            label6.Text = "Thêm Ảnh";
            // 
            // txtPrice
            // 
            txtPrice.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtPrice.Location = new Point(90, 92);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(178, 25);
            txtPrice.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(13, 93);
            label5.Name = "label5";
            label5.Size = new Size(35, 20);
            label5.TabIndex = 7;
            label5.Text = "Giá:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(13, 53);
            label3.Name = "label3";
            label3.Size = new Size(41, 20);
            label3.TabIndex = 5;
            label3.Text = "Loại:";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.White;
            pictureBox1.Location = new Point(13, 123);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(119, 102);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // txtLoai
            // 
            txtLoai.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtLoai.FormattingEnabled = true;
            txtLoai.Items.AddRange(new object[] { "Đồ Ăn", "Đồ Uống" });
            txtLoai.Location = new Point(90, 52);
            txtLoai.Name = "txtLoai";
            txtLoai.Size = new Size(178, 25);
            txtLoai.TabIndex = 2;
            // 
            // txtNameT
            // 
            txtNameT.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtNameT.Location = new Point(90, 18);
            txtNameT.Name = "txtNameT";
            txtNameT.Size = new Size(178, 25);
            txtNameT.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(13, 19);
            label2.Name = "label2";
            label2.Size = new Size(37, 20);
            label2.TabIndex = 0;
            label2.Text = "Tên:";
            // 
            // iconButton1
            // 
            iconButton1.Font = new Font("Segoe UI Semibold", 10.25F, FontStyle.Bold, GraphicsUnit.Point);
            iconButton1.IconChar = FontAwesome.Sharp.IconChar.PlusSquare;
            iconButton1.IconColor = Color.Black;
            iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton1.IconSize = 40;
            iconButton1.Location = new Point(375, 12);
            iconButton1.Name = "iconButton1";
            iconButton1.Size = new Size(127, 62);
            iconButton1.TabIndex = 1;
            iconButton1.Text = "Thêm Sản Phẩm";
            iconButton1.TextAlign = ContentAlignment.BottomCenter;
            iconButton1.UseVisualStyleBackColor = true;
            iconButton1.Click += iconButton1_Click;
            // 
            // iconButton2
            // 
            iconButton2.Font = new Font("Segoe UI Semibold", 10.25F, FontStyle.Bold, GraphicsUnit.Point);
            iconButton2.IconChar = FontAwesome.Sharp.IconChar.ShoppingCart;
            iconButton2.IconColor = Color.Black;
            iconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton2.IconSize = 40;
            iconButton2.Location = new Point(523, 12);
            iconButton2.Name = "iconButton2";
            iconButton2.Size = new Size(127, 62);
            iconButton2.TabIndex = 2;
            iconButton2.Text = "Nhập Hàng";
            iconButton2.TextAlign = ContentAlignment.BottomCenter;
            iconButton2.UseVisualStyleBackColor = true;
            iconButton2.Click += iconButton2_Click;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.Location = new Point(12, 41);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(330, 31);
            textBox1.TabIndex = 3;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(85, 23);
            label1.TabIndex = 4;
            label1.Text = "Tìm Kiếm:";
            // 
            // comboBox1
            // 
            comboBox1.Font = new Font("Segoe UI Semibold", 12.75F, FontStyle.Bold, GraphicsUnit.Point);
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Tất Cả", "Đồ Ăn", "Đồ Uống" });
            comboBox1.Location = new Point(911, 43);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 31);
            comboBox1.TabIndex = 5;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // qlSanPham
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1060, 640);
            Controls.Add(panelThem);
            Controls.Add(panelNhapHang);
            Controls.Add(comboBox1);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(iconButton2);
            Controls.Add(iconButton1);
            Controls.Add(panelSanPham);
            FormBorderStyle = FormBorderStyle.None;
            Name = "qlSanPham";
            Text = "qlSanPham";
            MouseMove += qlSanPham_MouseMove;
            panelSanPham.ResumeLayout(false);
            panelEdit.ResumeLayout(false);
            panelEdit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            panelNhapHang.ResumeLayout(false);
            panelNhapHang.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panelThem.ResumeLayout(false);
            panelThem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelSanPham;
        private FontAwesome.Sharp.IconButton iconButton1;
        private FontAwesome.Sharp.IconButton iconButton2;
        private TextBox textBox1;
        private Label label1;
        private ComboBox comboBox1;
        private Panel panelThem;
        private PictureBox pictureBox1;
        private ComboBox txtLoai;
        private TextBox txtNameT;
        private Label label2;
        private Label label5;
        private Label label3;
        private Button btnThem;
        private Button btnHuySP;
        private Label label6;
        private TextBox txtPrice;
        private Panel panelNhapHang;
        private TextBox txtnhapQuantity;
        private Button btnNhap;
        private Button button5;
        private TextBox txtnhapPrice;
        private Label label8;
        private Label label9;
        private PictureBox pictureBox2;
        private Label label11;
        private FontAwesome.Sharp.IconButton iconButton3;
        private Panel panelEdit;
        private TextBox txtEditName;
        private Label label10;
        private Label label7;
        private PictureBox pictureBox3;
        private TextBox txtEditPrice;
        private Label label12;
        private FontAwesome.Sharp.IconButton iconButton4;
        private Label label13;
        private Button btnCancelEdit;
        private Button btnSave;
        private ComboBox txtNameN;
    }
}