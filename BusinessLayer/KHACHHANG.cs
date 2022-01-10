using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace BusinessLayer
{
    public class KHACHHANG{
        Entities db;
        public KHACHHANG(){
            db = Entities.CreateEntities();
        }

        public List<KHACH_HANG> getAll(){
            return db.KHACH_HANG.OrderBy(x => x.TENKH).ToList(); // trả về danh sách khách hàng sắp xếp theo tên
        }

        public KHACH_HANG getItem(int makh){
            return db.KHACH_HANG.FirstOrDefault(x => x.MAKH == makh);
        }

        public KHACH_HANG getItem(string tenkh, string sdt, string gioitinh){
            return db.KHACH_HANG.FirstOrDefault(x => x.TENKH == tenkh && x.SDT == sdt && x.GIOITINH == gioitinh);
        }

        public void add(KHACH_HANG kh){
            try{
                db.KHACH_HANG.Add(kh);
                db.SaveChanges();
            }
            catch (Exception ex){
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu. " + ex.Message);
            }
        }

        public void update(KHACH_HANG kh){
            KHACH_HANG _kh = db.KHACH_HANG.FirstOrDefault(x => x.MAKH == kh.MAKH);
            _kh.TENKH = kh.TENKH;
            _kh.SDT = kh.SDT;
            _kh.GIOITINH = kh.GIOITINH;
            _kh.VOHIEUHOA = kh.VOHIEUHOA;
            try{
                db.SaveChanges();
            }
            catch (Exception ex){
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu. " + ex.Message);
            }
        }

        public void disable(int makh)
        {
            KHACH_HANG kh = db.KHACH_HANG.FirstOrDefault(x => x.MAKH == makh);
            kh.VOHIEUHOA = true;
            try{
                db.SaveChanges();
            }
            catch (Exception ex){
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu. " + ex.Message);
            }
        }
    }
}
