using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bokeSite.Models
{
    /// <summary>
    /// 用户表
    /// </summary>
    public class userinfo
    {
        public int id { get; set; }
        public string username { get; set; }
        public string pwd { get; set; }
        public string nicheng { get; set; }
        public DateTime zhuceshijian { get; set; }
        public DateTime xiugaishijian { get; set; }
        public string touxiangurl { get; set; }
        public int isdel { get; set; }
    }
    /// <summary>
    /// 文章详情表
    /// </summary>
    public class userwenzhang
    {
        public int id { get; set; }
        public int leixing { get; set; }
        public int userid { get; set; }
        public string content { get; set; }
        public string content100 { get; set; }
        public DateTime zhuceshijian { get; set; }
        public DateTime xiugaishijian { get; set; }
        public int dianjiliang { get; set; }
        public string wenzhangname { get; set; }
        public int iskejian { get; set; }
        public string wenzhangurl { get; set; }
        public int isdel { get; set; }
    }
    /// <summary>
    /// 文章类型表
    /// </summary>
    public class userwenzhangleixing
    {
        public int id { get; set; }
        public string leixingming { get; set; }
        public int userid { get; set; }
        public DateTime zhuceshijian { get; set; }
        public DateTime xiugaishijian { get; set; }
    }
    /// <summary>
    /// 文章评论表
    /// </summary>
    public class wenzhangpinglun
    {
        public int id { get; set; }
        public int wenzhangid { get; set; }
        public int pinglunrenid { get; set; }
        public string pinglunneirong { get; set; }
        public DateTime pinglunshijian { get; set; }
        public bool isdel { get; set; }
        public bool isread { get; set; }
        public int dianzanshu { get; set; }
    }
    /// <summary>
    /// 文章评论子集表
    /// </summary>
    public class wenzhangpinglunson
    {
        public int id { get; set; }
        public int pinglunid { get; set; }
        public int pinglunrenid { get; set; }
        public string pinglunneirong { get; set; }
        public DateTime pinglunshijian { get; set; }
        public int huifurenid { get; set; }
        public bool isdel { get; set; }
        public bool isread { get; set; }
        public int dianzanshu { get; set; }
    }

    public class userwenzhangleixingkuozhan : userwenzhangleixing
    {
        public int count { get; set; }
    }
   public class userwenzhangkuozhan : userwenzhang
    {
        public int count { get; set; }
        public int toal { get; set; }
        public int pingluntiaoshu { get; set; }
        public string leixingming { get; set; }
        public string nicheng { get; set; }
    }
    
   public class allwenzhengpinglun:wenzhangpinglunkuozhan
    {
        public Result<List<wenzhangpinglunsonkuozhan>> wenzhangpinglunsonlist { get; set; }
    }

    public class wenzhangpinglunkuozhan : wenzhangpinglun
    {
        public string pinglunrennicheng { get; set; }
        public string pinglunrenusername { get; set; }
        public string usertouxiangurl { get; set; }
    }
    public class wenzhangpinglunsonkuozhan : wenzhangpinglunson
    {
        public string pinglunrennicheng { get; set; }
        public string pinglunrenusername { get; set; }
        public string huifurennicheng { get; set; }
        public string huifurenusername { get; set; }
    }
   public class fenyezhuanyong
    {
        public  int page { get; set; }
        public  int pagecount { get; set; }
        public int id { get; set; }
    }
    public class Result<T>
    {
        public bool issuf { get; set; }
        public int count { get; set; }
        public string msg { get; set; }
        public T content { get; set; }
    }
}
