using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.Wpf;
using System.Linq;
using System.Data;

namespace Main
{
    public partial class FThongKeXuHuong : Form
    {
        public FThongKeXuHuong()
        {
            InitializeComponent();

            // Thêm tháng (1-12) vào cboThang
            for (int i = 1; i <= 12; i++)
            {
                cboThang.Items.Add(i);
            }

            // Thêm các năm (2022-2026) vào cboNam
            for (int i = 2022; i <= 2026; i++)
            {
                cboNam.Items.Add(i);
            }

            // Đăng ký sự kiện cho khi chỉ mục được chọn thay đổi
            cboThang.SelectedIndexChanged += cboThangNam_SelectedIndexChanged;
            cboNam.SelectedIndexChanged += cboThangNam_SelectedIndexChanged;

            // Hiển thị biểu đồ xu hướng cho tháng và năm được chọn ban đầu
            DisplayTrendCharts();
            
        }
        private void UpdateDataGridView1(int selectedMonth, int selectedYear)
        {
            DataTable dataTable = new DataTable();

            string query = @"
                SELECT TOP 3
                    M.DisplayName AS MovieName,
                    SUM(T.Price) AS TotalRevenue
                FROM 
                    Ticket T
                JOIN 
                    Bill B ON T.BillId = B.id
                JOIN 
                    Showtime S ON T.ShowtimeId = S.id
                JOIN 
                    Movie M ON S.MovieId = M.id
                JOIN 
                    ShowtimeSetting SS ON S.ShowtimeSettingId = SS.id
                WHERE 
                    MONTH(B.CreatedAt) = @Month
                    AND YEAR(B.CreatedAt) = @Year
                GROUP BY 
                    M.DisplayName
                ORDER BY 
                    SUM(T.Price) DESC;
            ";

            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Month", selectedMonth);
                command.Parameters.AddWithValue("@Year", selectedYear);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    dataTable.Load(reader);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }

            // Gán dữ liệu cho DataGridView1
            guna2DataGridView1.DataSource = dataTable;
        }

        private void UpdateDataGridView2(int selectedMonth, int selectedYear)
        {
            DataTable dataTable = new DataTable();

            string query = @"
                SELECT TOP 1 
                    Product_Name, 
                    SUM(pb.Quantity * p.Price) AS Revenue
                FROM 
                    ProductBillInfo pb
                INNER JOIN 
                    Product p ON pb.ProductID = p.id
                INNER JOIN 
                    Bill b ON pb.BillID = b.id
                WHERE 
                    MONTH(b.CreatedAt) = @Month
                    AND YEAR(b.CreatedAt) = @Year
                GROUP BY 
                    Product_Name
                ORDER BY 
                    Revenue DESC;
            ";

            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Month", selectedMonth);
                command.Parameters.AddWithValue("@Year", selectedYear);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    dataTable.Load(reader);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

            // Gán dữ liệu cho DataGridView2
            guna2DataGridView2.DataSource = dataTable;
        }


        private void DisplayTrendCharts()
        {
            if (cboThang.SelectedItem != null && cboNam.SelectedItem != null)
            {
                int selectedMonth = (int)cboThang.SelectedItem;
                int selectedYear = (int)cboNam.SelectedItem;

                DisplayMovieTrendChart(selectedMonth, selectedYear);
                DisplayProductTrendChart(selectedMonth, selectedYear);
                // datagridview
                UpdateDataGridView1(selectedMonth, selectedYear);
                UpdateDataGridView2(selectedMonth, selectedYear);
            }
        }

        private void DisplayMovieTrendChart(int selectedMonth, int selectedYear)
        {
            chartPhim.Series.Clear();
            chartPhim.AxisX.Clear();
            chartPhim.AxisY.Clear();

            string[] topMovies = new string[5];
            decimal[] revenueMovies = new decimal[5];

            string query = @"
     SELECT TOP 3
         M.DisplayName AS MovieName,
         SUM(T.Price) AS TotalRevenue
     FROM 
         Ticket T
     JOIN 
         Bill B ON T.BillId = B.id
     JOIN 
         Showtime S ON T.ShowtimeId = S.id
     JOIN 
         Movie M ON S.MovieId = M.id
     JOIN 
         ShowtimeSetting SS ON S.ShowtimeSettingId = SS.id
     WHERE 
         MONTH(B.CreatedAt) = @Month
         AND YEAR(B.CreatedAt) = @Year
     GROUP BY 
         M.DisplayName
     ORDER BY 
         SUM(T.Price) DESC;
 ";


            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Month", selectedMonth);
                command.Parameters.AddWithValue("@Year", selectedYear);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    int i = 0;
                    while (reader.Read() && i < 5)
                    {
                        topMovies[i] = reader["MovieName"].ToString();
                        revenueMovies[i] = reader.IsDBNull(reader.GetOrdinal("TotalRevenue")) ? 0 : reader.GetDecimal(reader.GetOrdinal("TotalRevenue"));
                        i++;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }

            SeriesCollection series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Doanh thu",
                    Values = new ChartValues<decimal>(revenueMovies)
                }
            };

            chartPhim.Series = series;
            chartPhim.AxisX.Add(new Axis
            {
                Title = "Phim",
                Labels = topMovies.Take(5).ToList() // Chỉ lấy 5 phim hàng đầu
            });
            chartPhim.AxisY.Add(new Axis
            {
                Title = "Doanh thu",
                LabelFormatter = value => value.ToString("C") // Định dạng tiền tệ
            });
        }


        private void DisplayProductTrendChart(int selectedMonth, int selectedYear)
        {

            chartSP.Series.Clear();
            chartSP.AxisX.Clear();
            chartSP.AxisY.Clear();

            string topProduct = "";
            decimal revenueProduct = 0;

            string query = @"
                SELECT TOP 1 Product_Name, SUM(pb.Quantity * p.Price) AS Revenue
                FROM ProductBillInfo pb
                INNER JOIN Product p ON pb.ProductID = p.id
                INNER JOIN Bill b ON pb.BillID = b.id
                WHERE MONTH(b.CreatedAt) = @Month
                    AND YEAR(b.CreatedAt) = @Year
                GROUP BY Product_Name
                ORDER BY Revenue DESC;
            ";

            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Month", selectedMonth);
                command.Parameters.AddWithValue("@Year", selectedYear);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        topProduct = reader["Product_Name"].ToString();
                        revenueProduct = reader.IsDBNull(reader.GetOrdinal("Revenue")) ? 0 : reader.GetDecimal(reader.GetOrdinal("Revenue"));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

            SeriesCollection series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Doanh thu",
                    Values = new ChartValues<decimal> { revenueProduct }
                }
            };

            chartSP.Series = series;
            chartSP.AxisX.Add(new Axis
            {
                Title = "Sản phẩm",
                Labels = new[] { topProduct }
            });
            chartSP.AxisY.Add(new Axis
            {
                Title = "Doanh thu",
                LabelFormatter = value => value.ToString("C") // Currency format
            });
        }

        private void cboThangNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayTrendCharts();
        }
    }
}
