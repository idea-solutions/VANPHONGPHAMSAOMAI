using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace BusinessLayer
{
    
    public class THONGKE
    {
        Entities db;
        public THONGKE()
        {
            db = Entities.CreateEntities();
        }
        public List<OBJTHONGKELOAIMH> thongKeMatHang()
        {
            string a = "";
            OBJTHONGKELOAIMH objloaimh; 
            List<OBJTHONGKELOAIMH> lst = new List<OBJTHONGKELOAIMH>();
            var lstLoaiMH =  db.FNLOAIMAT_HANG().ToList();
            foreach (var item in lstLoaiMH)
            {
                if(item.MALOAI != a)
                {
                    objloaimh = new OBJTHONGKELOAIMH();
                    objloaimh.MALOAI = item.MALOAI;
                    a = objloaimh.MALOAI;
                    objloaimh.TENLOAI = item.TENLOAI;
                    objloaimh.SOLUONG = int.Parse(db.FNLOAIMAT_HANG().Count(x => x.MALOAI == item.MALOAI).ToString());
                    lst.Add(objloaimh);
                }
            }
            return lst;
        }

        public List<OBJTHONGKEBANHANG> thongKeBanHang()
        {
            OBJTHONGKEBANHANG objTKBH;
            List<OBJTHONGKEBANHANG> lst = new List<OBJTHONGKEBANHANG>();
            var lstTKBH = db.FNBANHANGByTIMEGROUPMH(DateTime.Now).ToList();

            foreach (var item in lstTKBH)
            {
                objTKBH = new OBJTHONGKEBANHANG();
                objTKBH.TENMH = item.TENMH;
                objTKBH.SOLUONG = item.SOLUONG;
                lst.Add(objTKBH);
            }
            return lst;
        }

        public List<OBJTHONGKEKHACHHANG> thongKeKhachHang()
        {
            OBJTHONGKEKHACHHANG objTKKH;
            List<OBJTHONGKEKHACHHANG> lst = new List<OBJTHONGKEKHACHHANG>();
            var lstTKKH = db.FNKHACHHANGGROUP(DateTime.Now).ToList();

            //foreach (var item in lstTKKH)
            //{
            //    if (item.TENKH != "A_KHÁCH_LẺ")
            //    {
            //        objTKKH = new OBJTHONGKEKHACHHANG();
            //        objTKKH.TENKH = item.TENKH;
            //        objTKKH.THANHTIEN = item.THANHTIEN;
            //        lst.Add(objTKKH);
            //    }
            //}
            int dem = 1;
            for (int i = 0; i < lstTKKH.Count; i++)
            {
                if (lstTKKH[i].TENKH != "A_KHÁCH_LẺ")
                {
                    objTKKH = new OBJTHONGKEKHACHHANG();
                    objTKKH.TENKH = lstTKKH[i].TENKH;
                    objTKKH.THANHTIEN = lstTKKH[i].THANHTIEN;
                    lst.Add(objTKKH);
                    dem++;
                }
                if (dem > 5)
                    break;
            }

            return lst;
        }

        public List<OBJTHONGKEDOANHTHU> thongKeDoanhThu()
        {
            OBJTHONGKEDOANHTHU objTKDT;
            List<OBJTHONGKEDOANHTHU> lst = new List<OBJTHONGKEDOANHTHU>();
            var lstTKKH = db.FNTHONGKEDOANHTHU().ToList();

            foreach (var item in lstTKKH)
            {
                objTKDT = new OBJTHONGKEDOANHTHU();
                objTKDT.Ngay = item.Ngay;
                objTKDT.ThanhTien = item.TongTien;
                lst.Add(objTKDT);
            }
            return lst;
        }
    }
}
