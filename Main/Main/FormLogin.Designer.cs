namespace Main
{
    partial class FormLogin
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
            components = new System.ComponentModel.Container();
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            picClose = new PictureBox();
            lbForgotPassword = new Label();
            btnClear = new Button();
            btnLogin = new Button();
            cbShowPassword = new CheckBox();
            tbPassword = new TextBox();
            tbUsername = new TextBox();
            lbPassword = new Label();
            lbUsername = new Label();
            lblogin = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picClose).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(394, 600);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(picClose);
            panel1.Controls.Add(lbForgotPassword);
            panel1.Controls.Add(btnClear);
            panel1.Controls.Add(btnLogin);
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
            panel1.TabIndex = 1;
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
            // lbForgotPassword
            // 
            lbForgotPassword.AutoSize = true;
            lbForgotPassword.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            lbForgotPassword.ForeColor = Color.DarkOrange;
            lbForgotPassword.Location = new Point(134, 570);
            lbForgotPassword.Name = "lbForgotPassword";
            lbForgotPassword.Size = new Size(136, 21);
            lbForgotPassword.TabIndex = 9;
            lbForgotPassword.Text = "Forgot Password";
            lbForgotPassword.Click += lbForgotPassword_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.SeaShell;
            btnClear.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnClear.ForeColor = Color.Black;
            btnClear.Location = new Point(56, 463);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(292, 43);
            btnClear.TabIndex = 7;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.DarkOrange;
            btnLogin.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(56, 401);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(292, 43);
            btnLogin.TabIndex = 6;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // cbShowPassword
            // 
            cbShowPassword.AutoSize = true;
            cbShowPassword.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            cbShowPassword.Location = new Point(218, 336);
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
            tbPassword.Location = new Point(55, 281);
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
            tbUsername.Location = new Point(56, 170);
            tbUsername.Multiline = true;
            tbUsername.Name = "tbUsername";
            tbUsername.Size = new Size(292, 39);
            tbUsername.TabIndex = 2;
            // 
            // lbPassword
            // 
            lbPassword.AutoSize = true;
            lbPassword.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            lbPassword.ForeColor = Color.DimGray;
            lbPassword.Location = new Point(50, 248);
            lbPassword.Name = "lbPassword";
            lbPassword.Size = new Size(99, 30);
            lbPassword.TabIndex = 2;
            lbPassword.Text = "Password";
            // 
            // lbUsername
            // 
            lbUsername.AutoSize = true;
            lbUsername.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            lbUsername.ForeColor = Color.DimGray;
            lbUsername.Location = new Point(50, 135);
            lbUsername.Name = "lbUsername";
            lbUsername.Size = new Size(106, 30);
            lbUsername.TabIndex = 1;
            lbUsername.Text = "Username";
            // 
            // lblogin
            // 
            lblogin.AutoSize = true;
            lblogin.FlatStyle = FlatStyle.Flat;
            lblogin.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
            lblogin.ForeColor = Color.DarkOrange;
            lblogin.Location = new Point(50, 49);
            lblogin.Name = "lblogin";
            lblogin.Size = new Size(313, 45);
            lblogin.TabIndex = 0;
            lblogin.Text = "Login Your Account";
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 1500;
            timer1.Tick += timer1_Tick;
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 600);
            Controls.Add(panel1);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += FormLogin_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picClose).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Panel panel1;
        private Label lblogin;
        private Label lbUsername;
        private TextBox tbPassword;
        private TextBox tbUsername;
        private Label lbPassword;
        private Button btnLogin;
        private CheckBox cbShowPassword;
        private Button btnClear;
        private Label lbForgotPassword;
        private PictureBox picClose;
        private System.Windows.Forms.Timer timer1;
    }
}
