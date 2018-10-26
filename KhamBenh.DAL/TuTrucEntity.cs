using Core.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhamBenh.DAL
{
    public class TuTrucEntity
    {
        Connection db;
        public TuTrucEntity()
        {
            db = new Connection();
        }
        public string MaKhoa { get; set; }
        public string MaBV { get; set; }
        public int SoLuong { get; set; }
        public DataTable DSKhoaBan(int loaiPhong)
        {
            string sql = "";
            sql = "EXEC SpGetKhoaBan '" + AppConfig.CoSoKCB + "'," + loaiPhong;
            return db.ExcuteQuery(sql,
                CommandType.Text, null);
        }
        public DataTable DSThuoc()
        {
            return db.ExcuteQuery("select VatTu.MaBV,TenVatTu,HamLuong,SoLuong,Tu.MaBV as MaBVTu " +
                        "from (select MaBV,TenVatTu,HamLuong from VatTu " +
                                "where LoaiVatTu = '1' and KeDon=1 and TinhTrang=1)VatTu left join " +
                        "(select * from TuTruc where MaKhoa = '" + MaKhoa + "') as Tu " +
                        "on VatTu.MaBV = Tu.MaBV",
                CommandType.Text, null);
        }
        public bool SpTuTruc(ref string err, string Action)
        {
            return db.MyExecuteNonQuery("SpTuTruc",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@Action", Action),
                new SqlParameter("@MaBV", MaBV),
                new SqlParameter("@MaKhoa", MaKhoa),
                new SqlParameter("@SoLuong", SoLuong));
        }
    }
}
