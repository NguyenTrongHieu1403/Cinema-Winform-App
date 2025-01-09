namespace Main
{
    partial class FormSanPham
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
            panel1 = new Panel();
            btnDoUong = new Button();
            btnDoAn = new Button();
            btnTatCa = new Button();
            panelSanPham = new Panel();
            panel3 = new Panel();
            panel2 = new Panel();
            btnMua = new Button();
            panelHienThiSP = new Panel();
            lblThanhTien = new TextBox();
            label1 = new Label();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.PowderBlue;
            panel1.Controls.Add(btnDoUong);
            panel1.Controls.Add(btnDoAn);
            panel1.Controls.Add(btnTatCa);
            panel1.Controls.Add(panelSanPham);
            panel1.Location = new Point(1, 1);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(728, 601);
            panel1.TabIndex = 0;
            // 
            // btnDoUong
            // 
            btnDoUong.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            btnDoUong.Location = new Point(467, 10);
            btnDoUong.Margin = new Padding(3, 2, 3, 2);
            btnDoUong.Name = "btnDoUong";
            btnDoUong.Size = new Size(250, 38);
            btnDoUong.TabIndex = 3;
            btnDoUong.Text = "Đồ Uống";
            btnDoUong.UseVisualStyleBackColor = true;
            btnDoUong.Click += btnDoUong_Click;
            // 
            // btnDoAn
            // 
            btnDoAn.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            btnDoAn.Location = new Point(226, 10);
            btnDoAn.Margin = new Padding(3, 2, 3, 2);
            btnDoAn.Name = "btnDoAn";
            btnDoAn.Size = new Size(249, 38);
            btnDoAn.TabIndex = 2;
            btnDoAn.Text = "Đồ Ăn";
            btnDoAn.UseVisualStyleBackColor = true;
            btnDoAn.Click += btnDoAn_Click;
            // 
            // btnTatCa
            // 
            btnTatCa.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            btnTatCa.Location = new Point(11, 10);
            btnTatCa.Margin = new Padding(3, 2, 3, 2);
            btnTatCa.Name = "btnTatCa";
            btnTatCa.Size = new Size(220, 38);
            btnTatCa.TabIndex = 1;
            btnTatCa.Text = "Tất Cả";
            btnTatCa.UseVisualStyleBackColor = true;
            btnTatCa.Click += button1_Click;
            // 
            // panelSanPham
            // 
            panelSanPham.AutoScroll = true;
            panelSanPham.BackColor = Color.White;
            panelSanPham.Location = new Point(11, 48);
            panelSanPham.Margin = new Padding(3, 2, 3, 2);
            panelSanPham.Name = "panelSanPham";
            panelSanPham.Size = new Size(706, 541);
            panelSanPham.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.BackColor = Color.PowderBlue;
            panel3.Controls.Add(panel2);
            panel3.Location = new Point(724, 1);
            panel3.Margin = new Padding(3, 2, 3, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(321, 601);
            panel3.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.BorderStyle = BorderStyle.Fixed3D;
            panel2.Controls.Add(btnMua);
            panel2.Controls.Add(panelHienThiSP);
            panel2.Controls.Add(lblThanhTien);
            panel2.Controls.Add(label1);
            panel2.Location = new Point(3, 44);
            panel2.Name = "panel2";
            panel2.Size = new Size(305, 545);
            panel2.TabIndex = 2;
            // 
            // btnMua
            // 
            btnMua.BackColor = Color.PowderBlue;
            btnMua.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnMua.Location = new Point(195, 499);
            btnMua.Margin = new Padding(3, 2, 3, 2);
            btnMua.Name = "btnMua";
            btnMua.Size = new Size(98, 40);
            btnMua.TabIndex = 0;
            btnMua.Text = "Mua";
            btnMua.UseVisualStyleBackColor = false;
            btnMua.Click += button1_Click_1;
            // 
            // panelHienThiSP
            // 
            panelHienThiSP.AutoScroll = true;
            panelHienThiSP.BackColor = Color.White;
            panelHienThiSP.BorderStyle = BorderStyle.FixedSingle;
            panelHienThiSP.Location = new Point(-2, 2);
            panelHienThiSP.Margin = new Padding(3, 2, 3, 2);
            panelHienThiSP.Name = "panelHienThiSP";
            panelHienThiSP.Size = new Size(305, 467);
            panelHienThiSP.TabIndex = 1;
            // 
            // lblThanhTien
            // 
            lblThanhTien.BorderStyle = BorderStyle.None;
            lblThanhTien.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblThanhTien.Location = new Point(132, 474);
            lblThanhTien.Name = "lblThanhTien";
            lblThanhTien.RightToLeft = RightToLeft.Yes;
            lblThanhTien.Size = new Size(161, 20);
            lblThanhTien.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(3, 473);
            label1.Name = "label1";
            label1.Size = new Size(103, 21);
            label1.TabIndex = 1;
            label1.Text = "Thành Tiền: ";
            // 
            // FormSanPham
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(1044, 600);
            Controls.Add(panel3);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "FormSanPham";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormSanPham";
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnDoUong;
        private Button btnDoAn;
        private Button btnTatCa;
        private Panel panel3;
        private Button btnMua;
        private Panel panelHienThiSP;
        private Panel panel2;
        private Panel panelSanPham;
        private Label label1;
        private TextBox lblThanhTien;
    }
}