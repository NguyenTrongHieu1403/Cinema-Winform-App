namespace Main
{
    partial class EditCustomer
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
            tbphone = new TextBox();
            label5 = new Label();
            textBox1 = new TextBox();
            gender = new Label();
            btnSave = new Button();
            btnCancel = new Button();
            tbName = new TextBox();
            fullname = new Label();
            lbClose = new Label();
            label1 = new Label();
            tbEmail = new TextBox();
            label8 = new Label();
            SuspendLayout();
            // 
            // tbphone
            // 
            tbphone.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            tbphone.Location = new Point(32, 159);
            tbphone.Multiline = true;
            tbphone.Name = "tbphone";
            tbphone.Size = new Size(272, 23);
            tbphone.TabIndex = 193;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.White;
            label5.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(219, 161);
            label5.Name = "label5";
            label5.Size = new Size(66, 17);
            label5.TabIndex = 191;
            label5.Text = "Ngày sinh";
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.Black;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Location = new Point(0, 41);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(800, 4);
            textBox1.TabIndex = 190;
            // 
            // gender
            // 
            gender.AutoSize = true;
            gender.BackColor = Color.White;
            gender.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            gender.ForeColor = Color.Black;
            gender.Location = new Point(32, 137);
            gender.Name = "gender";
            gender.Size = new Size(85, 17);
            gender.TabIndex = 187;
            gender.Text = "Số điện thoại";
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.CadetBlue;
            btnSave.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(286, 331);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(79, 32);
            btnSave.TabIndex = 186;
            btnSave.Text = "Sửa";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Red;
            btnCancel.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(185, 331);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(79, 32);
            btnCancel.TabIndex = 185;
            btnCancel.Text = "Hủy";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // tbName
            // 
            tbName.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            tbName.Location = new Point(32, 86);
            tbName.Multiline = true;
            tbName.Name = "tbName";
            tbName.Size = new Size(272, 23);
            tbName.TabIndex = 184;
            // 
            // fullname
            // 
            fullname.AutoSize = true;
            fullname.BackColor = Color.White;
            fullname.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            fullname.ForeColor = Color.Black;
            fullname.Location = new Point(32, 66);
            fullname.Name = "fullname";
            fullname.Size = new Size(98, 17);
            fullname.TabIndex = 181;
            fullname.Text = "Tên khách hàng";
            // 
            // lbClose
            // 
            lbClose.AutoSize = true;
            lbClose.BackColor = Color.White;
            lbClose.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lbClose.ForeColor = Color.Black;
            lbClose.Location = new Point(362, 6);
            lbClose.Name = "lbClose";
            lbClose.Size = new Size(26, 32);
            lbClose.TabIndex = 177;
            lbClose.Text = "x";
            lbClose.Click += lbClose_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.White;
            label1.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(12, 6);
            label1.Name = "label1";
            label1.Size = new Size(297, 32);
            label1.TabIndex = 176;
            label1.Text = "Sửa thông tin khách hàng";
            // 
            // tbEmail
            // 
            tbEmail.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            tbEmail.Location = new Point(32, 232);
            tbEmail.Multiline = true;
            tbEmail.Name = "tbEmail";
            tbEmail.Size = new Size(272, 23);
            tbEmail.TabIndex = 202;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.White;
            label8.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label8.ForeColor = Color.Black;
            label8.Location = new Point(32, 212);
            label8.Name = "label8";
            label8.Size = new Size(39, 17);
            label8.TabIndex = 203;
            label8.Text = "Email";
            // 
            // EditCustomer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(400, 400);
            Controls.Add(label8);
            Controls.Add(tbEmail);
            Controls.Add(tbphone);
            Controls.Add(label5);
            Controls.Add(textBox1);
            Controls.Add(gender);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Controls.Add(tbName);
            Controls.Add(fullname);
            Controls.Add(lbClose);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "EditCustomer";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AddCustomer";
            Load += EditCustomer_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox tbphone;
        private Label label5;
        private TextBox textBox1;
        private Label gender;
        private Button btnSave;
        private Button btnCancel;
        private TextBox tbName;
        private Label fullname;
        private Label lbClose;
        private Label label1;
        private TextBox tbEmail;
        private Label label8;
    }
}