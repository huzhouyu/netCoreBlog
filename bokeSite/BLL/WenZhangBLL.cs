using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bokeSite.DAL;
using MySql.Data;
using MySql.Data.MySqlClient;
using bokeSite.Models;
using System.Data;
using bokeSite.tools.DataToEnity;
using System.Text.RegularExpressions;
using bokeSite.tools;

namespace bokeSite.BLL
{
    public class WenZhangBLL
    {


        /// <summary>
        /// 判断用户是否存在
        /// </summary>
        /// <param name="uif"></param>
        /// <returns></returns>
        public bool islogin(userinfo uif)
        {
            UserinfoDAL ud = new UserinfoDAL();
            MySqlParameter[] mySqlParameter = { new MySqlParameter("@username",uif.username),new MySqlParameter("@pwd", uif.pwd)  };
            
          var data=  ud.testlogin(@"SELECT  id FROM boke.userinfo where username=@username and pwd=@pwd and isdel=0",mySqlParameter);
            return data.Rows.Count==1;
        }
        /// <summary>
        /// 获得用户基础信息
        /// </summary>
        /// <param name="uif"></param>
        /// <returns></returns>
        public DataTable Getuserinfo(userinfo uif)
        {
            UserinfoDAL ud = new UserinfoDAL();
            MySqlParameter[] mySqlParameter = { new MySqlParameter("@username", uif.username), new MySqlParameter("@pwd", uif.pwd) };

            var data = ud.testlogin(@"SELECT  username, id, nicheng,touxiangurl FROM boke.userinfo where username=@username and pwd=@pwd and isdel=0", mySqlParameter);
            return data;
        }
        /// <summary>
        /// 获取用户文章分类
        /// </summary>
        /// <param name="uif"></param>
        /// <returns></returns>
        public List<userwenzhangleixingkuozhan> Getuserwenzhang(string id)
        {
            UserinfoDAL ud = new UserinfoDAL();
            MySqlParameter[] mySqlParameter = { new MySqlParameter("@userid", id) };

            var data = ud.testlogin(@"SELECT id, userid, leixingming FROM boke.userwenzhangleixing where userid=@userid", mySqlParameter);
            
            //if (data.Rows.Count == 0) return null ;
            List<userwenzhangleixingkuozhan> list = new List<userwenzhangleixingkuozhan>();
            foreach (DataRow item in data.Rows)
            {
                var row = DataToEnity<userwenzhangleixingkuozhan>.DataRowToEntity(item);
                MySqlParameter[] leixingmySqlParameter = { new MySqlParameter("@userid", id),new MySqlParameter("@leixing",row.id) };
                row.count =Convert.ToInt32(ud.testlogin(@"SELECT count(id) FROM boke.userwenzhang  where leixing=@leixing and userid=@userid and isdel=false", leixingmySqlParameter).Rows[0][0]);
                
               list.Add(row);
            }

            return list;
        }

