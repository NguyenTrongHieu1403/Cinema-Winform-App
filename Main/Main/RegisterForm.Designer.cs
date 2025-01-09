namespace Main
{
    partial class RegisterForm
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
            panel1 = new Panel();
            tbConfirmPassword = new TextBox();
            label2 = new Label();
            tbEmail = new TextBox();
            label1 = new Label();
            picClose = new PictureBox();
            lbBackToLogin = new Label();
            btnClear = new Button();
            btnRegister = new Button();
            cbShowPassword = new CheckBox();
            tbPassword = new TextBox();
            tbUsername = new TextBox();
            lbPassword = new Label();
            lbUsername = new Label();
            lblogin = new Label();
            pictureBox1 = new PictureBox();
            timer1 = new System.Windows.Forms.Timer(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picClose).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(tbConfirmPassword);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(tbEmail);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(picClose);
            panel1.Controls.Add(lbBackToLogin);
            panel1.Controls.Add(btnClear);
            panel1.Controls.Add(btnRegister);
            panel1.Controls.Add(cbShowPassword);
            panel1.Controls.Add(tbPassword);
            panel1.Controls.Add(tbUsername);
            panel1.Controls.Add(lbPassword);
            panel1.Controls.Add(lbUsername);
            panel1.Controls.Add(lblogin);
            panel1.Location = new Point(397, 0);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new Size(403, 600);
            panel1.TabIndex = 3;
            // 
            // tbConfirmPassword
            // 
            tbConfirmPassword.BackColor = Color.Silver;
            tbConfirmPassword.BorderStyle = BorderStyle.None;
            tbConfirmPassword.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            tbConfirmPassword.Location = new Point(56, 386);
            tbConfirmPassword.Multiline = true;
            tbConfirmPassword.Name = "tbConfirmPassword";
            tbConfirmPassword.PasswordChar = '*';
            tbConfirmPassword.Size = new Size(292, 39);
            tbConfirmPassword.TabIndex = 14;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.DimGray;
            label2.Location = new Point(55, 358);
            label2.Name = "label2";
            label2.Size = new Size(164, 25);
            label2.TabIndex = 13;
            label2.Text = "Confirm Password";
            // 
            // tbEmail
            // 
            tbEmail.BackColor = Color.Silver;
            tbEmail.BorderStyle = BorderStyle.None;
            tbEmail.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            tbEmail.Location = new Point(55, 215);
            tbEmail.Multiline = true;
            tbEmail.Name = "tbEmail";
            tbEmail.Size = new Size(292, 39);
            tbEmail.TabIndex = 12;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.DimGray;
            label1.Location = new Point(55, 187);
            label1.Name = "label1";
            label1.Size = new Size(58, 25);
            label1.TabIndex = 11;
            label1.Text = "Email";
            // 
            // picClose
            // 
            picClose.Image = Properties.Resources.sign_error_icon;
            picClose.Location = new Point(365, 0);
            picClose.Name = "picClose";
            picClose.Size = new Size(35, 35);
            picClose.SizeMode = PictureBoxSizeMode.StretchImage;
            picClose.TabIndex = 10;
            picClose.TabStop = false;
            picClose.Click += picClose_Click;
            // 
            // lbBackToLogin
            // 
            lbBackToLogin.AutoSize = true;
            lbBackToLogin.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            lbBackToLogin.ForeColor = Color.DarkOrange;
            lbBackToLogin.Location = new Point(150, 570);
            lbBackToLogin.Name = "lbBackToLogin";
            lbBackToLogin.Size = new Size(113, 21);
            lbBackToLogin.TabIndex = 9;
            lbBackToLogin.Text = "Back to Login";
            lbBackToLogin.Click += lbBackToLogin_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.SeaShell;
            btnClear.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnClear.ForeColor = Color.Black;
            btnClear.Location = new Point(56, 524);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(292, 43);
            btnClear.TabIndex = 7;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.DarkOrange;
            btnRegister.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnRegister.ForeColor = Color.White;
            btnRegister.Location = new Point(56, 475);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(292, 43);
            btnRegister.TabIndex = 6;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
            // 
            // cbShowPassword
            // 
            cbShowPassword.AutoSize = true;
            cbShowPassword.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            cbShowPassword.Location = new Point(218, 445);
            cbShowPassword.Name = "cbShowPassword";
            cbShowPassword.Size = new Size(129, 24);
            cbShowPassword.TabIndex = 4;
            cbShowPassword.Text = "Show Password";
            cbShowPassword.UseVisualStyleBackColor = true;
            cbShowPassword.CheckedChanged += cbShowPassword_CheckedChanged;
            // 
            // tbPassword
            // 
            tbPassword.BackColor = Color.Silver;
            tbPassword.BorderStyle = BorderStyle.None;
            tbPassword.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            tbPassword.Location = new Point(56, 296);
            tbPassword.Multiline = true;
            tbPassword.Name = "tbPassword";
            tbPassword.PasswordChar = '*';
            tbPassword.Size = new Size(292, 39);
            tbPassword.TabIndex = 3;
            // 
            // tbUsername
            // 
            tbUsername.BackColor = Color.Silver;
            tbUsername.BorderStyle = BorderStyle.None;
            tbUsername.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            tbUsername.Location = new Point(56, 140);
            tbUsername.Multiline = true;
            tbUsername.Name = "tbUsername";
            tbUsername.Size = new Size(292, 39);
            tbUsername.TabIndex = 2;
            // 
            // lbPassword
            // 
            lbPassword.AutoSize = true;
            lbPassword.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            lbPassword.ForeColor = Color.DimGray;
            lbPassword.Location = new Point(55, 268);
            lbPassword.Name = "lbPassword";
            lbPassword.Size = new Size(91, 25);
            lbPassword.TabIndex = 2;
            lbPassword.Text = "Password";
            // 
            // lbUsername
            // 
            lbUsername.AutoSize = true;
            lbUsername.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            lbUsername.ForeColor = Color.DimGray;
            lbUsername.Location = new Point(55, 107);
            lbUsername.Name = "lbUsername";
            lbUsername.Size = new Size(97, 25);
            lbUsername.TabIndex = 1;
            lbUsername.Text = "Username";
            // 
            // lblogin
            // 
            lblogin.AutoSize = true;
            lblogin.FlatStyle = FlatStyle.Flat;
            lblogin.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
            lblogin.ForeColor = Color.DarkOrange;
            lblogin.Location = new Point(40, 49);
            lblogin.Name = "lblogin";
            lblogin.Size = new Size(351, 45);
            lblogin.TabIndex = 0;
            lblogin.Text = "Register Your Account";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(394, 600);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 1000;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 600);
            Controls.Add(panel1);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "RegisterForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RegisterForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picClose).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private PictureBox picClose;
        private Label lbBackToLogin;
        private Button btnClear;
        private Button btnRegister;
        private CheckBox cbShowPassword;
        private TextBox tbPassword;
        private TextBox tbUsername;
        private Label lbPassword;
        private Label lbUsername;
        private Label lblogin;
        private PictureBox pictureBox1;
        private TextBox tbEmail;
        private Label label1;
        private TextBox tbConfirmPassword;
        private Label label2;
        private System.Windows.Forms.Timer timer1;
    }
}