using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Core.DAL
{
    public class ApiTheBHYT2018
    {
        [DataMember]
        public string maThe { get; set; }
        [DataMember]
        public string hoTen { get; set; }
        [DataMember]
        public string ngaySinh { get; set; }
    }
}
