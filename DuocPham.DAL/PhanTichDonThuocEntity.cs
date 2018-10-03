using Core.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuocPham.DAL
{
    public class PhanTichDonThuocEntity
    {
        Connection db;
        public PhanTichDonThuocEntity()
        {
            db = new Connection();
        }
        public DataTable DataThuoc()
        {
            return db.ExcuteQuery("Select KE_DON = " +
                    "STUFF((" +
                    "          SELECT ',' + convert(varchar(10), ID)" +
                    "          FROM(select MaLK, ID from DonThuocChiTiet, DataMaThuoc" +
                    "                    where DonThuocChiTiet.MaVatTu = DataMaThuoc.MaVatTu) as DonThuoc" +
                    "          WHERE DonThuocChiTiet.MaLK = DonThuoc.MaLK group by ID" +
                    "          FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 1, '')" +
                    "    From DonThuocChiTiet group by MaLK",
                CommandType.Text, null);
        }
        public DataTable DataDinhBenh()
        {
            return db.ExcuteQuery("select (convert(varchar,DinhBenh)+','+TONG_BENH) as KE_DON from " +
                        "(Select MaLK, TONG_BENH ="+
                        "STUFF(("+
                        "          SELECT ',' + convert(varchar(10), ID)"+
                        "          FROM(select MaLK, ID from DonThuocChiTiet, DataMaThuoc"+
                        "                    where DonThuocChiTiet.MaVatTu = DataMaThuoc.MaVatTu) as DonThuoc"+
                        "          WHERE DonThuocChiTiet.MaLK = DonThuoc.MaLK group by ID"+
                        "          FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 1, '')"+
                        "    From DonThuocChiTiet group by MaLK) Thuoc,"+
                        "	(select MaLK, ID as DinhBenh from ThongTinBNChiTiet, DataMaThuoc"+
                        "        where ThongTinBNChiTiet.MaBenh = DataMaThuoc.MaVatTu)"+
                        "    as CT where CT.MaLK = Thuoc.MaLK",
                CommandType.Text, null);
        }
        public DataTable DataTen()
        {
            return db.ExcuteQuery("select ID,TenVatTu as Ten from DataMaThuoc,VatTu " +
                            "where DataMaThuoc.MaVatTu = VatTu.MaBV and LoaiVatTu = '1'" +
                            "UNION ALL "+
                            "select ID, TenBenh as Ten from DataMaThuoc, BenhICD " +
                            "where DataMaThuoc.MaVatTu = BenhICD.MaBenh",
                CommandType.Text, null);
        }
    }
}
