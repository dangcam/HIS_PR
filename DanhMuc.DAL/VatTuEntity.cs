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
    public class VatTuEntity
    {
        Connection db;
        public VatTuEntity()
        {
            db = new Connection();
        }
        public string LoaiVatTu { get; set; }
        public string NhomVatTu { get; set; }
        public string MaBV { get; set; }
        public string MaHoatChat { get; set; }
        public string HoatChat { get; set; }
        public string MaDuongDung { get; set; }
        public string HamLuong { get; set; }
        public string TenVatTu { get; set; }
        public string SoDK { get; set; }
        public string DonViTinh { get; set; }
        public string QuyCach { get; set; }
        public string HangSX { get; set; }
        public string NuocSX { get; set; }
        public string QuyetDinh { get; set; }
        public string CongBo { get; set; }
        public string LoaiThuoc { get; set; }
        public decimal GiaBHYT { get; set; }
        public bool TinhTrang { get; set; }
        public string GoiThau { get; set; }
        public string NhomThau { get; set; }
        public int LoaiThau { get; set; }
        public bool KeDon { get; set; }
        public DataTable DSLoaiVatTu()
        {
            return db.ExcuteQuery("Select * From LoaiVatTu Where TinhTrang = 1",
                CommandType.Text, null);
        }
        public DataTable DSNhomVatTu()
        {
            return db.ExcuteQuery("Select * From NhomVatTu Where MaLoai = '" + LoaiVatTu + "' And TinhTrang = 1",
                CommandType.Text, null);
        }
        public DataTable DSDuongDung()
        {
            return db.ExcuteQuery("Select * From DuongDung",
                CommandType.Text, null);
        }
        public DataTable DSDonViTinh()
        {
            return db.ExcuteQuery("Select * From DonViTinh",
                CommandType.Text, null);
        }
        public DataTable DSNuocSX()
        {
            return db.ExcuteQuery("Select * From NuocSX Where TinhTrang = 1",
                CommandType.Text, null);
        }
        public DataTable DSGoiThau()
        {
            return db.ExcuteQuery("Select * From GoiThau",
                CommandType.Text, null);
        }
        public DataTable DSVatTu()
        {
            string sql = "Select* From VatTu Where LoaiVatTu = '" + LoaiVatTu + "'";
            if (!string.IsNullOrEmpty(NhomVatTu))
            {
                sql += " and NhomVatTu = '" + NhomVatTu + "'";
            }
            return db.ExcuteQuery(sql,
                CommandType.Text, null);
        }
        public bool SpVatTu(ref string err, string Action)
        {
            return db.MyExecuteNonQuery("SpVatTu",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@Action", Action),
                new SqlParameter("@LoaiVatTu", LoaiVatTu),
                new SqlParameter("@NhomVatTu", NhomVatTu),
                new SqlParameter("@MaBV", MaBV),
                new SqlParameter("@MaHoatChat", MaHoatChat),
                new SqlParameter("@HoatChat", HoatChat),
                new SqlParameter("@MaDuongDung", MaDuongDung),
                new SqlParameter("@HamLuong", HamLuong),
                new SqlParameter("@TenVatTu", TenVatTu),
                new SqlParameter("@SoDK", SoDK),
                new SqlParameter("@DonViTinh", DonViTinh),
                new SqlParameter("@QuyCach", QuyCach),
                new SqlParameter("@HangSX", HangSX),
                new SqlParameter("@NuocSX", NuocSX),
                new SqlParameter("@QuyetDinh", QuyetDinh),
                new SqlParameter("@CongBo", CongBo),
                new SqlParameter("@LoaiThuoc", LoaiThuoc),
                new SqlParameter("@GoiThau", GoiThau),
                new SqlParameter("@NhomThau", NhomThau),
                new SqlParameter("@LoaiThau", LoaiThau),
                new SqlParameter("@GiaBHYT", GiaBHYT),
                new SqlParameter("@TinhTrang", TinhTrang),
                new SqlParameter("@KeDon", KeDon));
        }
    }
}
