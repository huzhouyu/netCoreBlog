using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bokeSite.Models
{
    public class groupcomment
    {
        public int id { get; set; }
        public int groupid { get; set; }
        public int userid { get; set; }
        public DateTime fabiaoshijian { get; set; }
        public string comment { get; set; }
    }
}
