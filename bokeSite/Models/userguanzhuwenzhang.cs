using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bokeSite.Models
{
    public class userguanzhuwenzhang
    {
        public int id { get; set; }
        public int userid { get; set; }
        public int wenzhangid { get; set; }
        public DateTime guanzhushijian { get; set; }
        public DateTime quxiaoguanzhushijian { get; set; }
        public bool isdel { get; set; }
    }
}
