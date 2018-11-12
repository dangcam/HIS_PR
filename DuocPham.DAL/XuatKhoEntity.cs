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
    public class XuatKhoEntity
    {
        Connection db;
        public XuatKhoEntity()
        {
            db = new Connection ();
        }
        // phiếu xuất
        public int SoPhieu  { get;set;}
        public string TKCo { get;set;  }
        public string TKNo { get; set; }
        public DateTime NgayXuat { get; set; }
        public string KhoXuat { get; set; }
        public string KhoNhan { get; set; }
        public string NguoiNhan { get; set; }
        public string NoiDung { get; set; }
        public bool PheDuyet { get; set; }
        public string NguoiTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public string DiaChi { get; set; }
        public string NguoiCapNhat { get; set; }
        // phiếu xuất chi tiết
        public int SoPhieuNhap { get; set; }
        public string MaVatTu { get; set; }
        public string SoDangKy { get; set; }
        public int SoLuong { get; set; }
        public int SoLuongDung { get; set; }
        public decimal DonGiaBHYT { get; set; }
        public decimal DonGiaBV { get; set; }
        public DateTime HetHan { get; set; }
        public decimal ThanhTien { get; set; }
        public string LoaiVatTu { get; set; }
        public DataTable DSMaVatTu()
        {
            return db.ExcuteQuery("Select * from MaVatTu",
                CommandType.Text, null);
        }
        public DataTable DSKhoXuat ()
        {
            return db.ExcuteQuery ("Select MaKhoa,TenKhoa From KhoaBan Where TinhTrang = 1 And KhoVatTu = 1 And LoaiKho = 1",
                CommandType.Text, null);
        }
        public DataTable DSKho()
        {
            return db.ExcuteQuery("Select MaKhoa,TenKhoa From KhoaBan Where TinhTrang = 1 And KhoVatTu = 1",
                CommandType.Text, null);
        }
        public DataTable DSKhoNhan ()
        {
            return db.ExcuteQuery ("Select MaKhoa,TenKhoa From KhoaBan Where TinhTrang = 1 And KhoVatTu = 1 And LoaiKho = 2",
                CommandType.Text, null);
        }
        public DataTable DSTraNhaCungCap()
        {
            return db.ExcuteQuery("Select ID as MaKhoa,Ten as TenKhoa,DiaChi From NhaCungCap Where TinhTrang = 1 ",
                CommandType.Text, null);
        }
        public DataTable DSVatTu (string loaiVatTu)
        {
            return db.ExcuteQuery ("Select * From DSVatTu('"+loaiVatTu+"','"+KhoXuat+ "')",
                CommandType.Text, null);
        }
        public DataTable ChiTietVatTu(int thang,int nam)
        {
            return db.ExcuteQuery("Select * From ChiTietVatTu('" + thang + "','" + nam + "') ORDER BY NgayNhapXuat ASC",
                CommandType.Text, null);
        }
        public DataTable ChiTietTheKho(string maVatTu,int thang, int nam)
        {
            int thangTruoc = thang - 1;
            int namTruoc = nam;
            if(thangTruoc<1)
            {
                thangTruoc = 12;
                namTruoc--;
            }
            return db.ExcuteQuery("Select * From TheKho('"+maVatTu+"','" + thang + "','" + nam + "','" + thangTruoc + "','" + namTruoc + "') ORDER BY NgayNhapXuat ASC",
                CommandType.Text, null);
        }
        public DataTable DSPhieu (DateTime tuNgay, DateTime denNgay)
        {
            return db.ExcuteQuery ("Select *,CONVERT(bit,0) as Chon From PhieuXuat Where NgayXuat BETWEEN CAST('" + tuNgay.ToString("MM/dd/yyyy") + "' as DATE) AND CAST('" + denNgay.ToString("MM/dd/yyyy") + "' as DATE)",
                CommandType.Text, null);
        }
        public DataTable DSPhieuVatTu ()
        {
            return db.ExcuteQuery ("Select * From PhieuXuatChiTiet,(select MaBV,TenVatTu,DonViTinh from VatTu) as VT Where VT.MaBV = PhieuXuatChiTiet.MaVatTu and SoPhieu = " + this.SoPhieu,
                CommandType.Text, null);
        }
        public DataTable DSPhieuVatTuIn()
        {
            return db.ExcuteQuery("Select MaBV,TenVatTu,DonViTinh,DonGiaBHYT,DonGiaBV,LoaiVatTu," +
                "SUM(SoLuong) as SoLuong,SUM(ThanhTien) as ThanhTien " +
                "From PhieuXuatChiTiet,(select MaBV,TenVatTu,DonViTinh from VatTu) as VT " +
                "Where VT.MaBV = PhieuXuatChiTiet.MaVatTu and SoPhieu = " + this.SoPhieu+" " +
                "Group By MaBV,TenVatTu,DonViTinh,DonGiaBHYT,DonGiaBV,LoaiVatTu",
                CommandType.Text, null);
        }
        public DataTable DSPhieuVatTu(int soPhieu)
        {
            return db.ExcuteQuery("Select * From PhieuXuatChiTiet,(select MaBV,TenVatTu,DonViTinh from VatTu) as VT Where VT.MaBV = PhieuXuatChiTiet.MaVatTu and SoPhieu = " + soPhieu,
                CommandType.Text, null);
        }
        public DataTable DSXuatExcel(DateTime tuNgay,DateTime denNgay, string maKhoa)
        {
            return db.ExcuteQuery("Select * From XuatExcelXuat('"+tuNgay.ToString("MM/dd/yyyy") + "','"+denNgay.ToString("MM/dd/yyyy") + "','"+maKhoa+"')",
                CommandType.Text, null);
        }
        public DataTable DSKhoaBan(int loaiPhong)
        {
            string sql = "";
            sql = "EXEC SpGetKhoaBan '" + AppConfig.CoSoKCB + "'," + loaiPhong;
            return db.ExcuteQuery(sql,
                CommandType.Text, null);
        }
        public bool SpThemPhieuXuat (ref string err)
        {
            SqlParameter outSoPhieu = new SqlParameter ();
            outSoPhieu.SqlDbType = System.Data.SqlDbType.Int;
            outSoPhieu.ParameterName = "@SoPhieu";
            outSoPhieu.Value = SoPhieu;
            outSoPhieu.Direction = ParameterDirection.InputOutput;
            bool f = db.MyExecuteNonQuery("SpThemPhieuXuat",
                CommandType.StoredProcedure, ref err,
                outSoPhieu,
                new SqlParameter("@TKCo", TKCo),
                new SqlParameter("@NgayXuat", NgayXuat.ToString("MM/dd/yyyy")),
                new SqlParameter("@KhoXuat", KhoXuat),
                new SqlParameter("@KhoNhan", KhoNhan),
                new SqlParameter("@NguoiNhan", NguoiNhan),
                new SqlParameter("@NoiDung", NoiDung),
                new SqlParameter("@PheDuyet", PheDuyet),
                new SqlParameter("@NguoiTao", NguoiTao),
                new SqlParameter("@NgayCapNhat", NgayCapNhat.ToString("MM/dd/yyyy")),
                new SqlParameter("@NguoiCapNhat", NguoiCapNhat),
                new SqlParameter("@DiaChi", DiaChi),
                new SqlParameter("@TKNo", TKNo));
            this.SoPhieu = int.Parse (outSoPhieu.Value.ToString ());
            return f;
        }
        public bool SpSuaPhieuXuat(ref string err)
        {
            return db.MyExecuteNonQuery("SpSuaPhieuXuat",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@SoPhieu", SoPhieu),
                new SqlParameter("@TKCo", TKCo),
                new SqlParameter("@NgayXuat", NgayXuat.ToString("MM/dd/yyyy")),
                new SqlParameter("@KhoXuat", KhoXuat),
                new SqlParameter("@KhoNhan", KhoNhan),
                new SqlParameter("@NguoiNhan", NguoiNhan),
                new SqlParameter("@NoiDung", NoiDung),
                new SqlParameter("@PheDuyet", PheDuyet),
                new SqlParameter("@NguoiTao", NguoiTao),
                new SqlParameter("@NgayCapNhat", NgayCapNhat.ToString("MM/dd/yyyy")),
                new SqlParameter("@NguoiCapNhat", NguoiCapNhat),
                new SqlParameter("@DiaChi", DiaChi),
                new SqlParameter("@TKNo", TKNo));
        }
        public bool SpThemPhieuXuatChiTiet (ref string err)
        {
            return db.MyExecuteNonQuery ("SpThemPhieuXuatChiTiet",
                CommandType.StoredProcedure, ref err,              
                new SqlParameter ("@SoPhieu", SoPhieu),
                new SqlParameter ("@SoPhieuNhap", SoPhieuNhap),
                new SqlParameter ("@MaVatTu", MaVatTu),
                new SqlParameter ("@KhoNhan", KhoNhan),
                new SqlParameter ("@SoDangKy", SoDangKy),
                new SqlParameter ("@SoLuong", SoLuong),
                new SqlParameter ("@SoLuongDung", SoLuongDung),
                new SqlParameter ("@DonGiaBHYT", DonGiaBHYT),
                new SqlParameter ("@DonGiaBV", DonGiaBV),
                new SqlParameter ("@HetHan", HetHan.ToString("MM/dd/yyyy")),
                new SqlParameter ("@ThanhTien", ThanhTien),
                new SqlParameter ("@LoaiVatTu", LoaiVatTu));
        }
        public bool SpSuaPhieuXuatChiTiet(ref string err)
        {
            return db.MyExecuteNonQuery("SpSuaPhieuXuatChiTiet",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@SoPhieu", SoPhieu),
                new SqlParameter("@SoPhieuNhap", SoPhieuNhap),
                new SqlParameter("@KhoNhan", KhoNhan),
                new SqlParameter("@MaVatTu", MaVatTu),
                new SqlParameter("@DonGiaBHYT", DonGiaBHYT),
                new SqlParameter("@DonGiaBV", DonGiaBV),
                new SqlParameter("@ThanhTien", ThanhTien));
        }
        public bool SpXoaPhieuXuatChiTiet(ref string err)
        {
            return db.MyExecuteNonQuery("SpXoaPhieuXuatChiTiet",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@SoPhieu", SoPhieu),
                new SqlParameter("@SoPhieuNhap", SoPhieuNhap),
                new SqlParameter("@MaVatTu", MaVatTu));
        }
    }
}
