﻿namespace Main
{
    partial class MovieManager
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MovieManager));
            textBox1 = new TextBox();
            guna2TextBox2 = new Guna.UI2.WinForms.Guna2TextBox();
            guna2DataGridView1 = new Guna.UI2.WinForms.Guna2DataGridView();
            panel2 = new Panel();
            addMovie = new Guna.UI2.WinForms.Guna2Button();
            guna2TextBox1 = new Guna.UI2.WinForms.Guna2TextBox();
            id = new DataGridViewTextBoxColumn();
            Movie_Name = new DataGridViewTextBoxColumn();
            Country = new DataGridViewTextBoxColumn();
            Director = new DataGridViewTextBoxColumn();
            Genre = new DataGridViewTextBoxColumn();
            Duration = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewImageColumn();
            Column2 = new DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)guna2DataGridView1).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.RoyalBlue;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Location = new Point(21, 57);
            textBox1.Margin = new Padding(0);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(420, 2);
            textBox1.TabIndex = 43;
            // 
            // guna2TextBox2
            // 
            guna2TextBox2.BackColor = Color.Transparent;
            guna2TextBox2.BorderColor = Color.Silver;
            guna2TextBox2.BorderRadius = 7;
            guna2TextBox2.CustomizableEdges = customizableEdges1;
            guna2TextBox2.DefaultText = "";
            guna2TextBox2.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            guna2TextBox2.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            guna2TextBox2.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            guna2TextBox2.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            guna2TextBox2.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            guna2TextBox2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            guna2TextBox2.ForeColor = Color.White;
            guna2TextBox2.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            guna2TextBox2.Location = new Point(21, 73);
            guna2TextBox2.Name = "guna2TextBox2";
            guna2TextBox2.PasswordChar = '\0';
            guna2TextBox2.PlaceholderText = "";
            guna2TextBox2.SelectedText = "";
            guna2TextBox2.ShadowDecoration.Color = Color.Silver;
            guna2TextBox2.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2TextBox2.ShadowDecoration.Enabled = true;
            guna2TextBox2.Size = new Size(1027, 515);
            guna2TextBox2.TabIndex = 47;
            // 
            // guna2DataGridView1
            // 
            guna2DataGridView1.AllowUserToAddRows = false;
            guna2DataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = Color.DimGray;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(71, 69, 94);
            guna2DataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.DimGray;
            dataGridViewCellStyle2.SelectionBackColor = Color.White;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            guna2DataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            guna2DataGridView1.ColumnHeadersHeight = 40;
            guna2DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            guna2DataGridView1.Columns.AddRange(new DataGridViewColumn[] { id, Movie_Name, Country, Director, Genre, Duration, Column1, Column2 });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            guna2DataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            guna2DataGridView1.GridColor = Color.FromArgb(231, 229, 255);
            guna2DataGridView1.Location = new Point(32, 84);
            guna2DataGridView1.Margin = new Padding(0);
            guna2DataGridView1.Name = "guna2DataGridView1";
            guna2DataGridView1.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = Color.DimGray;
            dataGridViewCellStyle4.SelectionBackColor = Color.White;
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            guna2DataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            guna2DataGridView1.RowHeadersVisible = false;
            guna2DataGridView1.RowHeadersWidth = 40;
            dataGridViewCellStyle5.BackColor = Color.White;
            dataGridViewCellStyle5.ForeColor = Color.DimGray;
            dataGridViewCellStyle5.SelectionBackColor = Color.White;
            dataGridViewCellStyle5.SelectionForeColor = Color.DimGray;
            guna2DataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle5;
            guna2DataGridView1.RowTemplate.Height = 25;
            guna2DataGridView1.Size = new Size(1003, 493);
            guna2DataGridView1.TabIndex = 46;
            guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.Font = null;
            guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            guna2DataGridView1.ThemeStyle.BackColor = Color.White;
            guna2DataGridView1.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            guna2DataGridView1.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            guna2DataGridView1.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            guna2DataGridView1.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            guna2DataGridView1.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            guna2DataGridView1.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            guna2DataGridView1.ThemeStyle.HeaderStyle.Height = 40;
            guna2DataGridView1.ThemeStyle.ReadOnly = false;
            guna2DataGridView1.ThemeStyle.RowsStyle.BackColor = Color.White;
            guna2DataGridView1.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            guna2DataGridView1.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            guna2DataGridView1.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            guna2DataGridView1.ThemeStyle.RowsStyle.Height = 25;
            guna2DataGridView1.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            guna2DataGridView1.ThemeStyle.RowsStyle.SelectionForeColor = Color.Silver;
            guna2DataGridView1.CellContentClick += guna2DataGridView1_CellContentClick;
            // 
            // panel2
            // 
            panel2.Controls.Add(guna2DataGridView1);
            panel2.Controls.Add(guna2TextBox2);
            panel2.Controls.Add(textBox1);
            panel2.Controls.Add(addMovie);
            panel2.Controls.Add(guna2TextBox1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1060, 600);
            panel2.TabIndex = 1;
            // 
            // addMovie
            // 
            addMovie.BackColor = Color.White;
            addMovie.BorderColor = Color.White;
            addMovie.BorderRadius = 15;
            addMovie.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            addMovie.CustomizableEdges = customizableEdges3;
            addMovie.DisabledState.BorderColor = Color.DarkGray;
            addMovie.DisabledState.CustomBorderColor = Color.DarkGray;
            addMovie.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            addMovie.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            addMovie.FillColor = Color.RoyalBlue;
            addMovie.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            addMovie.ForeColor = Color.White;
            addMovie.Location = new Point(447, 19);
            addMovie.Name = "addMovie";
            addMovie.ShadowDecoration.CustomizableEdges = customizableEdges4;
            addMovie.Size = new Size(82, 35);
            addMovie.TabIndex = 42;
            addMovie.Text = "Thêm";
            addMovie.Click += addMovie_Click;
            // 
            // guna2TextBox1
            // 
            guna2TextBox1.CustomizableEdges = customizableEdges5;
            guna2TextBox1.DefaultText = "Tìm kiếm";
            guna2TextBox1.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            guna2TextBox1.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            guna2TextBox1.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            guna2TextBox1.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            guna2TextBox1.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            guna2TextBox1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            guna2TextBox1.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            guna2TextBox1.Location = new Point(21, 12);
            guna2TextBox1.Name = "guna2TextBox1";
            guna2TextBox1.PasswordChar = '\0';
            guna2TextBox1.PlaceholderText = "";
            guna2TextBox1.SelectedText = "";
            guna2TextBox1.ShadowDecoration.CustomizableEdges = customizableEdges6;
            guna2TextBox1.Size = new Size(420, 42);
            guna2TextBox1.TabIndex = 0;
            guna2TextBox1.TextChanged += guna2TextBox1_TextChanged;
            guna2TextBox1.Click += guna2TextBox1_Click;
            guna2TextBox1.Enter += guna2TextBox1_Enter;
            guna2TextBox1.Leave += guna2TextBox1_Leave;
            // 
            // id
            // 
            id.HeaderText = "ID";
            id.Name = "id";
            // 
            // Movie_Name
            // 
            Movie_Name.FillWeight = 150F;
            Movie_Name.HeaderText = "Tên phim";
            Movie_Name.Name = "Movie_Name";
            // 
            // Country
            // 
            Country.FillWeight = 80F;
            Country.HeaderText = "Quốc gia";
            Country.Name = "Country";
            // 
            // Director
            // 
            Director.FillWeight = 80F;
            Director.HeaderText = "Đạo diễn";
            Director.Name = "Director";
            // 
            // Genre
            // 
            Genre.HeaderText = "Thể loại";
            Genre.Name = "Genre";
            // 
            // Duration
            // 
            Duration.FillWeight = 125F;
            Duration.HeaderText = "Thời lượng";
            Duration.MinimumWidth = 7;
            Duration.Name = "Duration";
            // 
            // Column1
            // 
            Column1.FillWeight = 37.4378853F;
            Column1.HeaderText = "";
            Column1.Image = (Image)resources.GetObject("Column1.Image");
            Column1.Name = "Column1";
            // 
            // Column2
            // 
            Column2.FillWeight = 35.5329933F;
            Column2.HeaderText = "";
            Column2.Image = (Image)resources.GetObject("Column2.Image");
            Column2.Name = "Column2";
            // 
            // MovieManager
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1060, 600);
            Controls.Add(panel2);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MovieManager";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MovieManager";
            Load += MovieManager_Load;
            ((System.ComponentModel.ISupportInitialize)guna2DataGridView1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox textBox1;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox2;
        private Guna.UI2.WinForms.Guna2DataGridView guna2DataGridView1;
        private Panel panel2;
        private Guna.UI2.WinForms.Guna2Button addMovie;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox1;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn Movie_Name;
        private DataGridViewTextBoxColumn Country;
        private DataGridViewTextBoxColumn Director;
        private DataGridViewTextBoxColumn Genre;
        private DataGridViewTextBoxColumn Duration;
        private DataGridViewImageColumn Column1;
        private DataGridViewImageColumn Column2;
    }
}