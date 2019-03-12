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
using Newtonsoft.Json;

namespace bokeSite.BLL
{
    /// <summary>
    /// 文章评论BLL类
    /// </summary>
    public class CommentBLL
    {
        /// <summary>
        /// 获取指定文章id的评论
        /// </summary>
        /// <param name="wenzhangid"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public Result<List<allwenzhengpinglun>> GetAllwenzhengpingluns(int wenzhangid,out List<int> arr,int page=0,int pagecount=20)
        {
            int start = page * pagecount;
            int end = start + pagecount;
            Result<List<allwenzhengpinglun>> list = new Result<List<allwenzhengpinglun>>();
            UserinfoDAL udl = new UserinfoDAL();
            MySqlParameter[] mySqlParameter = {new MySqlParameter("@wenzhangid", wenzhangid),new MySqlParameter("@start",start),new MySqlParameter("@end",end) };
            DataTable pinglundt=udl.testlogin("select id,wenzhangid,pinglunneirong,pinglunrenid,pinglunshijian,dianzanshu from boke.wenzhangpinglun" +
                " where wenzhangid=@wenzhangid and isdel=0 order by pinglunshijian desc limit @start,@end", mySqlParameter);
            arr = new List<int>();
            if (pinglundt.Rows.Count > 0)
            {
                List<allwenzhengpinglun> wzllist = new List<allwenzhengpinglun>();
                foreach (DataRow item in pinglundt.Rows)
                {
                   // allwenzhengpinglun azpl = new allwenzhengpinglun();
                    allwenzhengpinglun azpl= DataToEnity<allwenzhengpinglun>.DataRowToEntity(item);
                    //azpl.wenzhangid = wzl.wenzhangid;
                    //azpl
                    if (arr==null||arr.IndexOf(azpl.pinglunrenid) == -1)
                    {
                        arr.Add(azpl.pinglunrenid);
                    }
                    azpl.wenzhangpinglunsonlist= GetWenzhangpinglunsons(azpl.id,arr,out arr);
                    wzllist.Add(azpl);
                }
                list.content = wzllist;
                list.count=Convert.ToInt32(udl.testlogin("select count(1) from boke.wenzhangpinglun where wenzhangid=@wenzhangid and isdel=0", mySqlParameter).Rows[0][0]);
                list.issuf = true;
                list.msg = end.ToString();
                return list;
            }
            list.issuf = false;
            list.msg = "无信息可看";
            list.count = 0;
            return list;
        }

