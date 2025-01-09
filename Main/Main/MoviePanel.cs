using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main
{
    public partial class MoviePanel : System.Windows.Forms.UserControl
    {
        internal ParentForm.Movie Movie;

        public MoviePanel()
        {
            InitializeComponent();
        }

        public void RegisterPictureBoxClick(EventHandler handler)
        {
            pictureBox.Click += handler;
        }
        public void SetMovieImage(string imagePath)
        {
            if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
            {
                pictureBox.Image = Image.FromFile(imagePath);
            }
            else
            {
                pictureBox.Image = null;
            }
        }

        public void SetMovieName(string name)
        {
            labelMovieName.Text = name;
        }

        public void SetMovieStyle(string style)
        {
            labelStyle.Text = style;
        }

        public void SetMovieRating(int year)
        {
            labelYear.Text = year.ToString();
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
        }

        private void labelMovieName_MouseEnter(object sender, EventArgs e)
        {
            labelMovieName.ForeColor = Color.Cyan;
        }

        private void labelMovieName_MouseLeave(object sender, EventArgs e)
        {
            labelMovieName.ForeColor = Color.White;
        }

        private void labelStyle_MouseEnter(object sender, EventArgs e)
        {
            labelStyle.ForeColor = Color.Cyan;
        }

        private void labelStyle_MouseLeave(object sender, EventArgs e)
        {
            labelStyle.ForeColor= Color.White;
        }

        private void labelRating_MouseEnter(object sender, EventArgs e)
        {
            labelYear.ForeColor = Color.Cyan;
        }

        private void labelRating_MouseLeave(object sender, EventArgs e)
        {
            labelYear.ForeColor= Color.White;
        }

        private void pictureBox_MouseEnter(object sender, EventArgs e)
        {
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void pictureBox_MouseLeave(object sender, EventArgs e)
        {
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }
    }
}
