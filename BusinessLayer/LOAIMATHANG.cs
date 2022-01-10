using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace BusinessLayer
{
    public class LOAIMATHANG
    {
        Entities db;
        public LOAIMATHANG()
        {
            db = Entities.CreateEntities();
        }

        public List<LOAI_MAT_HANG> getAll()
        {
            return db.LOAI_MAT_HANG.OrderBy(x => x.TENLOAI).ToList();
        }

        public List<OBJLOAIMATHANG> getAllFullShow()
        {
            // lấy ra list loại mặt hàng
            var listLoaiMatHang = db.LOAI_MAT_HANG.ToList();

            //tạo ra list mới đầy đủ
            List<OBJLOAIMATHANG> lstloaiMatHangFull = new List<OBJLOAIMATHANG>();
            
            // khai báo đối tượng loại mh có đầy đủ tt
            OBJLOAIMATHANG objLoaiMatHang;

            foreach (var item in listLoaiMatHang)
            {
                // tạo ra 1 đối tượng loại mh đầy đủ tt
                objLoaiMatHang = new OBJLOAIMATHANG();
                objLoaiMatHang.MALOAI = item.MALOAI;
                objLoaiMatHang.TENLOAI = item.TENLOAI;
                objLoaiMatHang.VOHIEUHOA = item.VOHIEUHOA;

                // tính số lượng
                int soLuong = db.MAT_HANG.Count(x => x.MALOAI == item.MALOAI);
                objLoaiMatHang.SOLUONG = soLuong;
                // sau khi thêm dữ liệu xong thì add vào list
                lstloaiMatHangFull.Add(objLoaiMatHang);
            }
            // trả về
            return lstloaiMatHangFull.OrderBy(x => x.TENLOAI).ToList();
        }

        public List<LOAI_MAT_HANG> getAllFull()
        {
            return db.LOAI_MAT_HANG.OrderBy(x => x.TENLOAI).ToList();
        }

        public LOAI_MAT_HANG getItem(string maloaimh)
        {
            return db.LOAI_MAT_HANG.FirstOrDefault(x => x.MALOAI == maloaimh);
        }

        public void add(LOAI_MAT_HANG loaimh)
        {
            try
            {
                db.LOAI_MAT_HANG.Add(loaimh);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu. " + ex.Message);
            }
        }

        public void update(LOAI_MAT_HANG loaimh){
            LOAI_MAT_HANG _loaimh = db.LOAI_MAT_HANG.FirstOrDefault(x => x.MALOAI == loaimh.MALOAI);
            try{
                _loaimh.TENLOAI = loaimh.TENLOAI;
                _loaimh.VOHIEUHOA = loaimh.VOHIEUHOA;
                db.SaveChanges();
            }
            catch (Exception ex){
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu. " + ex.Message);
            }
        }

        public void disable(string maloaimh){
            LOAI_MAT_HANG loaimh = db.LOAI_MAT_HANG.FirstOrDefault(x => x.MALOAI == maloaimh);
            loaimh.VOHIEUHOA = true;
            try{
                db.SaveChanges();
            }
            catch (Exception ex){
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu. " + ex.Message);
            }
        }
    }
}
