namespace Main
{
    partial class ParentForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelMovies = new Panel();
            comboBoxMovieStyle = new ComboBox();
            textBoxMovieName = new TextBox();
            btnNext = new Button();
            btnPrevious = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            iconButton1 = new FontAwesome.Sharp.IconButton();
            SuspendLayout();
            // 
            // panelMovies
            // 
            panelMovies.AutoScroll = true;
            panelMovies.BackColor = Color.Transparent;
            panelMovies.Location = new Point(57, 147);
            panelMovies.Margin = new Padding(3, 2, 3, 2);
            panelMovies.Name = "panelMovies";
            panelMovies.Size = new Size(943, 442);
            panelMovies.TabIndex = 1;
            // 
            // comboBoxMovieStyle
            // 
            comboBoxMovieStyle.FormattingEnabled = true;
            comboBoxMovieStyle.Items.AddRange(new object[] { "Hoạt Hình", "Hài", "Kinh Dị", "Lãng Mạn", "Bí Ẩn" });
            comboBoxMovieStyle.Location = new Point(425, 91);
            comboBoxMovieStyle.Margin = new Padding(3, 2, 3, 2);
            comboBoxMovieStyle.Name = "comboBoxMovieStyle";
            comboBoxMovieStyle.Size = new Size(133, 23);
            comboBoxMovieStyle.TabIndex = 3;
            comboBoxMovieStyle.SelectedIndexChanged += comboBoxMovieStyle_SelectedIndexChanged;
            // 
            // textBoxMovieName
            // 
            textBoxMovieName.Location = new Point(164, 91);
            textBoxMovieName.Margin = new Padding(3, 2, 3, 2);
            textBoxMovieName.Name = "textBoxMovieName";
            textBoxMovieName.Size = new Size(110, 23);
            textBoxMovieName.TabIndex = 4;
            textBoxMovieName.TextChanged += textBoxMovieName_TextChanged;
            // 
            // btnNext
            // 
            btnNext.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnNext.Location = new Point(1006, 337);
            btnNext.Margin = new Padding(3, 2, 3, 2);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(45, 45);
            btnNext.TabIndex = 5;
            btnNext.Text = ">";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // btnPrevious
            // 
            btnPrevious.BackColor = Color.Transparent;
            btnPrevious.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnPrevious.Location = new Point(6, 337);
            btnPrevious.Margin = new Padding(3, 2, 3, 2);
            btnPrevious.Name = "btnPrevious";
            btnPrevious.Size = new Size(45, 45);
            btnPrevious.TabIndex = 6;
            btnPrevious.Text = "<";
            btnPrevious.UseVisualStyleBackColor = false;
            btnPrevious.Click += btnPrevious_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(57, 33);
            label1.Name = "label1";
            label1.Size = new Size(208, 28);
            label1.TabIndex = 7;
            label1.Text = "Tìm kiếm phim theo:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(57, 91);
            label2.Name = "label2";
            label2.Size = new Size(85, 21);
            label2.TabIndex = 8;
            label2.Text = "Tên phim:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.White;
            label3.Location = new Point(314, 91);
            label3.Name = "label3";
            label3.Size = new Size(75, 21);
            label3.TabIndex = 9;
            label3.Text = "Thể loại:";
            // 
            // iconButton1
            // 
            iconButton1.IconChar = FontAwesome.Sharp.IconChar.Rotate;
            iconButton1.IconColor = Color.Black;
            iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton1.IconSize = 30;
            iconButton1.Location = new Point(597, 85);
            iconButton1.Name = "iconButton1";
            iconButton1.Size = new Size(45, 37);
            iconButton1.TabIndex = 10;
            iconButton1.UseVisualStyleBackColor = true;
            iconButton1.Click += iconButton1_Click;
            // 
            // ParentForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1060, 600);
            Controls.Add(iconButton1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnPrevious);
            Controls.Add(btnNext);
            Controls.Add(textBoxMovieName);
            Controls.Add(comboBoxMovieStyle);
            Controls.Add(panelMovies);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "ParentForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "<";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel panelMovies;
        private ComboBox comboBoxMovieStyle;
        private TextBox textBoxMovieName;
        private Button btnNext;
        private Button btnPrevious;
        private Label label1;
        private Label label2;
        private Label label3;
        private FontAwesome.Sharp.IconButton iconButton1;
    }
}