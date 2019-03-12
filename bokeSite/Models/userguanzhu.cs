using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bokeSite.Models
{
    public class userguanzhu
    {
        public int id { get; set; }
        public int userid { get; set; }
        public int guanzhuuserid{get;set;}
        public DateTime guanzhushijian { get; set; }
        public DateTime quxiaoguanzhushijian { get; set; }
        public bool isdel { get; set; }
        public string beizhu { get; set; }

    }
}
