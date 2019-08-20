using Core.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoCao.DAL
{
    public class TongHopKeDonEntity
    {
        Connection db;
        public TongHopKeDonEntity()
        {
            db = new Connection();
        }
        public DataTable DSKhoaBan(int loaiPhong)
        {
            string sql = "";
            sql = "EXEC SpGetKhoaBan '" + AppConfig.CoSoKCB + "'," + loaiPhong;
            return db.ExcuteQuery(sql,
                CommandType.Text, null);
        }
        public DataTable DSBacSi(string MaKhoa, DateTime ngayYLenh)
        {
            return db.ExcuteQuery("Select * From DSBacSiKeDon('" + MaKhoa + "','" + ngayYLenh + "') Order by Ten_NV DESC",
                CommandType.Text, null);
        }
        public DataTable DSBacSi(string MaKhoa, DateTime tuNgay, DateTime denNgay)
        {
            return db.ExcuteQuery("Select * From DSBacSiKeDonNgay('" + MaKhoa + "','" + tuNgay + "','" + denNgay + "') Order by Ten_NV DESC",
                CommandType.Text, null);
        }
    }
}
