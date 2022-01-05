using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using BusinessLayer;

namespace BusinessLayer
{
    public class NHANVIEN
    {
        Entities db;
        public NHANVIEN()
        {
            db = Entities.CreateEntities();
        }

        

        public List<NHAN_VIEN> getAll()
        {
            return db.NHAN_VIEN.OrderBy(x => x.TENNHANVIEN).ToList();
        }

        public NHAN_VIEN getItem(string manv)
        {
            return db.NHAN_VIEN.FirstOrDefault(x => x.MANHANVIEN == manv);
        }

        public NHAN_VIEN getItemDN(string user, string pass)
        {
            return db.NHAN_VIEN.FirstOrDefault(x => x.TENDANGNHAP == user && x.MATKHAU == pass);
        }
        public NHAN_VIEN getItemQMK(DateTime ngaysinh, string cmnd, string ten, string diachi)
        {
            return db.NHAN_VIEN.FirstOrDefault(x => x.NGAYSINH == ngaysinh && x.CMND_CCCD == cmnd && x.TENNHANVIEN == ten && x.DIACHI == diachi);
        }

        public List<NHAN_VIEN> getItemQMK(string sdt)
        {
            return db.NHAN_VIEN.Where(x => x.SDT == sdt).ToList();
        }

        public void add(NHAN_VIEN nv)
        {
            try
            {
                db.NHAN_VIEN.Add(nv);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu. " + ex.Message);
            }
        }

        public void update(NHAN_VIEN nv)
        {
            NHAN_VIEN _nv = db.NHAN_VIEN.FirstOrDefault(x => x.MANHANVIEN == nv.MANHANVIEN);
            _nv.TENNHANVIEN = nv.TENNHANVIEN;
            _nv.DIACHI = nv.DIACHI;
            _nv.SDT = nv.SDT;
            _nv.GIOITINH = nv.GIOITINH;
            _nv.NGAYSINH = nv.NGAYSINH;
            _nv.CMND_CCCD = nv.CMND_CCCD;
            _nv.MATKHAU = nv.MATKHAU;
            _nv.VOHIEUHOA = nv.VOHIEUHOA;
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu. " + ex.Message);
            }
        }

        public void updateMK(string tendn, string tk)
        {
            NHAN_VIEN _nv = db.NHAN_VIEN.FirstOrDefault(x => x.TENDANGNHAP == tendn);
            _nv.MATKHAU = tk;
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu. " + ex.Message);
            }
        }

        public void disable(string manv)
        {
            NHAN_VIEN nv = db.NHAN_VIEN.FirstOrDefault(x => x.MANHANVIEN == manv);
            nv.VOHIEUHOA = true;
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
