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
    public class VatTuDinhBenhEntity
    {
        Connection db;
        public VatTuDinhBenhEntity()
        {
            db = new Connection();
        }
        public string LoaiVatTu { get; set; }
        public string MaVatTu { get; set; }
        public string MaBenh { get; set; }
        public DataTable DSLoaiVatTu()
        {
            return db.ExcuteQuery("Select * From LoaiVatTu Where TinhTrang = 1",
                CommandType.Text, null);
        }
        public DataTable DSVatTu()
        {
            return db.ExcuteQuery("Select MaBV,MaHoatChat,HoatChat,HamLuong,TenVatTu,DonViTinh,GiaBHYT " +
                "From VatTu Where LoaiVatTu = '"+LoaiVatTu+"' and KeDon = 1",
                CommandType.Text, null);
        }
        public DataTable DSBenhIDC()
        {
            return db.ExcuteQuery("Select * From BenhICD",
                CommandType.Text, null);
        }
        public DataTable DSVatTuDinhBenh()
        {
            return db.ExcuteQuery("Select BenhICD.MaBenh,TenBenh From BenhICD,VatTuDinhBenh " +
                "where VatTuDinhBenh.MaBenh = BenhICD.MaBenh and VatTuDinhBenh.MaBV = '"+ MaVatTu + "'",
                CommandType.Text, null);
        }
        public bool SpVatTuDinhBenh(ref string err, string Action)
        {
            return db.MyExecuteNonQuery("SpVatTuDinhBenh",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@Action", Action),
                new SqlParameter("@MaBV", MaVatTu),
                new SqlParameter("@MaBenh", MaBenh));
        }
    }
}
