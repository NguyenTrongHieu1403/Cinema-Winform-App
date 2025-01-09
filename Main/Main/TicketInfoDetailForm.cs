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
    public partial class TicketInfoDetailForm : Form
    {
        public TicketInfoDetailForm()
        {
            InitializeComponent();
        }
        public TicketInfoDetailForm(string seatName, string roomName, string showtime, string movieName, string price)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            lblSeatName.Text = seatName;
            lblRoomName.Text =roomName;
            lblShowtime.Text = showtime;
            lblMovieName.Text =movieName;
            lblPrice.Text =price + "đ";
        }
    }
}
