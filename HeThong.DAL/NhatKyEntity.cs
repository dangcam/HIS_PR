using Core.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeThong.DAL
{
    public class NhatKyEntity
    {
        Connection db;
        public NhatKyEntity()
        {
            db = new Connection ();
        }
        public string MaNV
        {
            get;
            set;
        }
        public DateTime Ngay
        {
            get;
            set;
        }
        public DataTable DSHoatDong (string tuNgay, string denNgay)
        {
            return db.ExcuteQuery ("Select * From HoatDong Where CAST(Ngay AS DATE) BETWEEN CAST('"+tuNgay
                +"' AS DATE) AND CAST('"+denNgay+"' AS DATE)",
                CommandType.Text, null);
        }
        public DataTable DSDonThuoc(DateTime tuNgay, DateTime denNgay)
        {
            return db.ExcuteQuery("Select * From DonThuocXoa Where NgayXoa BETWEEN CAST('" + tuNgay
                + "' AS DATE) AND CAST('" + denNgay + "' AS DATE)",
                CommandType.Text, null);
        }
        public bool XoaHoatDong (ref string err)
        {
            return db.MyExecuteNonQuery ("SpXoaHoatDong",
                CommandType.StoredProcedure, ref err,
                new SqlParameter ("@Ma_NV", MaNV),
                new SqlParameter ("@Ngay", Ngay));
        }
        public bool XoaTatCa (ref string err, string tuNgay, string denNgay)
        {
            return db.BackUpOrRestore ("Delete From HoatDong Where CAST(Ngay AS DATE) BETWEEN CAST('" + tuNgay
                + "' AS DATE) AND CAST('" + denNgay + "' AS DATE)", ref err);
        }
    }
}
