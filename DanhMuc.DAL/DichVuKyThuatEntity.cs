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
    public class DichVuKyThuatEntity
    {
        Connection db;
        public string MaCS { get; set; }
        public string MaDVKT { get; set; }
        public string TenDVKT { get; set; }
        public decimal DonGia { get; set; }
        public bool TinhTrang { get; set; }
        public int MaNhom { get; set; }
        public string TT50 { get; set; }
        public string MaNhomCLS { get; set; }
        public DichVuKyThuatEntity()
        {
            db = new Connection();
        }
        public DataTable DSCoSo()
        {
            return db.ExcuteQuery("Select Ma_CS,Ten_CS From CoSoKCB Where Ma_CS = '70013' OR Ma_CS = '70074' "
                + "OR Ma_CS = '70075' OR Ma_CS = '70076' OR Ma_CS = '70077' OR Ma_CS = '70078'",
                CommandType.Text, null);
        }
        public DataTable DSNhom()
        {
            return db.ExcuteQuery("Select MaNhom,TenNhom From Nhom Where MaNhom != 10 And MaNhom != 4 And MaNhom != 5 And MaNhom != 6"+
                " And MaNhom != 11 And MaNhom != 13 And MaNhom != 14 And MaNhom != 15",
                CommandType.Text, null);
        }
        public DataTable DSDVKT()
        {
            return db.ExcuteQuery("Select * From DichVuKyThuat Where Ma_CS = '"+MaCS+"'",
                CommandType.Text, null);
        }
        public DataTable DSNhomCanLamSan()
        {
            return db.ExcuteQuery("Select * From NhomCanLamSan Where MaCoSo = '" + MaCS + "'",
                CommandType.Text, null);
        }
        public bool SpDichVuKyThuat(ref string err, string Action)
        {
            return db.MyExecuteNonQuery("SpDichVuKyThuat",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@Action", Action),
                new SqlParameter("@MaDVKT", MaDVKT),
                new SqlParameter("@TenDVKT", TenDVKT),
                new SqlParameter("@DonGia", DonGia),
                new SqlParameter("@Ma_CS", MaCS),
                new SqlParameter("@TinhTrang", TinhTrang),
                new SqlParameter("@MaNhom", MaNhom),
                new SqlParameter("@TT50",TT50),
                new SqlParameter("@MaNhomCLS", MaNhomCLS));
        }
    }
}
