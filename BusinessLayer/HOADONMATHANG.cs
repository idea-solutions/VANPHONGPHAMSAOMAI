using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;


namespace BusinessLayer
{
    public class HOADONMATHANG{
        Entities db;
        public HOADONMATHANG(){
            db = Entities.CreateEntities();
        }


        public List<HOADON_MATHANG> getAll(int mahd){
            return db.HOADON_MATHANG.Where(x=> x.MAHD == mahd).ToList();
        }

        public List<OBJHOADON_MATHANG> getAll(){
            var lstHDMH = db.HOADON_MATHANG.ToList();

            List<OBJHOADON_MATHANG> lstHDMHFull = new List<OBJHOADON_MATHANG>();
            OBJHOADON_MATHANG objHDMH;

            foreach (var item in lstHDMH){
                objHDMH = new OBJHOADON_MATHANG();

                var nvHD = db.HOA_DON.FirstOrDefault(x => x.MAHOADON == item.MAHD); //lấy ra nv từ bảng HOA_DON
                objHDMH.MANV = nvHD.MANHANVIEN;

                var nvNV = db.NHAN_VIEN.FirstOrDefault(x => x.MANHANVIEN == nvHD.MANHANVIEN); //lấy ra tennv từ bảng NHAN_VIEN
                objHDMH.TENNV = nvNV.TENNHANVIEN;

                var khHD = db.HOA_DON.FirstOrDefault(x => x.MAHOADON == item.MAHD); // lấy ra kh từ bảng HOA_DON
                objHDMH.MAKH = khHD.MAKH;

                var HD = db.HOA_DON.FirstOrDefault(x => x.MAHOADON == item.MAHD); // lấy ra hóa đơn từ bảng HOA_DON

                var khKH = db.KHACH_HANG.FirstOrDefault(x => x.MAKH == HD.MAKH); // lấy ra kh tu bảng KHACH_HANG
                objHDMH.TENKH = khKH.TENKH;

                objHDMH.MAMH = item.MAMH;

                var mhMH = db.MAT_HANG.FirstOrDefault(x => x.MAMH == item.MAMH); // lấy ra mh tu bang MAT_HANG
                objHDMH.TENMH = mhMH.TENMH;

                objHDMH.DVT = mhMH.DVT;

                objHDMH.SOLUONG = item.SOLUONGMUA;

                var hdHD = db.HOA_DON.FirstOrDefault(x => x.MAHOADON == item.MAHD); // lấy ra hd tu bang HOA_DON
                objHDMH.NGAYLAP = hdHD.NGAYLAP;

                objHDMH.DONGIA = mhMH.GIABAN;

                objHDMH.THANHTIEN = mhMH.GIABAN * item.SOLUONGMUA;

                lstHDMHFull.Add(objHDMH);
            }
            return lstHDMHFull.OrderBy(x => x.NGAYLAP).ToList();
        }

        public List<OBJHOADON_MATHANG> getAllByDate(DateTime tungay, DateTime denngay){
            var lstHDMH = db.HOADON_MATHANG.ToList();

            List<OBJHOADON_MATHANG> lstHDMHFull = new List<OBJHOADON_MATHANG>();
            OBJHOADON_MATHANG objHDMH;

            foreach (var item in lstHDMH){
                objHDMH = new OBJHOADON_MATHANG();

                var nvHD = db.HOA_DON.FirstOrDefault(x => x.MAHOADON == item.MAHD); //lấy ra nv từ bảng HOA_DON
                objHDMH.MANV = nvHD.MANHANVIEN;

                var nvNV = db.NHAN_VIEN.FirstOrDefault(x => x.MANHANVIEN == nvHD.MANHANVIEN); //lấy ra tennv từ bảng NHAN_VIEN
                objHDMH.TENNV = nvNV.TENNHANVIEN;

                var khHD = db.HOA_DON.FirstOrDefault(x => x.MAHOADON == item.MAHD); // lấy ra kh từ bảng HOA_DON
                objHDMH.MAKH = khHD.MAKH;

                var HD = db.HOA_DON.FirstOrDefault(x => x.MAHOADON == item.MAHD); // lấy ra hóa đơn từ bảng HOA_DON

                var khKH = db.KHACH_HANG.FirstOrDefault(x => x.MAKH == HD.MAKH); // lấy ra kh tu bảng KHACH_HANG
                objHDMH.TENKH = khKH.TENKH;

                objHDMH.MAMH = item.MAMH;

                var mhMH = db.MAT_HANG.FirstOrDefault(x => x.MAMH == item.MAMH); // lấy ra mh tu bang MAT_HANG
                objHDMH.TENMH = mhMH.TENMH;

                objHDMH.DVT = mhMH.DVT;

                objHDMH.SOLUONG = item.SOLUONGMUA;

                var hdHD = db.HOA_DON.FirstOrDefault(x => x.MAHOADON == item.MAHD); // lấy ra hd tu bang HOA_DON
                objHDMH.NGAYLAP = hdHD.NGAYLAP;

                objHDMH.DONGIA = mhMH.GIABAN;

                objHDMH.THANHTIEN = mhMH.GIABAN * item.SOLUONGMUA;

                lstHDMHFull.Add(objHDMH);
            }
            return lstHDMHFull.Where(x=> x.NGAYLAP>=tungay.AddDays(-1) && x.NGAYLAP<=denngay).OrderBy(x => x.NGAYLAP).ToList();
        }
        
        public void deleteAll(){
            var listHD = db.HOA_DON.ToList();
            var lstHDMH = db.HOADON_MATHANG.ToList();
            
            foreach (var item in lstHDMH){
                db.HOADON_MATHANG.Remove(item);
                db.SaveChanges();
            }

            foreach (var item in listHD){
                db.HOA_DON.Remove(item);
                db.SaveChanges();
            }
        }

        public HOADON_MATHANG add(HOADON_MATHANG cthd){
            try{
                db.HOADON_MATHANG.Add(cthd);
                db.SaveChanges();
                return cthd;
            }
            catch (Exception ex){
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu. " + ex.Message);
            }
        }
    }
}
