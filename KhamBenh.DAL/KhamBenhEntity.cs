﻿using Core.DAL;
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
            return db.ExcuteQuery("Select MaBenh,TenBenh From BenhICD Where HieuLuc = 1",
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
        public DataTable DSThuocChiTietGroup()
        {
            return db.ExcuteQuery("Select TenThuoc,DonViTinh,Sum(SoLuong) as SoLuong," +
                "ROW_NUMBER() OVER(ORDER BY TenThuoc) STT " +
                "From DonThuocChiTiet Where MaLK ='" + MaLK + "' Group by TenThuoc,DonViTinh",
                CommandType.Text, null);
        }
        public DataTable DSDichVuChiTietGroup()
        {
            return db.ExcuteQuery("Select TenDichVu,DonViTinh,Sum(SoLuong) as SoLuong," +
                "ROW_NUMBER() OVER(ORDER BY TenDichVu) STT " +
                "From DichVuChiTiet Where MaLK ='" + MaLK + "' Group by TenDichVu,DonViTinh",
                CommandType.Text, null);
        }
        public DataTable DSVatTuChiTietGroup()
        {
            return db.ExcuteQuery("Select TenVatTu,DonViTinh,Sum(SoLuong) as SoLuong," +
                "ROW_NUMBER() OVER(ORDER BY TenVatTu) STT " +
                "From VatTuChiTiet Where MaLK ='" + MaLK + "' Group by TenVatTu,DonViTinh",
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
        public DataTable DSTiepNhan(string ngayVao, int phong, string MaKhoa)
        {
            return db.ExcuteQuery("Select MaLK,MaBN,HoTen,NgaySinh,GioiTinh,DiaChi,MaThe,MaDKBD,TheTu,TheDen," +
                "TenBenh,MaBenh,MaBenhKhac,MaLyDoVaoVien,MaNoiChuyenDen,MaTaiNan,NgayVao,NgayRa,KetQuaDieuTri," +
                "TinhTrangRaVien,NgayThanhToan,MucHuong,MaLoaiKCB,MaKhoa,MaCoSoKCB,MaKhuVuc,STTNgay," +
                "STTPhong,Phong,TinhTrang,CoThe,CanNang From ThongTinBNChiTiet Where CAST(NgayVao AS DATE) = CAST('"
                //+ ngayVao + "' AS DATE) And (Phong = "+phong+" Or "+phong+ " = 0) And MaCoSoKCB='"+AppConfig.CoSoKCB+"' And MaKhoa='"+MaKhoa+"'  Order By STTNgay ASC",
                 +ngayVao + "' AS DATE) And (Phong = " + phong + " Or " + phong + " = 0) And MaCoSoKCB='" + AppConfig.CoSoKCB + "'  Order By STTNgay ASC",
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
            else // tính theo ngày ra
                return db.ExcuteQuery("Select * From ThongTinBNChiTiet Where MaLoaiKCB > 1 And MaKhoa = '" + maKhoa + "' " +
                "And CONVERT(Date,NgayRa) Between CONVERT(Date,'" + tuNgay + "') And CONVERT(Date,'" + denNgay + "') And NgayRa is not NULL " +
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
                                    "MaThe,CONVERT(VARCHAR,NgayYLenh,120) as NgayThanhToan,MaBenh,TenThuoc,SoLuong,LieuDung " +
                                    "from ThongTinBNChiTiet,DonThuocChiTiet " +
                                    "where ThongTinBNChiTiet.MaLK = DonThuocChiTiet.MaLK " +
                                    "And MaCoSoKCB='" + AppConfig.CoSoKCB + "' and ThongTinBNChiTiet.MaKhoa = '" + maKhoa + "' " +
                                    "And (NgayYLenh between '" + tuNgay + "' and '" + denNgay + "') " +
                                    "And ThongTinBNChiTiet.NgayRa is NULL " +
                                    "order by STTNgay",
                CommandType.Text, null);

        }
        public DataTable DSChiTietThuocAndGiuong(string maKhoa, DateTime tuNgay, DateTime  denNgay)
        {
            return db.ExcuteQuery("Select STTNgay,HoTen," +
                                    "(Case when GioiTinh = 0 then SUBSTRING(NgaySinh, Len(NgaySinh)-3, 4) end) as Nam," +
                                    "(Case when GioiTinh = 1 then SUBSTRING(NgaySinh, Len(NgaySinh)-3, 4) end) as Nu," +
                                    "ThongTinBNChiTiet.MaLK,GiuongBenh," +
                                    "TenBenh,HamLuong," +
                                    "MaThe,CONVERT(VARCHAR,NgayYLenh,120) as NgayThanhToan,MaBenh,TenThuoc,SoLuong,LieuDung,DonViTinh,Ten " +
                                    "from ThongTinBNChiTiet," +
                                    "(select * from DonThuocChiTiet,DuongDung where DonThuocChiTiet.MaDuongDung = DuongDung.Ma) as DonThuocChiTiet " +
                                    "where ThongTinBNChiTiet.MaLK = DonThuocChiTiet.MaLK " +
                                    "And MaCoSoKCB='" + AppConfig.CoSoKCB + "' and ThongTinBNChiTiet.MaKhoa = '" + maKhoa + "' " +
                                    "And (NgayYLenh between '" + tuNgay + "' and '" + denNgay + "') " +
                                    "And ThongTinBNChiTiet.NgayRa is NULL " +
                                    "order by STTNgay",
                CommandType.Text, null);
            //return db.ExcuteQuery("Select * from " +
            //                        "(Select STTNgay,HoTen,SUBSTRING(NgaySinh, Len(NgaySinh)-3, 4) as NgaySinh,ThongTinBNChiTiet.MaLK," +
            //                        "MaThe,CONVERT(VARCHAR,NgayYLenh,120) as NgayThanhToan,MaBenh,TenThuoc,SoLuong,LieuDung " +
            //                        "from ThongTinBNChiTiet,DonThuocChiTiet " +
            //                        "where ThongTinBNChiTiet.MaLK = DonThuocChiTiet.MaLK " +
            //                        "And MaCoSoKCB='" + AppConfig.CoSoKCB + "' and ThongTinBNChiTiet.MaKhoa = '" + maKhoa + "' " +
            //                        "And (NgayYLenh between '" + tuNgay + "' and '" + denNgay + "') " +
            //                        "And ThongTinBNChiTiet.NgayRa is NULL " +
            //                        ") as Thuoc " +
            //                        "left outer join (Select MaLK,TenDichVu,MaGiuong from DichVuChiTiet where MaNhom=15) as Giuong " +
            //                        "on Thuoc.MaLK = Giuong.MaLK " +
            //                        "order by STTNgay",
            //    CommandType.Text, null);

        }
        public DataTable DSTongHopKeVatTu(string maKhoa, DateTime tuNgay, DateTime denNgay)
        {
            return db.ExcuteQuery("Select * from DSTongHopKeVatTu('" + tuNgay + "','" + denNgay + "','" + maKhoa + "')", CommandType.Text, null);
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
        public DataTable DSNopBenhAn(string MaKhoa, DateTime tuNgay,DateTime denNgay, int chonNgay)
        {
            string strchonNgay = "NgayVao";
            if (chonNgay == 1)
                strchonNgay = "NgayRa";
            if (chonNgay == 2)
                strchonNgay = "NgayNop";

            return db.ExcuteQuery("select ThongTinBNChiTiet.MaLK,HoTen,MaThe,NgaySinh,TenBenh,NgayVao,NgayRa,NgayNop," +
                "case when NgayNop IS null then CONVERT(bit,0) else CONVERT(bit,1) end as Nop from ThongTinBNChiTiet " +
                                    "left join NopBenhAn " +
                                    "on NopBenhAn.MaLK = ThongTinBNChiTiet.MaLK " +
                                    "where Convert(date,"+ strchonNgay + ") between '"+tuNgay+"' and '"+denNgay+"' and (MaKhoa = '"+MaKhoa+"')",
                CommandType.Text, null);
        }
        public DataTable DSNopBenhAn(DateTime tuNgay, DateTime denNgay, string MaKhoa, int loaiIn, int chonNgay)
        {
            string strloai = "";
            if (loaiIn == 1)
                strloai = " and NgayNop is not null";
            if (loaiIn == 2)
                strloai = " and NgayNop is null";
            string strchonNgay = "NgayVao";
            if (chonNgay == 1)
                strchonNgay = "NgayRa";
            if (chonNgay == 2)
                strchonNgay = "NgayNop";
            return db.ExcuteQuery("select *,ROW_NUMBER() OVER(ORDER BY NgayVao ASC) AS STT," +
                "(DATEDIFF(DAY, NgayVao, NgayRa)+1) as SoNgayDT," +
                                    "case when GioiTinh = 0 then SUBSTRING(NgaySinh,LEN(NgaySinh)-3,4) end as NgaySinhNam," +
                                    "case when GioiTinh = 1 then SUBSTRING(NgaySinh,LEN(NgaySinh)-3,4) end as NgaySinhNu " +
                                 "from(select MaLK, HoTen, MaThe, MaBenh, NgayVao, NgayRa, DiaChi, GioiTinh, CoThe, NgaySinh," +
                                    "KetQuaDieuTri, TinhTrangRaVien, TenKhoa from ThongTinBNChiTiet," +
                                    "(select MaKhoa,TenKhoa from KhoaBan where (MaKhoa = '" + MaKhoa + "')) as KhoaBan " +
                                    " where ThongTinBNChiTiet.MaKhoa = KhoaBan.MaKhoa ) " +
                                     "as CT left join NopBenhAn " +
                                 "on NopBenhAn.MaLK = CT.MaLK " +
                                "Where (Convert(date," + strchonNgay + ") between '" + tuNgay + "' and '" + denNgay + "') " + strloai,
                CommandType.Text, null);
        }
        public DataTable DSLichSuPhanMem(string MaBN, string HoTen, int GioiTinh, string NgaySinh)
        {
            return db.ExcuteQuery("select MaLK as maHoSo,MaCoSoKCB as maCSKCB,"
            + "NgayVao as tuNgay, NgayRa as denNgay, TenBenh as tenBenh, "
            + "TinhTrangRaVien as tinhTrang, KetQuaDieuTri as kqDieuTri "
            + "from ThongTinBNChiTiet "
            + "where MaBN = '" + MaBN + "' ",
            //+ "or(dbo.ChangeVietnameseWord(N'" + HoTen + "') = dbo.ChangeVietnameseWord(HoTen) "
            //+ "AND '"+NgaySinh+"' = NgaySinh AND GioiTinh = " + GioiTinh + ")",
                CommandType.Text, null);
        }
        public DataTable DSLichSuPhanMem(string MaThe)
        {
            return db.ExcuteQuery("select MaLK as maHoSo,MaCoSoKCB as maCSKCB,"
            + "NgayVao as tuNgay, NgayRa as denNgay, TenBenh as tenBenh, "
            + "TinhTrangRaVien as tinhTrang, KetQuaDieuTri as kqDieuTri "
            + "from ThongTinBNChiTiet "
            + "where MaThe = '" + MaThe + "' and YEAR(NgayVao) = " + DateTime.Now.Year,
            //+ "or(dbo.ChangeVietnameseWord(N'"+HoTen+"') = dbo.ChangeVietnameseWord(HoTen) "
            //+ "AND '"+NgaySinh+"' = NgaySinh AND GioiTinh = "+GioiTinh+")",
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
        public bool SpCapNhatBenh(ref string err,string tenBenh,string maBenh, string maBenhKhac, string giuongBenh)
        {
            return db.MyExecuteNonQuery("SpCapNhatBenh",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@MaLK", MaLK),
                new SqlParameter("@TenBenh", tenBenh),
                new SqlParameter("@MaBenh", maBenh),
                new SqlParameter("@MaBenhKhac", maBenhKhac),
                new SqlParameter("@GiuongBenh",giuongBenh));
        }
        public bool SpNopBenhAn(ref string err,string Action, string MaLK)
        {
            return db.MyExecuteNonQuery("SpNopBenhAn",
                CommandType.StoredProcedure, ref err, 
                new SqlParameter("@Action", Action),
                new SqlParameter("@MaLK", MaLK),
                new SqlParameter("@NgayNop", DateTime.Now));
        }
    }
}