        /// <summary>
        /// 获取指定评论的子评论
        /// </summary>
        /// <param name="punlunid"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public Result<List<wenzhangpinglunsonkuozhan>> GetWenzhangpinglunsons(int punlunid, List<int> arelarr,out List<int> arr, int page = 0,int pagecount = 5)  
        {
            int start = page * pagecount;
            int end = start + pagecount;
            Result<List<wenzhangpinglunsonkuozhan>> list =new Result<List<wenzhangpinglunsonkuozhan>>();
            UserinfoDAL udl = new UserinfoDAL();
            MySqlParameter[] mySqlParameter = { new MySqlParameter("@pinglunid", punlunid), new MySqlParameter("@start", start), new MySqlParameter("@end", end) };
            DataTable pinglunsondt = udl.testlogin("select id,pinglunid,pinglunrenid,pinglunneirong,pinglunshijian,huifurenid,dianzanshu from boke.wenzhangpinglunson " +
                "where pinglunid=@pinglunid and isdel=0 order by pinglunshijian limit @start,@end", mySqlParameter);
            arr = arelarr;
            if (pinglunsondt.Rows.Count > 0)
            {
                List<wenzhangpinglunsonkuozhan> wezsonlist = new List<wenzhangpinglunsonkuozhan>();
                
                foreach (DataRow item in pinglunsondt.Rows)
                {
                    wenzhangpinglunsonkuozhan wzkz = DataToEnity<wenzhangpinglunsonkuozhan>.DataRowToEntity(item);
                    if (arr==null||arr.IndexOf(wzkz.pinglunrenid) == -1)
                    {
                        arr.Add(wzkz.pinglunrenid);
                    }
                    if (arr == null || arr.IndexOf(wzkz.huifurenid) == -1)
                    {
                        arr.Add(wzkz.huifurenid);
                    }
                   wezsonlist.Add(wzkz);
                }
                list.content = wezsonlist;
                list.count= Convert.ToInt32(udl.testlogin("select count(1) from boke.wenzhangpinglunson where pinglunid=@pinglunid and isdel=0", mySqlParameter).Rows[0][0]);
                list.issuf = true;
                list.msg = end.ToString();
                return list;
            }
            list.issuf = false;
            list.msg = "无信息可看";
            list.count = 0;
            return list;
        }
        /// <summary>
        /// 根据id获取用户信息
        /// </summary>
        /// <param name="useridlist">用户id列表</param>
        /// <returns></returns>
        public List<userinfo> GetUserinfos(List<int> useridlist)
        {

            UserinfoDAL uid = new UserinfoDAL();
            string userliststr = "";
            if (useridlist.Count > 0)
            {
                foreach (var item in useridlist)
                {
                    userliststr += item + ",";
                }
            }
            else
            {
                userliststr = "0";
            }
            userliststr = userliststr.Trim(',');
            string sql = string.Format("select username,id, nicheng,zhuceshijian, xiugaishijian, touxiangurl from boke.userinfo where id in({0}) and isdel=0", userliststr);
            MySqlParameter[] mySqlParameter = { new MySqlParameter("@null", "null")};
            DataTable dt = uid.testlogin(sql, mySqlParameter);
            if (dt.Rows.Count > 0)
            {
                List<userinfo> list = new List<userinfo>();
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        list.Add(DataToEnity<userinfo>.DataRowToEntity(item));
                    }
                }
                return list;
            }

