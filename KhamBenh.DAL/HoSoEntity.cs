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
    public class HoSoEntity
    {
        Connection db;
        public HoSoEntity()
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
        public string MaKhoa { get; set; }
        public string MaGiuong { get; set; }
        public string MaBacSi { get; set; }
        public DateTime NgayYLenh { get; set; }
        public DateTime NgayKQ { get; set; }
        public string MaChiSo { get; set; }
        public string GiaTri { get; set; }
       public string MoTa { get; set; }
        public string KetLuan { get; set; }
        public string MaMay { get; set; }

        public DataTable DSGiuong()
        {
            return db.ExcuteQuery("Select Ma,Ten,DonGia,MaNhom From GiuongBenh Where TinhTrang =1 And Ma_CS ='" + 
                AppConfig.CoSoKCB + "'", CommandType.Text, null);
        }
        public DataTable DSDichVu()
        {
            return db.ExcuteQuery("Select MaDVKT,TenDVKT,DonGia,DV.MaNhom,TT50," +
                "MauSo,MaMay From" +
                "(Select * From DichVuKyThuat Where TinhTrang =1 And Ma_CS ='" +
                AppConfig.CoSoKCB + "') AS DV " +
                "LEFT JOIN NhomCanLamSan ON NhomCanLamSan.MaNhom = DV.MaNhom", CommandType.Text, null);
        }
        public DataTable DSDichVuGiuongBenh()
        {
            return db.ExcuteQuery("Select MaDichVu,TenDichVu,DonViTinh,SoLuong,DonGia," +
                "ThanhTien,MaKhoa,MaGiuong,MaBacSi,NgayYLenh,NgayKQ " +
                " From DichVuChiTiet Where MaNhom = 15 And MaLK ='" +
                this.MaLK + "'", CommandType.Text, null);
        }
        public DataTable DSDichVuChiTiet()
        {
            return db.ExcuteQuery(" " +
                "Select DichVuChiTiet.MaLK,DichVuChiTiet.MaDichVu,MaNhom,TenDichVu,DonViTinh,SoLuong,DonGia," +
                "ThanhTien,MaKhoa,MaGiuong,MaBacSi,NgayYLenh,DichVuChiTiet.NgayKQ,GiaTri,MoTa,KetLuan,MaChiSo," +
                "MaMay " +
                " From DichVuChiTiet,HoSoCanLamSan Where DichVuChiTiet.MaLK ='" + MaLK + "' And MaNhom != 15 And MaNhom != 13 " +
                " AND HoSoCanLamSan.MaDichVu = DichVuChiTiet.MaDichVu And HoSoCanLamSan.MaLK ='" + MaLK + "'",
                CommandType.Text, null);

            //return db.ExcuteQuery("Select * From " +
            //    "(Select MaLK,MaDichVu,MaNhom,TenDichVu,DonViTinh,SoLuong,DonGia," +
            //    "ThanhTien,MaKhoa,MaGiuong,MaBacSi,NgayYLenh,NgayKQ" +
            //    " From DichVuChiTiet Where MaLK ='" + MaLK + "' And MaNhom != 15 And MaNhom != 13) AS DV" +
            //    " LEFT JOIN HoSoCanLamSan ON HoSoCanLamSan.MaDichVu = DV.MaDichVu",
            //    CommandType.Text, null);

            //return db.ExcuteQuery("Select DichVuChiTiet.MaDichVu,TenDichVu,GiaTri,MoTa,KetLuan,DonViTinh,SoLuong,DonGia," +
            //   "ThanhTien,MaKhoa,MaGiuong,MaBacSi,NgayYLenh,DichVuChiTiet.NgayKQ " +
            //   "From DichVuChiTiet,HoSoCanLamSan " +
            //   "Where DichVuChiTiet.MaLK ='" + MaLK + "' And DichVuChiTiet.MaDichVu = HoSoCanLamSan.MaDichVu " +
            //   "And HoSoCanLamSan.MaLK = '" + MaLK + "'",
            //   CommandType.Text, null);
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
                new SqlParameter("@MaGiuong", MaGiuong),
                new SqlParameter("@MaBacSi", MaBacSi),
                new SqlParameter("@NgayYLenh", NgayYLenh),
                new SqlParameter("@NgayKQ", NgayKQ),
                new SqlParameter("@MaChiSo", MaChiSo),
                new SqlParameter("@GiaTri", GiaTri),
                new SqlParameter("@MaMay", MaMay),
                new SqlParameter("@MoTa", MoTa),
                new SqlParameter("@KetLuan", KetLuan));
        }
    }
}
