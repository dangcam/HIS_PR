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
    public class ThanhToanEntity
    {
        Connection db;
        public ThanhToanEntity()
        {
            db = new Connection();
        }
        public string MaLK { get; set; }
        public string MaDichVu { get; set; }
        public string TenDichVu { get; set; }
        public int MaNhom { get; set; }
        public string DonViTinh { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public int TyLe { get; set; }
        public decimal ThanhTien { get; set; }
        public string MaKhoa { get; set; }
        public string MaBacSi { get; set; }
        public DateTime NgayYLenh { get; set; }
        public DateTime NgayKQ { get; set; }
        //
        public int MucHuong { get; set; }
        public string MaBenh { get; set; }
        public string TenBenh { get; set; }
        public DateTime NgayRa { get; set; }
        public DateTime NgayVao { get; set; }
        public int SoNgayDieuTri { get; set; }
        public int KetQuaDieuTri { get; set; }
        public int TinhTrangRaVien { get; set; }
        public int LyDoVaoVien { get; set; }
        public DateTime NgayThanhToan { get; set; }
        public decimal TienThuoc { get; set; }
        public decimal TienVTYT { get; set; }
        public decimal TongChi { get; set; }
        public decimal TienBNTT { get; set; }
        public decimal TienBNCCT { get; set; }
        public decimal TienBHTT { get; set; }
        public decimal TienNguonKhac { get; set; }
        public decimal TienNgoaiDS { get; set; }
        public string NamQT { get; set; }
        public string ThangQT { get; set; }
        //
        public string HoTen { get; set; }
        public string NgaySinh { get; set; }
        public int GioiTinh { get; set; }
        public string DiaChi { get; set; }
        public string MaThe { get; set; }
        public string MaDKBD { get; set; }
        public DateTime TheTu { get; set; }
        public DateTime TheDen { get; set; }
        public string MienCungCT { get; set; }
        public string MaKhuVuc { get; set; }
        public float CanNang { get; set; }
        public bool CoThe { get; set; }
        public int SoPhieu { get; set; }
        public int SoPhieuNhap { get; set; }
        public string MaVatTu { get; set; }
        //
        public DataTable DSTaiNan()
        {
            return db.ExcuteQuery("Select * From TaiNan ",
                CommandType.Text, null);
        }
        public DataTable DSNhom()
        {
            return db.ExcuteQuery("Select * From Nhom ",
                CommandType.Text, null);
        }
        public DataTable DSCoSoKCB()
        {
            return db.ExcuteQuery("Select Ma_CS,Ten_CS From CoSoKCB ",
                CommandType.Text, null);
        }
        public DataTable DSBacSi()
        {
            return db.ExcuteQuery("Select Ma_BS, Ten_NV From NhanVien Where TinhTrang=1 And LEN(Ma_BS) > 0 Order by Ten_NV DESC",
                CommandType.Text, null);
            //return db.ExcuteQuery("Select Ma_BS, Ten_NV From NhanVien Where TinhTrang=1 And CoSoKCB = '"
            //    + AppConfig.CoSoKCB + "' And LEN(Ma_BS) > 0",
            //    CommandType.Text, null);
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
        public DataTable DSKhoaBan(int loaiPhong)
        {
            string sql = "";
            sql = "EXEC SpGetKhoaBan '" + AppConfig.CoSoKCB + "'," + loaiPhong;
            return db.ExcuteQuery(sql,
                CommandType.Text, null);
        }
        public DataTable DSBenh()
        {
            return db.ExcuteQuery("Select MaBenh,TenBenh From BenhICD ",
                CommandType.Text, null);
        }
        public string LuongCoSo()
        {
            DataTable dt = db.ExcuteQuery("Select Luong_CS From LuongCoSo Where Ma_CS = '"+AppConfig.CoSoKCB+"' ",
                CommandType.Text, null);
            if (dt != null && dt.Rows.Count > 0)
            {
                return dt.Rows[0]["Luong_CS"].ToString();
            }
            return "0";
        }
        public DataTable DSDuongDung()
        {
            return db.ExcuteQuery("Select * From DuongDung ",
                CommandType.Text, null);
        }
        public DataTable DSBenhNhan(DateTime tuNgay, DateTime denNgay, int maLoaiKCB,int timTheo)
        {
            string sql = "Select ROW_NUMBER() OVER(ORDER BY STTNgay) STT,* " +
                "From ThongTinBNChiTiet Where MaCoSoKCB = '" + AppConfig.CoSoKCB + "' ";
            if(maLoaiKCB==0)
            {
                sql += "And MaLoaiKCB = 1 ";
            }
            else
            {
                sql += "And MaLoaiKCB != 1 ";
            }
            if(timTheo==0)
            {
                sql += "And CONVERT(Date,NgayVao) Between CONVERT(Date,'" + tuNgay + "') And CONVERT(Date,'" + denNgay + "')";
            }else
                if(timTheo==1)
            {
                sql += "And CONVERT(Date,NgayRa) Between CONVERT(Date,'" + tuNgay + "') And CONVERT(Date,'" + denNgay + "')";
            }
            else
            {
                sql += "And CONVERT(Date,NgayThanhToan) Between CONVERT(Date,'" + tuNgay + "') And CONVERT(Date,'" + denNgay + "')";
            }

            return db.ExcuteQuery(sql,
                CommandType.Text, null);
        }
        public DataTable DSCongKhamChiTiet()
        {
            return db.ExcuteQuery("Select * From DichVuChiTiet Where MaLK ='"+this.MaLK+"' " +
                "And MaNhom = 13",
                CommandType.Text, null);
        }
        public DataTable DSCongKham()
        {
            return db.ExcuteQuery("Select * From " +
                "(Select Ma,Ten,DonGia,MaNhom " +
                "From CongKham Where TinhTrang =1) AS CK " +
                "LEFT JOIN " +
                "(Select MaDichVu,CONVERT(bit,1) as Chon From DichVuChiTiet Where MaLK ='" + this.MaLK + "' " +
                "And MaNhom = 13) AS CKCT ON CKCT.MaDichVu = CK.Ma",
                CommandType.Text, null);
            //return db.ExcuteQuery("Select * From " +
            //    "(Select Ma,Ten,DonGia,MaNhom " +
            //    "From CongKham Where Ma_CS = '" + AppConfig.CoSoKCB + "' And TinhTrang =1) AS CK " +
            //    "LEFT JOIN " +
            //    "(Select MaDichVu,CONVERT(bit,1) as Chon From DichVuChiTiet Where MaLK ='" + this.MaLK + "' " +
            //    "And MaNhom = 13) AS CKCT ON CKCT.MaDichVu = CK.Ma",
            //    CommandType.Text, null);
        }
        public DataTable DSDichVuChiTiet()
        {
            // không có công khám
            return db.ExcuteQuery("Select * From DichVuChiTiet Where MaLK ='" + this.MaLK + "' " +
                "And MaNhom != 13",
                CommandType.Text, null);
        }
        public DataTable DSVTYTChiTiet()
        {
            return db.ExcuteQuery("Select * From VatTuChiTiet Where MaLK ='" + this.MaLK + "' ",
                CommandType.Text, null);
        }
        public DataTable DSThuocChiTiet()
        {
            return db.ExcuteQuery("Select * From DonThuocChiTiet Where MaLK ='" + this.MaLK + "' ",
                CommandType.Text, null);
        }
        public bool XoaHoSo(ref string err)
        {
            return db.BackUpOrRestore("Delete From ThongTinBNChiTiet Where MaLK ='" + this.MaLK + "' ",
                 ref err);
        }
        public bool SpDichVuChiTiet(ref string err, string Action)
        {
            return db.MyExecuteNonQuery("SpDichVuChiTiet",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@Action", Action),
                new SqlParameter("@MaLK", MaLK),
                new SqlParameter("@MaDichVu", MaDichVu),
                new SqlParameter("@MaNhom", MaNhom),
                new SqlParameter("@TenDichVu", TenDichVu),
                new SqlParameter("@DonViTinh", DonViTinh),
                new SqlParameter("@SoLuong", SoLuong),
                new SqlParameter("@DonGia", DonGia),
                new SqlParameter("@TyLe", TyLe),
                new SqlParameter("@ThanhTien", ThanhTien),
                //new SqlParameter("@MucHuong", ),
                //new SqlParameter("@TienNguonKhac", ),
                //new SqlParameter("@TienBNTT", ),
                //new SqlParameter("@TienBHTT", ),
                //new SqlParameter("@TienBNCCT", ),
                //new SqlParameter("@TienNgoaiDS", ),
                new SqlParameter("@MaKhoa", MaKhoa),
                //new SqlParameter("@MaGiuong", MaGiuong),
                new SqlParameter("@MaBacSi", MaBacSi),
                new SqlParameter("@NgayYLenh", NgayYLenh),
                new SqlParameter("@NgayKQ", NgayKQ)
                //new SqlParameter("@MaChiSo", MaChiSo),
                //new SqlParameter("@GiaTri", GiaTri),
                //new SqlParameter("@MaMay", MaMay),
                //new SqlParameter("@MoTa", MoTa),
                //new SqlParameter("@KetLuan", KetLuan)
                );
        }
        public bool SpThanhToan(ref string err, string Action)
        {
            return db.MyExecuteNonQuery("SpThanhToan",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@Action", Action),
                new SqlParameter("@MaLK", MaLK),
                new SqlParameter("@HoTen", HoTen),
                new SqlParameter("@NgaySinh", NgaySinh),
                new SqlParameter("@GioiTinh", GioiTinh),
                new SqlParameter("@DiaChi", DiaChi),
                new SqlParameter("@MaThe", MaThe),
                new SqlParameter("@MaDKBD", MaDKBD),
                new SqlParameter("@TheTu", TheTu),
                new SqlParameter("@TheDen", TheDen),
                new SqlParameter("@MienCungCT", MienCungCT),
                new SqlParameter("@TenBenh", TenBenh),
                new SqlParameter("@MaBenh", MaBenh),
                new SqlParameter("@NgayRa", NgayRa),
                new SqlParameter("@NgayVao", NgayVao),
                new SqlParameter("@SoNgayDieuTri", SoNgayDieuTri),
                new SqlParameter("@KetQuaDieuTri", KetQuaDieuTri),
                new SqlParameter("@TinhTrangRaVien", TinhTrangRaVien),
                new SqlParameter("@NgayThanhToan", NgayThanhToan),
                new SqlParameter("@MucHuong", MucHuong),
                new SqlParameter("@TienThuoc", TienThuoc),
                new SqlParameter("@TienVTYT", TienVTYT),
                new SqlParameter("@TongChi", TongChi),
                new SqlParameter("@TienBNTT", TienBNTT),
                new SqlParameter("@TienBNCCT", TienBNCCT),
                new SqlParameter("@TienBHTT", TienBHTT),
                new SqlParameter("@TienNguonKhac", TienNguonKhac),
                new SqlParameter("@TienNgoaiDS", TienNgoaiDS),
                new SqlParameter("@NamQT", NamQT),
                new SqlParameter("@ThangQT", ThangQT),
                new SqlParameter("@MaKhuVuc", MaKhuVuc),
                new SqlParameter("@CanNang",CanNang ),
                new SqlParameter("@CoThe", CoThe),
                new SqlParameter("@SoPhieu", SoPhieu),
                new SqlParameter("@SoPhieuNhap", SoPhieuNhap),
                new SqlParameter("@MaVatTu", MaVatTu),
                new SqlParameter("@TyLe", TyLe));
        }
        // tạo XML 
        public DataTable DSThuoc(string maLK)
        {
            return db.ExcuteQuery("SELECT ROW_NUMBER() OVER(ORDER BY MaVatTu) STT," +
                "MaLK,MaVatTu,MaThuoc,MaNhom,TenThuoc,DonViTinh,HamLuong,MaDuongDung," +
                "LieuDung,SoDK,TTinThau,PhamVi,SUM(SoLuong) as SoLuong,DonGia,TyLe,SUM(ThanhTien) as ThanhTien,MucHuong," +
                "SUM(TienNguonKhac) as TienNguonKhac,SUM(TienBNTT) as TienBNTT,SUM(TienBHTT) as TienBHTT," +
                "SUM(TienBNCCT) as TienBNCCT,SUM(TienNgoaiDS) as TienNgoaiDS," +
                "MaKhoa,MaBacSi,NgayYLenh,MaPTTT " +
                "FROM HIS_PR.dbo.DonThuocChiTiet Where MaLK='" + maLK + "' " +
                "GROUP BY MaLK,MaVatTu,MaThuoc,MaNhom,TenThuoc,DonViTinh,HamLuong,MaDuongDung,LieuDung,SoDK," +
                "TTinThau,PhamVi,DonGia,TyLe,MucHuong,MaKhoa,MaBacSi,NgayYLenh,MaPTTT", CommandType.Text, null);
        }
        public DataTable DSHoSoCanLamSan(string maLK)
        {
            return db.ExcuteQuery("SELECT ROW_NUMBER() OVER(ORDER BY MaDichVu) STT, * FROM HoSoCanLamSan " +
                "Where MaLK = '" + maLK + "'", CommandType.Text, null);
        }
        public DataTable ThongTinBN(string maLK)
        {
            return db.ExcuteQuery("SELECT MaLK,ROW_NUMBER() OVER(ORDER BY MaLK) STT,* FROM ThongTinBNChiTiet " +
                "Where MaLK = '" + maLK + "'", CommandType.Text, null);
        }
        public DataTable DSVatTu(string maLK)
        {
            return db.ExcuteQuery("SELECT MaLK,ROW_NUMBER() OVER(ORDER BY MaVatTu) STT,'' as MaDichVu," +
                "MaVT,MaNhom,GoiVTYT,TenVatTu,'' as TenDichVu,DonViTinh,PhamVi,SoLuong,DonGia,TTinThau," +
                "TyLe,SUM(ThanhTien) as ThanhTien,TTrantT,MucHuong," +
                "SUM(TienNguonKhac) as TienNguonKhac,SUM(TienBNTT) as TienBNTT,SUM(TienBHTT) as TienBHTT," +
                "SUM(TienBNCCT) as TienBNCCT,SUM(TienNgoaiDS) as TienNgoaiDS," +
                "MaKhoa,'' as MaGiuong,MaBacSi,NgayYLenh,NgayYLenh as NgayKQ,MaPTTT " +
                "FROM VatTuChiTiet WHERE MaLK = '" + maLK + "' " +
                "GROUP BY MaLK, MaVatTu, MaVT, MaNhom, GoiVTYT, TenVatTu, DonViTinh, PhamVi, SoLuong, DonGia," +
                "TTinThau, TyLe, TTrantT, MucHuong," +
                "MaKhoa, MaBacSi, NgayYLenh, MaPTTT", CommandType.Text, null);
        }
        public DataTable DSDichVu(string maLK)
        {
            return db.ExcuteQuery("SELECT  MaLK,ROW_NUMBER() OVER(ORDER BY MaDichVu) STT,MaDichVu,'' as MaVT,MaNhom," +
                "'' as GoiVTYT,'' as TenVatTu,TenDichVu,DonViTinh,1 as PhamVi,SoLuong,DonGia,'' as TTinThau,TyLe," +
                "ThanhTien,'' as TTrantT,MucHuong,TienNguonKhac,TienBNTT,TienBHTT,TienBNCCT,TienNgoaiDS," +
                "MaKhoa,MaGiuong,MaBacSi,NgayYLenh,NgayKQ,MaPTTT " +
                "FROM DichVuChiTiet Where MaLK = '" + maLK + "'", CommandType.Text, null);
        }
        public DataTable DSLichSuPhanMem(string MaBN, string HoTen, int GioiTinh)
        {
            return db.ExcuteQuery("select MaLK as maHoSo,MaCoSoKCB as maCSKCB,"
            + "NgayVao as tuNgay, NgayRa as denNgay, TenBenh as tenBenh, "
            + "TinhTrangRaVien as tinhTrang, KetQuaDieuTri as kqDieuTri "
            + "from ThongTinBNChiTiet "
            + "where MaBN = '" + MaBN + "' "
            + "or(dbo.ChangeVietnameseWord(N'" + HoTen + "') = dbo.ChangeVietnameseWord(HoTen) "
            + "AND '01/11/1994' = NgaySinh AND GioiTinh = " + GioiTinh + ")",
                CommandType.Text, null);
        }
    }
}
