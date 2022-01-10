using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
namespace BusinessLayer
{
    public class NHACUNGCAP
    {
        Entities db;
        public NHACUNGCAP(){
            db = Entities.CreateEntities();
        }

        public List<NHA_CUNG_CAP> getAll(){
            return db.NHA_CUNG_CAP.OrderBy(x => x.TENNCC).ToList();
        }

        public NHA_CUNG_CAP getItem(String mancc){
            return db.NHA_CUNG_CAP.FirstOrDefault(x => x.MANCC == mancc);
        }

        public void add(NHA_CUNG_CAP ncc){
            try{
                db.NHA_CUNG_CAP.Add(ncc);
                db.SaveChanges();
            }
            catch (Exception ex){
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu. " + ex.Message);
            }
        }

        public void update(NHA_CUNG_CAP ncc){
            NHA_CUNG_CAP _ncc = db.NHA_CUNG_CAP.FirstOrDefault(x => x.MANCC == ncc.MANCC);
            _ncc.TENNCC = ncc.TENNCC;
            _ncc.SDT = ncc.SDT;
            _ncc.DIACHI = ncc.DIACHI;
            _ncc.EMAIL = ncc.EMAIL;
            _ncc.VOHIEUHOA = ncc.VOHIEUHOA;
            try{
                db.SaveChanges();
            }
            catch (Exception ex){
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu. " + ex.Message);
            }
        }

        public void disable(string mancc){
            NHA_CUNG_CAP ncc = db.NHA_CUNG_CAP.FirstOrDefault(x => x.MANCC == mancc);
            ncc.VOHIEUHOA = true;
            try{
                db.SaveChanges();
            }
            catch (Exception ex){
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu. " + ex.Message);
            }
        }
    }
}
