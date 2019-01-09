using Core.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoCao.DAL
{
    public class TonKhoEntity
    {
        Connection db;
        public TonKhoEntity()
        {
            db = new Connection ();
        }
        public DataTable DSNVKhoDuoc ()
        {
            return db.ExcuteQuery ("Select * From NVKhoaDuoc ",
                CommandType.Text, null);
        }
        public DataTable DSKho ()
        {
            return db.ExcuteQuery ("Select ROW_NUMBER() OVER(ORDER BY Mau,LoaiVatTu ASC) AS STT,* from "+
                        "(select LoaiVatTu, MaBV, TenVatTu, DonViTinh, Ten, Mau "+
                        "from VatTu, LoaiVatTu where VatTu.LoaiVatTu = LoaiVatTu.Ma) as VatTu, "+
                        "(select MaVatTu, (SoLuongQuyDoi - SoLuongDung) as SoLuongTon "+
                        "from PhieuNhapChiTiet where (SoLuongQuyDoi - SoLuongDung) > 0) as Kho "+
                        "where VatTu.MaBV = Kho.MaVatTu "+
                        "order by Mau,LoaiVatTu asc",
                CommandType.Text, null);
        }
        public DataTable DSKhoNhap(DateTime tungay, DateTime denngay)
        {
            return db.ExcuteQuery("Select *, ROW_NUMBER() OVER(ORDER BY NhaCungCap ASC) As STT from " +
                        "(select SoPhieu, SUM(ThanhTien) as ThanhTien " +
                        "from PhieuNhapChiTiet group by SoPhieu) as SoPhieu, " +
                        "(select SoPhieu, SoHoaDon, NgayNhap, NguoiGiaoHang, NhaCungCap " +
                        "from PhieuNhap Where NgayNhap Between '" + tungay + "' And '" + denngay + "') as KhoNhap " +
                        "where SoPhieu.SoPhieu = KhoNhap.SoPhieu and NhaCungCap != '' " +
                        "And NhaCungCap NOT IN (Select TenKhoa From KhoaBan Where TinhTrang = 1 And KhoVatTu = 1 And LoaiKho = 2)",
                CommandType.Text, null);
        }
        public DataTable DSDuTru(DateTime tungay, DateTime denngay)
        {
            return db.ExcuteQuery("select NhaCungCap, TenVatTu, DonViTinh, SUM(SoLuongQuyDoi) as SoLuongQuyDoi, SUM(ThanhTien) as ThanhTien,"+
                        "SUM(ThanhTien) / SUM(SoLuongQuyDoi) as DonGia,ROW_NUMBER() OVER(ORDER BY NhaCungCap ASC) As STT " +
                        "from PhieuNhap, "+
                        "(select TenVatTu, DonViTinh, SUM(SoLuongQuyDoi) as SoLuongQuyDoi, SUM(ThanhTien) as ThanhTien, SoPhieu "+
                        "from PhieuNhapChiTiet, VatTu where PhieuNhapChiTiet.MaVatTu = VatTu.MaBV "+
                        "group by TenVatTu, SoPhieu, DonViTinh) as PNCT "+
                        "where PhieuNhap.SoPhieu = PNCT.SoPhieu and NhaCungCap != '' "+
                        "    And NhaCungCap NOT IN(Select TenKhoa From KhoaBan Where TinhTrang = 1 And KhoVatTu = 1 And LoaiKho = 2) "+
                        "    And NgayNhap between '" + tungay + "' And '" + denngay + "' " +
                        "group by NhaCungCap,TenVatTu,DonViTinh ",
                CommandType.Text, null);
        }
    }
}
