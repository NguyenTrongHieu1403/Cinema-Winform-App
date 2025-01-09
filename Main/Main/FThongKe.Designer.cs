namespace Main
{
    partial class FThongKe
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
            cboThang = new Guna.UI2.WinForms.Guna2ComboBox();
            cboNam = new Guna.UI2.WinForms.Guna2ComboBox();
            panel1 = new Panel();
            lblBanSP = new Label();
            lblBanVe = new Label();
            guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel5 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel4 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            panel2 = new Panel();
            lblNhapSP = new Label();
            lblSuaChua = new Label();
            guna2HtmlLabel6 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel7 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            panel3 = new Panel();
            lblChiTra = new Label();
            lblDoanhThu = new Label();
            guna2HtmlLabel10 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel9 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel8 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            panel4 = new Panel();
            lblThang = new Label();
            lblNam = new Label();
            lblHoaDon = new Label();
            lblLoiNhuan = new Label();
            guna2HtmlLabel11 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel12 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel13 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel14 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            panel5 = new Panel();
            chartDoanhThu = new LiveCharts.WinForms.CartesianChart();
            btnBaocao = new Guna.UI2.WinForms.Guna2Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // cboThang
            // 
            cboThang.BackColor = Color.Transparent;
            cboThang.CustomizableEdges = customizableEdges1;
            cboThang.DrawMode = DrawMode.OwnerDrawFixed;
            cboThang.DropDownStyle = ComboBoxStyle.DropDownList;
            cboThang.FocusedColor = Color.FromArgb(94, 148, 255);
            cboThang.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cboThang.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            cboThang.ForeColor = Color.FromArgb(68, 88, 112);
            cboThang.ItemHeight = 30;
            cboThang.Location = new Point(10, 52);
            cboThang.Margin = new Padding(3, 2, 3, 2);
            cboThang.Name = "cboThang";
            cboThang.ShadowDecoration.CustomizableEdges = customizableEdges2;
            cboThang.Size = new Size(154, 36);
            cboThang.TabIndex = 3;
            cboThang.SelectedIndexChanged += cboThangNam_SelectedIndexChanged;
            // 
            // cboNam
            // 
            cboNam.BackColor = Color.Transparent;
            cboNam.CustomizableEdges = customizableEdges3;
            cboNam.DrawMode = DrawMode.OwnerDrawFixed;
            cboNam.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNam.FocusedColor = Color.FromArgb(94, 148, 255);
            cboNam.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cboNam.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            cboNam.ForeColor = Color.FromArgb(68, 88, 112);
            cboNam.ItemHeight = 30;
            cboNam.Location = new Point(242, 52);
            cboNam.Margin = new Padding(3, 2, 3, 2);
            cboNam.Name = "cboNam";
            cboNam.ShadowDecoration.CustomizableEdges = customizableEdges4;
            cboNam.Size = new Size(154, 36);
            cboNam.TabIndex = 4;
            cboNam.SelectedIndexChanged += cboThangNam_SelectedIndexChanged;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(lblBanSP);
            panel1.Controls.Add(lblBanVe);
            panel1.Controls.Add(guna2HtmlLabel2);
            panel1.Controls.Add(guna2HtmlLabel5);
            panel1.Controls.Add(guna2HtmlLabel4);
            panel1.Controls.Add(guna2HtmlLabel1);
            panel1.Location = new Point(10, 91);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(227, 105);
            panel1.TabIndex = 5;
            // 
            // lblBanSP
            // 
            lblBanSP.AutoSize = true;
            lblBanSP.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblBanSP.ForeColor = Color.Blue;
            lblBanSP.Location = new Point(155, 62);
            lblBanSP.Name = "lblBanSP";
            lblBanSP.Size = new Size(19, 21);
            lblBanSP.TabIndex = 6;
            lblBanSP.Text = "0";
            // 
            // lblBanVe
            // 
            lblBanVe.AutoSize = true;
            lblBanVe.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblBanVe.ForeColor = Color.Blue;
            lblBanVe.Location = new Point(10, 62);
            lblBanVe.Name = "lblBanVe";
            lblBanVe.Size = new Size(19, 21);
            lblBanVe.TabIndex = 5;
            lblBanVe.Text = "0";
            // 
            // guna2HtmlLabel2
            // 
            guna2HtmlLabel2.BackColor = Color.Transparent;
            guna2HtmlLabel2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            guna2HtmlLabel2.Location = new Point(10, 2);
            guna2HtmlLabel2.Margin = new Padding(3, 2, 3, 2);
            guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            guna2HtmlLabel2.Size = new Size(60, 23);
            guna2HtmlLabel2.TabIndex = 4;
            guna2HtmlLabel2.Text = "Income";
            // 
            // guna2HtmlLabel5
            // 
            guna2HtmlLabel5.BackColor = Color.Transparent;
            guna2HtmlLabel5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            guna2HtmlLabel5.Location = new Point(155, 29);
            guna2HtmlLabel5.Margin = new Padding(3, 2, 3, 2);
            guna2HtmlLabel5.Name = "guna2HtmlLabel5";
            guna2HtmlLabel5.Size = new Size(51, 23);
            guna2HtmlLabel5.TabIndex = 3;
            guna2HtmlLabel5.Text = "Goods";
            // 
            // guna2HtmlLabel4
            // 
            guna2HtmlLabel4.BackColor = Color.Transparent;
            guna2HtmlLabel4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            guna2HtmlLabel4.Location = new Point(10, 29);
            guna2HtmlLabel4.Margin = new Padding(3, 2, 3, 2);
            guna2HtmlLabel4.Name = "guna2HtmlLabel4";
            guna2HtmlLabel4.Size = new Size(49, 23);
            guna2HtmlLabel4.TabIndex = 2;
            guna2HtmlLabel4.Text = "Ticket";
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Location = new Point(5, 4);
            guna2HtmlLabel1.Margin = new Padding(3, 2, 3, 2);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(3, 2);
            guna2HtmlLabel1.TabIndex = 0;
            guna2HtmlLabel1.Text = null;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(lblNhapSP);
            panel2.Controls.Add(lblSuaChua);
            panel2.Controls.Add(guna2HtmlLabel6);
            panel2.Controls.Add(guna2HtmlLabel7);
            panel2.Controls.Add(guna2HtmlLabel3);
            panel2.Location = new Point(242, 91);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(231, 105);
            panel2.TabIndex = 6;
            // 
            // lblNhapSP
            // 
            lblNhapSP.AutoSize = true;
            lblNhapSP.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblNhapSP.ForeColor = Color.Red;
            lblNhapSP.Location = new Point(9, 62);
            lblNhapSP.Name = "lblNhapSP";
            lblNhapSP.Size = new Size(19, 21);
            lblNhapSP.TabIndex = 7;
            lblNhapSP.Text = "0";
            // 
            // lblSuaChua
            // 
            lblSuaChua.AutoSize = true;
            lblSuaChua.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblSuaChua.ForeColor = Color.Red;
            lblSuaChua.Location = new Point(150, 62);
            lblSuaChua.Name = "lblSuaChua";
            lblSuaChua.Size = new Size(19, 21);
            lblSuaChua.TabIndex = 8;
            lblSuaChua.Text = "0";
            // 
            // guna2HtmlLabel6
            // 
            guna2HtmlLabel6.BackColor = Color.Transparent;
            guna2HtmlLabel6.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            guna2HtmlLabel6.Location = new Point(11, 32);
            guna2HtmlLabel6.Margin = new Padding(3, 2, 3, 2);
            guna2HtmlLabel6.Name = "guna2HtmlLabel6";
            guna2HtmlLabel6.Size = new Size(51, 23);
            guna2HtmlLabel6.TabIndex = 4;
            guna2HtmlLabel6.Text = "Goods";
            // 
            // guna2HtmlLabel7
            // 
            guna2HtmlLabel7.BackColor = Color.Transparent;
            guna2HtmlLabel7.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            guna2HtmlLabel7.Location = new Point(150, 29);
            guna2HtmlLabel7.Margin = new Padding(3, 2, 3, 2);
            guna2HtmlLabel7.Name = "guna2HtmlLabel7";
            guna2HtmlLabel7.Size = new Size(52, 23);
            guna2HtmlLabel7.TabIndex = 5;
            guna2HtmlLabel7.Text = "Repair";
            // 
            // guna2HtmlLabel3
            // 
            guna2HtmlLabel3.BackColor = Color.Transparent;
            guna2HtmlLabel3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            guna2HtmlLabel3.Location = new Point(11, 4);
            guna2HtmlLabel3.Margin = new Padding(3, 2, 3, 2);
            guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            guna2HtmlLabel3.Size = new Size(31, 23);
            guna2HtmlLabel3.TabIndex = 2;
            guna2HtmlLabel3.Text = "Pay";
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(lblChiTra);
            panel3.Controls.Add(lblDoanhThu);
            panel3.Controls.Add(guna2HtmlLabel10);
            panel3.Controls.Add(guna2HtmlLabel9);
            panel3.Controls.Add(guna2HtmlLabel8);
            panel3.Location = new Point(10, 200);
            panel3.Margin = new Padding(3, 2, 3, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(463, 161);
            panel3.TabIndex = 6;
            // 
            // lblChiTra
            // 
            lblChiTra.AutoSize = true;
            lblChiTra.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblChiTra.ForeColor = Color.Red;
            lblChiTra.Location = new Point(134, 112);
            lblChiTra.Name = "lblChiTra";
            lblChiTra.Size = new Size(19, 21);
            lblChiTra.TabIndex = 8;
            lblChiTra.Text = "0";
            // 
            // lblDoanhThu
            // 
            lblDoanhThu.AutoSize = true;
            lblDoanhThu.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblDoanhThu.ForeColor = Color.Blue;
            lblDoanhThu.Location = new Point(134, 61);
            lblDoanhThu.Name = "lblDoanhThu";
            lblDoanhThu.Size = new Size(19, 21);
            lblDoanhThu.TabIndex = 7;
            lblDoanhThu.Text = "0";
            // 
            // guna2HtmlLabel10
            // 
            guna2HtmlLabel10.BackColor = Color.Transparent;
            guna2HtmlLabel10.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            guna2HtmlLabel10.Location = new Point(10, 110);
            guna2HtmlLabel10.Margin = new Padding(3, 2, 3, 2);
            guna2HtmlLabel10.Name = "guna2HtmlLabel10";
            guna2HtmlLabel10.Size = new Size(31, 23);
            guna2HtmlLabel10.TabIndex = 6;
            guna2HtmlLabel10.Text = "Pay";
            // 
            // guna2HtmlLabel9
            // 
            guna2HtmlLabel9.BackColor = Color.Transparent;
            guna2HtmlLabel9.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            guna2HtmlLabel9.Location = new Point(10, 59);
            guna2HtmlLabel9.Margin = new Padding(3, 2, 3, 2);
            guna2HtmlLabel9.Name = "guna2HtmlLabel9";
            guna2HtmlLabel9.Size = new Size(60, 23);
            guna2HtmlLabel9.TabIndex = 5;
            guna2HtmlLabel9.Text = "Income";
            // 
            // guna2HtmlLabel8
            // 
            guna2HtmlLabel8.BackColor = Color.Transparent;
            guna2HtmlLabel8.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            guna2HtmlLabel8.Location = new Point(10, 9);
            guna2HtmlLabel8.Margin = new Padding(3, 2, 3, 2);
            guna2HtmlLabel8.Name = "guna2HtmlLabel8";
            guna2HtmlLabel8.Size = new Size(42, 23);
            guna2HtmlLabel8.TabIndex = 4;
            guna2HtmlLabel8.Text = "Total";
            // 
            // panel4
            // 
            panel4.BackColor = Color.White;
            panel4.Controls.Add(lblThang);
            panel4.Controls.Add(lblNam);
            panel4.Controls.Add(lblHoaDon);
            panel4.Controls.Add(lblLoiNhuan);
            panel4.Controls.Add(guna2HtmlLabel11);
            panel4.Controls.Add(guna2HtmlLabel12);
            panel4.Controls.Add(guna2HtmlLabel13);
            panel4.Controls.Add(guna2HtmlLabel14);
            panel4.Location = new Point(10, 366);
            panel4.Margin = new Padding(3, 2, 3, 2);
            panel4.Name = "panel4";
            panel4.Size = new Size(463, 190);
            panel4.TabIndex = 7;
            // 
            // lblThang
            // 
            lblThang.AutoSize = true;
            lblThang.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblThang.Location = new Point(121, 19);
            lblThang.Name = "lblThang";
            lblThang.Size = new Size(56, 21);
            lblThang.TabIndex = 9;
            lblThang.Text = "Month";
            // 
            // lblNam
            // 
            lblNam.AutoSize = true;
            lblNam.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblNam.Location = new Point(121, 57);
            lblNam.Name = "lblNam";
            lblNam.Size = new Size(40, 21);
            lblNam.TabIndex = 10;
            lblNam.Text = "Year";
            // 
            // lblHoaDon
            // 
            lblHoaDon.AutoSize = true;
            lblHoaDon.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblHoaDon.ForeColor = Color.Blue;
            lblHoaDon.Location = new Point(121, 99);
            lblHoaDon.Name = "lblHoaDon";
            lblHoaDon.Size = new Size(19, 21);
            lblHoaDon.TabIndex = 11;
            lblHoaDon.Text = "0";
            // 
            // lblLoiNhuan
            // 
            lblLoiNhuan.AutoSize = true;
            lblLoiNhuan.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblLoiNhuan.ForeColor = Color.Blue;
            lblLoiNhuan.Location = new Point(121, 134);
            lblLoiNhuan.Name = "lblLoiNhuan";
            lblLoiNhuan.Size = new Size(19, 21);
            lblLoiNhuan.TabIndex = 12;
            lblLoiNhuan.Text = "0";
            // 
            // guna2HtmlLabel11
            // 
            guna2HtmlLabel11.BackColor = Color.Transparent;
            guna2HtmlLabel11.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            guna2HtmlLabel11.Location = new Point(10, 19);
            guna2HtmlLabel11.Margin = new Padding(3, 2, 3, 2);
            guna2HtmlLabel11.Name = "guna2HtmlLabel11";
            guna2HtmlLabel11.Size = new Size(54, 23);
            guna2HtmlLabel11.TabIndex = 7;
            guna2HtmlLabel11.Text = "Month";
            // 
            // guna2HtmlLabel12
            // 
            guna2HtmlLabel12.BackColor = Color.Transparent;
            guna2HtmlLabel12.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            guna2HtmlLabel12.Location = new Point(10, 56);
            guna2HtmlLabel12.Margin = new Padding(3, 2, 3, 2);
            guna2HtmlLabel12.Name = "guna2HtmlLabel12";
            guna2HtmlLabel12.Size = new Size(37, 23);
            guna2HtmlLabel12.TabIndex = 8;
            guna2HtmlLabel12.Text = "Year";
            // 
            // guna2HtmlLabel13
            // 
            guna2HtmlLabel13.BackColor = Color.Transparent;
            guna2HtmlLabel13.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            guna2HtmlLabel13.Location = new Point(10, 98);
            guna2HtmlLabel13.Margin = new Padding(3, 2, 3, 2);
            guna2HtmlLabel13.Name = "guna2HtmlLabel13";
            guna2HtmlLabel13.Size = new Size(28, 23);
            guna2HtmlLabel13.TabIndex = 9;
            guna2HtmlLabel13.Text = "Bill";
            // 
            // guna2HtmlLabel14
            // 
            guna2HtmlLabel14.BackColor = Color.Transparent;
            guna2HtmlLabel14.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            guna2HtmlLabel14.Location = new Point(10, 134);
            guna2HtmlLabel14.Margin = new Padding(3, 2, 3, 2);
            guna2HtmlLabel14.Name = "guna2HtmlLabel14";
            guna2HtmlLabel14.Size = new Size(46, 23);
            guna2HtmlLabel14.TabIndex = 10;
            guna2HtmlLabel14.Text = "Profit";
            // 
            // panel5
            // 
            panel5.BackColor = Color.White;
            panel5.Controls.Add(chartDoanhThu);
            panel5.Location = new Point(479, 91);
            panel5.Margin = new Padding(3, 2, 3, 2);
            panel5.Name = "panel5";
            panel5.Size = new Size(555, 465);
            panel5.TabIndex = 8;
            // 
            // chartDoanhThu
            // 
            chartDoanhThu.Location = new Point(17, 16);
            chartDoanhThu.Margin = new Padding(3, 2, 3, 2);
            chartDoanhThu.Name = "chartDoanhThu";
            chartDoanhThu.Size = new Size(522, 440);
            chartDoanhThu.TabIndex = 0;
            chartDoanhThu.Text = "cartesianChart1";
            // 
            // btnBaocao
            // 
            btnBaocao.BorderRadius = 10;
            btnBaocao.CustomizableEdges = customizableEdges5;
            btnBaocao.DisabledState.BorderColor = Color.DarkGray;
            btnBaocao.DisabledState.CustomBorderColor = Color.DarkGray;
            btnBaocao.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnBaocao.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnBaocao.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnBaocao.ForeColor = Color.White;
            btnBaocao.Location = new Point(879, 40);
            btnBaocao.Margin = new Padding(3, 2, 3, 2);
            btnBaocao.Name = "btnBaocao";
            btnBaocao.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnBaocao.Size = new Size(154, 29);
            btnBaocao.TabIndex = 9;
            btnBaocao.Text = "Report";
            btnBaocao.Click += btnBaocao_Click;
            // 
            // FThongKe
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            ClientSize = new Size(1044, 565);
            Controls.Add(btnBaocao);
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(cboNam);
            Controls.Add(cboThang);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "FThongKe";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FThongKe";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Guna.UI2.WinForms.Guna2ComboBox cboThang;
        private Guna.UI2.WinForms.Guna2ComboBox cboNam;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel6;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel5;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel4;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Panel panel4;
        private Panel panel5;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel7;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel10;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel9;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel8;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel11;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel12;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel13;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel14;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private LiveCharts.WinForms.CartesianChart chartDoanhThu;
        private Label lblBanSP;
        private Label lblBanVe;
        private Label lblNhapSP;
        private Label lblSuaChua;
        private Label lblChiTra;
        private Label lblDoanhThu;
        private Label lblThang;
        private Label lblNam;
        private Label lblHoaDon;
        private Label lblLoiNhuan;
        private Guna.UI2.WinForms.Guna2Button btnBaocao;
    }
}