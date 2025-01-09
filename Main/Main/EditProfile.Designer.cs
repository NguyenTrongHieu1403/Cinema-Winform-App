namespace Main
{
    partial class EditProfile
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
            button1 = new Button();
            label1 = new Label();
            lbClose = new Label();
            label3 = new Label();
            picPhoto = new PictureBox();
            btnPhoto = new Button();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            labelPassword = new Label();
            tbName = new TextBox();
            tbPhoneNumber = new TextBox();
            tbCreatedAt = new TextBox();
            tbEmail = new TextBox();
            tbUsername = new TextBox();
            tbPassword = new TextBox();
            btnCancel = new Button();
            btnSave = new Button();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            ((System.ComponentModel.ISupportInitialize)picPhoto).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.CornflowerBlue;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = Color.White;
            button1.Location = new Point(-3, -5);
            button1.Name = "button1";
            button1.Size = new Size(807, 64);
            button1.TabIndex = 0;
            button1.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.CornflowerBlue;
            label1.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.Transparent;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(188, 32);
            label1.TabIndex = 1;
            label1.Text = "Edit Your Profile";
            // 
            // lbClose
            // 
            lbClose.AutoSize = true;
            lbClose.BackColor = Color.CornflowerBlue;
            lbClose.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lbClose.ForeColor = Color.Transparent;
            lbClose.Location = new Point(762, 9);
            lbClose.Name = "lbClose";
            lbClose.Size = new Size(26, 32);
            lbClose.TabIndex = 2;
            lbClose.Text = "x";
            lbClose.Click += lbClose_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.White;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(12, 91);
            label3.Name = "label3";
            label3.Size = new Size(62, 25);
            label3.TabIndex = 3;
            label3.Text = "Photo";
            // 
            // picPhoto
            // 
            picPhoto.Location = new Point(12, 119);
            picPhoto.Name = "picPhoto";
            picPhoto.Size = new Size(256, 256);
            picPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
            picPhoto.TabIndex = 4;
            picPhoto.TabStop = false;
            // 
            // btnPhoto
            // 
            btnPhoto.BackColor = Color.CornflowerBlue;
            btnPhoto.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnPhoto.ForeColor = Color.White;
            btnPhoto.Location = new Point(12, 381);
            btnPhoto.Name = "btnPhoto";
            btnPhoto.Size = new Size(256, 40);
            btnPhoto.TabIndex = 5;
            btnPhoto.Text = "Change Photo";
            btnPhoto.UseVisualStyleBackColor = false;
            btnPhoto.Click += btnPhoto_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.White;
            label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(305, 119);
            label4.Name = "label4";
            label4.Size = new Size(62, 25);
            label4.TabIndex = 6;
            label4.Text = "Name";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.White;
            label5.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(305, 165);
            label5.Name = "label5";
            label5.Size = new Size(140, 25);
            label5.TabIndex = 7;
            label5.Text = "Phone Number";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.White;
            label6.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label6.ForeColor = Color.Black;
            label6.Location = new Point(305, 214);
            label6.Name = "label6";
            label6.Size = new Size(101, 25);
            label6.TabIndex = 8;
            label6.Text = "Created At";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.White;
            label7.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label7.ForeColor = Color.Black;
            label7.Location = new Point(305, 263);
            label7.Name = "label7";
            label7.Size = new Size(58, 25);
            label7.TabIndex = 9;
            label7.Text = "Email";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.White;
            label8.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label8.ForeColor = Color.Black;
            label8.Location = new Point(305, 319);
            label8.Name = "label8";
            label8.Size = new Size(97, 25);
            label8.TabIndex = 10;
            label8.Text = "Username";
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.BackColor = Color.White;
            labelPassword.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            labelPassword.ForeColor = Color.Black;
            labelPassword.Location = new Point(305, 369);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(91, 25);
            labelPassword.TabIndex = 11;
            labelPassword.Text = "Password";
            // 
            // tbName
            // 
            tbName.BorderStyle = BorderStyle.FixedSingle;
            tbName.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            tbName.Location = new Point(464, 117);
            tbName.Name = "tbName";
            tbName.Size = new Size(272, 33);
            tbName.TabIndex = 12;
            // 
            // tbPhoneNumber
            // 
            tbPhoneNumber.BorderStyle = BorderStyle.FixedSingle;
            tbPhoneNumber.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            tbPhoneNumber.Location = new Point(464, 165);
            tbPhoneNumber.Name = "tbPhoneNumber";
            tbPhoneNumber.Size = new Size(272, 33);
            tbPhoneNumber.TabIndex = 13;
            // 
            // tbCreatedAt
            // 
            tbCreatedAt.BorderStyle = BorderStyle.FixedSingle;
            tbCreatedAt.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            tbCreatedAt.Location = new Point(464, 214);
            tbCreatedAt.Name = "tbCreatedAt";
            tbCreatedAt.Size = new Size(272, 33);
            tbCreatedAt.TabIndex = 14;
            // 
            // tbEmail
            // 
            tbEmail.BorderStyle = BorderStyle.FixedSingle;
            tbEmail.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            tbEmail.Location = new Point(464, 263);
            tbEmail.Name = "tbEmail";
            tbEmail.Size = new Size(272, 33);
            tbEmail.TabIndex = 15;
            // 
            // tbUsername
            // 
            tbUsername.BorderStyle = BorderStyle.FixedSingle;
            tbUsername.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            tbUsername.Location = new Point(464, 317);
            tbUsername.Name = "tbUsername";
            tbUsername.Size = new Size(272, 33);
            tbUsername.TabIndex = 16;
            // 
            // tbPassword
            // 
            tbPassword.BorderStyle = BorderStyle.FixedSingle;
            tbPassword.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            tbPassword.Location = new Point(464, 367);
            tbPassword.Name = "tbPassword";
            tbPassword.Size = new Size(272, 33);
            tbPassword.TabIndex = 17;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.CornflowerBlue;
            btnCancel.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(562, 426);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(79, 32);
            btnCancel.TabIndex = 18;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.CadetBlue;
            btnSave.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(657, 426);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(79, 32);
            btnSave.TabIndex = 19;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label10.ForeColor = Color.Red;
            label10.Location = new Point(12, 548);
            label10.Name = "label10";
            label10.Size = new Size(301, 17);
            label10.TabIndex = 20;
            label10.Text = "* Note: You cannot change data marked with (*)";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label11.ForeColor = Color.Red;
            label11.Location = new Point(742, 319);
            label11.Name = "label11";
            label11.Size = new Size(29, 21);
            label11.TabIndex = 21;
            label11.Text = "(*)";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label12.ForeColor = Color.Red;
            label12.Location = new Point(742, 266);
            label12.Name = "label12";
            label12.Size = new Size(29, 21);
            label12.TabIndex = 22;
            label12.Text = "(*)";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label13.ForeColor = Color.Red;
            label13.Location = new Point(742, 217);
            label13.Name = "label13";
            label13.Size = new Size(29, 21);
            label13.TabIndex = 23;
            label13.Text = "(*)";
            // 
            // EditProfile
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 600);
            Controls.Add(label13);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Controls.Add(tbPassword);
            Controls.Add(tbUsername);
            Controls.Add(tbEmail);
            Controls.Add(tbCreatedAt);
            Controls.Add(tbPhoneNumber);
            Controls.Add(tbName);
            Controls.Add(labelPassword);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(btnPhoto);
            Controls.Add(picPhoto);
            Controls.Add(label3);
            Controls.Add(lbClose);
            Controls.Add(label1);
            Controls.Add(button1);
            ForeColor = SystemColors.ActiveCaptionText;
            FormBorderStyle = FormBorderStyle.None;
            Name = "EditProfile";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EditProfile";
            Load += EditProfile_Load;
            ((System.ComponentModel.ISupportInitialize)picPhoto).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private Label lbClose;
        private Label label3;
        private PictureBox picPhoto;
        private Button btnPhoto;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label labelPassword;
        private TextBox tbName;
        private TextBox tbPhoneNumber;
        private TextBox tbCreatedAt;
        private TextBox tbEmail;
        private TextBox tbUsername;
        private TextBox tbPassword;
        private Button btnCancel;
        private Button btnSave;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
    }
}