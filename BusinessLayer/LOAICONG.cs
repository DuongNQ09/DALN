using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace BusinessLayer
{
    public class LOAICONG
    {
        QUANLYNHANSUEntities db = new QUANLYNHANSUEntities();
        public tb_LOAICONGG getItem(int idloaicong)
        {
            return db.tb_LOAICONGG.FirstOrDefault(x => x.IDLC == idloaicong);
        }
        public List<tb_LOAICONGG> getList()
        {
            return db.tb_LOAICONGG.ToList();
        }
        public tb_LOAICONGG Add(tb_LOAICONGG lc)
        {
            try
            {
                db.tb_LOAICONGG.Add(lc);
                db.SaveChanges();
                return lc;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }
        public tb_LOAICONGG Update(tb_LOAICONGG lc)
        {
            try
            {
                var _lc = db.tb_LOAICONGG.FirstOrDefault(x => x.IDLC == lc.IDLC);
                _lc.TENLC = lc.TENLC;
                _lc.HESO = lc.HESO;
                _lc.UPDATED_BY = lc.UPDATED_BY;
                _lc.UPDATED_DATE = lc.UPDATED_DATE;
                db.SaveChanges();
                return lc;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }
        public void Delete(int idloaicong, int iduser)
        {
            try
            {
                var _lc = db.tb_LOAICONGG.FirstOrDefault(x => x.IDLC == idloaicong);
                _lc.DELETED_BY = iduser;
                _lc.DELETED_DATE = DateTime.Now;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }            
        }
    }
}