            return null;
        }
        /// <summary>
        /// 添加文章评论
        /// </summary>
        /// <param name="wzp"></param>
        /// <returns></returns>
        public wenzhangpinglun addWenZhangPingLun(wenzhangpinglun wzp)
        {
            UserinfoDAL ud = new UserinfoDAL();
            MySqlParameter[] mySqlParameter = { new MySqlParameter("@pinglunneirong", bokeSite.tools.FileRW.Html2Text(wzp.pinglunneirong)),
                new MySqlParameter("@pinglunrenid", wzp.pinglunrenid), new MySqlParameter("@wenzhangid", wzp.wenzhangid) };

            var data = ud.dataUapdatOrInsert(@"insert into boke.wenzhangpinglun values(null,@wenzhangid,@pinglunneirong,@pinglunrenid,now(),0,1,1)", mySqlParameter);
            if (data == 1)
            {
                var dt = ud.testlogin(@"select * from boke.wenzhangpinglun where wenzhangid=@wenzhangid and pinglunneirong=@pinglunneirong and pinglunrenid=@pinglunrenid  order by pinglunshijian desc", mySqlParameter);
                return DataToEnity<wenzhangpinglun>.DataRowToEntity(dt.Rows[0]);
            }
            return null;
        }
        /// <summary>
        /// 添加评论子集
        /// </summary>
        /// <param name="wzs"></param>
        /// <returns></returns>
        public wenzhangpinglunson Addcommentson( wenzhangpinglunson wzs)
        {
            UserinfoDAL ud = new UserinfoDAL();
            //MySqlParameter[] Parameter = { new MySqlParameter("@pinglunid", wzs.pinglunid) };
            //var pinglunpa = ud.testlogin("select pinglunrenid from boke.wenzhangpinglun where id=@pinglunid", Parameter);
            //if (pinglunpa != null)
            //{
            //    wzs.huifurenid = Convert.ToInt32(pinglunpa.Rows[0][0]);
            //}
            //else
            //{
            //    return null;
            //}
            MySqlParameter[] mySqlParameter = { new MySqlParameter("@pinglunneirong", bokeSite.tools.FileRW.Html2Text(wzs.pinglunneirong)),
                new MySqlParameter("@pinglunrenid", wzs.pinglunrenid), new MySqlParameter("@pinglunid", wzs.pinglunid), new MySqlParameter("@huifurenid", wzs.huifurenid) };
            var data = ud.dataUapdatOrInsert(@"insert into boke.wenzhangpinglunson values(null,@pinglunid,@pinglunrenid,@pinglunneirong,0,1,now(),@huifurenid,1)", mySqlParameter);
            if (data == 1)
            {
                var dt = ud.testlogin(@"select * from boke.wenzhangpinglunson where pinglunid=@pinglunid and pinglunneirong=@pinglunneirong and pinglunrenid=@pinglunrenid and huifurenid=@huifurenid  order by pinglunshijian desc", mySqlParameter);
                return DataToEnity<wenzhangpinglunson>.DataRowToEntity(dt.Rows[0]);
            }
            return null;
        }
        /// <summary>
        /// 根据评论id判断用户是否是他的作者
        /// </summary>
        /// <param name="userid">作者id</param>
        /// <param name="pinglunid">要判断的评论id</param>
        /// <returns></returns>
        public bool iswenzhangbelongher(int userid,int pinglunid)
        {
            UserinfoDAL ud = new UserinfoDAL();
            MySqlParameter[] mySqlParameter = { new MySqlParameter("@id", pinglunid) };
            DataTable wenzhangiddt=ud.testlogin("select wenzhangid from boke.wenzhangpinglun where id=@id and isdel=0", mySqlParameter);
            if (wenzhangiddt.Rows.Count < 1)
            {
                return false;
            }
            else
            {
                int wenzhangid = Convert.ToInt32(wenzhangiddt.Rows[0][0]);
                MySqlParameter[] mySqlPa = { new MySqlParameter("@id", wenzhangid), new MySqlParameter("@userid", userid) };
                var data = ud.testlogin(@"select id from boke.userwenzhang where id = @id and userid = @userid and isdel=0", mySqlPa);
                return data.Rows.Count > 0;
            }
          
        }
        /// <summary>
        /// 根据评论子集id判断该用户是否是该评论的作者
        /// </summary>
        /// <param name="userid">作者id</param>
        /// <param name="pinglunsonid">要判断的评论子集id</param>
        /// <returns></returns>
        public bool iswenzhangzuoze(int userid, int pinglunsonid)
        {
            UserinfoDAL ud = new UserinfoDAL();
            MySqlParameter[] mySqlParameter = { new MySqlParameter("@id", pinglunsonid), new MySqlParameter("@userid", userid) };

            DataTable pingluniddt=ud.testlogin("select pinglunid from boke.wenzhangpinglunson where id=@id", mySqlParameter);
            if (pingluniddt.Rows.Count < 1)
            {
                return false;
            }
            else
            {
                int pinglunid=Convert.ToInt32(pingluniddt.Rows[0][0]);
                return iswenzhangbelongher(userid, pinglunid);
            }
        }

        /// <summary>
        /// 根据评论id判读该评论是否该用户所留
        /// </summary>
        /// <param name="userid">用户id</param>
        /// <param name="pinglunid">评论id</param>
        /// <returns></returns>
        public bool isgaipinglunzuoze(int userid,int pinglunid)
        {
            UserinfoDAL ud = new UserinfoDAL();
            MySqlParameter[] mySqlParameter = { new MySqlParameter("@id", pinglunid),new MySqlParameter("@pinglunrenid",userid) };
            DataTable dataTable = ud.testlogin("select pinglunid from boke.wenzhangpinglun where id=@id and pinglunrenid=@pinglunrenid and isdel=0", mySqlParameter);
            if (dataTable.Rows.Count > 0) return true;
            return false;
        }
        /// <summary>
        /// 根据评论id子集，判断该评论子集是否该用户所留
        /// </summary>
        /// <param name="userid">用户id</param>
        /// <param name="pinglunsonid">评论子集id</param>
        /// <returns></returns>
        public bool isgaipinglunsonzuoze(int userid, int pinglunsonid)
        {
            UserinfoDAL ud = new UserinfoDAL();
            MySqlParameter[] mySqlParameter = { new MySqlParameter("@id", pinglunsonid), new MySqlParameter("@pinglunrenid", userid) };
            DataTable dataTable = ud.testlogin("select pinglunid from boke.wenzhangpinglunson where id=@id and pinglunrenid=@pinglunrenid and isdel=0", mySqlParameter);
            if (dataTable.Rows.Count > 0) return true;
            return false;
        }

        /// <summary>
        /// 根据评论id删除评论（实际为修改评论是否删除的标识）
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public bool delcomment(wenzhangpinglun wzp)
        {

            UserinfoDAL ud = new UserinfoDAL();
            MySqlParameter[] mySqlParameter = { new MySqlParameter("@id", wzp.id) };
            int dt = ud.dataUapdatOrInsert(@"update boke.wenzhangpinglun set isdel=true where id=@id", mySqlParameter);
            return dt>0;
        }

        /// <summary>
        /// 根据评论子集id删除评论（实际为修改评论是否删除的标识）
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public bool delcommentson(wenzhangpinglunson wzp)
        {
            UserinfoDAL ud = new UserinfoDAL();
            MySqlParameter[] mySqlParameter = { new MySqlParameter("@id", wzp.id) };
            int dt = ud.dataUapdatOrInsert(@"update boke.wenzhangpinglunson set isdel=true where id=@id", mySqlParameter);
            return dt > 0;
        }
        /// <summary>
        /// 评论点赞书增加1
        /// </summary>
        /// <param name="wzp"></param>
        /// <returns></returns>
        public bool pinglundianzhan(wenzhangpinglun wzp)
        {
            if (wzp.dianzanshu == 0)
            {
                return false;
            }
            UserinfoDAL ud = new UserinfoDAL();
            MySqlParameter[] mySqlParameter = { new MySqlParameter("@id", wzp.id) };
            try
            {
             int dianzhanshu=Convert.ToInt32(ud.testlogin("select dianzanshu from boke.wenzhangpinglun where id=@id and isdel=0", mySqlParameter).Rows[0][0]);
                MySqlParameter[]   mySqlPr ={ new MySqlParameter("@dianzanshu",dianzhanshu+1), new MySqlParameter("@id", wzp.id) };
                return ud.dataUapdatOrInsert("update boke.wenzhangpinglun set dianzanshu=@dianzanshu where id=@id and isdel=0", mySqlPr) >0;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 评论点赞书增加1
        /// </summary>
        /// <param name="wzp"></param>
        /// <returns></returns>
        public bool pinglundianzhanson(wenzhangpinglunson wzp)
        {
            if (wzp.dianzanshu == 0)
            {
                return false;
            }
            UserinfoDAL ud = new UserinfoDAL();
            MySqlParameter[] mySqlParameter = { new MySqlParameter("@id", wzp.id) };
            try
            {
                int dianzhanshu = Convert.ToInt32(ud.testlogin("select dianzanshu from boke.wenzhangpinglunson where id=@id and isdel=0", mySqlParameter).Rows[0][0]);
                MySqlParameter[] mySqlPr = { new MySqlParameter("@dianzanshu", dianzhanshu + 1), new MySqlParameter("@id", wzp.id) };
                return ud.dataUapdatOrInsert("update boke.wenzhangpinglunson set dianzanshu=@dianzanshu where id=@id and isdel=0", mySqlPr) > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
