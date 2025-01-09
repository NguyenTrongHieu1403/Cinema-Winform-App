namespace Main
{
    partial class EditUser
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            RoleCB = new Guna.UI2.WinForms.Guna2ComboBox();
            label2 = new Label();
            cinemaid = new Label();
            cinemaidCb = new Guna.UI2.WinForms.Guna2ComboBox();
            genderfemale = new Guna.UI2.WinForms.Guna2RadioButton();
            gendermale = new Guna.UI2.WinForms.Guna2RadioButton();
            gender = new Label();
            tbaddress = new TextBox();
            address = new Label();
            label13 = new Label();
            label11 = new Label();
            label10 = new Label();
            btnSave = new Button();
            btnCancel = new Button();
            tbPassword = new TextBox();
            tbUsername = new TextBox();
            tbEmail = new TextBox();
            tbPhoneNumber = new TextBox();
            tbName = new TextBox();
            labelPassword = new Label();
            username = new Label();
            email = new Label();
            phone = new Label();
            fullname = new Label();
            btnPhoto = new Button();
            picPhoto = new PictureBox();
            label3 = new Label();
            lbClose = new Label();
            label1 = new Label();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)picPhoto).BeginInit();
            SuspendLayout();
            // 
            // RoleCB
            // 
            RoleCB.BackColor = Color.Transparent;
            RoleCB.BorderColor = Color.DarkGray;
            RoleCB.BorderThickness = 2;
            RoleCB.CustomizableEdges = customizableEdges5;
            RoleCB.DrawMode = DrawMode.OwnerDrawFixed;
            RoleCB.DropDownStyle = ComboBoxStyle.DropDownList;
            RoleCB.FocusedColor = Color.FromArgb(94, 148, 255);
            RoleCB.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            RoleCB.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            RoleCB.ForeColor = Color.Black;
            RoleCB.ItemHeight = 29;
            RoleCB.Location = new Point(464, 420);
            RoleCB.Name = "RoleCB";
            RoleCB.ShadowDecoration.CustomizableEdges = customizableEdges6;
            RoleCB.Size = new Size(118, 35);
            RoleCB.TabIndex = 90;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.White;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(305, 434);
            label2.Name = "label2";
            label2.Size = new Size(55, 21);
            label2.TabIndex = 89;
            label2.Text = "Vai trò";
            // 
            // cinemaid
            // 
            cinemaid.AutoSize = true;
            cinemaid.BackColor = Color.White;
            cinemaid.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cinemaid.ForeColor = Color.Black;
            cinemaid.Location = new Point(305, 380);
            cinemaid.Name = "cinemaid";
            cinemaid.Size = new Size(78, 21);
            cinemaid.TabIndex = 87;
            cinemaid.Text = "Rạp chiếu";
            // 
            // cinemaidCb
            // 
            cinemaidCb.BackColor = Color.Transparent;
            cinemaidCb.BorderColor = Color.DarkGray;
            cinemaidCb.BorderThickness = 2;
            cinemaidCb.CustomizableEdges = customizableEdges7;
            cinemaidCb.DrawMode = DrawMode.OwnerDrawFixed;
            cinemaidCb.DropDownStyle = ComboBoxStyle.DropDownList;
            cinemaidCb.FocusedColor = Color.FromArgb(94, 148, 255);
            cinemaidCb.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cinemaidCb.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cinemaidCb.ForeColor = Color.Black;
            cinemaidCb.ItemHeight = 29;
            cinemaidCb.Location = new Point(464, 370);
            cinemaidCb.Name = "cinemaidCb";
            cinemaidCb.ShadowDecoration.CustomizableEdges = customizableEdges8;
            cinemaidCb.Size = new Size(272, 35);
            cinemaidCb.TabIndex = 86;
            // 
            // genderfemale
            // 
            genderfemale.AutoSize = true;
            genderfemale.CheckedState.BorderColor = Color.FromArgb(94, 148, 255);
            genderfemale.CheckedState.BorderThickness = 0;
            genderfemale.CheckedState.FillColor = Color.FromArgb(94, 148, 255);
            genderfemale.CheckedState.InnerColor = Color.White;
            genderfemale.CheckedState.InnerOffset = -4;
            genderfemale.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            genderfemale.Location = new Point(539, 482);
            genderfemale.Name = "genderfemale";
            genderfemale.Size = new Size(78, 25);
            genderfemale.TabIndex = 85;
            genderfemale.Text = "Female";
            genderfemale.UncheckedState.BorderColor = Color.FromArgb(125, 137, 149);
            genderfemale.UncheckedState.BorderThickness = 2;
            genderfemale.UncheckedState.FillColor = Color.Transparent;
            genderfemale.UncheckedState.InnerColor = Color.Transparent;
            // 
            // gendermale
            // 
            gendermale.AutoSize = true;
            gendermale.CheckedState.BorderColor = Color.FromArgb(94, 148, 255);
            gendermale.CheckedState.BorderThickness = 0;
            gendermale.CheckedState.FillColor = Color.FromArgb(94, 148, 255);
            gendermale.CheckedState.InnerColor = Color.White;
            gendermale.CheckedState.InnerOffset = -4;
            gendermale.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            gendermale.Location = new Point(464, 482);
            gendermale.Name = "gendermale";
            gendermale.Size = new Size(62, 25);
            gendermale.TabIndex = 84;
            gendermale.Text = "Male";
            gendermale.UncheckedState.BorderColor = Color.FromArgb(125, 137, 149);
            gendermale.UncheckedState.BorderThickness = 2;
            gendermale.UncheckedState.FillColor = Color.Transparent;
            gendermale.UncheckedState.InnerColor = Color.Transparent;
            // 
            // gender
            // 
            gender.AutoSize = true;
            gender.BackColor = Color.White;
            gender.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            gender.ForeColor = Color.Black;
            gender.Location = new Point(305, 482);
            gender.Name = "gender";
            gender.Size = new Size(70, 21);
            gender.TabIndex = 83;
            gender.Text = "Giới tính";
            // 
            // tbaddress
            // 
            tbaddress.BorderStyle = BorderStyle.FixedSingle;
            tbaddress.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tbaddress.Location = new Point(464, 314);
            tbaddress.Name = "tbaddress";
            tbaddress.Size = new Size(272, 29);
            tbaddress.TabIndex = 82;
            // 
            // address
            // 
            address.AutoSize = true;
            address.BackColor = Color.White;
            address.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            address.ForeColor = Color.Black;
            address.Location = new Point(305, 314);
            address.Name = "address";
            address.Size = new Size(57, 21);
            address.TabIndex = 81;
            address.Text = "Địa chỉ";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label13.ForeColor = Color.Red;
            label13.Location = new Point(742, 231);
            label13.Name = "label13";
            label13.Size = new Size(29, 21);
            label13.TabIndex = 80;
            label13.Text = "(*)";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label11.ForeColor = Color.Red;
            label11.Location = new Point(742, 187);
            label11.Name = "label11";
            label11.Size = new Size(29, 21);
            label11.TabIndex = 78;
            label11.Text = "(*)";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label10.ForeColor = Color.Red;
            label10.Location = new Point(12, 552);
            label10.Name = "label10";
            label10.Size = new Size(272, 17);
            label10.TabIndex = 77;
            label10.Text = "*Note : The following lines must not be null";
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.CadetBlue;
            btnSave.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(657, 570);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(79, 32);
            btnSave.TabIndex = 76;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.CornflowerBlue;
            btnCancel.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(557, 570);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(79, 32);
            btnCancel.TabIndex = 75;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // tbPassword
            // 
            tbPassword.BorderStyle = BorderStyle.FixedSingle;
            tbPassword.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tbPassword.Location = new Point(464, 270);
            tbPassword.Name = "tbPassword";
            tbPassword.Size = new Size(272, 29);
            tbPassword.TabIndex = 74;
            // 
            // tbUsername
            // 
            tbUsername.BorderStyle = BorderStyle.FixedSingle;
            tbUsername.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tbUsername.Location = new Point(464, 223);
            tbUsername.Name = "tbUsername";
            tbUsername.ReadOnly = true;
            tbUsername.Size = new Size(272, 29);
            tbUsername.TabIndex = 73;
            // 
            // tbEmail
            // 
            tbEmail.BorderStyle = BorderStyle.FixedSingle;
            tbEmail.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tbEmail.Location = new Point(464, 179);
            tbEmail.Name = "tbEmail";
            tbEmail.ReadOnly = true;
            tbEmail.Size = new Size(272, 29);
            tbEmail.TabIndex = 72;
            // 
            // tbPhoneNumber
            // 
            tbPhoneNumber.BorderStyle = BorderStyle.FixedSingle;
            tbPhoneNumber.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tbPhoneNumber.Location = new Point(464, 137);
            tbPhoneNumber.Name = "tbPhoneNumber";
            tbPhoneNumber.Size = new Size(272, 29);
            tbPhoneNumber.TabIndex = 71;
            // 
            // tbName
            // 
            tbName.BorderStyle = BorderStyle.FixedSingle;
            tbName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tbName.Location = new Point(464, 95);
            tbName.Name = "tbName";
            tbName.Size = new Size(272, 29);
            tbName.TabIndex = 70;
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.BackColor = Color.White;
            labelPassword.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelPassword.ForeColor = Color.Black;
            labelPassword.Location = new Point(305, 270);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(75, 21);
            labelPassword.TabIndex = 69;
            labelPassword.Text = "Mật khẩu";
            // 
            // username
            // 
            username.AutoSize = true;
            username.BackColor = Color.White;
            username.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            username.ForeColor = Color.Black;
            username.Location = new Point(305, 223);
            username.Name = "username";
            username.Size = new Size(111, 21);
            username.TabIndex = 68;
            username.Text = "Tên đăng nhập";
            // 
            // email
            // 
            email.AutoSize = true;
            email.BackColor = Color.White;
            email.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            email.ForeColor = Color.Black;
            email.Location = new Point(305, 179);
            email.Name = "email";
            email.Size = new Size(48, 21);
            email.TabIndex = 67;
            email.Text = "Email";
            // 
            // phone
            // 
            phone.AutoSize = true;
            phone.BackColor = Color.White;
            phone.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            phone.ForeColor = Color.Black;
            phone.Location = new Point(305, 137);
            phone.Name = "phone";
            phone.Size = new Size(101, 21);
            phone.TabIndex = 66;
            phone.Text = "Số điện thoại";
            // 
            // fullname
            // 
            fullname.AutoSize = true;
            fullname.BackColor = Color.White;
            fullname.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            fullname.ForeColor = Color.Black;
            fullname.Location = new Point(305, 97);
            fullname.Name = "fullname";
            fullname.Size = new Size(77, 21);
            fullname.TabIndex = 65;
            fullname.Text = "Họ và Tên";
            // 
            // btnPhoto
            // 
            btnPhoto.BackColor = Color.CornflowerBlue;
            btnPhoto.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnPhoto.ForeColor = Color.White;
            btnPhoto.Location = new Point(12, 370);
            btnPhoto.Name = "btnPhoto";
            btnPhoto.Size = new Size(256, 40);
            btnPhoto.TabIndex = 64;
            btnPhoto.Text = "Change Photo";
            btnPhoto.UseVisualStyleBackColor = false;
            btnPhoto.Click += btnPhoto_Click_1;
            // 
            // picPhoto
            // 
            picPhoto.Location = new Point(12, 108);
            picPhoto.Name = "picPhoto";
            picPhoto.Size = new Size(256, 256);
            picPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
            picPhoto.TabIndex = 63;
            picPhoto.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.White;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(12, 80);
            label3.Name = "label3";
            label3.Size = new Size(62, 25);
            label3.TabIndex = 62;
            label3.Text = "Photo";
            // 
            // lbClose
            // 
            lbClose.AutoSize = true;
            lbClose.BackColor = Color.CornflowerBlue;
            lbClose.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lbClose.ForeColor = Color.Transparent;
            lbClose.Location = new Point(762, 13);
            lbClose.Name = "lbClose";
            lbClose.Size = new Size(26, 32);
            lbClose.TabIndex = 61;
            lbClose.Text = "x";
            lbClose.Click += lbClose_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.CornflowerBlue;
            label1.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.Transparent;
            label1.Location = new Point(12, 13);
            label1.Name = "label1";
            label1.Size = new Size(111, 32);
            label1.TabIndex = 60;
            label1.Text = "Edit User";
            // 
            // button1
            // 
            button1.BackColor = Color.CornflowerBlue;
            button1.Enabled = false;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = Color.White;
            button1.Location = new Point(-3, -1);
            button1.Name = "button1";
            button1.Size = new Size(807, 64);
            button1.TabIndex = 59;
            button1.UseVisualStyleBackColor = false;
            // 
            // EditUser
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 600);
            Controls.Add(RoleCB);
            Controls.Add(label2);
            Controls.Add(cinemaid);
            Controls.Add(cinemaidCb);
            Controls.Add(genderfemale);
            Controls.Add(gendermale);
            Controls.Add(gender);
            Controls.Add(tbaddress);
            Controls.Add(address);
            Controls.Add(label13);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Controls.Add(tbPassword);
            Controls.Add(tbUsername);
            Controls.Add(tbEmail);
            Controls.Add(tbPhoneNumber);
            Controls.Add(tbName);
            Controls.Add(labelPassword);
            Controls.Add(username);
            Controls.Add(email);
            Controls.Add(phone);
            Controls.Add(fullname);
            Controls.Add(btnPhoto);
            Controls.Add(picPhoto);
            Controls.Add(label3);
            Controls.Add(lbClose);
            Controls.Add(label1);
            Controls.Add(button1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "EditUser";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EditUser";
            Load += EditUser_Load;
            ((System.ComponentModel.ISupportInitialize)picPhoto).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Guna.UI2.WinForms.Guna2ComboBox RoleCB;
        private Label label2;
        private Label cinemaid;
        private Guna.UI2.WinForms.Guna2ComboBox cinemaidCb;
        private Guna.UI2.WinForms.Guna2RadioButton genderfemale;
        private Guna.UI2.WinForms.Guna2RadioButton gendermale;
        private Label gender;
        private TextBox tbaddress;
        private Label address;
        private Label label13;
        private Label label11;
        private Label label10;
        private Button btnSave;
        private Button btnCancel;
        private TextBox tbPassword;
        private TextBox tbUsername;
        private TextBox tbEmail;
        private TextBox tbPhoneNumber;
        private TextBox tbName;
        private Label labelPassword;
        private Label username;
        private Label email;
        private Label phone;
        private Label fullname;
        private Button btnPhoto;
        private PictureBox picPhoto;
        private Label label3;
        private Label lbClose;
        private Label label1;
        private Button button1;
    }
}