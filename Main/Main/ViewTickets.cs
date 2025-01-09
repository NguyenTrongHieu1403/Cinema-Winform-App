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

namespace Main
{
    public partial class ViewTickets : Form
    {
        private string connectionString = "Data Source=LAPTOP-96IDN57Q\\LAPTRINH2024;Initial Catalog=CinemaDBAW;Integrated Security=True;";
        public ViewTickets()
        {
            InitializeComponent();
            LoadTicketData();
        }

        private void LoadTicketData()
        {
            string query = @"
            SELECT 
                s.id,
                s.SeatNumber,
                r.RoomName,
                st.StartTime,
                m.DisplayName,
                st.TicketPrice
            FROM 
                Seat s
            INNER JOIN 
                Room r ON s.RoomID = r.id
            INNER JOIN 
                SeatSetting ss ON s.id = ss.id
            INNER JOIN 
                Showtime st ON ss.ShowtimeID = st.id
            INNER JOIN 
                Movie m ON st.MovieID = m.id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataGridViewTickets.DataSource = dataTable;
            }
        }

        private void dataGridViewTickets_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewTickets.Columns["Column1"].Index && e.RowIndex >= 0)
            {
                // Lấy thông tin từ hàng được chọn
                DataGridViewRow selectedRow = dataGridViewTickets.Rows[e.RowIndex];
                string seatName = selectedRow.Cells["SeatNumber"].Value.ToString();
                string roomName = selectedRow.Cells["RoomName"].Value.ToString();
                string showtime = selectedRow.Cells["StartTime"].Value.ToString();
                string movieName = selectedRow.Cells["DisplayName"].Value.ToString();
                string price = selectedRow.Cells["TicketPrice"].Value.ToString();

                // Hiển thị thông tin vé trên form mới
                TicketInfoDetailForm detailForm = new TicketInfoDetailForm(seatName, roomName, showtime, movieName, price);
                detailForm.ShowDialog();
            }
        }
    }
}