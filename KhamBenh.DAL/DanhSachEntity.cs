using Core.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhamBenh.DAL
{
    public class DanhSachEntity
    {
        Connection db;
        public DanhSachEntity()
        {
            db = new Connection();
        }
        public DataTable DSBenhNhan(string maKhoa,DateTime tuNgay, DateTime denNgay)
        {
            return db.ExcuteQuery("Select *,(~DaGui) as Chon,ROW_NUMBER() OVER(ORDER BY STTNgay) STT " +
                "From ThongTinBNChiTiet " +
                "Where CONVERT(Date,NgayThanhToan) between CONVERT(Date, '"+tuNgay+"') and CONVERT(Date, '"+denNgay+ "') " +
                "And MaCoSoKCB = '" + AppConfig.CoSoKCB + "' And MaKhoa = '"+maKhoa+"'",
                CommandType.Text, null);
        }
        public DataTable DSThuoc(string maLK)
        {
            return db.ExcuteQuery("SELECT ROW_NUMBER() OVER(ORDER BY MaVatTu) STT," +
                "MaLK,MaVatTu,MaThuoc,MaNhom,TenThuoc,DonViTinh,HamLuong,MaDuongDung," +
                "LieuDung,SoDK,TTinThau,PhamVi,SUM(SoLuong) as SoLuong,DonGia,TyLe,SUM(ThanhTien) as ThanhTien,MucHuong," +
                "SUM(TienNguonKhac) as TienNguonKhac,SUM(TienBNTT) as TienBNTT,SUM(TienBHTT) as TienBHTT," +
                "SUM(TienBNCCT) as TienBNCCT,SUM(TienNgoaiDS) as TienNgoaiDS," +
                "MaKhoa,MaBacSi,NgayYLenh,MaPTTT " +
                "FROM HIS_PR.dbo.DonThuocChiTiet Where MaLK='"+maLK+"' " +
                "GROUP BY MaLK,MaVatTu,MaThuoc,MaNhom,TenThuoc,DonViTinh,HamLuong,MaDuongDung,LieuDung,SoDK," +
                "TTinThau,PhamVi,DonGia,TyLe,MucHuong,MaKhoa,MaBacSi,NgayYLenh,MaPTTT", CommandType.Text, null);
        }
        public DataTable DSHoSoCanLamSan(string maLK)
        {
            return db.ExcuteQuery("SELECT ROW_NUMBER() OVER(ORDER BY MaDichVu) STT, * FROM HoSoCanLamSan " +
                "Where MaLK = '"+maLK+"'", CommandType.Text, null);
        }
        public DataTable DSVatTu(string maLK)
        {
            return db.ExcuteQuery("SELECT MaLK,ROW_NUMBER() OVER(ORDER BY MaVatTu) STT,'' as MaDichVu," +
                "MaVT,MaNhom,GoiVTYT,TenVatTu,'' as TenDichVu,DonViTinh,PhamVi,SoLuong,DonGia,TTinThau," +
                "TyLe,SUM(ThanhTien) as ThanhTien,TTrantT,MucHuong," +
                "SUM(TienNguonKhac) as TienNguonKhac,SUM(TienBNTT) as TienBNTT,SUM(TienBHTT) as TienBHTT," +
                "SUM(TienBNCCT) as TienBNCCT,SUM(TienNgoaiDS) as TienNgoaiDS," +
                "MaKhoa,'' as MaGiuong,MaBacSi,NgayYLenh,NgayYLenh as NgayKQ,MaPTTT " +
                "FROM VatTuChiTiet WHERE MaLK = '"+maLK+"' "+
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
                "FROM DichVuChiTiet Where MaLK = '"+maLK+"'", CommandType.Text, null);
        }
        public bool CapNhatDaGui(ref string err, string MaLK)
        {
            return db.BackUpOrRestore("Update ThongTinBNChiTiet Set DaGui = 1 Where MaLK = '" + MaLK + "'",
                ref err);
        }
        public DataTable DSKhoaBan(int loaiPhong)
        {
            string sql = "";
            sql = "EXEC SpGetKhoaBan '" + AppConfig.CoSoKCB + "'," + loaiPhong;
            return db.ExcuteQuery(sql,
                CommandType.Text, null);
        }
    }
}
