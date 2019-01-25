using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DAL
{
    public class KQNhanLichSuKCBBS
    {
        public string maKetQua { get; set; }
        public string ghiChu { get; set; }
        public string maThe { get; set; }
        public string hoTen { get; set; }
        public string ngaySinh { get; set; }
        public string gioiTinh { get; set; }
        public string diaChi { get; set; }
        public string maDKBD { get; set; }
        public string cqBHXH { get; set; }
        public string gtTheTu { get; set; }
        public string gtTheDen { get; set; }
        public string maKV { get; set; }
        public string ngayDu5Nam { get; set; }
        public string maSoBHXH { get; set; }
        public string maTheCu { get; set; }
        public string maTheMoi { get; set; }
        public string gtTheTuMoi { get; set; }
        public string gtTheDenMoi { get; set; }
        public List<LichSuKCB2018> dsLichSuKCB2018 { get; set; }
        public List<LichSuKT2018> dsLichSuKT2018 { get; set; }
        //
        public System.Data.DataTable LichSuPhanMem { get; set; }
        public string MaBN { get; set; }
    }
}
