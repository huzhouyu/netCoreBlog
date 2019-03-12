using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bokeSite.Models
{
    public class haoyoushenqing
    {
        public int id { get; set; }
        public int shenqingrenid { get; set; }
        public int bieshenqingrenid { get; set; }
        public DateTime shenqingshijian { get; set; }
        public string comment { get; set; }
        public int countmax { get; set; }
    }
}
