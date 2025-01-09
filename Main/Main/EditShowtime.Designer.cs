namespace Main
{
    partial class EditShowtime
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            moviecb = new Guna.UI2.WinForms.Guna2ComboBox();
            button1 = new Button();
            pricetb = new TextBox();
            guna2HtmlLabel5 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            StartTime = new Guna.UI2.WinForms.Guna2DateTimePicker();
            guna2HtmlLabel4 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            roomcb = new Guna.UI2.WinForms.Guna2ComboBox();
            btnSave = new Button();
            btnCancel = new Button();
            stname = new TextBox();
            guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            textBox1 = new TextBox();
            lbClose = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // moviecb
            // 
            moviecb.BackColor = Color.Transparent;
            moviecb.CustomizableEdges = customizableEdges1;
            moviecb.DrawMode = DrawMode.OwnerDrawFixed;
            moviecb.DropDownStyle = ComboBoxStyle.DropDownList;
            moviecb.FocusedColor = Color.FromArgb(94, 148, 255);
            moviecb.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            moviecb.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            moviecb.ForeColor = Color.FromArgb(68, 88, 112);
            moviecb.ItemHeight = 30;
            moviecb.Location = new Point(125, 51);
            moviecb.Name = "moviecb";
            moviecb.ShadowDecoration.CustomizableEdges = customizableEdges2;
            moviecb.Size = new Size(314, 36);
            moviecb.TabIndex = 193;
            // 
            // button1
            // 
            button1.BackColor = Color.Red;
            button1.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            button1.ForeColor = Color.White;
            button1.Location = new Point(13, 367);
            button1.Name = "button1";
            button1.Size = new Size(79, 32);
            button1.TabIndex = 191;
            button1.Text = "Xóa";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // pricetb
            // 
            pricetb.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            pricetb.Location = new Point(618, 142);
            pricetb.Multiline = true;
            pricetb.Name = "pricetb";
            pricetb.Size = new Size(174, 32);
            pricetb.TabIndex = 190;
            // 
            // guna2HtmlLabel5
            // 
            guna2HtmlLabel5.BackColor = Color.Transparent;
            guna2HtmlLabel5.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            guna2HtmlLabel5.Location = new Point(544, 147);
            guna2HtmlLabel5.Name = "guna2HtmlLabel5";
            guna2HtmlLabel5.Size = new Size(55, 27);
            guna2HtmlLabel5.TabIndex = 189;
            guna2HtmlLabel5.Text = "Giá vé";
            // 
            // StartTime
            // 
            StartTime.BorderRadius = 5;
            StartTime.Checked = true;
            StartTime.CustomizableEdges = customizableEdges3;
            StartTime.FillColor = Color.RoyalBlue;
            StartTime.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            StartTime.ForeColor = Color.White;
            StartTime.Format = DateTimePickerFormat.Custom;
            StartTime.Location = new Point(618, 39);
            StartTime.Margin = new Padding(0);
            StartTime.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            StartTime.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            StartTime.Name = "StartTime";
            StartTime.ShadowDecoration.CustomizableEdges = customizableEdges4;
            StartTime.Size = new Size(174, 35);
            StartTime.TabIndex = 188;
            StartTime.Value = new DateTime(2024, 5, 6, 8, 4, 35, 291);
            // 
            // guna2HtmlLabel4
            // 
            guna2HtmlLabel4.BackColor = Color.Transparent;
            guna2HtmlLabel4.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            guna2HtmlLabel4.Location = new Point(501, 44);
            guna2HtmlLabel4.Name = "guna2HtmlLabel4";
            guna2HtmlLabel4.Size = new Size(98, 27);
            guna2HtmlLabel4.TabIndex = 187;
            guna2HtmlLabel4.Text = "Ngày chiếu";
            // 
            // roomcb
            // 
            roomcb.BackColor = Color.Transparent;
            roomcb.CustomizableEdges = customizableEdges5;
            roomcb.DrawMode = DrawMode.OwnerDrawFixed;
            roomcb.DropDownStyle = ComboBoxStyle.DropDownList;
            roomcb.FocusedColor = Color.FromArgb(94, 148, 255);
            roomcb.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            roomcb.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            roomcb.ForeColor = Color.FromArgb(68, 88, 112);
            roomcb.ItemHeight = 30;
            roomcb.Location = new Point(125, 147);
            roomcb.Name = "roomcb";
            roomcb.ShadowDecoration.CustomizableEdges = customizableEdges6;
            roomcb.Size = new Size(317, 36);
            roomcb.TabIndex = 186;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.CornflowerBlue;
            btnSave.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(713, 367);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(79, 32);
            btnSave.TabIndex = 185;
            btnSave.Text = "Lưu";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click_1;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Red;
            btnCancel.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(628, 367);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(79, 32);
            btnCancel.TabIndex = 184;
            btnCancel.Text = "Hủy";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // stname
            // 
            stname.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            stname.Location = new Point(125, 93);
            stname.Multiline = true;
            stname.Name = "stname";
            stname.Size = new Size(317, 32);
            stname.TabIndex = 183;
            // 
            // guna2HtmlLabel3
            // 
            guna2HtmlLabel3.BackColor = Color.Transparent;
            guna2HtmlLabel3.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            guna2HtmlLabel3.Location = new Point(13, 156);
            guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            guna2HtmlLabel3.Size = new Size(58, 27);
            guna2HtmlLabel3.TabIndex = 182;
            guna2HtmlLabel3.Text = "Phòng";
            // 
            // guna2HtmlLabel2
            // 
            guna2HtmlLabel2.BackColor = Color.Transparent;
            guna2HtmlLabel2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            guna2HtmlLabel2.Location = new Point(13, 46);
            guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            guna2HtmlLabel2.Size = new Size(82, 27);
            guna2HtmlLabel2.TabIndex = 180;
            guna2HtmlLabel2.Text = "Tên phim";
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            guna2HtmlLabel1.Location = new Point(13, 98);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(91, 27);
            guna2HtmlLabel1.TabIndex = 181;
            guna2HtmlLabel1.Text = "Suất chiếu";
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.Black;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Location = new Point(-2, 29);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(805, 4);
            textBox1.TabIndex = 179;
            // 
            // lbClose
            // 
            lbClose.AutoSize = true;
            lbClose.BackColor = Color.White;
            lbClose.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lbClose.ForeColor = Color.Black;
            lbClose.Location = new Point(777, 1);
            lbClose.Name = "lbClose";
            lbClose.Size = new Size(26, 32);
            lbClose.TabIndex = 178;
            lbClose.Text = "x";
            lbClose.Click += lbClose_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.White;
            label1.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(3, 1);
            label1.Name = "label1";
            label1.Size = new Size(281, 32);
            label1.TabIndex = 177;
            label1.Text = "Sửa thông tin suất chiếu";
            // 
            // EditShowtime
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 400);
            Controls.Add(moviecb);
            Controls.Add(button1);
            Controls.Add(pricetb);
            Controls.Add(guna2HtmlLabel5);
            Controls.Add(StartTime);
            Controls.Add(guna2HtmlLabel4);
            Controls.Add(roomcb);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Controls.Add(stname);
            Controls.Add(guna2HtmlLabel3);
            Controls.Add(guna2HtmlLabel2);
            Controls.Add(guna2HtmlLabel1);
            Controls.Add(textBox1);
            Controls.Add(lbClose);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "EditShowtime";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EditShowtime";
            Load += EditShowtime_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2ComboBox moviecb;
        private Button button1;
        private TextBox pricetb;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel5;
        private Guna.UI2.WinForms.Guna2DateTimePicker StartTime;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel4;
        private Guna.UI2.WinForms.Guna2ComboBox roomcb;
        private Button btnSave;
        private Button btnCancel;
        private TextBox stname;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private TextBox textBox1;
        private Label lbClose;
        private Label label1;
    }
}