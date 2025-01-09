namespace Main
{
    partial class Help
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
            lbSubject = new Label();
            groupBox1 = new GroupBox();
            button1 = new Button();
            tbDescription = new TextBox();
            tbTitle = new TextBox();
            btnSend = new Button();
            lbImage = new Label();
            lbDescription = new Label();
            lbTitle = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // lbSubject
            // 
            lbSubject.AutoSize = true;
            lbSubject.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold, GraphicsUnit.Point);
            lbSubject.Location = new Point(49, 35);
            lbSubject.Name = "lbSubject";
            lbSubject.Size = new Size(706, 45);
            lbSubject.TabIndex = 0;
            lbSubject.Text = "Submit Your Problem and we'll fix it right now !";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(tbDescription);
            groupBox1.Controls.Add(tbTitle);
            groupBox1.Controls.Add(btnSend);
            groupBox1.Controls.Add(lbImage);
            groupBox1.Controls.Add(lbDescription);
            groupBox1.Controls.Add(lbTitle);
            groupBox1.Location = new Point(49, 83);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(726, 505);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(0, 353);
            button1.Name = "button1";
            button1.Size = new Size(97, 33);
            button1.TabIndex = 6;
            button1.Text = "Insert";
            button1.UseVisualStyleBackColor = true;
            // 
            // tbDescription
            // 
            tbDescription.BorderStyle = BorderStyle.FixedSingle;
            tbDescription.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            tbDescription.Location = new Point(6, 137);
            tbDescription.Multiline = true;
            tbDescription.Name = "tbDescription";
            tbDescription.Size = new Size(714, 172);
            tbDescription.TabIndex = 5;
            // 
            // tbTitle
            // 
            tbTitle.BorderStyle = BorderStyle.FixedSingle;
            tbTitle.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            tbTitle.Location = new Point(6, 47);
            tbTitle.Multiline = true;
            tbTitle.Name = "tbTitle";
            tbTitle.Size = new Size(714, 45);
            tbTitle.TabIndex = 4;
            // 
            // btnSend
            // 
            btnSend.BackColor = Color.DarkOrange;
            btnSend.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnSend.ForeColor = Color.White;
            btnSend.Location = new Point(0, 458);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(133, 41);
            btnSend.TabIndex = 3;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = false;
            // 
            // lbImage
            // 
            lbImage.AutoSize = true;
            lbImage.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lbImage.Location = new Point(0, 325);
            lbImage.Name = "lbImage";
            lbImage.Size = new Size(384, 25);
            lbImage.TabIndex = 2;
            lbImage.Text = "Image (If available, please attach an image)";
            // 
            // lbDescription
            // 
            lbDescription.AutoSize = true;
            lbDescription.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lbDescription.Location = new Point(0, 109);
            lbDescription.Name = "lbDescription";
            lbDescription.Size = new Size(110, 25);
            lbDescription.TabIndex = 1;
            lbDescription.Text = "Description";
            // 
            // lbTitle
            // 
            lbTitle.AutoSize = true;
            lbTitle.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lbTitle.Location = new Point(0, 19);
            lbTitle.Name = "lbTitle";
            lbTitle.Size = new Size(428, 25);
            lbTitle.TabIndex = 0;
            lbTitle.Text = "Title (Your Account is not displayed on this form)";
            // 
            // Help
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 600);
            Controls.Add(groupBox1);
            Controls.Add(lbSubject);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Help";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Help";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbSubject;
        private GroupBox groupBox1;
        private Label lbImage;
        private Label lbDescription;
        private Label lbTitle;
        private Button btnSend;
        private TextBox tbTitle;
        private TextBox tbDescription;
        private Button button1;
    }
}