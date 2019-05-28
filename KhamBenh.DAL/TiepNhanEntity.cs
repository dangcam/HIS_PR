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
    public class TiepNhanEntity
    {
        Connection db;
        public TiepNhanEntity()
        {
            db = new Connection();
        }
        // Thông Tin Thẻ
        public string MaBN { get; set; }
        public bool CoThe { get; set; }
        public string MaThe { get; set; }
        public string HoTen { get; set; }
        public string NgaySinh { get; set; }
        public int GioiTinh { get; set; }
        public string DiaChi { get; set; }
        public DateTime TheTu { get; set; }
        public DateTime TheDen { get; set; }
        public string MaCS { get; set; }
        public DateTime Du5Nam { get; set; }
        public string MaKhuVuc { get; set; }
        // Thông tin hồ sơ bệnh nhân
        public string MaLK { get; set; }
        public int LyDoVaoVien { get; set; }
        public string MaNoiChuyenDen { get; set; }
        public int MaTaiNan { get; set; }
        public string MienCungCT { get; set; }
        public DateTime NgayVao { get; set; }
        public int MucHuong { get; set; }
        public int MaLoaiKCB { get; set; }
        public string MaKhoa { get; set; }
        public string MaCoSoKCB { get; set; }
        public double CanNang { get; set; }
        public string STTNgay { get; set; }
        public int STTPhong { get; set; }
        public int TinhTrang { get; set; }
        public int Phong { get; set; }

        public string TinhTrangRaVien { get; set; }
        public DataTable DSTaiNan()
        {
            return db.ExcuteQuery("Select * From TaiNan ",
                CommandType.Text, null);
        }
        public DataTable DSCoSoKCB()
        {
            return db.ExcuteQuery("Select Ma_CS,Ten_CS From CoSoKCB ",
                CommandType.Text, null);
        }
        public DataTable DSKhoaBan(int loaiPhong)
        {
            string sql = "";
            sql = "EXEC SpGetKhoaBan '"+AppConfig.CoSoKCB+"'," +loaiPhong;
            return db.ExcuteQuery(sql,
                CommandType.Text, null);
        }
        public DataTable DSMucHuong()
        {
            return db.ExcuteQuery("Select Ma, MaHieu, TyLe From MucHuong ",
                CommandType.Text, null);
        }
        public DataTable DSTinh()
        {
            return db.ExcuteQuery("Select Ma From MaTinh ",
                CommandType.Text, null);
        }
        public DataTable DSTiepNhan(string ngayVao)
        {
            return db.ExcuteQuery("Select MaLK,MaBN,HoTen,NgaySinh,GioiTinh,DiaChi,MaThe,MaDKBD,TheTu,TheDen,MienCungCT,"+
                "TenBenh,MaBenh,MaLyDoVaoVien,MaNoiChuyenDen,MaTaiNan,NgayVao,NgayRa,KetQuaDieuTri,"+
                "TinhTrangRaVien,NgayThanhToan,MucHuong,MaLoaiKCB,MaKhoa,MaCoSoKCB,MaKhuVuc,STTNgay,"+
                "STTPhong,Phong,TinhTrang,CoThe,CanNang From ThongTinBNChiTiet Where CAST(NgayVao AS DATE) = CAST('"
                + ngayVao+"' AS DATE) And MaCoSoKCB = '"+AppConfig.CoSoKCB+"'  Order By STTNgay ASC",
                CommandType.Text, null);
        }
        public DataTable DSTiepNhan(string ngayBT, string ngayKT)
        {
            return db.ExcuteQuery("Select MaLK,MaBN,HoTen,NgaySinh,GioiTinh,DiaChi,MaThe,MaDKBD,TheTu,TheDen,MienCungCT," +
                "TenBenh,MaBenh,MaLyDoVaoVien,MaNoiChuyenDen,MaTaiNan,NgayVao,NgayRa,KetQuaDieuTri," +
                "TinhTrangRaVien,NgayThanhToan,MucHuong,MaLoaiKCB,MaKhoa,MaCoSoKCB,MaKhuVuc,CanNang,STTNgay," +
                "STTPhong,Phong,TinhTrang,CoThe From ThongTinBNChiTiet Where CAST(NgayVao AS DATE) Between  CAST('"
                + ngayBT + "' AS DATE) And  CAST('"+ ngayKT + "' AS DATE) And MaCoSoKCB = '" + AppConfig.CoSoKCB + "'  Order By STTNgay ASC",
                CommandType.Text, null);
        }
        public DataTable DSLichSuPhanMem()
        {
            return db.ExcuteQuery("select MaLK as maHoSo,MaCoSoKCB as maCSKCB,"
            + "NgayVao as tuNgay, NgayRa as denNgay, TenBenh as tenBenh, "
            + "TinhTrangRaVien as tinhTrang, KetQuaDieuTri as kqDieuTri "
            + "from ThongTinBNChiTiet "
            + "where MaBN = '"+MaBN+"' ",
            //+ "or(dbo.ChangeVietnameseWord(N'"+HoTen+"') = dbo.ChangeVietnameseWord(HoTen) "
            //+ "AND '"+NgaySinh+"' = NgaySinh AND GioiTinh = "+GioiTinh+")",
                CommandType.Text, null);
        }
        public bool SpThongTinBN(ref string err, string Action)
        {
            return db.MyExecuteNonQuery("SpThongTinBN",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@Action", Action),
                new SqlParameter("@MaBN", MaBN),
                new SqlParameter("@CoThe", CoThe),
                new SqlParameter("@MaThe", MaThe),
                new SqlParameter("@HoTen", HoTen),
                new SqlParameter("@NgaySinh", NgaySinh),
                new SqlParameter("@DiaChi", DiaChi),
                new SqlParameter("@TheTu", TheTu),
                new SqlParameter("@TheDen", TheDen),
                new SqlParameter("@MaCS", MaCS),
                new SqlParameter("@Du5Nam", Du5Nam),
                new SqlParameter("@MaKhuVuc", MaKhuVuc));
        }
        public bool SpThongTinTiepNhan(ref string err)
        {
            SqlParameter outMaBN = new SqlParameter();
            outMaBN.SqlDbType = System.Data.SqlDbType.VarChar;
            outMaBN.Size = 15;
            outMaBN.ParameterName = "@MaBN";
            outMaBN.Value = MaBN;
            outMaBN.Direction = ParameterDirection.InputOutput;
            bool kq = db.MyExecuteNonQuery("SpThongTinTiepNhan",
                CommandType.StoredProcedure, ref err,
                outMaBN,
                new SqlParameter("@CoThe", CoThe),
                new SqlParameter("@MaThe", MaThe),
                new SqlParameter("@HoTen", HoTen),
                new SqlParameter("@NgaySinh", NgaySinh),
                new SqlParameter("@GioiTinh", GioiTinh),
                new SqlParameter("@DiaChi", DiaChi),
                new SqlParameter("@TheTu", TheTu),
                new SqlParameter("@TheDen", TheDen),
                new SqlParameter("@MaCS", MaCS),
                new SqlParameter("@Du5Nam", Du5Nam),
                new SqlParameter("@MaKhuVuc", MaKhuVuc),
                new SqlParameter("@MaCoSoBV",AppConfig.CoSoKCB));
            this.MaBN = Utils.ToString(outMaBN.Value);
            return kq;
        }
        public bool SpThongTinChiTietTiepNhan(ref string err)
        {
            // mã liên kết
            SqlParameter outMaLK = new SqlParameter();
            outMaLK.SqlDbType = System.Data.SqlDbType.VarChar;
            outMaLK.Size = 100;
            outMaLK.ParameterName = "@MaLK";
            outMaLK.Value = MaLK;
            outMaLK.Direction = ParameterDirection.InputOutput;
            // số thứ tự ngày
            SqlParameter outSTTNgay = new SqlParameter();
            outSTTNgay.SqlDbType = System.Data.SqlDbType.VarChar;
            outSTTNgay.Size = 12;
            outSTTNgay.ParameterName = "@STTNgay";
            outSTTNgay.Value = STTNgay;
            outSTTNgay.Direction = ParameterDirection.InputOutput;
            // số thứ tự phiếu theo phòng
            SqlParameter outSTTPhong = new SqlParameter();
            outSTTPhong.SqlDbType = System.Data.SqlDbType.Int;
            outSTTPhong.ParameterName = "@STTPhong";
            outSTTPhong.Value = STTPhong;
            outSTTPhong.Direction = ParameterDirection.InputOutput;
            bool kq = db.MyExecuteNonQuery("SpThongTinBNChiTiet",
               CommandType.StoredProcedure, ref err,
               new SqlParameter("@Action", "Insert"),
               outMaLK,
               new SqlParameter("@MaBN", MaBN),
               new SqlParameter("@HoTen", HoTen),
               new SqlParameter("@NgaySinh", NgaySinh),
               new SqlParameter("@GioiTinh", GioiTinh),
               new SqlParameter("@DiaChi", DiaChi),
               new SqlParameter("@MaThe", MaThe),
               new SqlParameter("@MaDKBD", MaCS),
               new SqlParameter("@TheTu", TheTu),
               new SqlParameter("@TheDen", TheDen),
               new SqlParameter("@MienCungCT", MienCungCT),
               //new SqlParameter("@TenBenh", TenBenh),
               //new SqlParameter("@MaBenh", MaBenh),
               //new SqlParameter("@MaBenhKhac", MaBenhKhac),
               new SqlParameter("@MaLyDoVaoVien", LyDoVaoVien),
               new SqlParameter("@MaNoiChuyenDen", MaNoiChuyenDen),
               new SqlParameter("@MaTaiNan", MaTaiNan),
               new SqlParameter("@NgayVao", NgayVao),
               //new SqlParameter("@NgayRa", NgayRa),
               //new SqlParameter("@SoNgayDieuTri", SoNgayDieuTri),
               //new SqlParameter("@KetQuaDieuTri", KetQuaDieuTri),
               new SqlParameter("@TinhTrangRaVien", TinhTrangRaVien),
               //new SqlParameter("@NgayThanhToan", NgayThanhToan),
               new SqlParameter("@MucHuong", MucHuong),
               //new SqlParameter("@TienThuoc", TienThuoc),
               //new SqlParameter("@TienVTYT", TienVTYT),
               //new SqlParameter("@TongChi", TongChi),
               //new SqlParameter("@TienBNTT", TienBNTT),
               //new SqlParameter("@TienBHTT", TienBHTT),
               //new SqlParameter("@TienNguonKhac", TienNguonKhac),
               //new SqlParameter("@TienNgoaiDS", TienNgoaiDS),
               //new SqlParameter("@NamQT", NamQT),
               //new SqlParameter("@ThangQT", ThangQT),
               new SqlParameter("@MaLoaiKCB", MaLoaiKCB),
               new SqlParameter("@MaKhoa", MaKhoa),
               new SqlParameter("@MaCoSoKCB", MaCoSoKCB),
               new SqlParameter("@MaKhuVuc", MaKhuVuc),
               //new SqlParameter("@MaPTTTTQT", MaPTTTTQT),
               new SqlParameter("@CanNang", CanNang),
               outSTTNgay,
               outSTTPhong,
               new SqlParameter("@Phong", Phong),
               new SqlParameter("@TinhTrang", TinhTrang),
               new SqlParameter("@CoThe", CoThe));
            // gán giá trị out
            if (kq == true)
            {
                this.MaLK = Utils.ToString(outMaLK.Value);
                this.STTNgay = Utils.ToString(outSTTNgay.Value);
                this.STTPhong = Utils.ToInt(outSTTPhong.Value);
            }
            return kq;
        }
        public bool SpThongTinChiTietTiepNhan(ref string err, string Action)
        {
            // mã liên kết
            return db.MyExecuteNonQuery("SpThongTinBNChiTiet",
               CommandType.StoredProcedure, ref err,
               new SqlParameter("@Action", Action),
               new SqlParameter("@MaLK", MaLK),
               new SqlParameter("@MaBN", MaBN),
               new SqlParameter("@HoTen", HoTen),
               new SqlParameter("@NgaySinh", NgaySinh),
               new SqlParameter("@GioiTinh", GioiTinh),
               new SqlParameter("@DiaChi", DiaChi),
               new SqlParameter("@MaThe", MaThe),
               new SqlParameter("@MaDKBD", MaCS),
               new SqlParameter("@TheTu", TheTu),
               new SqlParameter("@TheDen", TheDen),
               new SqlParameter("@MienCungCT", MienCungCT),
               //new SqlParameter("@TenBenh", TenBenh),
               //new SqlParameter("@MaBenh", MaBenh),
               //new SqlParameter("@MaBenhKhac", MaBenhKhac),
               new SqlParameter("@MaLyDoVaoVien", LyDoVaoVien),
               new SqlParameter("@MaNoiChuyenDen", MaNoiChuyenDen),
               new SqlParameter("@MaTaiNan", MaTaiNan),
               new SqlParameter("@NgayVao", NgayVao),
               //new SqlParameter("@NgayRa", NgayRa),
               //new SqlParameter("@SoNgayDieuTri", SoNgayDieuTri),
               //new SqlParameter("@KetQuaDieuTri", KetQuaDieuTri),
               //new SqlParameter("@TinhTrangRaVien", TinhTrangRaVien),
               //new SqlParameter("@NgayThanhToan", NgayThanhToan),
               new SqlParameter("@MucHuong", MucHuong),
               //new SqlParameter("@TienThuoc", TienThuoc),
               //new SqlParameter("@TienVTYT", TienVTYT),
               //new SqlParameter("@TongChi", TongChi),
               //new SqlParameter("@TienBNTT", TienBNTT),
               //new SqlParameter("@TienBHTT", TienBHTT),
               //new SqlParameter("@TienNguonKhac", TienNguonKhac),
               //new SqlParameter("@TienNgoaiDS", TienNgoaiDS),
               //new SqlParameter("@NamQT", NamQT),
               //new SqlParameter("@ThangQT", ThangQT),
               new SqlParameter("@MaLoaiKCB", MaLoaiKCB),
               new SqlParameter("@MaKhoa", MaKhoa),
               new SqlParameter("@MaCoSoKCB", MaCoSoKCB),
               new SqlParameter("@MaKhuVuc", MaKhuVuc),
               //new SqlParameter("@MaPTTTTQT", MaPTTTTQT),
               new SqlParameter("@CanNang", CanNang),
               new SqlParameter("@STTNgay", STTNgay),
               new SqlParameter("@STTPhong", STTPhong),
               new SqlParameter("@Phong", Phong),
               new SqlParameter("@TinhTrang", TinhTrang),
               new SqlParameter("@CoThe", CoThe));
        }
        public DataTable LayLichSuNamVien(string maThe)
        {
            return db.ExcuteQuery("Select * From ThongTinBNChiTiet Where MaThe = '" + maThe + "' And NgayThanhToan is null",
               CommandType.Text, null);
        }
        public void LayThongTinCoThe(string maThe, string ngayVao)
        {
            DataTable data = db.ExcuteQuery("Select * From LayThongTinCoThe('" + maThe + "','" + ngayVao + "')",
               CommandType.Text, null);
            this.MaBN = null;
            this.MaLK = null;
            if(data!=null && data.Rows.Count>0)
            {
                this.MaBN = data.Rows[0]["MaBN"].ToString();
                this.MaLK = Utils.ToString(data.Rows[0]["MaLK"]);
                this.HoTen = data.Rows[0]["HoTen"].ToString();
                this.NgaySinh = data.Rows[0]["NgaySinh"].ToString();
                this.GioiTinh =Utils.ToInt( data.Rows[0]["GioiTinh"].ToString());
                this.DiaChi = data.Rows[0]["DiaChi"].ToString();
                this.TheTu = Utils.ToDateTime(data.Rows[0]["TheTu"].ToString());
                this.TheDen = Utils.ToDateTime(data.Rows[0]["TheDen"].ToString());
                this.MaCS = data.Rows[0]["MaCS"].ToString();
                this.Du5Nam = Utils.ToDateTime( data.Rows[0]["Du5Nam"].ToString());
                this.MaKhuVuc = data.Rows[0]["MaKhuVuc"].ToString();
            }
        }
        public bool LayThongTinKhongThe(string maBN)
        {
            this.MaBN = null;
            DataTable data = db.ExcuteQuery("Select * From ThongTinBN Where MaBN = '" + maBN + "'",
               CommandType.Text, null);
            if (data != null && data.Rows.Count > 0)
            {
                this.MaBN = data.Rows[0]["MaBN"].ToString();
                this.HoTen = data.Rows[0]["HoTen"].ToString();
                this.NgaySinh = data.Rows[0]["NgaySinh"].ToString();
                this.GioiTinh = Utils.ToInt(data.Rows[0]["GioiTinh"].ToString());
                this.DiaChi = data.Rows[0]["DiaChi"].ToString();
                this.CoThe = Utils.ToBoolean(data.Rows[0]["CoThe"]);
                if (this.CoThe)
                {
                    this.MaThe = data.Rows[0]["MaThe"].ToString();
                    this.TheTu =Utils.ToDateTime( data.Rows[0]["TheTu"].ToString());
                    this.TheDen = Utils.ToDateTime(data.Rows[0]["TheDen"].ToString());
                    this.MaCS = data.Rows[0]["MaCS"].ToString();
                    this.Du5Nam = Utils.ToDateTime(data.Rows[0]["Du5Nam"].ToString());
                    this.MaKhuVuc = data.Rows[0]["MaKhuVuc"].ToString();
                }
                return true;
            }
            return false;
        }
    }
}