     /// <summary>
     /// 获取文章列表
     /// </summary>
     /// <param name="id"></param>
     /// <param name="wenzhangleixing"></param>
     /// <param name="desc">是否倒序</param>
     /// <param name="pagestart"></param>
     /// <param name="pagecount"></param>
     /// <param name="datetimesta"></param>
     /// <param name="datetimeend"></param>
     /// <returns></returns>
        public List<userwenzhangkuozhan> Getuserwenzhanglist(string id, string wenzhangleixing = "-1", string keyword = "", int pagestart = 0, int pagecount = 20, string desc= "asc", string paixuziduan="zhuceshijian", string datetimesta="-1", string datetimeend = "-1")
        {
            List<userwenzhangkuozhan> list = new List<userwenzhangkuozhan>();
            UserinfoDAL ud = new UserinfoDAL();
            DataTable data = new DataTable();
            int toal = 0;
             int start =pagestart * pagecount;
            DateTime dtsta = DateTime.Parse("1970-01-01");
            DateTime dtend = DateTime.Now;
            if (datetimesta != "-1")
            {
                dtsta = DateTime.Parse(datetimesta);
            }
            if (datetimeend != "-1")
            {
                dtend = DateTime.Parse(datetimeend);
            }
            string key = "";
            
            if (string.IsNullOrEmpty(keyword)|| keyword=="-1")
            {
                key = ".{1}";
            }
            else
            {
                for (int i = 0; i < keyword.Length; i++)
                {
                    if (Regex.IsMatch(keyword[i].ToString(), "[a-z|A-Z]")) {
                        key += keyword[i];
                        continue;
                    }
                    key += keyword[i] + ".{0,8}";
                }
            }
            if (wenzhangleixing =="-1")
                {
                    MySqlParameter[] mySqlParameter = { new MySqlParameter("@userid", id),new MySqlParameter("@pagestart", start), new MySqlParameter("@pagecount", pagecount),new MySqlParameter("@zhuceshijiansta",dtsta),new MySqlParameter("@zhuceshijianend",dtend),new MySqlParameter("@content",key) };
                    data = ud.testlogin(String.Format("SELECT id, leixing, userid, content100, zhuceshijian, xiugaishijian, dianjiliang, wenzhangname FROM boke.userwenzhang where userid=@userid and zhuceshijian>@zhuceshijiansta and zhuceshijian<@zhuceshijianend and isdel=false and content regexp @content order by {0} {1} limit @pagestart,@pagecount", paixuziduan,desc), mySqlParameter);
                    toal =Convert.ToInt32(ud.testlogin(@"SELECT count(id) as toal FROM boke.userwenzhang where userid=@userid and zhuceshijian>@zhuceshijiansta and zhuceshijian<@zhuceshijianend and isdel=false and content regexp @content", mySqlParameter).Rows[0][0]);
            }
                else
                {
                    MySqlParameter[] mySqlParameter = { new MySqlParameter("@userid", id), new MySqlParameter("@leixing", wenzhangleixing), new MySqlParameter("@pagestart", start), new MySqlParameter("@pagecount", pagecount), new MySqlParameter("@zhuceshijiansta", dtsta), new MySqlParameter("@zhuceshijianend", dtend),new MySqlParameter("@content",key) };
                    data = ud.testlogin(String.Format("SELECT id, leixing, userid, content100, zhuceshijian, xiugaishijian, dianjiliang, wenzhangname FROM boke.userwenzhang where leixing=@leixing and userid=@userid and zhuceshijian>@zhuceshijiansta and zhuceshijian<@zhuceshijianend and isdel=false and content regexp @content order by {0} {1}  limit @pagestart,@pagecount", paixuziduan, desc), mySqlParameter);
                    toal = Convert.ToInt32(ud.testlogin(@"SELECT count(id) as toal FROM boke.userwenzhang where leixing=@leixing and userid=@userid and zhuceshijian>@zhuceshijiansta and zhuceshijian<@zhuceshijianend and isdel=false and content regexp @content", mySqlParameter).Rows[0][0]);

            }
            
                var leixinglist= Getuserwenzhang(id); ;
            foreach (DataRow item in data.Rows)
            {

                var row = DataToEnity<userwenzhangkuozhan>.DataRowToEntity(item);
                MySqlParameter[] mySqlParameter = { new MySqlParameter("@wenzhangid", row.id) };
                row.pingluntiaoshu = Convert.ToInt32(ud.testlogin(@"SELECT count(id) as toal FROM boke.wenzhangpinglun where wenzhangid=@wenzhangid and isdel=0", mySqlParameter).Rows[0][0]);
                var leixingming= leixinglist.Where(u => u.id == row.leixing).ToList();
                row.leixingming = "未设主题";
                if (leixingming != null && leixingming.Count ==1)
                {
                    row.leixingming = leixingming[0].leixingming;
                }
                list.Add(row);
            }
            if (list.Count > 0)
            {
                list[0].toal = toal;
                list[0].count = list.Count;
            }
            else
            {
                list.Add(new userwenzhangkuozhan() {toal=toal,count=0 });
            }
            return list;
        }
        /// <summary>
        /// 获取指定用户的指定文章
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public userwenzhangkuozhan GetUserwenzhang(string userid,string id)
        {
            UserinfoDAL ud = new UserinfoDAL();
            MySqlParameter[] mySqlParameter = { new MySqlParameter("@id",id),new MySqlParameter("@userid",userid)};
            var data = ud.testlogin(@"SELECT id, leixing, userid,wenzhangurl, zhuceshijian, xiugaishijian, dianjiliang, wenzhangname,iskejian FROM boke.userwenzhang where id=@id and userid=@userid and isdel=false", mySqlParameter);
            if (data.Rows.Count == 1)
            {
              var dt= DataToEnity<userwenzhangkuozhan>.DataRowToEntity(data.Rows[0]);
                dt.leixingming = "未设主题";
                dt.nicheng = "欠名";
                if (dt.leixing != 0)
                {
                   dt.leixingming= Getuserwenzhang(userid).Where(u=>u.id==dt.leixing).FirstOrDefault().leixingming;
                }
                var uif =new UserInfoBLL().Getuserinfo(dt.userid);
                if (uif != null&&uif.nicheng!=null)
                {
                    dt.nicheng = uif.nicheng;
                }
                dt.content= bokeSite.tools.FileRW.readHtml(dt.wenzhangurl);
                return dt;
                
            }
            return null;
        }


