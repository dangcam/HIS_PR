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
    public class CanLamSanEntity
    {
        Connection db;
        public CanLamSanEntity()
        {
            db = new Connection();
        }
        public string MaLK { get; set; }
        public string MaDichVu { get; set; }
        public int MaNhom { get; set; }
        public string TenDichVu { get; set; }
        public string DonViTinh { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public int TyLe { get; set; }
        public decimal ThanhTien { get; set; }
        public int MucHuong { get; set; }
        //public string TienNguonKhac { get; set; }
        //public string TienBNTT { get; set; }
        //public string TienBHTT { get; set; }
        //public string TienBNCCT { get; set; }
        //public string TienNgoaiDS { get; set; }
        public string MaKhoa { get; set; }
        //public string MaGiuong { get; set; }
        public string MaBacSi { get; set; }
        public DateTime NgayYLenh { get; set; }
        public DateTime NgayKQ { get; set; }
        public int MaPTTT { get; set; }
        public string MaCLS { get; set; }
        public string MaChiSo { get; set; }
        public string GiaTri { get; set; }
        public string MaMay { get; set; }
        public string MoTa { get; set; }
        public string KetLuan { get; set; }
        public DataTable DSBNCanLamSan(DateTime ngayYLenh, string maKhoa)
        {
            return db.ExcuteQuery("Select CDCanLamSan.MaLK,MaCLS,MaBS,ChuanDoan,"
            + "YeuCau, NgayChiDinh, KetQua, HoTen, NgaySinh, GioiTinh,MaThe, "
            + "Ten,MaNhom,MauSo,NhomCanLamSan.MaKhoa,MaMay,NgayThanhToan,DiaChi, " 
            + "ThongTinBNChiTiet.MaKhoa as KhoaBan "
            + "From CDCanLamSan, ThongTinBNChiTiet,NhomCanLamSan "
            + "Where CDCanLamSan.MaLK = ThongTinBNChiTiet.MaLK And NhomCanLamSan.Ma = CDCanLamSan.MaCLS "
            + "And NgayChiDinh = CONVERT(DATE,'"+ngayYLenh+ "') And NhomCanLamSan.MaKhoa = '"+maKhoa+ "' And MaCoSoKCB = '" + AppConfig.CoSoKCB + "'",
                CommandType.Text, null);
        }
        public DataTable DSKhoaBan(int loaiPhong)
        {
            string sql = "";
            sql = "EXEC SpGetKhoaBan '" + AppConfig.CoSoKCB + "'," + loaiPhong;
            return db.ExcuteQuery(sql,
                CommandType.Text, null);
        }
        public DataTable DSBacSi()
        {
            return db.ExcuteQuery("Select Ma_BS, Ten_NV From NhanVien Where TinhTrang=1 And CoSoKCB = '"
                + AppConfig.CoSoKCB + "' And LEN(Ma_BS) > 0",
                CommandType.Text, null);
        }
        public DataTable DSDichVu(int maNhom)
        {
            return db.ExcuteQuery("Select * From DichVuKyThuat Where Ma_CS = '"+AppConfig.CoSoKCB+"' And TinhTrang = 1 And MaNhom = "+maNhom,
                CommandType.Text, null);
        }
        public DataTable DSDichVuChiTiet()
        {
            return db.ExcuteQuery("Select* from " +
            "(select* from DichVuChiTiet where MaLK = '" + this.MaLK + "' and MaCLS = '" + this.MaCLS + "') as ThongTin, " +
            "(select * from HoSoCanLamSan where MaLK = '" + this.MaLK + "' and MaCLS = '" + this.MaCLS + "') as HoSo Where HoSo.MaDichVu = ThongTin.MaDichVu",
                CommandType.Text, null);
        }
        public bool CapNhatCDCanLamSan(ref string err, int ketQua)
        {
            return db.BackUpOrRestore("Update CDCanLamSan Set KetQua = "+ketQua+" Where MaLK = '"+MaLK+"' And MaCLS ='"+MaCLS+"'",
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
                new SqlParameter("@DonViTinh",DonViTinh),
                new SqlParameter("@SoLuong", SoLuong),
                new SqlParameter("@DonGia",DonGia ),
                new SqlParameter("@TyLe", TyLe),
                new SqlParameter("@ThanhTien", ThanhTien),
                //new SqlParameter("@MucHuong", ),
                //new SqlParameter("@TienNguonKhac", ),
                //new SqlParameter("@TienBNTT", ),
                //new SqlParameter("@TienBHTT", ),
                //new SqlParameter("@TienBNCCT", ),
                //new SqlParameter("@TienNgoaiDS", ),
                new SqlParameter("@MaKhoa",MaKhoa ),
                //new SqlParameter("@MaGiuong", ),
                new SqlParameter("@MaBacSi",MaBacSi ),
                new SqlParameter("@NgayYLenh",NgayYLenh ),
                new SqlParameter("@NgayKQ", NgayKQ),
                new SqlParameter("@MaPTTT",MaPTTT ),
                new SqlParameter("@MaCLS", MaCLS),
                new SqlParameter("@MaChiSo", MaChiSo),
                new SqlParameter("@GiaTri",GiaTri ),
                new SqlParameter("@MaMay", MaMay),
                new SqlParameter("@MoTa", MoTa),
                new SqlParameter("@KetLuan",KetLuan));
        }
    }
}
