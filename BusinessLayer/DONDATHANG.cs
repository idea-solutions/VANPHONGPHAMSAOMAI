using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace BusinessLayer
{
    public class DONDATHANG
    {
        Entities db;
        public DONDATHANG()
        {
            db = Entities.CreateEntities();
        }

        public DON_DAT_HANG add(DON_DAT_HANG ddh)
        {
            try
            {
                db.DON_DAT_HANG.Add(ddh);
                db.SaveChanges();
                return ddh;
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu. " + ex.Message);
            }
        }
    }
}
