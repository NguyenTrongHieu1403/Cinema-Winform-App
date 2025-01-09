namespace Main
{
    partial class SeatBookingForm
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
            components = new System.ComponentModel.Container();
            lblMovieName = new Label();
            lblMovieStyle = new Label();
            lblMovieRating = new Label();
            pictureBox1 = new PictureBox();
            panelSeats = new Panel();
            lblRoomNumber = new Label();
            btnBook = new Button();
            lblGiaVe = new Label();
            label1 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            label2 = new Label();
            lblgia1Ve = new Label();
            textBox1 = new TextBox();
            label3 = new Label();
            textBox2 = new TextBox();
            label4 = new Label();
            textBox3 = new TextBox();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            lblTotalSeats = new Label();
            lblBookedSeats = new Label();
            lblEmptySeats = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblMovieName
            // 
            lblMovieName.AutoSize = true;
            lblMovieName.BackColor = Color.Transparent;
            lblMovieName.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point);
            lblMovieName.ForeColor = Color.White;
            lblMovieName.Location = new Point(994, 388);
            lblMovieName.Name = "lblMovieName";
            lblMovieName.Size = new Size(61, 25);
            lblMovieName.TabIndex = 0;
            lblMovieName.Text = "label1";
            lblMovieName.Click += lblMovieName_Click;
            // 
            // lblMovieStyle
            // 
            lblMovieStyle.AutoSize = true;
            lblMovieStyle.BackColor = Color.Transparent;
            lblMovieStyle.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblMovieStyle.ForeColor = Color.White;
            lblMovieStyle.Location = new Point(994, 413);
            lblMovieStyle.Name = "lblMovieStyle";
            lblMovieStyle.Size = new Size(54, 21);
            lblMovieStyle.TabIndex = 1;
            lblMovieStyle.Text = "label2";
            // 
            // lblMovieRating
            // 
            lblMovieRating.AutoSize = true;
            lblMovieRating.BackColor = Color.Transparent;
            lblMovieRating.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblMovieRating.ForeColor = Color.White;
            lblMovieRating.Location = new Point(996, 442);
            lblMovieRating.Name = "lblMovieRating";
            lblMovieRating.Size = new Size(54, 21);
            lblMovieRating.TabIndex = 2;
            lblMovieRating.Text = "label3";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(994, 23);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(245, 348);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // panelSeats
            // 
            panelSeats.AutoScroll = true;
            panelSeats.BackColor = Color.Transparent;
            panelSeats.Location = new Point(120, 23);
            panelSeats.Margin = new Padding(3, 2, 3, 2);
            panelSeats.Name = "panelSeats";
            panelSeats.Size = new Size(786, 532);
            panelSeats.TabIndex = 4;
            // 
            // lblRoomNumber
            // 
            lblRoomNumber.AutoSize = true;
            lblRoomNumber.BackColor = Color.Transparent;
            lblRoomNumber.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold, GraphicsUnit.Point);
            lblRoomNumber.ForeColor = Color.White;
            lblRoomNumber.Location = new Point(994, 463);
            lblRoomNumber.Name = "lblRoomNumber";
            lblRoomNumber.Size = new Size(63, 28);
            lblRoomNumber.TabIndex = 5;
            lblRoomNumber.Text = "label1";
            // 
            // btnBook
            // 
            btnBook.Location = new Point(1072, 585);
            btnBook.Margin = new Padding(3, 2, 3, 2);
            btnBook.Name = "btnBook";
            btnBook.Size = new Size(97, 38);
            btnBook.TabIndex = 6;
            btnBook.Text = "Đặt Ghế";
            btnBook.UseVisualStyleBackColor = true;
            btnBook.Click += btnBook_Click;
            // 
            // lblGiaVe
            // 
            lblGiaVe.AutoSize = true;
            lblGiaVe.BackColor = Color.Transparent;
            lblGiaVe.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold, GraphicsUnit.Point);
            lblGiaVe.ForeColor = Color.White;
            lblGiaVe.Location = new Point(1098, 549);
            lblGiaVe.Name = "lblGiaVe";
            lblGiaVe.Size = new Size(22, 25);
            lblGiaVe.TabIndex = 7;
            lblGiaVe.Text = "0";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(994, 549);
            label1.Name = "label1";
            label1.Size = new Size(108, 25);
            label1.TabIndex = 8;
            label1.Text = "Tổng Cộng:";
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(996, 504);
            label2.Name = "label2";
            label2.Size = new Size(59, 21);
            label2.TabIndex = 9;
            label2.Text = "Giá Vé:";
            // 
            // lblgia1Ve
            // 
            lblgia1Ve.AutoSize = true;
            lblgia1Ve.BackColor = Color.Transparent;
            lblgia1Ve.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblgia1Ve.ForeColor = Color.White;
            lblgia1Ve.Location = new Point(1052, 504);
            lblgia1Ve.Name = "lblgia1Ve";
            lblgia1Ve.Size = new Size(19, 21);
            lblgia1Ve.TabIndex = 10;
            lblgia1Ve.Text = "0";
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.Control;
            textBox1.Location = new Point(222, 568);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(28, 23);
            textBox1.TabIndex = 11;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.White;
            label3.Location = new Point(256, 571);
            label3.Name = "label3";
            label3.Size = new Size(80, 20);
            label3.TabIndex = 12;
            label3.Text = "Ghế Trống";
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.Red;
            textBox2.Location = new Point(414, 568);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(28, 23);
            textBox2.TabIndex = 11;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = Color.White;
            label4.Location = new Point(448, 571);
            label4.Name = "label4";
            label4.Size = new Size(117, 20);
            label4.TabIndex = 12;
            label4.Text = "Ghế Đang Chọn";
            // 
            // textBox3
            // 
            textBox3.BackColor = Color.Gray;
            textBox3.Location = new Point(636, 568);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(28, 23);
            textBox3.TabIndex = 11;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = Color.White;
            label5.Location = new Point(670, 571);
            label5.Name = "label5";
            label5.Size = new Size(127, 20);
            label5.TabIndex = 12;
            label5.Text = "Ghế Đã Được Đặt";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = Color.White;
            label6.Location = new Point(222, 603);
            label6.Name = "label6";
            label6.Size = new Size(100, 20);
            label6.TabIndex = 13;
            label6.Text = "Tổng Số Ghế:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label7.ForeColor = Color.White;
            label7.Location = new Point(413, 603);
            label7.Name = "label7";
            label7.Size = new Size(152, 20);
            label7.TabIndex = 14;
            label7.Text = "Số Ghế Đã Được Đặt:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label8.ForeColor = Color.White;
            label8.Location = new Point(636, 603);
            label8.Name = "label8";
            label8.Size = new Size(105, 20);
            label8.TabIndex = 15;
            label8.Text = "Số Ghế Trống:";
            // 
            // lblTotalSeats
            // 
            lblTotalSeats.AutoSize = true;
            lblTotalSeats.BackColor = Color.Transparent;
            lblTotalSeats.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblTotalSeats.ForeColor = Color.White;
            lblTotalSeats.Location = new Point(317, 603);
            lblTotalSeats.Name = "lblTotalSeats";
            lblTotalSeats.Size = new Size(19, 21);
            lblTotalSeats.TabIndex = 17;
            lblTotalSeats.Text = "0";
            // 
            // lblBookedSeats
            // 
            lblBookedSeats.AutoSize = true;
            lblBookedSeats.BackColor = Color.Transparent;
            lblBookedSeats.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblBookedSeats.ForeColor = Color.White;
            lblBookedSeats.Location = new Point(560, 603);
            lblBookedSeats.Name = "lblBookedSeats";
            lblBookedSeats.Size = new Size(19, 21);
            lblBookedSeats.TabIndex = 18;
            lblBookedSeats.Text = "0";
            // 
            // lblEmptySeats
            // 
            lblEmptySeats.AutoSize = true;
            lblEmptySeats.BackColor = Color.Transparent;
            lblEmptySeats.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblEmptySeats.ForeColor = Color.White;
            lblEmptySeats.Location = new Point(738, 603);
            lblEmptySeats.Name = "lblEmptySeats";
            lblEmptySeats.Size = new Size(19, 21);
            lblEmptySeats.TabIndex = 17;
            lblEmptySeats.Text = "0";
            // 
            // SeatBookingForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightGray;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1264, 681);
            Controls.Add(lblBookedSeats);
            Controls.Add(lblEmptySeats);
            Controls.Add(lblTotalSeats);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(lblgia1Ve);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblGiaVe);
            Controls.Add(btnBook);
            Controls.Add(lblRoomNumber);
            Controls.Add(panelSeats);
            Controls.Add(pictureBox1);
            Controls.Add(lblMovieRating);
            Controls.Add(lblMovieStyle);
            Controls.Add(lblMovieName);
            Margin = new Padding(3, 2, 3, 2);
            Name = "SeatBookingForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SeatBookingForm";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblMovieName;
        private Label lblMovieStyle;
        private Label lblMovieRating;
        private PictureBox pictureBox1;
        private Panel panelSeats;
        private Label lblRoomNumber;
        private Button btnBook;
        private Label lblGiaVe;
        private Label label1;
        private System.Windows.Forms.Timer timer1;
        private Label label2;
        private Label lblgia1Ve;
        private TextBox textBox1;
        private Label label3;
        private TextBox textBox2;
        private Label label4;
        private TextBox textBox3;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label lblTotalSeats;
        private Label lblBookedSeats;
        private Label lblEmptySeats;
    }
}