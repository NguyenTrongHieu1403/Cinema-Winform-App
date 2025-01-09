using OfficeOpenXml;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace Main
{
    public partial class FLichSu : Form
    {
        private DataTable originalDataTable; // DataTable lưu trữ dữ liệu gốc

        public FLichSu()
        {
            InitializeComponent();
            cbo1.Items.Add("Nhập Kho");
            cbo1.Items.Add("Hoá Đơn");
        }

        private void cbo1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Hiển thị dữ liệu tương ứng với lựa chọn trong cbo1
            if (cbo1.SelectedItem != null)
            {
                if (cbo1.SelectedItem.ToString() == "Nhập Kho")
                {
                    DisplayProductImportDetails();
                }
                else if (cbo1.SelectedItem.ToString() == "Hoá Đơn")
                {
                    DisplayBillDetails();
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            // Tìm kiếm thông tin dựa trên giá trị trong txtSearch
            if (cbo1.SelectedItem != null)
            {
                if (cbo1.SelectedItem.ToString() == "Nhập Kho")
                {
                    SearchProductImportDetails();
                }
                else if (cbo1.SelectedItem.ToString() == "Hoá Đơn")
                {
                    SearchBillDetails();
                }
            }
        }

        private void DisplayProductImportDetails()
        {
            string query = "SELECT p.Product_Name AS [Product Name], pr.ImportPrice AS [Import Price], pr.Quantity, pr.CreatedAt AS [Import Date], s.Name AS [Staff Name] " +
                           "FROM ProductReceipt pr " +
                           "INNER JOIN Product p ON pr.ProductId = p.id " +
                           "INNER JOIN Staff s ON pr.StaffId = s.StaffID"; // Sửa StaffId thành StaffID

            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                originalDataTable = new DataTable(); // Khởi tạo DataTable gốc
                adapter.Fill(originalDataTable);
                ShowDataInDataGridView(originalDataTable);
            }
        }

        private void DisplayBillDetails()
        {
            string query = "SELECT b.id AS [Bill ID], ISNULL(c.Name, 'Khách vãng lai') AS [Customer Name], s.Name AS [Staff Name], b.CreatedAt AS [Created At], b.TotalPrice " +
                           "FROM Bill b " +
                           "LEFT JOIN Customer c ON b.CustomerId = c.id " + // Sử dụng LEFT JOIN để bao gồm cả khi CustomerId là null
                           "INNER JOIN Staff s ON b.StaffId = s.StaffID"; // Sửa StaffId thành StaffID

            using (SqlConnection connection = Connection.GetSqlConnection())
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                originalDataTable = new DataTable(); // Khởi tạo DataTable gốc
                adapter.Fill(originalDataTable);
                ShowDataInDataGridView(originalDataTable);
            }
        }


        private void ShowDataInDataGridView(DataTable dataTable)
        {
            guna2DataGridView1.DataSource = null; // Xóa dữ liệu cũ
            guna2DataGridView1.ColumnHeadersVisible = true;

            // Thêm DataTable với tên cột vào DataGridView
            guna2DataGridView1.DataSource = dataTable;
        }

        private void SearchProductImportDetails()
        {
            if (originalDataTable != null)
            {
                string searchText = txtSearch.Text.Trim();
                DataView dv = originalDataTable.DefaultView;

                // Sử dụng hàm CONVERT của SQL để chuyển đổi các giá trị Decimal sang kiểu string
                dv.RowFilter = $"[Product Name] LIKE '%{searchText}%' OR [Staff Name] LIKE '%{searchText}%'";
                ShowDataInDataGridView(dv.ToTable());
            }
        }

        private void SearchBillDetails()
        {
            if (originalDataTable != null)
            {
                string searchText = txtSearch.Text.Trim();
                DataView dv = originalDataTable.DefaultView;

                // Sử dụng hàm CONVERT của SQL để chuyển đổi các giá trị Decimal sang kiểu string
                dv.RowFilter = $" [Customer Name] LIKE '%{searchText}%' OR [Staff Name] LIKE '%{searchText}%'";
                ShowDataInDataGridView(dv.ToTable());
            }
        }

        // Export excel data 
        private void btnXuat_Click(object sender, EventArgs e)
        {
            // Set LicenseContext to NonCommercial
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            // Create Excel package
            ExcelPackage package = new ExcelPackage();

            // Add a worksheet to the package
            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Data");

            // Write column headers
            for (int i = 1; i <= guna2DataGridView1.Columns.Count; i++)
            {
                worksheet.Cells[1, i].Value = guna2DataGridView1.Columns[i - 1].HeaderText;
            }

            // Write data to Excel worksheet
            for (int i = 0; i < guna2DataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < guna2DataGridView1.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1].Value = guna2DataGridView1.Rows[i].Cells[j].Value?.ToString();
                }
            }

            // Save Excel package to a file
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            saveFileDialog.FileName = "Dulieu.xlsx"; // Default file name
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                package.SaveAs(new System.IO.FileInfo(saveFileDialog.FileName));
                MessageBox.Show("Xuất File thành công !");
            }
        }

        private void btnBaocao_Click(object sender, EventArgs e)
        {
            GenerateReport();
        }
        // report 
        private void GenerateReport()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Word files (*.docx)|*.docx|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string savePath = saveFileDialog.FileName;

                using (DocX document = DocX.Create(savePath))
                {
                    // Thêm thông tin công ty
                    string companyName = "LOBBYMOVIE";
                    document.InsertParagraph(companyName).FontSize(16).Bold().Color(Color.DarkBlue).Alignment = Alignment.left;
                    document.InsertParagraph("\n");

                    // Thêm tiêu đề báo cáo
                    string reportType = cbo1.SelectedItem.ToString() == "Nhập Kho" ? "NHẬP KHO" : "HOÁ ĐƠN";
                    string reportTitle = $"BÁO CÁO {reportType}";
                    document.InsertParagraph(reportTitle).FontSize(20).Bold().Color(Color.DarkBlue).Alignment = Alignment.center;
                    document.InsertParagraph("\n");

                    // Thêm tên nhân viên xuất báo cáo
                    string staffTitle = $"Nguyễn Trung Tính";
                    document.InsertParagraph(staffTitle).FontSize(14).Bold().Color(Color.DarkBlue).Alignment = Alignment.right;
                    document.InsertParagraph("\n");

                    // Thêm ngày tháng năm
                    string currentDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

                    document.InsertParagraph($"Ngày tạo : {currentDate}").FontSize(14).Bold().Alignment = Alignment.right;
                    document.InsertParagraph("\n");

                    // Tạo bảng và định dạng tiêu đề
                    Table table = document.AddTable(guna2DataGridView1.Rows.Count + 1, guna2DataGridView1.Columns.Count + 1); // Thêm 1 cột cho STT
                    table.Design = TableDesign.TableGrid;
                    table.Alignment = Alignment.center;
                    table.Rows[0].Cells[0].Paragraphs.First().Append("STT").Bold().Color(Color.White);
                    for (int j = 0; j < guna2DataGridView1.Columns.Count; j++)
                    {
                        table.Rows[0].Cells[j + 1].Paragraphs.First().Append(guna2DataGridView1.Columns[j].HeaderText).Bold().Color(Color.White);
                    }

                    // Thêm dữ liệu từ DataGridView vào bảng
                    for (int i = 0; i < guna2DataGridView1.Rows.Count; i++)
                    {
                        table.Rows[i + 1].Cells[0].Paragraphs.First().Append((i + 1).ToString()).Color(Color.DarkBlue);
                        for (int j = 0; j < guna2DataGridView1.Columns.Count; j++)
                        {
                            string cellValue = guna2DataGridView1.Rows[i].Cells[j].Value?.ToString();
                            table.Rows[i + 1].Cells[j + 1].Paragraphs.First().Append(cellValue ?? string.Empty).Color(Color.Black);
                        }
                    }

                    // Thêm bảng vào tài liệu và căn chỉnh
                    document.InsertTable(table);
                    document.Tables.ForEach(t => t.AutoFit = AutoFit.Contents);

                    // Lưu tài liệu
                    document.Save();
                    MessageBox.Show("Báo cáo đã được lưu thành công!");
                }
            }
        }


    }
}
