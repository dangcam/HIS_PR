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
    public class VSSIDEntity
    {
        Connection db;
        public VSSIDEntity()
        {
            db = new Connection();
        }
        public string MaBN { get; set; }
        public string CCCD { get; set; }
        public string SDT { get; set; }
        public byte[] ChanDung { get; set; }
        public byte[] MatTruoc { get; set; }
        public byte[] MatSau { get; set; }
        public DataTable DSVSSID()
        {
            return db.ExcuteQuery("Select * From VSSID Where MaBN = '" + MaBN + "'",
                CommandType.Text, null);
        }
        public bool SpVSSID(ref string err, string Action)
        {
            return db.MyExecuteNonQuery("SpVSSID",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@Action", Action),
                new SqlParameter("@MaBN", MaBN),
                new SqlParameter("@CCCD", CCCD),
                new SqlParameter("@SDT", SDT),
                new SqlParameter("@ChanDung", ChanDung),
                new SqlParameter("@MatTruoc", MatTruoc),
                new SqlParameter("@MatSau", MatSau));
        }
    }
}
