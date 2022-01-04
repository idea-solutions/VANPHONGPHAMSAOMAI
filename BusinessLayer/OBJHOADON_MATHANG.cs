using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace BusinessLayer
{
    public class OBJHOADON_MATHANG
    {
        // từ bảng HOADON_MUAHAN
        public int MAHOADON { get; set; }
        public DateTime NGAYLAP { get; set; }
        public string MAMH { get; set; }
        public string TENMH { get; set; }
        public int SOLUONG { get; set; }
        public double THANHTIEN { get; set; }


        // từ bảng HOADON
        public string MANV { get; set; }
        public string TENNV { get; set; }
        public string DVT { get; set; }
        public int? MAKH { get; set; }
        public string TENKH { get; set; }
        
        // từ bảng MATHANG
        public double DONGIA { get; set; }


        // thêm vào GRIDCONTROl
        public double? TONGTIEN { get; set; }

    }
}
