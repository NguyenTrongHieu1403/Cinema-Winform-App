using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Main.FormLogin;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Main
{
    public partial class Fhome : Form
    {
        private int currentId = 1;

        public Fhome()
        {
            InitializeComponent();
        }

        private void Fhome_Load(object sender, EventArgs e)
        {
            LoadData(); // Load dữ liệu ban đầu khi form được mở
        }

        private void LoadData()
        {
            // Xây dựng câu truy vấn SQL để lấy dữ liệu từ bảng Movies, bắt đầu từ id_Movie hiện tại
            string query = $"SELECT TOP 4 DisplayName, RunningTime, ReleaseYear, id_Movie, Age, Image FROM Movie WHERE id_Movie >= {currentId} ORDER BY id_Movie ASC";

            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Duyệt qua từng panel
                        for (int i = 2; i <= 5; i++)
                        {
                            if (reader.Read())
                            {
                                // Tìm các label trong panel tương ứng
                                Label displayNameLabel = null;
                                Label runningTimeLabel = null;
                                Label releaseYearLabel = null;
                                Label idMovieLabel = null;
                                Label lbAge = null;
                                PictureBox pictureBox = null;

                                switch (i)
                                {
                                    case 2:
                                        displayNameLabel = Controls.Find("label1", true).FirstOrDefault() as Label;
                                        runningTimeLabel = Controls.Find("label2", true).FirstOrDefault() as Label;
                                        releaseYearLabel = Controls.Find("label3", true).FirstOrDefault() as Label;
                                        idMovieLabel = Controls.Find("label4", true).FirstOrDefault() as Label;
                                        lbAge = Controls.Find("lbAge1", true).FirstOrDefault() as Label;
                                        pictureBox = pictureBox2;
                                        break;
                                    case 3:
                                        displayNameLabel = Controls.Find("label6", true).FirstOrDefault() as Label;
                                        runningTimeLabel = Controls.Find("label7", true).FirstOrDefault() as Label;
                                        releaseYearLabel = Controls.Find("label8", true).FirstOrDefault() as Label;
                                        idMovieLabel = Controls.Find("label9", true).FirstOrDefault() as Label;
                                        lbAge = Controls.Find("lbAge2", true).FirstOrDefault() as Label;
                                        pictureBox = pictureBox3;
                                        break;
                                    case 4:
                                        displayNameLabel = Controls.Find("label10", true).FirstOrDefault() as Label;
                                        runningTimeLabel = Controls.Find("label11", true).FirstOrDefault() as Label;
                                        releaseYearLabel = Controls.Find("label12", true).FirstOrDefault() as Label;
                                        idMovieLabel = Controls.Find("label13", true).FirstOrDefault() as Label;
                                        lbAge = Controls.Find("lbAge3", true).FirstOrDefault() as Label;
                                        pictureBox = pictureBox4;
                                        break;
                                    case 5:
                                        displayNameLabel = Controls.Find("label14", true).FirstOrDefault() as Label;
                                        runningTimeLabel = Controls.Find("label15", true).FirstOrDefault() as Label;
                                        releaseYearLabel = Controls.Find("label16", true).FirstOrDefault() as Label;
                                        idMovieLabel = Controls.Find("label18", true).FirstOrDefault() as Label;
                                        lbAge = Controls.Find("lbAge4", true).FirstOrDefault() as Label;
                                        pictureBox = pictureBox5;
                                        break;
                                    default:
                                        break;
                                }

                                if (displayNameLabel != null && runningTimeLabel != null && releaseYearLabel != null && idMovieLabel != null && lbAge != null && pictureBox != null)
                                {
                                    // Gán dữ liệu từ SqlDataReader vào các label tương ứng
                                    displayNameLabel.Text = reader["DisplayName"].ToString();
                                    runningTimeLabel.Text = reader["RunningTime"].ToString() + " Phút";
                                    releaseYearLabel.Text = "Năm " + reader["ReleaseYear"].ToString();
                                    idMovieLabel.Text = reader["id_Movie"].ToString();
                                    string age = reader["Age"].ToString();
                                    lbAge.Text = age;

                                    // Thiết lập màu sắc cho lbAge dựa trên giá trị của Age
                                    switch (age)
                                    {
                                        case "13+":
                                            lbAge.BackColor = Color.LightGreen;
                                            break;
                                        case "16+":
                                            lbAge.BackColor = Color.Orange;
                                            break;
                                        case "18+":
                                            lbAge.BackColor = Color.Red;
                                            break;
                                        default:
                                            lbAge.BackColor = Color.Transparent; // Mặc định
                                            break;
                                    }



                                    // Thiết lập hình ảnh cho pictureBox
                                    if (!reader.IsDBNull(reader.GetOrdinal("Image")))
                                    {
                                        string imagePath = reader["Image"].ToString(); // Đường dẫn của tập tin ảnh
                                        if (File.Exists(imagePath)) // Kiểm tra xem tập tin ảnh có tồn tại không
                                        {
                                            pictureBox.Image = Image.FromFile(imagePath); // Hiển thị ảnh trên PictureBox
                                        }
                                        else
                                        {
                                            MessageBox.Show("Không tìm thấy tập tin ảnh!");
                                        }
                                    }
                                }
                                else
                                {
                                    // Nếu không còn dữ liệu từ cơ sở dữ liệu, đặt các label trong panel không có dữ liệu thành chuỗi rỗng hoặc giá trị mặc định
                                    SetEmptyLabels(i);
                                }
                            }
                            else
                            {
                                SetEmptyLabels(i);
                            }
                        }
                    }
                }
            }
        }


        private void SetEmptyLabels(int panelIndex)
        {
            switch (panelIndex)
            {
                case 2:
                    SetLabelValues("label1", "label2", "label3", "label4", "lbAge1", "", "", "", "", "");
                    pictureBox2.Image = null;
                    break;
                case 3:
                    SetLabelValues("label6", "label7", "label8", "label9", "lbAge2", "", "", "", "", "");
                    pictureBox3.Image = null;
                    break;
                case 4:
                    SetLabelValues("label10", "label11", "label12", "label13", "lbAge3", "", "", "", "", "");
                    pictureBox4.Image = null;
                    break;
                case 5:
                    SetLabelValues("label14", "label15", "label16", "label18", "lbAge4", "", "", "", "", "");
                    pictureBox5.Image = null;
                    break;
                default:
                    break;
            }
        }


        private void SetLabelValues(string displayNameLabelName, string runningTimeLabelName, string releaseYearLabelName, string idMovieLabelName, string lbAgeName, string displayNameText, string runningTimeText, string releaseYearText, string idMovieText, string lbAgeText)
        {
            Label displayNameLabel = Controls.Find(displayNameLabelName, true).FirstOrDefault() as Label;
            Label runningTimeLabel = Controls.Find(runningTimeLabelName, true).FirstOrDefault() as Label;
            Label releaseYearLabel = Controls.Find(releaseYearLabelName, true).FirstOrDefault() as Label;
            Label idMovieLabel = Controls.Find(idMovieLabelName, true).FirstOrDefault() as Label;
            Label lbAge = Controls.Find(lbAgeName, true).FirstOrDefault() as Label;

            if (displayNameLabel != null && runningTimeLabel != null && releaseYearLabel != null && idMovieLabel != null && lbAge != null)
            {
                displayNameLabel.Text = displayNameText;
                runningTimeLabel.Text = runningTimeText;
                releaseYearLabel.Text = releaseYearText;
                idMovieLabel.Text = idMovieText;
                lbAge.Text = lbAgeText;
                lbAge.BackColor = Color.Transparent; // Mặc định
            }
        }




        private void CloseMenu_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thoát chương trình ? ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void MenuEditProfile_Click(object sender, EventArgs e)
        {
            EditProfile editprofile = new EditProfile();
            this.Hide();
            editprofile.ShowDialog();
            this.Show();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            currentId -= 4;
            LoadData();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            currentId += 4; // Tăng giá trị của currentId lên 4 để chuyển sang id_Movie tiếp theo
            LoadData(); // Tải dữ liệu mới
        }

        private void systemToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
