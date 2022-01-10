using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace BusinessLayer
{
    public class DONDATHANGMATHANG{
        Entities db;
        public DONDATHANGMATHANG(){
            db = Entities.CreateEntities();
        }

        public List<DONDATHANG_MATHANG> getAll(int maddh){
            return db.DONDATHANG_MATHANG.Where(x => x.MADDH == maddh).ToList();
        }

        public List<OBJDDH_MH> getAll(){

            var lstDDHMH = db.DONDATHANG_MATHANG.ToList();

            List<OBJDDH_MH> lstDDHMHFull = new List<OBJDDH_MH>();
            OBJDDH_MH objDDHMH;

            foreach (var item in lstDDHMH){
                objDDHMH = new OBJDDH_MH();

                var nvDDH = db.DON_DAT_HANG.FirstOrDefault(x => x.MADDH == item.MADDH); //lấy ra nv từ bảng DON_DAT_HANG
                objDDHMH.MANV = nvDDH.MANV;

                var nvNV = db.NHAN_VIEN.FirstOrDefault(x => x.MANHANVIEN == nvDDH.MANV); //lấy ra tennv từ bảng NHAN_VIEN
                objDDHMH.TENNV = nvNV.TENNHANVIEN;

                var nccDDH = db.DON_DAT_HANG.FirstOrDefault(x => x.MADDH == item.MADDH); // lấy ra ncc từ bảng DON_DAT_HANG
                objDDHMH.MANCC = nccDDH.MANCC;

                var DDH = db.DON_DAT_HANG.FirstOrDefault(x => x.MADDH == item.MADDH); // lấy ra DDH từ bảng DON_DAT_HANG

                var nccNCC = db.NHA_CUNG_CAP.FirstOrDefault(x => x.MANCC == DDH.MANCC); // lấy ra ncc tu bảng NCC
                objDDHMH.TENNCC = nccNCC.TENNCC;

                objDDHMH.MAMH = item.MAMH;

                var mhMH = db.MAT_HANG.FirstOrDefault(x => x.MAMH == item.MAMH); 
                objDDHMH.TENMH = mhMH.TENMH;

                objDDHMH.DVT = mhMH.DVT;


                objDDHMH.SOLUONG = item.SOLUONG;

                var ddhDDH = db.DON_DAT_HANG.FirstOrDefault(x => x.MADDH == item.MADDH);
                objDDHMH.NGAYDAT = ddhDDH.NGAYDAT;

                objDDHMH.DONGIA = mhMH.GIABAN;

                objDDHMH.THANHTIEN = mhMH.GIABAN * item.SOLUONG;

                lstDDHMHFull.Add(objDDHMH);
            }
            return lstDDHMHFull.OrderBy(x => x.NGAYDAT).ToList();
        }
        public List<OBJDDH_MH> getAllByDate(DateTime tungay, DateTime denngay){

            var lstDDHMH = db.DONDATHANG_MATHANG.ToList();

            List<OBJDDH_MH> lstDDHMHFull = new List<OBJDDH_MH>();
            OBJDDH_MH objDDHMH;

            foreach (var item in lstDDHMH){
                objDDHMH = new OBJDDH_MH();

                var nvDDH = db.DON_DAT_HANG.FirstOrDefault(x => x.MADDH == item.MADDH); //lấy ra nv từ bảng DON_DAT_HANG
                objDDHMH.MANV = nvDDH.MANV;

                var nvNV = db.NHAN_VIEN.FirstOrDefault(x => x.MANHANVIEN == nvDDH.MANV); //lấy ra tennv từ bảng NHAN_VIEN
                objDDHMH.TENNV = nvNV.TENNHANVIEN;

                var nccDDH = db.DON_DAT_HANG.FirstOrDefault(x => x.MADDH == item.MADDH); // lấy ra ncc từ bảng DON_DAT_HANG
                objDDHMH.MANCC = nccDDH.MANCC;

                var DDH = db.DON_DAT_HANG.FirstOrDefault(x => x.MADDH == item.MADDH); // lấy ra DDH từ bảng DON_DAT_HANG

                var nccNCC = db.NHA_CUNG_CAP.FirstOrDefault(x => x.MANCC == DDH.MANCC); // lấy ra ncc tu bảng NCC
                objDDHMH.TENNCC = nccNCC.TENNCC;

                objDDHMH.MAMH = item.MAMH;

                var mhMH = db.MAT_HANG.FirstOrDefault(x => x.MAMH == item.MAMH);
                objDDHMH.TENMH = mhMH.TENMH;

                objDDHMH.DVT = mhMH.DVT;

                objDDHMH.SOLUONG = item.SOLUONG;

                var ddhDDH = db.DON_DAT_HANG.FirstOrDefault(x => x.MADDH == item.MADDH);
                objDDHMH.NGAYDAT = ddhDDH.NGAYDAT;

                objDDHMH.DONGIA = mhMH.GIABAN;

                objDDHMH.THANHTIEN = mhMH.GIABAN * item.SOLUONG;

                lstDDHMHFull.Add(objDDHMH);
            }
            return lstDDHMHFull.Where(x => x.NGAYDAT >= tungay.AddDays(-1) && x.NGAYDAT <= denngay).OrderBy(x => x.NGAYDAT).ToList();
        }
        public void deleteAll(){
            var listDDH = db.DON_DAT_HANG.ToList();
            var lstDDHMH = db.DONDATHANG_MATHANG.ToList();

            foreach (var item in lstDDHMH){
                db.DONDATHANG_MATHANG.Remove(item);
                db.SaveChanges();
            }

            foreach (var item in listDDH){
                db.DON_DAT_HANG.Remove(item);
                db.SaveChanges();
            }
        }

        public DONDATHANG_MATHANG add(DONDATHANG_MATHANG ddhmh){
            try{
                db.DONDATHANG_MATHANG.Add(ddhmh);
                db.SaveChanges();
                return ddhmh;
            }
            catch (Exception ex){
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu. " + ex.Message);
            }
        }
    }
}
