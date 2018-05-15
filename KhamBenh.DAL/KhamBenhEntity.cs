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
    public class KhamBenhEntity
    {
        Connection db;
        public KhamBenhEntity()
        {
            db = new Connection();
        }
        // thông tin chuyển phòng
        public string MaLK { get; set; }
        public DateTime NgayVao { get; set; }
        public int Phong { get; set; }
        // Nhập viện
        public int MaLoaiKCB { get; set; }
        public string MaKhoa { get; set; }
        // Ra viện
        public int KetQuaDieuTri { get; set; }
        public int TinhTrangRaVien { get; set; }
        public DateTime NgayRa { get; set; }
        // cận lâm sàn
        public string MaCSL { get; set; }
        public string MaBS { get; set; }
        public string ChuanDoan { get; set; }
        public string YeuCau { get; set; }
        public string NgayChiDinh { get; set; }
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
        public DataTable DSVatTuChiTiet()
        {
            return db.ExcuteQuery("Select * From VatTuChiTiet Where MaLK ='"+MaLK+"' ",
                CommandType.Text, null);
        }
        public DataTable DSDichVuChiTiet()
        {
            return db.ExcuteQuery("Select * From " +
                "(Select MaLK,MaDichVu,MaNhom,TenDichVu,DonViTinh,SoLuong,DonGia," +
                "ThanhTien,MaKhoa,MaGiuong,MaBacSi,NgayYLenh,NgayKQ" +
                " From DichVuChiTiet Where MaLK ='" + MaLK + "') AS DV" +
                " LEFT JOIN HoSoCanLamSan ON HoSoCanLamSan.MaDichVu = DV.MaDichVu",
                CommandType.Text, null);
        }
        public DataTable DSDichVuKyThuat()
        {
            return db.ExcuteQuery("Select DichVuChiTiet.MaDichVu,TenDichVu,GiaTri,MoTa,KetLuan,DonViTinh,SoLuong,DonGia," +
                "ThanhTien,MaKhoa,MaGiuong,MaBacSi,NgayYLenh,DichVuChiTiet.NgayKQ " +
                "From DichVuChiTiet,HoSoCanLamSan " +
                "Where DichVuChiTiet.MaLK ='" + MaLK + "' And DichVuChiTiet.MaDichVu = HoSoCanLamSan.MaDichVu " +
                "And HoSoCanLamSan.MaLK = '" + MaLK + "'",
                CommandType.Text, null);
        }
        public DataTable DSThuocChiTiet()
        {
            return db.ExcuteQuery("Select * From DonThuocChiTiet Where MaLK ='" + MaLK + "' ",
                CommandType.Text, null);
        }
        public string GetMaBacSi()
        {
            DataTable data = db.ExcuteQuery("Select Top 1 MaBacSi From DonThuocChiTiet Where MaLK ='" + MaLK + "' ", CommandType.Text, null);
            if(data!=null && data.Rows.Count>0)
            {
                return data.Rows[0][0].ToString();
            }
            data = db.ExcuteQuery("Select Top 1 MaBacSi From DichVuChiTiet Where MaLK ='" + MaLK + "' ", CommandType.Text, null);
            if (data != null && data.Rows.Count > 0)
            {
                return data.Rows[0][0].ToString();
            }
            data = db.ExcuteQuery("Select Top 1 MaBacSi From VatTuChiTiet Where MaLK ='" + MaLK + "' ", CommandType.Text, null);
            if (data != null && data.Rows.Count > 0)
            {
                return data.Rows[0][0].ToString();
            }
            return "";
        }
        public DataTable DSTiepNhan(string ngayVao, int phong)
        {
            return db.ExcuteQuery("Select MaLK,MaBN,HoTen,NgaySinh,GioiTinh,DiaChi,MaThe,MaDKBD,TheTu,TheDen," +
                "TenBenh,MaBenh,MaLyDoVaoVien,MaNoiChuyenDen,MaTaiNan,NgayVao,NgayRa,KetQuaDieuTri," +
                "TinhTrangRaVien,NgayThanhToan,MucHuong,MaLoaiKCB,MaKhoa,MaCoSoKCB,MaKhuVuc,STTNgay," +
                "STTPhong,Phong,TinhTrang,CoThe,CanNang From ThongTinBNChiTiet Where CAST(NgayVao AS DATE) = CAST('"
                + ngayVao + "' AS DATE) And (Phong = "+phong+" Or "+phong+ " = 0) And MaCoSoKCB='"+AppConfig.CoSoKCB+"'  Order By STTNgay ASC",
                CommandType.Text, null);
        }
        public DataTable DSBenhNhanNoiTru(string tuNgay, string denNgay, string maKhoa,int loai)
        {
            if (loai == 0)
                return db.ExcuteQuery("Select * From ThongTinBNChiTiet Where MaLoaiKCB > 1 And MaKhoa = '" + maKhoa + "' " +
                "And CONVERT(Date,NgayVao) Between CONVERT(Date,'" + tuNgay + "') And CONVERT(Date,'" + denNgay + "') " +
                "And MaCoSoKCB = '"+AppConfig.CoSoKCB+"'",
                CommandType.Text, null);
            else
                if (loai == 1)
                return db.ExcuteQuery("Select * From ThongTinBNChiTiet Where MaLoaiKCB > 1 And MaKhoa = '" + maKhoa + "' " +
                "And CONVERT(Date,NgayVao) Between CONVERT(Date,'" + tuNgay + "') And CONVERT(Date,'" + denNgay + "') And NgayRa is NULL " +
                "And MaCoSoKCB = '" + AppConfig.CoSoKCB + "'",
                CommandType.Text, null);
            else
                return db.ExcuteQuery("Select * From ThongTinBNChiTiet Where MaLoaiKCB > 1 And MaKhoa = '" + maKhoa + "' " +
                "And CONVERT(Date,NgayVao) Between CONVERT(Date,'" + tuNgay + "') And CONVERT(Date,'" + denNgay + "') And NgayRa is not NULL " +
                "And MaCoSoKCB = '" + AppConfig.CoSoKCB + "'",
                CommandType.Text, null);

        }
        public DataTable DSBenhNhanNoiTru(string maKhoa, int loai)
        {
            if(loai==0)
            return db.ExcuteQuery("Select * From ThongTinBNChiTiet Where MaLoaiKCB > 1 And MaKhoa = '" + maKhoa + "' " +
                //"And NgayRa is NULL " +
                "And MaCoSoKCB = '" + AppConfig.CoSoKCB + "'",
                CommandType.Text, null);
            else
                if(loai == 1)
                return db.ExcuteQuery("Select * From ThongTinBNChiTiet Where MaLoaiKCB > 1 And MaKhoa = '" + maKhoa + "' " +
                "And NgayRa is NULL " +
                "And MaCoSoKCB = '" + AppConfig.CoSoKCB + "'",
                CommandType.Text, null);
            else
                return db.ExcuteQuery("Select * From ThongTinBNChiTiet Where MaLoaiKCB > 1 And MaKhoa = '" + maKhoa + "' " +
                "And NgayRa is not NULL " +
                "And MaCoSoKCB = '" + AppConfig.CoSoKCB + "'",
                CommandType.Text, null);

        }
        public DataTable DSChiTietThuoc(string maKhoa, DateTime tuNgay, DateTime denNgay)
        {
            return db.ExcuteQuery("Select STTNgay,HoTen,SUBSTRING(NgaySinh, Len(NgaySinh)-3, 4) as NgaySinh," +
                                    "MaThe,CONVERT(VARCHAR,NgayYLenh,120) as NgayThanhToan,MaBenh,TenThuoc,SoLuong " +
                                    "from ThongTinBNChiTiet,DonThuocChiTiet " +
                                    "where ThongTinBNChiTiet.MaLK = DonThuocChiTiet.MaLK " +
                                    "And MaCoSoKCB='" + AppConfig.CoSoKCB + "' and ThongTinBNChiTiet.MaKhoa = '" + maKhoa + "' " +
                                    "And (convert(date,NgayYLenh) between convert(date,'" + tuNgay + "') and convert(date,'" + denNgay + "')) " +
                                    "And ThongTinBNChiTiet.NgayRa is NULL " +
                                    "order by STTNgay",
                CommandType.Text, null);

        }
        public DataTable CountSoLuongBN(string sql)
        {
            return db.ExcuteQuery(sql,
                CommandType.Text, null);
        }
        public DataTable DSCoSoKCB()
        {
            return db.ExcuteQuery("Select Ma_CS,Ten_CS From CoSoKCB",
                CommandType.Text, null);
        }
        public DataTable DSBacSi()
        {
            return db.ExcuteQuery("Select Ma_BS, Ten_NV From NhanVien Where TinhTrang=1 And CoSoKCB = '"
                +AppConfig.CoSoKCB+ "' And LEN(Ma_BS) > 0 Order By Ten_NV DESC",
                CommandType.Text, null);
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
        public bool SpChuyenPhong(ref string err)
        {
            return db.MyExecuteNonQuery("SpChuyenPhong",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@MaLK", MaLK),
                new SqlParameter("@NgayVao", NgayVao),
                new SqlParameter("@Phong", Phong));
        }
        public bool SpChuyenVien(ref string err)
        {
            return db.MyExecuteNonQuery("SpChuyenVien",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@MaLK", MaLK),
                new SqlParameter("@TinhTrangRaVien", TinhTrangRaVien));
        }
        public bool SpNhapVien(ref string err)
        {
            return db.MyExecuteNonQuery("SpNhapVien",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@MaLK", MaLK),
                new SqlParameter("@MaLoaiKCB", MaLoaiKCB),
                new SqlParameter("@MaKhoa", MaKhoa));
        }
        public bool SpRaVien(ref string err)
        {
            return db.MyExecuteNonQuery("SpRaVien",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@MaLK", MaLK),
                new SqlParameter("@NgayRa", NgayRa),
                new SqlParameter("@KetQuaDieuTri", KetQuaDieuTri),
                new SqlParameter("@TinhTrangRaVien", TinhTrangRaVien));
        }
        // chỉ định cận lâm sàn
        public DataTable DSChiDinhCanLamSan(string maLK)
        {
            return db.ExcuteQuery("Select * From getChiDinhCLS('"+AppConfig.CoSoKCB+"','" + maLK + "')",
                CommandType.Text, null);
        }
        public bool SpCDCanLamSan(ref string err, string Action)
        {
            return db.MyExecuteNonQuery("SpCDCanLamSan",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@Action", Action),
                new SqlParameter("@MaLK", MaLK),
                new SqlParameter("@MaCLS", MaCSL),
                new SqlParameter("@MaBS", MaBS),
                new SqlParameter("@ChuanDoan",ChuanDoan ),
                new SqlParameter("@YeuCau", YeuCau),
                new SqlParameter("@NgayChiDinh",NgayChiDinh ));
        }
        public bool SpCapNhatBenh(ref string err,string tenBenh,string maBenh, string maBenhKhac)
        {
            return db.MyExecuteNonQuery("SpCapNhatBenh",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@MaLK", MaLK),
                new SqlParameter("@TenBenh", tenBenh),
                new SqlParameter("@MaBenh", maBenh),
                new SqlParameter("@MaBenhKhac", maBenhKhac));
        }
    }
}