        /// <summary>
        /// 获取指定用户的指定文章的文本
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public userwenzhangkuozhan GetUserwenzhangText(string userid, string id)
        {
            UserinfoDAL ud = new UserinfoDAL();
            MySqlParameter[] mySqlParameter = { new MySqlParameter("@id", id), new MySqlParameter("@userid", userid) };
            var data = ud.testlogin(@"SELECT id, leixing, userid,wenzhangurl, zhuceshijian, xiugaishijian, dianjiliang, wenzhangname,iskejian FROM boke.userwenzhang where id=@id and userid=@userid and isdel=false", mySqlParameter);
            if (data.Rows.Count == 1)
            {
                var dt = DataToEnity<userwenzhangkuozhan>.DataRowToEntity(data.Rows[0]);
                dt.leixingming = "未设主题";
                dt.nicheng = "欠名";
                if (dt.leixing != 0)
                {
                    dt.leixingming = Getuserwenzhang(userid).Where(u => u.id == dt.leixing).FirstOrDefault().leixingming;
                }
                var uif = new UserInfoBLL().Getuserinfo(dt.userid);
                if (uif != null && uif.nicheng != null)
                {
                    dt.nicheng = uif.nicheng;
                }
                dt.content= bokeSite.tools.FileRW.readHtml(dt.wenzhangurl);
                return dt;

            }
            return null;
        }

        /// <summary>
        /// 添加文章类型
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="leixingming"></param>
        /// <returns>添加成功的文章类型的主键</returns>
        public int addleixing(string userid,string leixingming)
        {
            UserinfoDAL ud = new UserinfoDAL();
            MySqlParameter[] mySqlParameter = { new MySqlParameter("@leixingming", bokeSite.tools.FileRW.Html2Text(leixingming)),new MySqlParameter("@userid",userid) };

            var data = ud.dataUapdatOrInsert(@"insert into boke.userwenzhangleixing values(null,@userid,@leixingming,now(),now())", mySqlParameter);
            if (data== 1)
            {
               var dt=  ud.testlogin(@"select id from boke.userwenzhangleixing where userid=@userid and leixingming =@leixingming  order by zhuceshijian desc", mySqlParameter);
                return Convert.ToInt32(dt.Rows[0][0]) ;
            }

            return 0;
        }

        /// <summary>
        /// 添加文章
        /// </summary>
        /// <param name="uz"></param>
        /// <returns></returns>

        public Result<userwenzhang> addwenzhang( userwenzhang uz,string path)
        {

            UserinfoDAL ud = new UserinfoDAL();
            MySqlParameter[] mySqlParameter1 = { new MySqlParameter("@userid", uz.userid), new MySqlParameter("@wenzhangname", uz.wenzhangname) };
            Result<userwenzhang> rs = new Result<userwenzhang>();
            rs.issuf = false;
            int ishavaname =Convert.ToInt32(ud.testlogin(@"select count(id) from boke.userwenzhang where userid =@userid and wenzhangname =@wenzhangname and isdel=0", mySqlParameter1).Rows[0][0]);
            if (ishavaname == 0)
            {
                string pathjichu = "\\upload\\wenzhang\\"+DateTime.Now.ToString("yyyyMMdd") +"\\"+Guid.NewGuid() + ".ihtml";
                pathjichu = pathjichu.Replace("\\", "/");
                path = path + "wwwroot"+pathjichu;
                if (bokeSite.tools.FileRW.CreateHtml(path, uz.content))
                {
                    uz.content100 = bokeSite.tools.FileRW.Html2Text(uz.content100);
                    string content100 = "";
                    if (uz.content100!=null&& uz.content100.Length > 400)
                    {
                        content100 = uz.content100.Substring(0, 400);
                    }
                    else
                    {
                        content100 = uz.content100;
                    }
                    MySqlParameter[] mySqlParameter = { new MySqlParameter("@content", uz.content100), new MySqlParameter("@content100", content100)
                    , new MySqlParameter("@iskejian", uz.iskejian), new MySqlParameter("@leixing", uz.leixing), new MySqlParameter("@userid", uz.userid)
                    , new MySqlParameter("@wenzhangname",bokeSite.tools.FileRW.Html2Text(uz.wenzhangname)),new MySqlParameter("@wenzhangurl",pathjichu) };
                    var data = ud.dataUapdatOrInsert(@"insert into boke.userwenzhang values(null,@leixing,@userid,@content,@content100,now(),now(),0,@wenzhangname,@iskejian,false,@wenzhangurl)", mySqlParameter);
                    if (data == 1)
                    {
                        var dt = ud.testlogin(@"select id from boke.userwenzhang where wenzhangname =@wenzhangname and isdel=0  order by zhuceshijian desc", mySqlParameter);
                        rs.issuf = true;
                        rs.count = 1;
                        rs.content = DataToEnity<userwenzhang>.DataRowToEntity(dt.Rows[0]);
                        rs.content.content = null;
                        return rs;
                    }
                    else
                    {
                        rs.msg = "发生了不知名的错误";
                    }
                }
                else
                {
                    rs.msg="服务器写入错误";
                }
            }
            else
            {
                rs.msg = "文章名字已经存在了";
            }
            return rs;
        }
        /// <summary>
        /// 删除文章
        /// </summary>
        /// <param name="uz"></param>
        /// <returns></returns>

