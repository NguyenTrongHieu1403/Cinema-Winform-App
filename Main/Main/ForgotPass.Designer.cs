namespace Main
{
    partial class ForgotPass
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
            label1 = new Label();
            tbPassword = new TextBox();
            picClose = new PictureBox();
            backtologin = new Label();
            btnClear = new Button();
            btnLogin = new Button();
            tbEmail = new TextBox();
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
            panel1.Controls.Add(label1);
            panel1.Controls.Add(tbPassword);
            panel1.Controls.Add(picClose);
            panel1.Controls.Add(backtologin);
            panel1.Controls.Add(btnClear);
            panel1.Controls.Add(btnLogin);
            panel1.Controls.Add(tbEmail);
            panel1.Controls.Add(lbUsername);
            panel1.Controls.Add(lblogin);
            panel1.Location = new Point(397, 0);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new Size(403, 600);
            panel1.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.DimGray;
            label1.Location = new Point(56, 455);
            label1.Name = "label1";
            label1.Size = new Size(188, 30);
            label1.TabIndex = 12;
            label1.Text = "Your NewPassword";
            // 
            // tbPassword
            // 
            tbPassword.BackColor = Color.Silver;
            tbPassword.BorderStyle = BorderStyle.None;
            tbPassword.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            tbPassword.Location = new Point(56, 488);
            tbPassword.Multiline = true;
            tbPassword.Name = "tbPassword";
            tbPassword.Size = new Size(292, 39);
            tbPassword.TabIndex = 11;
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
            // backtologin
            // 
            backtologin.AutoSize = true;
            backtologin.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            backtologin.ForeColor = Color.DarkOrange;
            backtologin.Location = new Point(145, 570);
            backtologin.Name = "backtologin";
            backtologin.Size = new Size(113, 21);
            backtologin.TabIndex = 9;
            backtologin.Text = "Back to Login";
            backtologin.Click += lbForgotPassword_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.SeaShell;
            btnClear.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnClear.ForeColor = Color.Black;
            btnClear.Location = new Point(56, 286);
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
            btnLogin.Location = new Point(56, 237);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(292, 43);
            btnLogin.TabIndex = 6;
            btnLogin.Text = "Confirm";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // tbEmail
            // 
            tbEmail.BackColor = Color.Silver;
            tbEmail.BorderStyle = BorderStyle.None;
            tbEmail.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            tbEmail.Location = new Point(56, 170);
            tbEmail.Multiline = true;
            tbEmail.Name = "tbEmail";
            tbEmail.Size = new Size(292, 39);
            tbEmail.TabIndex = 2;
            // 
            // lbUsername
            // 
            lbUsername.AutoSize = true;
            lbUsername.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            lbUsername.ForeColor = Color.DimGray;
            lbUsername.Location = new Point(50, 135);
            lbUsername.Name = "lbUsername";
            lbUsername.Size = new Size(63, 30);
            lbUsername.TabIndex = 1;
            lbUsername.Text = "Email";
            // 
            // lblogin
            // 
            lblogin.AutoSize = true;
            lblogin.FlatStyle = FlatStyle.Flat;
            lblogin.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
            lblogin.ForeColor = Color.DarkOrange;
            lblogin.Location = new Point(50, 49);
            lblogin.Name = "lblogin";
            lblogin.Size = new Size(274, 45);
            lblogin.TabIndex = 0;
            lblogin.Text = "Forgot Password";
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
            timer1.Interval = 1500;
            timer1.Tick += timer1_Tick;
            // 
            // ForgotPass
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 600);
            Controls.Add(panel1);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ForgotPass";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ForgotPass";
            Load += ForgotPass_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picClose).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private PictureBox picClose;
        private Label backtologin;
        private Button btnClear;
        private Button btnLogin;
        private TextBox tbEmail;
        private Label lbUsername;
        private Label lblogin;
        private PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private TextBox tbPassword;
        private Label label1;
    }
}