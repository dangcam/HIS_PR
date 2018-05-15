using Core.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanhMuc.DAL
{
    public class VatTuYTeEntity
    {
        Connection db;
        public VatTuYTeEntity()
        {
            db = new Connection();
        }
        public string MaVatTu { get; set; }
        public string TenVatTu { get; set; }
        public string DonViTinh { get; set; }
        public decimal DonGiaBV { get; set; }
        public string QuyetDinh { get; set; }
        public string CongBo { get; set; }
        public DataTable DSDonViTinh()
        {
            return db.ExcuteQuery("Select * From DonViTinh",
                CommandType.Text, null);
        }
        public DataTable DSVatTuYTe()
        {
            return db.ExcuteQuery("Select * From VatTuYTe",
                CommandType.Text, null);
        }
        public bool SpVatTuYTe(ref string err, string Action)
        {
            return db.MyExecuteNonQuery("SpVatTuYTe",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@Action", Action),
                new SqlParameter("@MaVatTu", MaVatTu),
                new SqlParameter("@TenVatTu", TenVatTu),
                new SqlParameter("@DonViTinh", DonViTinh),
                new SqlParameter("@DonGiaBV", DonGiaBV),
                new SqlParameter("@QuyetDinh", QuyetDinh),
                new SqlParameter("@CongBo", CongBo));
        }
    }
}
