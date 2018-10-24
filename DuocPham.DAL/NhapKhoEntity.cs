using Core.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuocPham.DAL
{
    public class NhapKhoEntity
    {
        Connection db;
        public NhapKhoEntity ()
        {
            db = new Connection ();
        }
        // Table PhieuNhap
        public int SoPhieu { get; set; }
        public string SoHoaDon { get; set; }
        public string TKNo { get; set; }
        public DateTime NgayNhap { get; set; }
        public string NhaCungCap { get; set; }
        public string IDNhaCC { get; set; }
        public string NguoiGiaoHang { get; set; }
        public string KhoNhap { get; set; }
        public string NguoiNhan { get; set; }
        public string NoiDung { get; set; }
        public string NguoiTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public string NguoiCapNhat { get; set; }
        // Table PhieuNhapChiTiet
        public string MaVatTu { get; set; }
        public string SoDangKy { get; set; }
        public int SoLuong { get; set; }
        public int SoLuongQuyDoi { get; set; }
        public int SoLuongDung { get; set; }
        public decimal DonGiaBHYT { get; set; }
        public decimal DonGiaBV { get; set; }
        public string SoLo { get; set; }
        public DateTime HetHan { get; set; }
        public decimal ThanhTien { get; set; }
        public string LoaiVatTu { get; set; }
        public int SoPhieuXuat { get; set; }
        public int SoPhieuNhap { get; set; }
        public int STT { get; set; }
        public DataTable DSMaVatTu()
        {
            return db.ExcuteQuery("Select * from MaVatTu",
                CommandType.Text, null);
        }
        public DataTable DSKho ()
        {
            return db.ExcuteQuery ("Select MaKhoa,TenKhoa From KhoaBan Where TinhTrang = 1 And KhoVatTu = 1 And LoaiKho = 1",
                CommandType.Text, null);
        }
        public DataTable DSTraNhaCungCap()
        {
            return db.ExcuteQuery("Select ID as MaKhoa,Ten as TenKhoa,DiaChi From NhaCungCap Where TinhTrang = 1 ",
                CommandType.Text, null);
        }
        public DataTable DSKhoTra ()
        {
            return db.ExcuteQuery ("Select MaKhoa,TenKhoa From KhoaBan Where TinhTrang = 1 And KhoVatTu = 1 And LoaiKho = 2",
                CommandType.Text, null);
        }
        public DataTable DSNguoiNhan ()
        {
            return db.ExcuteQuery ("Select Ma_NV,Ten_NV From NhanVien Where TinhTrang = 1",
                CommandType.Text, null);
        }
        public DataTable DSNhaCungCap ()
        {
            return db.ExcuteQuery ("Select ID,Ten,DiaChi From NhaCungCap Where TinhTrang = 1",
                CommandType.Text, null);
        }
        public DataTable BKNhapThuoc(int thang, int nam)
        {
            return db.ExcuteQuery("Select ROW_NUMBER() OVER(ORDER BY TenVatTu ASC) AS STT,MaVatTu,TenVatTu,DonViTinh,SoLuong,GiaBHYT, DonGiaBV,ThanhTien " +
                "from (Select MaVatTu,SUM(SoLuongQuyDoi) as SoLuong,AVG(DonGiaBV) as DonGiaBV,SUM(ThanhTien) as ThanhTien from PhieuNhap,PhieuNhapChiTiet " +
                "where PhieuNhap.SoPhieu = PhieuNhapChiTiet.SoPhieu and MONTH(NgayNhap) = "+thang+" And YEAR(NgayNhap) = "+nam+" Group by MaVatTu) as Nhap,VatTu " +
                "Where Nhap.MaVatTu = VatTu.MaBV",
                CommandType.Text, null);
        }
        public DataTable DSPhieuVatTu ()
        {
            return db.ExcuteQuery ("Select *,'' as TenVatTu,'' as DonViTinh, '' as NuocSanXuat" +
                " From PhieuNhapChiTiet Where SoPhieu = " + this.SoPhieu+" Order By STT",
                CommandType.Text, null);
        }
        public DataTable DSPhieuVatTu(int SoPhieu)
        {
            return db.ExcuteQuery("Select * From PhieuNhapChiTiet,(select MaBV,TenVatTu,DonViTinh from VatTu) as " +
                "VT Where VT.MaBV = PhieuNhapChiTiet.MaVatTu and SoPhieu = " + SoPhieu,
                CommandType.Text, null);
        }
        public DataTable DSPhieuVatTuTra ()
        {
            return db.ExcuteQuery ("Select * "
                + " From PhieuTraChiTiet,(select MaBV,TenVatTu,DonViTinh from VatTu) as VT Where VT.MaBV=PhieuTraChiTiet.MaVatTu AND SoPhieuTra = " + this.SoPhieu,
                CommandType.Text, null);
        }
        public DataTable DSPhieu (DateTime tuNgay, DateTime denNgay)
        {
            return db.ExcuteQuery ("Select *,Convert(bit,0) as Chon From PhieuNhap Where (NgayNhap BETWEEN CAST('" +tuNgay.ToString("MM/dd/yyyy") + "' as DATE) " +
                "AND CAST('" +denNgay.ToString("MM/dd/yyyy") + "' as DATE))"+
                " --AND NhaCungCap NOT IN (Select TenKhoa From KhoaBan) ",
                CommandType.Text, null);
        }
        public DataTable DSPhieuTra (DateTime tuNgay, DateTime denNgay)
        {
            return db.ExcuteQuery ("Select * From PhieuTra Where " +
                "(NgayXuat BETWEEN CAST('" + tuNgay.ToString("MM/dd/yyyy") + "' as DATE) AND CAST('" + denNgay.ToString("MM/dd/yyyy") + "' as DATE))" ,
                CommandType.Text, null);
        }
        public DataTable DSVatTu (string loaiVatTu)
        {
            return db.ExcuteQuery ("Select MaBV,TenVatTu,DonViTinh,SoDK,GiaBHYT From VatTu Where TinhTrang = 1 And LoaiVatTu = '" + loaiVatTu + "'",
                CommandType.Text, null);
        }
        public DataTable DSVatTu()
        {
            return db.ExcuteQuery("Select MaBV,TenVatTu,DonViTinh,SoDK,GiaBHYT,LoaiVatTu,HamLuong,TinhTrang,NuocSX From VatTu",
                CommandType.Text, null);
        }
        public DataTable DSVatTu (string loaiVatTu, string khoTra)
        {
            return db.ExcuteQuery ("Select * From DSVatTuTra('" + loaiVatTu + "','" + khoTra + "') ORDER BY SoPhieuNhap,SoPhieu ASC",
                CommandType.Text, null);
        }
        public bool SpPhieuNhap (ref string err, string Action)
        {
            SqlParameter outSoPhieu = new SqlParameter ();
            outSoPhieu.SqlDbType = System.Data.SqlDbType.Int;
            outSoPhieu.ParameterName = "@SoPhieu";
            outSoPhieu.Value = SoPhieu;
            outSoPhieu.Direction = ParameterDirection.InputOutput;
            bool f = db.MyExecuteNonQuery ("SpPhieuNhap",
                CommandType.StoredProcedure, ref err,
                new SqlParameter ("@Action", Action),
                outSoPhieu,
                new SqlParameter ("@SoHoaDon", SoHoaDon),
                new SqlParameter ("@TKNo", TKNo),
                new SqlParameter ("@NgayNhap", NgayNhap.ToString("MM/dd/yyyy")),
                new SqlParameter ("@NhaCungCap", NhaCungCap),
                new SqlParameter ("@NguoiGiaoHang", NguoiGiaoHang),
                new SqlParameter ("@KhoNhap", KhoNhap),
                new SqlParameter ("@NguoiNhan", NguoiNhan),
                new SqlParameter ("@NoiDung", NoiDung),
                new SqlParameter ("@NguoiTao", NguoiTao),
                new SqlParameter ("@NgayCapNhat", NgayCapNhat.ToString("MM/dd/yyyy")),
                new SqlParameter ("@NguoiCapNhat", NguoiCapNhat),
                new SqlParameter("@IDNhaCC", IDNhaCC));
                this.SoPhieu = int.Parse (outSoPhieu.Value.ToString ());
            return f;
        }
        public bool SpPhieuTra(ref string err, string Action)
        {
            SqlParameter outSoPhieu = new SqlParameter();
            outSoPhieu.SqlDbType = System.Data.SqlDbType.Int;
            outSoPhieu.ParameterName = "@SoPhieu";
            outSoPhieu.Value = SoPhieu;
            outSoPhieu.Direction = ParameterDirection.InputOutput;
            bool f = db.MyExecuteNonQuery("SpPhieuTra",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@Action", Action),
                outSoPhieu,
                new SqlParameter("@TKNo", TKNo),
                new SqlParameter("@NgayXuat", NgayNhap.ToString("MM/dd/yyyy")),
                new SqlParameter("@KhoXuat", NhaCungCap),
                new SqlParameter("@KhoNhan", KhoNhap),
                new SqlParameter("@NoiDung", NoiDung),
                new SqlParameter("@NguoiTra", NguoiGiaoHang),
                new SqlParameter("@MaNV", NguoiNhan));
            this.SoPhieu = int.Parse(outSoPhieu.Value.ToString());
            return f;
        }
        public bool SpPhieuNhapXoa (ref string err)
        {
            return db.MyExecuteNonQuery ("SpPhieuNhap",
                CommandType.StoredProcedure, ref err,
                new SqlParameter ("@Action", "DELETE"),
                new SqlParameter ("@SoPhieu", SoPhieu));
        }
        public bool SpPhieuNhapChiTiet (ref string err, string Action)
        {
            return db.MyExecuteNonQuery("SpPhieuNhapChiTiet",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@Action", Action),
                new SqlParameter("@MaVatTu", MaVatTu),
                new SqlParameter("@SoPhieu", SoPhieu),
                new SqlParameter("@KhoNhap", KhoNhap),
                new SqlParameter("@SoDangKy", SoDangKy),
                new SqlParameter("@SoLuong", SoLuong),
                new SqlParameter("@SoLuongQuyDoi", SoLuongQuyDoi),
                new SqlParameter("@SoLuongDung", SoLuongDung),
                new SqlParameter("@DonGiaBHYT", DonGiaBHYT),
                new SqlParameter("@DonGiaBV", DonGiaBV),
                new SqlParameter("@SoLo", SoLo),
                new SqlParameter("@HetHan", HetHan.ToString("MM/dd/yyyy")),
                new SqlParameter("@ThanhTien", ThanhTien),
                new SqlParameter("@LoaiVatTu", LoaiVatTu),
                new SqlParameter("@STT", STT));
        }
        public bool SpPhieuChiTietTra(ref string err, string Action)
        {
            return db.MyExecuteNonQuery("SpPhieuChiTietTra",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@Action", Action),
                new SqlParameter("@SoPhieuTra", SoPhieu),
                new SqlParameter("@SoPhieuXuat", SoPhieuXuat),
                new SqlParameter("@SoPhieuNhap", SoPhieuNhap),
                new SqlParameter("@MaVatTu", MaVatTu),
                new SqlParameter("@SoLuong", SoLuong),
                new SqlParameter("@DonGia", DonGiaBV),
                new SqlParameter("@HetHan", HetHan),
                new SqlParameter("@ThanhTien", ThanhTien),
                new SqlParameter("@LoaiVatTu", LoaiVatTu));
        }
    }
}
