using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Core.DAL
{
    [DataContract]
    public class LichSuKCB
    {
        [DataMember]
        public string maHoSo { get; set; }
        [DataMember]
        public string maCSKCB { get; set; }
        [DataMember]
        public string tuNgay { get; set; }
        [DataMember]
        public string denNgay { get; set; }
        [DataMember]
        public string tenBenh { get; set; }
        [DataMember]
        public string tinhTrang { get; set; }
        [DataMember]
        public string kqDieuTri { get; set; }
    }
}
