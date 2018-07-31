using Core.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanhMuc.DAL
{
    public class NhanVienEntity
    {
        Connection db;
        public NhanVienEntity()
        {
            db = new Connection ();
        }
        public string MaNV
        {
            get;
            set;
        }
        public string TenNV
        {
            get;
            set;
        }
        public int GioiTinh
        {
            get;
            set;
        }
        public DateTime NamSinh
        {
            get;
            set;
        }
        public string MaKhoa
        {
            get;
            set;
        }
        public string MaCV
        {
            get;
            set;
        }
        public string HocHamHocVi
        {
            get;
            set;
        }
        public string ChuyenMon
        {
            get;
            set;
        }
        public DateTime NgayVao
        {
            get;
            set;
        }
        public bool TinhTrang
        {
            get;
            set;
        }    
        public string MaBS
        {
            get;
            set;
        }
        public string MatKhau
        {
            get;
            set;
        }
        public string CoSoKCB
        {
            get;
            set;
        }
        public DataTable DSChucVu ()
        {
            return db.ExcuteQuery ("Select * From ChucVu",
                CommandType.Text, null);
        }
        public DataTable DSCoSo ()
        {
            return db.ExcuteQuery ("Select * From CoSoKCB Where Ma_CS = '70013' OR Ma_CS = '70074' "
                + "OR Ma_CS = '70075' OR Ma_CS = '70076' OR Ma_CS = '70077' OR Ma_CS = '70078'",
                CommandType.Text, null);
        }
        public DataTable DSKhoaBanCap(int cap)
        {
            return db.ExcuteQuery("Select MaKhoa as Ma_CS,TenKhoa as Ten_CS From KhoaBan where CapDo = " + cap + " and TinhTrang = 1",
                CommandType.Text, null);
        }
        public DataTable DSHocHamHocVi ()
        {
            return db.ExcuteQuery ("Select * From HocHamHocVi",
                CommandType.Text, null);
        }
        public DataTable DSKhoaBoPhan ()
        {
            return db.ExcuteQuery ("Select MaKhoa,TenKhoa From KhoaBan Where TinhTrang = 1",
                CommandType.Text, null);
        }
        public DataTable DSKhoaBan(int loaiPhong, string coSo)
        {
            string sql = "";
            sql = "EXEC SpGetKhoaBan '" +coSo + "'," + loaiPhong;
            return db.ExcuteQuery(sql,
                CommandType.Text, null);
        }
        public DataTable DSChuyenMon ()
        {
            return db.ExcuteQuery ("Select * From ChuyenMon",
                CommandType.Text, null);
        }
        public DataTable DSNhanVien ()
        {
            return db.ExcuteQuery ("Select * From NhanVien",
                CommandType.Text, null);
        }
        public bool ThemNhanVien (ref string err)
        {
            return db.MyExecuteNonQuery ("SpThemNhanVien",
                CommandType.StoredProcedure, ref err,
                new SqlParameter ("@Ma_NV", MaNV),
                new SqlParameter ("@Ten_NV", TenNV),
                new SqlParameter ("@GioiTinh", GioiTinh),
                new SqlParameter ("@NamSinh", NamSinh),
                new SqlParameter ("@MaKhoa", MaKhoa),
                new SqlParameter ("@Ma_CV", MaCV),
                new SqlParameter ("@HocHamHocVi", HocHamHocVi),
                new SqlParameter ("@ChuyenMon", ChuyenMon),
                new SqlParameter ("@NgayVao", NgayVao),
                new SqlParameter ("@TinhTrang", TinhTrang),
                new SqlParameter ("@Ma_BS", MaBS),
                new SqlParameter ("@MatKhau", MatKhau),
                new SqlParameter ("@CoSoKCB", CoSoKCB));
        }
        public bool SuaNhanVien (ref string err)
        {
            return db.MyExecuteNonQuery ("SpSuaNhanVien",
                CommandType.StoredProcedure, ref err,
                new SqlParameter ("@Ma_NV", MaNV),
                new SqlParameter ("@Ten_NV", TenNV),
                new SqlParameter ("@GioiTinh", GioiTinh),
                new SqlParameter ("@NamSinh", NamSinh),
                new SqlParameter ("@MaKhoa", MaKhoa),
                new SqlParameter ("@Ma_CV", MaCV),
                new SqlParameter ("@HocHamHocVi", HocHamHocVi),
                new SqlParameter ("@ChuyenMon", ChuyenMon),
                new SqlParameter ("@NgayVao", NgayVao),
                new SqlParameter ("@TinhTrang", TinhTrang),
                new SqlParameter ("@Ma_BS", MaBS),
                new SqlParameter ("@MatKhau", MatKhau),
                new SqlParameter ("@CoSoKCB", CoSoKCB));
        }
        public bool XoaNhanVien (ref string err)
        {
            return db.MyExecuteNonQuery ("SpXoaNhanVien",
                CommandType.StoredProcedure, ref err,
                new SqlParameter ("@Ma_NV", MaNV));
        }
    }
}
