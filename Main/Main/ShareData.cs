using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using static Main.ParentForm;
namespace Main
{
    public static class SharedData
    {
        public static List<string> SelectedSeats { get; set; } = new List<string>();
        public static List<string> SelectedProducts { get; set; } = new List<string>();
    }

    public static class ShareData
    {
        public static string MovieName { get; set; }
        public static DateTime TimeOfPurchase { get; set; }
        public static int Gia1Ve { get; set; } // Giá vé cho một ghế
        public static string RoomNumber { get; set; }
        public static int TongGiaVe { get; set; } // Tổng giá vé của tất cả các ghế
        public static int TongSanPham { get; set; }
        public static string SelectedSeats { get; set;}
    }
}
