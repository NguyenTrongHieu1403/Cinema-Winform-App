using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.WinForms;
using LiveCharts.Wpf;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace Main
{
    public partial class FThongKe : Form
    {
        public FThongKe()
        {
            InitializeComponent();

            // Add months (1-12) to cboThang
            for (int i = 1; i <= 12; i++)
            {
                cboThang.Items.Add(i);
            }

            // Add years (2022-2030) to cboNam
            for (int i = 2022; i <= 2030; i++)
            {
                cboNam.Items.Add(i);
            }
        }

        private void CalculateStatistics(int month, int year)
        {
            int totalTicketsSold = 0;
            int totalProductsSold = 0;
            decimal totalRevenue = 0;
            decimal totalExpenditure = 0;

            string query = @"
                SELECT COUNT(id) AS TotalTickets,
                       SUM(TotalPrice) AS TotalRevenue
                FROM Bill
                WHERE MONTH(CreatedAt) = @Month 
                    AND YEAR(CreatedAt) = @Year;

                SELECT SUM(pb.Quantity) AS TotalProductsSold
                FROM ProductBillInfo pb
                INNER JOIN Bill b ON pb.BillID = b.id
                WHERE MONTH(b.CreatedAt) = @Month 
                    AND YEAR(b.CreatedAt) = @Year;

                SELECT SUM(pr.ImportPrice * pr.Quantity) AS TotalExpenditure
                FROM ProductReceipt pr
                INNER JOIN Product p ON pr.ProductID = p.id
                WHERE MONTH(pr.CreatedAt) = @Month 
                    AND YEAR(pr.CreatedAt) = @Year;

                SELECT COUNT(id) AS TotalBills
                FROM Bill
                WHERE YEAR(CreatedAt) = @Year
                    AND MONTH(CreatedAt) = @Month;
            ";
            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Month", month);
                command.Parameters.AddWithValue("@Year", year);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        reader.Read();
                        totalTicketsSold = reader.IsDBNull(reader.GetOrdinal("TotalTickets")) ? 0 : reader.GetInt32(reader.GetOrdinal("TotalTickets"));
                        totalRevenue = reader.IsDBNull(reader.GetOrdinal("TotalRevenue")) ? 0 : reader.GetDecimal(reader.GetOrdinal("TotalRevenue"));
                    }

                    reader.NextResult();

                    if (reader.HasRows)
                    {
                        reader.Read();
                        totalProductsSold = reader.IsDBNull(reader.GetOrdinal("TotalProductsSold")) ? 0 : reader.GetInt32(reader.GetOrdinal("TotalProductsSold"));
                    }

                    reader.NextResult();

                    if (reader.HasRows)
                    {
                        reader.Read();
                        totalExpenditure = reader.IsDBNull(reader.GetOrdinal("TotalExpenditure")) ? 0 : reader.GetDecimal(reader.GetOrdinal("TotalExpenditure"));
                    }

                    reader.NextResult();

                    if (reader.HasRows)
                    {
                        reader.Read();
                        int totalBills = reader.IsDBNull(reader.GetOrdinal("TotalBills")) ? 0 : reader.GetInt32(reader.GetOrdinal("TotalBills"));
                        lblHoaDon.Text = totalBills.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }

            decimal netIncome = totalRevenue - totalExpenditure;

            lblBanVe.Text = totalTicketsSold.ToString();
            lblBanSP.Text = totalProductsSold.ToString();
            lblDoanhThu.Text = totalRevenue.ToString("C");
            lblChiTra.Text = totalExpenditure.ToString("C");
            lblNhapSP.Text = totalExpenditure.ToString("C");
            lblThang.Text = month.ToString();
            lblNam.Text = year.ToString();
            lblLoiNhuan.Text = netIncome.ToString("C");
            DisplayChart(month, year, totalRevenue, totalExpenditure);
        }

        private void DisplayChart(int month, int year, decimal totalRevenue, decimal totalExpenditure)
        {
            chartDoanhThu.Series.Clear();
            chartDoanhThu.AxisX.Clear();
            chartDoanhThu.AxisY.Clear();

            SeriesCollection series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Doanh thu",
                    Values = new ChartValues<decimal> { totalRevenue }
                },
                new ColumnSeries
                {
                    Title = "Chi phí",
                    Values = new ChartValues<decimal> { totalExpenditure }
                }
            };

            chartDoanhThu.Series = series;
            chartDoanhThu.AxisX.Add(new LiveCharts.Wpf.Axis
            {
                Title = $"Tháng {month}, Năm {year}",
                Labels = new[] { "Doanh thu", "Chi phí" }
            });
            chartDoanhThu.AxisY.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Số tiền",
                LabelFormatter = value => value.ToString("C")
            });
        }

        private void cboThangNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboThang.SelectedIndex != -1 && cboNam.SelectedIndex != -1)
            {
                int selectedMonth = (int)cboThang.SelectedItem;
                int selectedYear = (int)cboNam.SelectedItem;

                CalculateStatistics(selectedMonth, selectedYear);
            }
        }

        private void btnBaocao_Click(object sender, EventArgs e)
        {
            if (cboThang.SelectedIndex != -1 && cboNam.SelectedIndex != -1)
            {
                int selectedMonth = (int)cboThang.SelectedItem;
                int selectedYear = (int)cboNam.SelectedItem;

                // Calculate statistics to use in the report
                CalculateStatistics(selectedMonth, selectedYear);

                // Create the report
                CreateReport(selectedMonth, selectedYear);
            }
            else
            {
                MessageBox.Show("Please select both month and year.");
            }
        }

        // Create report revenue
        private void CreateReport(int month, int year)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Word Documents|*.docx";
                saveFileDialog.Title = "Save Report";
                saveFileDialog.FileName = $"Báo cáo tháng {month} năm {year}.docx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = saveFileDialog.FileName;

                    var doc = DocX.Create(fileName);

                    // Add title
                    string title = $"BÁO CÁO DOANH THU THÁNG {month} NĂM {year}";
                    var titleParagraph = doc.InsertParagraph(title)
                        .FontSize(16)
                        .Bold()
                        .Alignment = Alignment.center;

                    // Add a header
                    doc.AddHeaders();
                    doc.Headers.Odd.InsertParagraph("LOBBYMOVIE")
                        .FontSize(20)
                        .Bold()
                        .Alignment = Alignment.left;
                    doc.Headers.Odd.InsertParagraph("Nhân viên : Nguyễn Trung Tính")
                       .FontSize(14)
                       .Bold()
                       .Alignment = Alignment.right;
                    doc.Headers.Odd.InsertParagraph($"Ngày tạo {DateTime.Now}")
                      .FontSize(14)
                      .Bold()
                      .Alignment = Alignment.right;

                    // Add a footer
                    doc.AddFooters();
                    doc.Footers.Odd.InsertParagraph($"{DateTime.Now}")
                        .FontSize(10)
                        .Italic()
                        .Alignment = Alignment.left;

                    // Add details
                    var detailsTable = doc.AddTable(8, 2);
                    detailsTable.Design = TableDesign.LightShadingAccent1;

                    // Populate the table with data
                    detailsTable.Rows[0].Cells[0].Paragraphs[0].Append("Tháng").Bold();
                    detailsTable.Rows[0].Cells[1].Paragraphs[0].Append(month.ToString());

                    detailsTable.Rows[1].Cells[0].Paragraphs[0].Append("Năm").Bold();
                    detailsTable.Rows[1].Cells[1].Paragraphs[0].Append(year.ToString());

                    detailsTable.Rows[2].Cells[0].Paragraphs[0].Append("Tồng vé").Bold();
                    detailsTable.Rows[2].Cells[1].Paragraphs[0].Append(lblBanVe.Text);

                    detailsTable.Rows[3].Cells[0].Paragraphs[0].Append("Tổng sản phẩm").Bold();
                    detailsTable.Rows[3].Cells[1].Paragraphs[0].Append(lblBanSP.Text);

                    detailsTable.Rows[4].Cells[0].Paragraphs[0].Append("Tổng doanh thu").Bold();
                    detailsTable.Rows[4].Cells[1].Paragraphs[0].Append(lblDoanhThu.Text);

                    detailsTable.Rows[5].Cells[0].Paragraphs[0].Append("Chi trả").Bold();
                    detailsTable.Rows[5].Cells[1].Paragraphs[0].Append(lblChiTra.Text);

                    detailsTable.Rows[6].Cells[0].Paragraphs[0].Append("Lợi nhuận").Bold();
                    detailsTable.Rows[6].Cells[1].Paragraphs[0].Append(lblLoiNhuan.Text);

                    detailsTable.Rows[7].Cells[0].Paragraphs[0].Append("Sản phẩm").Bold();
                    detailsTable.Rows[7].Cells[1].Paragraphs[0].Append(lblNhapSP.Text);

                    doc.InsertTable(detailsTable);
                    doc.InsertParagraph(Environment.NewLine);

                    // Add a summary or conclusion
                    var summaryParagraph = doc.InsertParagraph("Tóm tắc")
                        .FontSize(16)
                        .Bold()
                        .SpacingAfter(10);

                    doc.InsertParagraph($"Báo cáo tháng {month} năm {year} cho thấy một hiệu suất mạnh mẽ trong doanh số bán vé và doanh số sản phẩm. " +
                        "Các khoản thu chi đã được quản lý một cách hiệu quả, dẫn đến lợi nhuận ròng khá tích cực. " +
                        "Chi phí sửa chữa cũng đã được ghi nhận và tính vào tổng chi phí.")
                        .FontSize(12)
                        .SpacingAfter(20);

                    // Save the document
                    try
                    {
                        doc.Save();
                        MessageBox.Show($"Xuất báo cáo tháng {month} năm {year} thành công !");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message);
                    }
                }
            }
        }

    }
}
