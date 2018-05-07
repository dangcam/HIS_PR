using Core.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoCao.DAL
{
    public class NhapXuatEntity
    {
        Connection db;
        public NhapXuatEntity()
        {
            db = new Connection ();
        }
        public string LoaiVatTu { get; set; }
        public DateTime TuNgay { get; set; }
        public DateTime DenNgay { get; set; }
        public DataTable DSNVKhoDuoc()
        {
            return db.ExcuteQuery("Select * From NVKhoaDuoc ",
                CommandType.Text, null);
        }
        public DataTable DSLoaiVatTu ()
        {
            return db.ExcuteQuery ("Select Ma,Ten From LoaiVattu Where TinhTrang = 1 ",
                CommandType.Text, null);
        }
        public DataTable DSLoaiVatTuChon()
        {
            return db.ExcuteQuery("Select Ma,Ten,CONVERT(bit,1) as Chon From LoaiVatTu Where TinhTrang = 1",
                CommandType.Text, null);
        }
        public DataTable DSTonKhoThuc(string sql)
        {
            return db.ExcuteQuery("Select *,(SLTonDau*DonGia) as GTTonDau,(SLNhap*DonGia) as GTNhap, " +
                "(SLXuatTrong*DonGia) as GTXuat,(SLTonCuoi*DonGia) as GTTonCuoi " +
                "From BaoCaoTonThuc('" + TuNgay.ToString("MM/dd/yyyy") + "','" + DenNgay.ToString("MM/dd/yyyy") + "') Where "+sql,
                CommandType.Text, null);
        }
        public DataTable DSVatTu ()
        {
            string sql = "";
            if (LoaiVatTu == null)
            {
                sql = "Select *,((GTT+GTN)/(SLT + SLN)) AS DonGia,((SLT + SLN) - SLX) AS SoLuongTon,CASE WHEN ((SLT + SLN) - SLX) = 0 THEN 0 ELSE ((GTT+GTN)-GTX) END AS GiaTriTon From BaoCaoNhapXuat('" + TuNgay.ToString("MM/dd/yyyy") + "','" + DenNgay.ToString("MM/dd/yyyy") + "') ORDER BY MaBV ASC";
            }
            else
            {
                sql = "Select *,((GTT+GTN)/(SLT + SLN)) AS DonGia,((SLT + SLN) - SLX) AS SoLuongTon,CASE WHEN ((SLT + SLN) - SLX) = 0 THEN 0 ELSE ((GTT+GTN)-GTX) END AS GiaTriTon From BaoCaoNhapXuat('" + TuNgay.ToString("MM/dd/yyyy") + "','" + DenNgay.ToString("MM/dd/yyyy") + "') WHERE LoaiVatTu = '"+LoaiVatTu+"'";
            }
            return db.ExcuteQuery (sql,
                CommandType.Text, null);
        }
        public DataTable DSTongHopXuat(int loaiBC, int thang1, int thang2, int thang3 ,int year)
        {
            string sql = "EXEC SpTongHopXuatKho " + loaiBC + " ," + thang1 + "," + thang2 + "," + thang3 + "," + year;
            return db.ExcuteQuery(sql,
                CommandType.Text, null);
        }
        public bool XuLyTonKho(ref string err, int Thang,int Nam)
        {
            return db.MyExecuteNonQuery("SpXuLyTonKho",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@Thang", Thang),
                new SqlParameter("@Nam", Nam));
        }
        public DataTable DSTonKhoThucLuyKe(string sql,int Thang,int Nam)
        {
            return db.ExcuteQuery("Select *,((GTTonDau+GTNhap) - (SLTonCuoi*DonGia))" +
                " as GTXuat,(SLTonCuoi*DonGia) as GTTonCuoi " +
                "From BaoCaoTonThucLuyKe('"+Thang+"','"+Nam+"','" + TuNgay.ToString("MM/dd/yyyy") + "','" + DenNgay.ToString("MM/dd/yyyy") + "') Where " + sql,
                CommandType.Text, null);
        }
    }
}
