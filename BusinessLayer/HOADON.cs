using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace BusinessLayer
{
    public class HOADON{
        Entities db;
        public HOADON(){
            db = Entities.CreateEntities();
        }

        public HOA_DON add(HOA_DON hd){
            try{
                db.HOA_DON.Add(hd);
                db.SaveChanges();
                return hd;
            }
            catch (Exception ex){
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu. " + ex.Message);
            }
        }
    }
}
