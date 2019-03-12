using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bokeSite.Models
{
    public class group
    {
        public int id { get; set; }
        public string groupname { get; set; }
        public DateTime zhuceshijian { get; set; }
        public DateTime delshijian { get; set; }
        public bool isdel { get; set; }

    }
}
