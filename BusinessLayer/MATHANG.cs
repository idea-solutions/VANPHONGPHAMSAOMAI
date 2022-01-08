using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;


namespace BusinessLayer
{
    public class MATHANG
    {
        Entities db;
        public MATHANG()
        {
            db = Entities.CreateEntities();
        }

        public List<OBJMATHANG> getAll()
        {
            var listMatHang = db.MAT_HANG.ToList();

            List<OBJMATHANG> lstmatHangFull = new List<OBJMATHANG>();
            OBJMATHANG objMatHang;

            foreach (var item in listMatHang)
            {
                objMatHang = new OBJMATHANG();
                objMatHang.MAMH = item.MAMH;
                objMatHang.TENMH = item.TENMH;
                objMatHang.GIABAN = item.GIABAN;
                objMatHang.DVT = item.DVT;
                objMatHang.MALOAI = item.MALOAI;
                objMatHang.MOTA = item.MOTA;
                objMatHang.VOHIEUHOA = item.VOHIEUHOA;
                var loaimh = db.LOAI_MAT_HANG.FirstOrDefault(x => x.MALOAI == item.MALOAI);
                objMatHang.TENLOAIMH = loaimh.TENLOAI;
                lstmatHangFull.Add(objMatHang);
            }
            return lstmatHangFull.OrderBy(x => x.MALOAI).ToList();
        }

        public MAT_HANG getItem(string mamh)
        {
            return db.MAT_HANG.FirstOrDefault(x => x.MAMH == mamh);
        }

        public List<OBJMATHANG> getAllByLoaiMH(string maloai)
        {

            var listMatHang = db.MAT_HANG.ToList();

            List<OBJMATHANG> lstmatHangFull = new List<OBJMATHANG>();
            OBJMATHANG objMatHang;

            foreach (var item in listMatHang)
            {
                objMatHang = new OBJMATHANG();
                objMatHang.MAMH = item.MAMH;
                objMatHang.TENMH = item.TENMH;
                objMatHang.GIABAN = item.GIABAN;
                objMatHang.DVT = item.DVT;
                objMatHang.MALOAI = item.MALOAI;
                objMatHang.MOTA = item.MOTA;
                objMatHang.VOHIEUHOA = item.VOHIEUHOA;
                var loaimh = db.LOAI_MAT_HANG.FirstOrDefault(x => x.MALOAI == item.MALOAI);
                objMatHang.TENLOAIMH = loaimh.TENLOAI;
                lstmatHangFull.Add(objMatHang);
            }
            return lstmatHangFull.Where(x=>x.MALOAI == maloai).OrderBy(x => x.MALOAI).ToList();
        }

        public void add(MAT_HANG mh)
        {
            try
            {
                db.MAT_HANG.Add(mh);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu. " + ex.Message);
            }
        }

        public void update(MAT_HANG mh)
        {
            MAT_HANG _mh = db.MAT_HANG.FirstOrDefault(x => x.MAMH == mh.MAMH);
            _mh.TENMH = mh.TENMH;
            _mh.GIABAN = mh.GIABAN;
            _mh.DVT = mh.DVT;
            _mh.MALOAI = mh.MALOAI;
            _mh.MOTA = mh.MOTA;
            _mh.VOHIEUHOA = mh.VOHIEUHOA;
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu. " + ex.Message);
            }
        }

        public void disable(string mamh)
        {
            MAT_HANG mh = db.MAT_HANG.FirstOrDefault(x => x.MAMH == mamh);
            mh.VOHIEUHOA = true;
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu. " + ex.Message);
            }
        }
    }
}