        public Result<userwenzhang> delwenzhang(userwenzhang uz)
        {
            UserinfoDAL ud = new UserinfoDAL();
            MySqlParameter[] mySqlParameter = {  new MySqlParameter("@userid", uz.userid), new MySqlParameter("@id", uz.id) };
            Result<userwenzhang> rs = new Result<userwenzhang>();
            rs.issuf = false;

            int  data = ud.dataUapdatOrInsert(@"update boke.userwenzhang set isdel=true where  id = @id and userid = @userid and isdel=0", mySqlParameter);
            if (data == 1)
            {
                rs.issuf = true;
                return rs;
            }
            else
            {
                rs.msg = "文章不属于你，或者文章已经删除";
            }
            return rs;
        }

        /// <summary>
        /// 文章更新
        /// </summary>
        /// <param name="uz"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public Result<userwenzhang> editwenzhang( userwenzhang uz,string path)
        {

            UserinfoDAL ud = new UserinfoDAL();
            MySqlParameter[] mySqlParameter1 = { new MySqlParameter("@userid", uz.userid), new MySqlParameter("@id", uz.id) };
            Result<userwenzhang> rs = new Result<userwenzhang>();
            rs.issuf = false;
            int ishavathiswenzhang = Convert.ToInt32(ud.testlogin(@"select count(id) from boke.userwenzhang where userid =@userid and id =@id and isdel=0", mySqlParameter1).Rows[0][0]);
            if (ishavathiswenzhang == 1)
            {
                string pathjichu = "\\upload\\wenzhang\\" + DateTime.Now.ToString("yyyyMMdd") + "\\" + Guid.NewGuid() + ".ihtml";
                pathjichu = pathjichu.Replace("\\", "/");
                path = path + "wwwroot" + pathjichu;
                if (bokeSite.tools.FileRW.CreateHtml(path, uz.content))
                {
                    string content100 = "";
                    uz.content100 = bokeSite.tools.FileRW.Html2Text(uz.content100);
                    if (uz.content100 != null && uz.content100.Length > 400)
                    {
                        content100 = uz.content100.Substring(0, 400);
                    }
                    else
                    {
                        content100 = uz.content100;
                    }
                    MySqlParameter[] mySqlParameter = { new MySqlParameter("@content", uz.content100), new MySqlParameter("@content100", content100)
                    , new MySqlParameter("@iskejian", uz.iskejian), new MySqlParameter("@leixing", uz.leixing), new MySqlParameter("@userid", uz.userid)
                    , new MySqlParameter("@wenzhangname", bokeSite.tools.FileRW.Html2Text(uz.wenzhangname)),new MySqlParameter("@wenzhangurl",pathjichu) ,new MySqlParameter("@id",uz.id)};
                    var data = ud.dataUapdatOrInsert(@"update boke.userwenzhang set leixing=@leixing,content=@content,content100=@content100,xiugaishijian=now(),wenzhangname=@wenzhangname,iskejian=@iskejian,wenzhangurl=@wenzhangurl where userid=@userid and id=@id and isdel=0", mySqlParameter);
                    if (data == 1)
                    {
                        rs.issuf = true;
                        rs.count = 1;
                        rs.content = new userwenzhang() { id=uz.id};
                        return rs;
                    }
                    else
                    {
                        rs.msg = "发生了不知名的错误";
                    }
                }
                else
                {
                    rs.msg = "服务器写入错误";
                }
            }
            else
            {
                rs.msg = "你要修改的文章不存在";
            }
            return rs;
        }
    }
}
