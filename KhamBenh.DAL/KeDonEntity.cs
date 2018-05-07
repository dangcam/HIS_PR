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
    public class KeDonEntity
    {
        Connection db;
        public KeDonEntity()
        {
            db = new Connection();
        }
        public string MaLK { get; set; }
        public string MaBenh { get; set; }
        public string MaBenhKhac { get; set; }
        public string TenBenh { get; set; }
        // Bảng đơn thuốc
        public string KhoNhan { get; set; }
        public string MaVatTu { get; set; }
        public string MaThuoc { get; set; }
        public int MaNhom { get; set; }
        public string TenThuoc { get; set; }
        public string DonViTinh { get; set; }
        public string HamLuong { get; set; }
        public string MaDuongDung { get; set; }
        public string LieuDung { get; set; }
        public string SoDK { get; set; }
        public string TTinThau { get; set; }
        public int PhamVi { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public int TyLe { get; set; }
        public decimal ThanhTien { get; set; }
        public int MucHuong { get; set; }
        public decimal TienNguonKhac { get; set; }
        public decimal TienBNTT { get; set; }
        public decimal TienBHTT { get; set; }
        public decimal TienBNCCT { get; set; }
        public decimal TienNgoaiDS { get; set; }
        public string MaKhoa { get; set; }
        public string MaBacSi { get; set; }
        public DateTime NgayYLenh { get; set; }
        public int MaPTTT { get; set; }
        // Bảng vật tư
        public string MaVT { get; set; }
        public string GoiVTYT { get; set; }
        public string TenVatTu { get; set; }
        public int TTrantT { get; set; }
        public DataTable DSBacSi()
        {
            return db.ExcuteQuery("Select Ma_BS, Ten_NV From NhanVien Where TinhTrang=1 And LEN(Ma_BS) > 0 Order by Ten_NV DESC",
                CommandType.Text, null);
            //return db.ExcuteQuery("Select Ma_BS, Ten_NV From NhanVien Where TinhTrang=1 And CoSoKCB = '"
            //    + AppConfig.CoSoKCB + "' And LEN(Ma_BS) > 0 Order by Ten_NV DESC",
            //    CommandType.Text, null);
        }
        public DataTable DSBenh()
        {
            return db.ExcuteQuery("Select MaBenh,TenBenh From BenhICD ",
                CommandType.Text, null);
        }
        public DataTable DSDuongDung()
        {
            return db.ExcuteQuery("Select * From DuongDung ",
                CommandType.Text, null);
        }
        public DataTable DSKhoaBan(int loaiPhong)
        {
            string sql = "";
            sql = "EXEC SpGetKhoaBan '" + AppConfig.CoSoKCB + "'," + loaiPhong;
            return db.ExcuteQuery(sql,
                CommandType.Text, null);
        }
        public DataTable DSKeDon(string loaiVatTu)
        {
            return db.ExcuteQuery("Select * From DSKeDonThuoc('"+loaiVatTu+"','"+KhoNhan+"')",
                CommandType.Text, null);
        }
        public DataTable DSKeDonNgoaiDM()
        {
            return db.ExcuteQuery("Select MaBV as MaVatTu,MaThuoc as MaHoatChat,TenThuoc as TenVatTu," +
                "DonViTinh,HamLuong,MaDuongDung,DonGia as GiaBHYT,SoDK,TTinThau,MaNhom,TyLeTT " +
                "From ThuocNgoaiDM Where Ma_CS = '"+AppConfig.CoSoKCB+"'",
                CommandType.Text, null);
        }
        public DataTable DSThuoc()
        {
            return db.ExcuteQuery("Select MaVatTu, MaThuoc, TenThuoc, HamLuong, DonViTinh, DonGia,MaDuongDung, "
                + "LieuDung, SUM(SoLuong) as SoLuong, SUM(ThanhTien) as ThanhTien,SoDK,TTinThau,NgayYLenh,convert(varchar, NgayYLenh, 120) as NhomYLenh,TyLe "
                + "From DonThuocChiTiet Where MaLK = '"+MaLK+"' GROUP BY MaVatTu, MaThuoc,MaDuongDung, "
                + "TenThuoc, HamLuong, DonViTinh, DonGia, LieuDung,SoDK,TTinThau,NgayYLenh,TyLe",
                CommandType.Text, null);
        }
        public DataTable DSVatTu()
        {
            return db.ExcuteQuery("Select MaVatTu,TenVatTu,DonGia,MaKhoa,MaBacSi,NgayYLenh,TTinThau,TyLe, "
                                   + "SUM(SoLuong) as SoLuong, SUM(ThanhTien) As ThanhTien,MaVT,DonViTinh "
                                   + "From VatTuChiTiet Where MaLK = '"+MaLK+"' "
                                   + "Group By MaVatTu,MaVT, TenVatTu, DonGia, MaKhoa, MaBacSi, NgayYLenh, DonViTinh, TTinThau,TyLe",
                CommandType.Text, null);
        }
        public DataTable DSDichVuKyThuat()
        {
            return db.ExcuteQuery("Select DichVuChiTiet.MaDichVu,TenDichVu,GiaTri,MoTa,KetLuan " +
                "From DichVuChiTiet,HoSoCanLamSan " +
                "Where DichVuChiTiet.MaLK ='"+MaLK+"' And DichVuChiTiet.MaDichVu = HoSoCanLamSan.MaDichVu " +
                "And HoSoCanLamSan.MaLK = '" + MaLK + "'",
                CommandType.Text, null);
        }
        public bool LayThongTinMaBenh()
        {
            DataTable dt  = db.ExcuteQuery("Select MaBenh,MaBenhKhac,TenBenh From ThongTinBNChiTiet Where MaLK = '"+this.MaLK+"'",
                CommandType.Text, null);
            
            if(dt!=null && dt.Rows.Count>0)
            {
                this.MaBenh = dt.Rows[0]["MaBenh"].ToString();
                this.MaBenhKhac = dt.Rows[0]["MaBenhKhac"].ToString();
                this.TenBenh = dt.Rows[0]["TenBenh"].ToString();
                return true;
            }
            else
            {
                this.MaBenh = null;
                this.MaBenhKhac = null;
                this.TenBenh = null;
                return false;
            }
        }
        public bool SpKeDonThuoc(ref string err, string Action)
        {
            return db.MyExecuteNonQuery("SpKeDonThuoc",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@Action", Action),
                new SqlParameter("@KhoNhan", KhoNhan),
                new SqlParameter("@MaLK", MaLK),
                new SqlParameter("@SoPhieu", 0),
                new SqlParameter("@SoPhieuNhap", 0),
                new SqlParameter("@MaVatTu", MaVatTu),
                new SqlParameter("@MaThuoc", MaThuoc),
                new SqlParameter("@MaNhom", MaNhom),
                new SqlParameter("@TenThuoc", TenThuoc),
                new SqlParameter("@DonViTinh", DonViTinh),
                new SqlParameter("@HamLuong", HamLuong),
                new SqlParameter("@MaDuongDung", MaDuongDung),
                new SqlParameter("@LieuDung", LieuDung),
                new SqlParameter("@SoDK", SoDK),
                new SqlParameter("@TTinThau",TTinThau ),
                new SqlParameter("@PhamVi", PhamVi),
                new SqlParameter("@SoLuong", SoLuong),
                new SqlParameter("@DonGia", DonGia),
                new SqlParameter("@TyLe", TyLe),
                new SqlParameter("@ThanhTien",ThanhTien ),
                new SqlParameter("@MucHuong", MucHuong),
                new SqlParameter("@TienNguonKhac", TienNguonKhac),
                new SqlParameter("@TienBNTT", TienBNTT),
                new SqlParameter("@TienBHTT", TienBHTT),
                new SqlParameter("@TienBNCCT", TienBNCCT),
                new SqlParameter("@TienNgoaiDS", TienNgoaiDS),
                new SqlParameter("@MaKhoa", MaKhoa),
                new SqlParameter("@MaBacSi", MaBacSi),
                new SqlParameter("@NgayYLenh", NgayYLenh),
                new SqlParameter("@MaPTTT",MaPTTT ));
        }
        public bool SpCapNhatBenh(ref string err)
        {
            return db.MyExecuteNonQuery("SpCapNhatBenh",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@MaLK", MaLK),
                new SqlParameter("@TenBenh", TenBenh),
                new SqlParameter("@MaBenh", MaBenh),
                new SqlParameter("@MaBenhKhac", MaBenhKhac));
        }
        public bool SpKeVatTu(ref string err, string Action)
        {
            return db.MyExecuteNonQuery("SpKeVatTu",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@Action", Action),
                new SqlParameter("@KhoNhan", KhoNhan),
                new SqlParameter("@MaLK", MaLK),
                //new SqlParameter("@SoPhieu", 0),
                //new SqlParameter("@SoPhieuNhap", 0),
                new SqlParameter("@MaVatTu", MaVatTu),
                new SqlParameter("@MaVT", MaVT),
                new SqlParameter("@MaNhom", MaNhom),
                new SqlParameter("@GoiVTYT", GoiVTYT),
                new SqlParameter("@TenVatTu", TenVatTu),
                new SqlParameter("@DonViTinh", DonViTinh),
                new SqlParameter("@PhamVi", PhamVi),
                new SqlParameter("@SoLuong", SoLuong),
                new SqlParameter("@DonGia", DonGia),
                new SqlParameter("@TTinThau", TTinThau),
                new SqlParameter("@ThanhTien", ThanhTien),
                new SqlParameter("@TyLe", TyLe),
                new SqlParameter("@TTrantT", TTrantT),
                new SqlParameter("@MucHuong", MucHuong),
                new SqlParameter("@TienNguonKhac", TienNguonKhac),
                new SqlParameter("@TienBNTT", TienBNTT),
                new SqlParameter("@TienBHTT", TienBHTT),
                new SqlParameter("@TienBNCCT", TienBNCCT),
                new SqlParameter("@TienNgoaiDS", TienNgoaiDS),
                new SqlParameter("@MaKhoa", MaKhoa),
                new SqlParameter("@MaBacSi", MaBacSi),
                new SqlParameter("@NgayYLenh", NgayYLenh),
                new SqlParameter("@MaPTTT", MaPTTT));
        }
    }
}
