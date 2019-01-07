using Core.DAL;
using System;
using System.Collections.Generic;
using System.Data;
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
        public DataTable DSLoaiVatTu()
        {
            return db.ExcuteQuery("Select * From LoaiVatTu Where TinhTrang = 1",
                CommandType.Text, null);
        }
        public DataTable DSVatTu()
        {
            return db.ExcuteQuery("Select MaBV,MaHoatChat,HoatChat,HamLuong,TenVatTu,DonViTinh " +
                "From VatTu Where LoaiVatTu = '"+LoaiVatTu+"'",
                CommandType.Text, null);
        }
    }
}
