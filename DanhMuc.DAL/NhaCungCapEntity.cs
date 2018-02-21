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
    public class NhaCungCapEntity
    {
        Connection db;
        public NhaCungCapEntity ()
        {
            db = new Connection ();
        }
        public string ID
        {
            get;
            set;
        }
        public string Ten
        {
            get;
            set;
        }
        public bool TinhTrang
        {
            get;
            set;
        }
        public string DiaChi { get; set; }
        public DataTable DSNhaCungCap ()
        {
            return db.ExcuteQuery ("Select * From NhaCungCap",
                CommandType.Text, null);
        }
        public bool ThemNhaCungCap (ref string err)
        {
            return db.MyExecuteNonQuery ("SpThemNhaCungCap",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@ID", ID),
                new SqlParameter ("@Ten", Ten),
                new SqlParameter ("@TinhTrang", TinhTrang),
                new SqlParameter("@DiaChi", DiaChi));
        }
        public bool SuaNhaCungCap (ref string err)
        {
            return db.MyExecuteNonQuery ("SpSuaNhaCungCap",
                CommandType.StoredProcedure, ref err,
                new SqlParameter ("@ID", ID),
                new SqlParameter ("@Ten", Ten),
                new SqlParameter ("@TinhTrang", TinhTrang),
                new SqlParameter("@DiaChi", DiaChi));
        }
        public bool XoaNhaCungCap (ref string err)
        {
            return db.MyExecuteNonQuery ("SpXoaNhaCungCap",
                CommandType.StoredProcedure, ref err,
                new SqlParameter ("@ID", ID));
        }
    }
}
