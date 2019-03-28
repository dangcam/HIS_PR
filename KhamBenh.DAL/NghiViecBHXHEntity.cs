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
    public class NghiViecBHXHEntity
    {
        Connection db;
        public NghiViecBHXHEntity()
        {
            db = new Connection();
        }
        public string MaLK { get; set; }
        public string MaCT { get; set; }
        public int SoPhieu { get; set; }
        public string MaBS { get; set; }
        public string MaSoBHXH { get; set; }
        public string TenCha { get; set; }
        public string TenMe { get; set; }
        public string PPDieuTri { get; set; }
        public string MaDonVi { get; set; }
        public string TenDonVi { get; set; }
        public DateTime TuNgay { get; set; }
        public DateTime DenNgay { get; set; }
        public int SoNgay { get; set; }
        public DateTime NgayCT { get; set; }
        public string NguoiDaiDien { get; set; }
        public string MaBenh { get; set; }
        public DataTable DSBenh()
        {
            return db.ExcuteQuery("Select MaBenh,TenBenh From BenhICD ",
                CommandType.Text, null);
        }
        public DataTable NghiViec()
        {
            return db.ExcuteQuery("Select * From NghiViec Where MaLK = '"+MaLK+"' ",
                CommandType.Text, null);
        }
        public DataTable DSNghiViec()
        {
            return db.ExcuteQuery("select NghiViec.MaLK, ROW_NUMBER() OVER(ORDER BY SoPhieu ASC) AS STT," +
                "MaCT,SoPhieu,MaCoSoKCB,MaBS,MaSoBHXH,MaThe,HoTen,NgaySinh,MaBenh,NgayVao, " +
                "(GioiTinh+1) as GioiTinh,PPDieuTri,MaDonVi,TenDonVi,TuNgay,DenNgay,SoNgay,TenCha,TenMe,NgayCT,NguoiDaiDien " +
                "from ThongTinBNChiTiet,NghiViec where ThongTinBNChiTiet.MaLK = NghiViec.MaLK " +
                "and NgayCT Between '" + TuNgay + "' And '" + DenNgay + "' ",
                CommandType.Text, null);
        }
        public object SoChungTu()
        {
            DataTable dataTable = db.ExcuteQuery("Select (ISNULL(MAX(SoPhieu),0)+1) as SoCT from NghiViec where YEAR(NgayCT) = " + NgayCT.Year + " ",
                CommandType.Text, null);
            if(dataTable!=null && dataTable.Rows.Count>0)
            {
                return dataTable.Rows[0][0];
            }
            return 1;
        }
        public DataTable DSBacSi()
        {
            return db.ExcuteQuery("Select MaCC, Ten_NV From NhanVien Where TinhTrang=1 And CoSoKCB = '"
                + AppConfig.CoSoKCB + "' And LEN(MaCC) > 0 Order By Ten_NV DESC",
                CommandType.Text, null);
        }
        public bool SpCapNhatMaBenh(ref string err)
        {
            return db.MyExecuteNonQuery("SpCapNhatMaBenh",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@MaLK", MaLK),
                new SqlParameter("@MaBenh", MaBenh));
        }
        public bool SpNghiViec(ref string err, string Action)
        {
            return db.MyExecuteNonQuery("SpNghiViec",
                CommandType.StoredProcedure, ref err, 
                new SqlParameter("@Action", Action),
                new SqlParameter("@MaLK", MaLK),
                new SqlParameter("@MaCT", MaCT),
                new SqlParameter("@SoPhieu", SoPhieu),
                new SqlParameter("@MaBS", MaBS),
                new SqlParameter("@MaSoBHXH", MaSoBHXH),
                new SqlParameter("@TenCha", TenCha),
                new SqlParameter("@TenMe", TenMe),
                new SqlParameter("@PPDieuTri", PPDieuTri),
                new SqlParameter("@MaDonVi", MaDonVi),
                new SqlParameter("@TenDonVi", TenDonVi),
                new SqlParameter("@TuNgay", TuNgay),
                new SqlParameter("@DenNgay", DenNgay),
                new SqlParameter("@SoNgay", SoNgay),
                new SqlParameter("@NgayCT", NgayCT),
                new SqlParameter("@NguoiDaiDien", NguoiDaiDien));
        }
    }
}
