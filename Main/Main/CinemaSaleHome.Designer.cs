namespace Main
{
    partial class CinemaSaleHome
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CinemaSaleHome));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            panel4 = new Panel();
            label1 = new Label();
            panel3 = new Panel();
            iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            pictureBox1 = new PictureBox();
            iconButton13 = new FontAwesome.Sharp.IconButton();
            iconButton3 = new FontAwesome.Sharp.IconButton();
            iconButton2 = new FontAwesome.Sharp.IconButton();
            panel2 = new Panel();
            panel5 = new Panel();
            panel1 = new Panel();
            guna2TextBox1 = new Guna.UI2.WinForms.Guna2TextBox();
            picPhoto = new Guna.UI2.WinForms.Guna2PictureBox();
            guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picPhoto).BeginInit();
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(24, 23, 37);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(220, 74);
            panel4.Name = "panel4";
            panel4.Size = new Size(1060, 7);
            panel4.TabIndex = 38;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.Gainsboro;
            label1.Location = new Point(59, 35);
            label1.Margin = new Padding(0);
            label1.Name = "label1";
            label1.Size = new Size(52, 21);
            label1.TabIndex = 33;
            label1.Text = "Home";
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(24, 23, 37);
            panel3.Controls.Add(guna2TextBox1);
            panel3.Controls.Add(picPhoto);
            panel3.Controls.Add(label1);
            panel3.Controls.Add(guna2PictureBox1);
            panel3.Controls.Add(iconPictureBox1);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(220, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(1060, 74);
            panel3.TabIndex = 37;
            // 
            // iconPictureBox1
            // 
            iconPictureBox1.BackColor = Color.FromArgb(24, 23, 37);
            iconPictureBox1.ForeColor = Color.MediumSlateBlue;
            iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.House;
            iconPictureBox1.IconColor = Color.MediumSlateBlue;
            iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconPictureBox1.IconSize = 40;
            iconPictureBox1.Location = new Point(16, 24);
            iconPictureBox1.Name = "iconPictureBox1";
            iconPictureBox1.Size = new Size(40, 40);
            iconPictureBox1.TabIndex = 32;
            iconPictureBox1.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(12, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(191, 99);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // iconButton13
            // 
            iconButton13.Dock = DockStyle.Bottom;
            iconButton13.FlatAppearance.BorderSize = 0;
            iconButton13.FlatStyle = FlatStyle.Flat;
            iconButton13.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            iconButton13.ForeColor = Color.Gainsboro;
            iconButton13.IconChar = FontAwesome.Sharp.IconChar.SignOutAlt;
            iconButton13.IconColor = Color.Gainsboro;
            iconButton13.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton13.IconSize = 35;
            iconButton13.ImageAlign = ContentAlignment.MiddleLeft;
            iconButton13.Location = new Point(0, 680);
            iconButton13.Name = "iconButton13";
            iconButton13.Padding = new Padding(10, 0, 20, 0);
            iconButton13.Size = new Size(220, 40);
            iconButton13.TabIndex = 43;
            iconButton13.Text = "Log Out";
            iconButton13.TextAlign = ContentAlignment.MiddleLeft;
            iconButton13.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButton13.UseVisualStyleBackColor = true;
            iconButton13.Click += iconButton13_Click;
            // 
            // iconButton3
            // 
            iconButton3.Dock = DockStyle.Top;
            iconButton3.FlatAppearance.BorderSize = 0;
            iconButton3.FlatStyle = FlatStyle.Flat;
            iconButton3.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            iconButton3.ForeColor = Color.Gainsboro;
            iconButton3.IconChar = FontAwesome.Sharp.IconChar.Utensils;
            iconButton3.IconColor = Color.Gainsboro;
            iconButton3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton3.IconSize = 35;
            iconButton3.ImageAlign = ContentAlignment.MiddleLeft;
            iconButton3.Location = new Point(0, 160);
            iconButton3.Name = "iconButton3";
            iconButton3.Padding = new Padding(10, 0, 20, 0);
            iconButton3.Size = new Size(220, 40);
            iconButton3.TabIndex = 33;
            iconButton3.Text = "Bán sản phẩm";
            iconButton3.TextAlign = ContentAlignment.MiddleLeft;
            iconButton3.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButton3.UseVisualStyleBackColor = true;
            iconButton3.Click += iconButton3_Click;
            // 
            // iconButton2
            // 
            iconButton2.Dock = DockStyle.Top;
            iconButton2.FlatAppearance.BorderSize = 0;
            iconButton2.FlatStyle = FlatStyle.Flat;
            iconButton2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            iconButton2.ForeColor = Color.Gainsboro;
            iconButton2.IconChar = FontAwesome.Sharp.IconChar.VideoCamera;
            iconButton2.IconColor = Color.Gainsboro;
            iconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton2.IconSize = 35;
            iconButton2.ImageAlign = ContentAlignment.MiddleLeft;
            iconButton2.Location = new Point(0, 120);
            iconButton2.Name = "iconButton2";
            iconButton2.Padding = new Padding(10, 0, 20, 0);
            iconButton2.Size = new Size(220, 40);
            iconButton2.TabIndex = 32;
            iconButton2.Text = "Bán vé";
            iconButton2.TextAlign = ContentAlignment.MiddleLeft;
            iconButton2.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButton2.UseVisualStyleBackColor = true;
            iconButton2.Click += iconButton2_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(pictureBox1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(220, 120);
            panel2.TabIndex = 31;
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(24, 23, 37);
            panel5.Location = new Point(220, 77);
            panel5.Name = "panel5";
            panel5.Size = new Size(1060, 643);
            panel5.TabIndex = 39;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(24, 23, 37);
            panel1.Controls.Add(iconButton13);
            panel1.Controls.Add(iconButton3);
            panel1.Controls.Add(iconButton2);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new Size(220, 720);
            panel1.TabIndex = 36;
            // 
            // guna2TextBox1
            // 
            guna2TextBox1.BackColor = Color.FromArgb(24, 23, 37);
            guna2TextBox1.BorderColor = Color.FromArgb(24, 23, 37);
            guna2TextBox1.CustomizableEdges = customizableEdges1;
            guna2TextBox1.DefaultText = "Full Name";
            guna2TextBox1.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            guna2TextBox1.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            guna2TextBox1.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            guna2TextBox1.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            guna2TextBox1.FillColor = Color.FromArgb(24, 23, 37);
            guna2TextBox1.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            guna2TextBox1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            guna2TextBox1.ForeColor = Color.FromArgb(213, 212, 215);
            guna2TextBox1.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            guna2TextBox1.Location = new Point(915, 9);
            guna2TextBox1.Name = "guna2TextBox1";
            guna2TextBox1.PasswordChar = '\0';
            guna2TextBox1.PlaceholderForeColor = Color.FromArgb(213, 212, 215);
            guna2TextBox1.PlaceholderText = "";
            guna2TextBox1.SelectedText = "";
            guna2TextBox1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2TextBox1.Size = new Size(85, 36);
            guna2TextBox1.TabIndex = 42;
            guna2TextBox1.TextAlign = HorizontalAlignment.Right;
            // 
            // picPhoto
            // 
            picPhoto.CustomizableEdges = customizableEdges3;
            picPhoto.ImageRotate = 0F;
            picPhoto.Location = new Point(1030, 9);
            picPhoto.Margin = new Padding(0);
            picPhoto.Name = "picPhoto";
            picPhoto.ShadowDecoration.CustomizableEdges = customizableEdges4;
            picPhoto.Size = new Size(30, 30);
            picPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
            picPhoto.TabIndex = 41;
            picPhoto.TabStop = false;
            // 
            // guna2PictureBox1
            // 
            guna2PictureBox1.CustomizableEdges = customizableEdges5;
            guna2PictureBox1.Image = (Image)resources.GetObject("guna2PictureBox1.Image");
            guna2PictureBox1.ImageRotate = 0F;
            guna2PictureBox1.Location = new Point(1003, 20);
            guna2PictureBox1.Margin = new Padding(0);
            guna2PictureBox1.Name = "guna2PictureBox1";
            guna2PictureBox1.ShadowDecoration.CustomizableEdges = customizableEdges6;
            guna2PictureBox1.Size = new Size(15, 15);
            guna2PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            guna2PictureBox1.TabIndex = 40;
            guna2PictureBox1.TabStop = false;
            // 
            // CinemaSaleHome
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1280, 720);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel5);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "CinemaSaleHome";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CinemaSaleHome";
            Load += CinemaSaleHome_Load;
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picPhoto).EndInit();
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel4;
        private Label label1;
        private Panel panel3;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private PictureBox pictureBox1;
        private FontAwesome.Sharp.IconButton iconButton13;
        private FontAwesome.Sharp.IconButton iconButton3;
        private FontAwesome.Sharp.IconButton iconButton2;
        private Panel panel2;
        private Panel panel5;
        private Panel panel1;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox1;
        private Guna.UI2.WinForms.Guna2PictureBox picPhoto;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
    }
}