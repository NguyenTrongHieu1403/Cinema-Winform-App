namespace Main
{
    partial class MoviePanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.labelMovieName = new System.Windows.Forms.Label();
            this.labelStyle = new System.Windows.Forms.Label();
            this.labelYear = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(11, 10);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(191, 318);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.Click += new System.EventHandler(this.pictureBox_Click);
            this.pictureBox.MouseEnter += new System.EventHandler(this.pictureBox_MouseEnter);
            this.pictureBox.MouseLeave += new System.EventHandler(this.pictureBox_MouseLeave);
            // 
            // labelMovieName
            // 
            this.labelMovieName.AutoSize = true;
            this.labelMovieName.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelMovieName.ForeColor = System.Drawing.Color.White;
            this.labelMovieName.Location = new System.Drawing.Point(11, 330);
            this.labelMovieName.Name = "labelMovieName";
            this.labelMovieName.Size = new System.Drawing.Size(63, 25);
            this.labelMovieName.TabIndex = 1;
            this.labelMovieName.Text = "label1";
            this.labelMovieName.MouseEnter += new System.EventHandler(this.labelMovieName_MouseEnter);
            this.labelMovieName.MouseLeave += new System.EventHandler(this.labelMovieName_MouseLeave);
            // 
            // labelStyle
            // 
            this.labelStyle.AutoSize = true;
            this.labelStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelStyle.ForeColor = System.Drawing.Color.White;
            this.labelStyle.Location = new System.Drawing.Point(11, 355);
            this.labelStyle.Name = "labelStyle";
            this.labelStyle.Size = new System.Drawing.Size(54, 21);
            this.labelStyle.TabIndex = 2;
            this.labelStyle.Text = "label2";
            this.labelStyle.MouseEnter += new System.EventHandler(this.labelStyle_MouseEnter);
            this.labelStyle.MouseLeave += new System.EventHandler(this.labelStyle_MouseLeave);
            // 
            // labelYear
            // 
            this.labelYear.AutoSize = true;
            this.labelYear.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelYear.ForeColor = System.Drawing.Color.White;
            this.labelYear.Location = new System.Drawing.Point(11, 376);
            this.labelYear.Name = "labelYear";
            this.labelYear.Size = new System.Drawing.Size(63, 25);
            this.labelYear.TabIndex = 3;
            this.labelYear.Text = "label3";
            this.labelYear.MouseEnter += new System.EventHandler(this.labelRating_MouseEnter);
            this.labelYear.MouseLeave += new System.EventHandler(this.labelRating_MouseLeave);
            // 
            // MoviePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.labelYear);
            this.Controls.Add(this.labelStyle);
            this.Controls.Add(this.labelMovieName);
            this.Controls.Add(this.pictureBox);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MoviePanel";
            this.Size = new System.Drawing.Size(212, 414);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pictureBox;
        private Label labelMovieName;
        private Label labelStyle;
        private Label labelYear;
    }
}
