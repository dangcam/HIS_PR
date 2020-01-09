using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DAL
{
    public class DangNhapEntity
    {
        Connection db;
        public DangNhapEntity()
        {
            db = new Connection ();
        }
        public string MaNV
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
        public int CheckLogin ()
        {
            DataTable data = db.ExcuteQuery ("Select Ma_NV,MatKhau,CoSoKCB,MaKhoa,Ten_CS" +
                " From NhanVien,CoSoKCB Where Ma_NV = '"+MaNV+"' And MatKhau = '"+MatKhau+"' And TinhTrang = 1 and CoSoKCB.Ma_CS = NhanVien.CoSoKCB",
                CommandType.Text, null);

            if(data == null )
            {
                return -1;
            }
            if (data.Rows.Count == 0)
            {
                return 0;
            }
            AppConfig.MaNV = data.Rows[0]["Ma_NV"].ToString ();
            AppConfig.MatKhau = data.Rows[0]["MatKhau"].ToString ();
            AppConfig.CoSoKCB = data.Rows[0]["CoSoKCB"].ToString ();
            AppConfig.MaKhoa = data.Rows[0]["MaKhoa"].ToString();
            AppConfig.TenCoSoKCB = Utils.ToString(data.Rows[0]["Ten_CS"]);

            
            Utils.ThemHoatDong (Library.DANGNHAP);

            return 1;
        }
       
    }
}
