using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using bokeSite.Models;
using bokeSite.tools;
using bokeSite.BLL;
using bokeSite.tools.DataToEnity;
using bokeSite.Filter;

namespace bokeSite.Controllers
{
    public class CommentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 获得所有的评论
        /// </summary>
        /// <param name="uwz"></param>
        /// <returns></returns>
        public JsonResult commentlist(fenyezhuanyong uwz)
        {
            CommentBLL cb = new CommentBLL();
            List<int> useridlist = new List<int>();
            Result<List<allwenzhengpinglun>> result=  cb.GetAllwenzhengpingluns(uwz.id,out useridlist, uwz.page, uwz.pagecount);
            List<userinfo> userinfos= cb.GetUserinfos(useridlist);
            if (result.content != null) {
                foreach (allwenzhengpinglun item in result.content)
                {
                    userinfo uif = new userinfo();
                    uif = userinfos.Where(u => u.id == item.pinglunrenid).FirstOrDefault();
                    item.pinglunrennicheng = uif.nicheng;
                    item.pinglunrenusername = uif.username;
                    item.usertouxiangurl = uif.touxiangurl==null? @"\images\header-img-comment_03.png":uif.touxiangurl;
                    if (item.wenzhangpinglunsonlist.content != null)
                    {
                        foreach (wenzhangpinglunsonkuozhan wenzhangpinglunson in item.wenzhangpinglunsonlist.content)
                        {
                            uif = userinfos.Where(u => u.id == wenzhangpinglunson.pinglunrenid).FirstOrDefault();
                            wenzhangpinglunson.pinglunrennicheng = uif.nicheng;
                            wenzhangpinglunson.pinglunrenusername = uif.username;
                            uif = userinfos.Where(u => u.id == wenzhangpinglunson.huifurenid).FirstOrDefault();
                            wenzhangpinglunson.huifurennicheng = uif.nicheng;
                            wenzhangpinglunson.huifurenusername = uif.username;
                        }
                    }
                }
            }

            return Json(result);
        }
        /// <summary>
        /// 获取文章评论子评论
        /// </summary>
        /// <param name="fzy"></param>
        /// <returns></returns>
        public JsonResult commentsonlist(fenyezhuanyong uwz)
        {
            CommentBLL cb = new CommentBLL();
            List<int> useridlist = new List<int>();
            Result<List<wenzhangpinglunsonkuozhan>> result = cb.GetWenzhangpinglunsons(uwz.id, useridlist,out useridlist, uwz.page, uwz.pagecount);
            List<userinfo> userinfos = cb.GetUserinfos(useridlist);
            if (result.content != null && result.content.Count > 0)
            {
                foreach (wenzhangpinglunsonkuozhan wenzhangpinglunson in result.content)
                {
                    userinfo uif = new userinfo();
                    uif = userinfos.Where(u => u.id == wenzhangpinglunson.pinglunrenid).FirstOrDefault();
                    wenzhangpinglunson.pinglunrennicheng = uif.nicheng;
                    wenzhangpinglunson.pinglunrenusername = uif.username;
                    uif = userinfos.Where(u => u.id == wenzhangpinglunson.huifurenid).FirstOrDefault();
                    wenzhangpinglunson.huifurennicheng = uif.nicheng;
                    wenzhangpinglunson.huifurenusername = uif.username;
                }
            }
                return Json(new { result });
            
        }

        /// <summary>
        /// 创建评论条
        /// </summary>
        /// <param name="wzp"></param>
        /// <returns></returns>
        public JsonResult Addcomment(wenzhangpinglun wzp)
        {
            userinfo uif = new userinfo();
            uif.username = HttpContext.Request.Cookies["user"];
            uif.pwd = HttpContext.Request.Cookies["key"];
            if (wzp.wenzhangid == 0 || wzp.pinglunneirong == null)
            {
                return Json(new { msg = "操作出错" });
            }
            if (string.IsNullOrEmpty(uif.username)){
                userinfo userinfo = new userinfo() { id=0,nicheng= "欠名", username="hufei",touxiangurl= @"\images\header-img-comment_03.png" };
                wenzhangpinglun wenzhangpinglun = new CommentBLL().addWenZhangPingLun(wzp);
                return Json(new { issuf = true, wenzhangpinglun, userinfo });
            }
            else
            {
                WenZhangBLL uib = new WenZhangBLL();
                var uifdata = uib.Getuserinfo(uif);
                wzp.pinglunrenid = uifdata.Rows.Count != 0 ? Convert.ToInt32(uifdata.Rows[0]["id"]) : 0;
                if (wzp.pinglunrenid == 0)
                {
                    return Json(new { msg = "非法登陆,评论失败" });
                }                
                else
                {
                    var userinfo =DataToEnity<userinfo>.DataRowToEntity(uifdata.Rows[0]);
                    if (userinfo.touxiangurl == null)
                    {
                        userinfo.touxiangurl = @"\images\header-img-comment_03.png";
                    }
                    if (userinfo.nicheng == null || userinfo.nicheng == "")
                    {
                        userinfo.nicheng = "未设置昵称";
                    }
                    wenzhangpinglun wenzhangpinglun = new CommentBLL().addWenZhangPingLun(wzp);
                    return Json(new { issuf=true,wenzhangpinglun,userinfo });
                }
            }
        }
        /// <summary>
        /// 删除评论
        /// </summary>
        /// <param name="wzp"></param>
        /// <returns></returns>
        [TypeFilter(typeof(LoginFilter))]
        public JsonResult delcomment(wenzhangpinglun wzp)
        {
            userinfo uif = new userinfo();
            uif.username = HttpContext.Request.Cookies["user"];
            uif.pwd = HttpContext.Request.Cookies["key"];
            WenZhangBLL wz = new WenZhangBLL();
            uif=DataToEnity<userinfo>.DataRowToEntity(wz.Getuserinfo(uif).Rows[0]);            
            CommentBLL cb = new CommentBLL();
            if (cb.iswenzhangbelongher(uif.id, wzp.id))
            {
                wzp.pinglunrenid = uif.id;
                return Json(new { issuf = cb.delcomment(wzp) });
            }
            else if(cb.isgaipinglunzuoze(uif.id,wzp.id))
            {
                wzp.pinglunrenid = uif.id;
                return Json(new { issuf = cb.delcomment(wzp) });
            }
            return Json(new { issuf = false });
        }
        /// <summary>
        /// 对评论进行评论
        /// </summary>
        /// <param name="wps"></param>
        /// <returns></returns>
        public JsonResult Addcommentson(wenzhangpinglunson wps)
        {

            userinfo uif = new userinfo();
            uif.username = HttpContext.Request.Cookies["user"];
            uif.pwd = HttpContext.Request.Cookies["key"];
            if (wps.pinglunid == 0 || wps.pinglunneirong == null)
            {
                return Json(new { msg = "操作出错" });
            }
            if (string.IsNullOrEmpty(uif.username))
            {
                userinfo userinfo = new userinfo() { id = 0, nicheng = "欠名", username = "hufei", touxiangurl = @"\images\header-img-comment_03.png" };
                wenzhangpinglunson wenzhangpinglunson = new CommentBLL().Addcommentson(wps);
                return Json(new { issuf = true, wenzhangpinglunson, userinfo });
            }
            else
            {
                WenZhangBLL uib = new WenZhangBLL();
                var uifdata = uib.Getuserinfo(uif);
                wps.pinglunrenid = uifdata.Rows.Count != 0 ? Convert.ToInt32(uifdata.Rows[0]["id"]) : 0;
                if (wps.pinglunrenid == 0)
                {
                    return Json(new { msg = "非法登陆,评论失败" });
                }
                else
                {
                    var userinfo = DataToEnity<userinfo>.DataRowToEntity(uifdata.Rows[0]);
                    if (userinfo.touxiangurl == null)
                    {
                        userinfo.touxiangurl = @"\images\header-img-comment_03.png";
                    }
                    wenzhangpinglunson wenzhangpinglunson = new CommentBLL().Addcommentson(wps);
                    return Json(new { issuf = true, wenzhangpinglunson, userinfo });
                }
            }
        }
        /// <summary>
        /// 删除文章评论的子评论
        /// </summary>
        /// <param name="wps"></param>
        /// <returns></returns>   
        [TypeFilter(typeof(LoginFilter))]
        public JsonResult delcommentson(wenzhangpinglunson wps)
        {
            try
            {
                userinfo uif = new userinfo();
                uif.username = HttpContext.Request.Cookies["user"];
                uif.pwd = HttpContext.Request.Cookies["key"];
                WenZhangBLL wz = new WenZhangBLL();
                uif = DataToEnity<userinfo>.DataRowToEntity(wz.Getuserinfo(uif).Rows[0]);
                CommentBLL cb = new CommentBLL();
                if (cb.iswenzhangzuoze(uif.id, wps.id))
                {
                    wps.pinglunrenid = uif.id;
                    return Json(new { issuf = cb.delcommentson(wps) });
                }
                else if (cb.isgaipinglunsonzuoze(uif.id, wps.id))
                {
                    wps.pinglunrenid = uif.id;
                    return Json(new { issuf = cb.delcommentson(wps) });
                }
                return Json(new { issuf = false });
            }
            catch
            {
                return Json(new { issuf = true });
            }
        }

        /// <summary>
        /// 评论点赞
        /// </summary>
        /// <param name="wzp"></param>
        /// <returns></returns>
        public JsonResult pinglundianzhan(wenzhangpinglun wzp)
        {
            CommentBLL commentBLL = new CommentBLL();

            return Json(new {issuf=commentBLL.pinglundianzhan(wzp) });
        }
        /// <summary>
        /// 评论的子集点赞
        /// </summary>
        /// <param name="wzs"></param>
        /// <returns></returns>
        public JsonResult pinglundianzhanson(wenzhangpinglunson wzs)
        {
            CommentBLL commentBLL = new CommentBLL();

            bool issuf = commentBLL.pinglundianzhanson(wzs);
            return Json(new { issuf = issuf });
        }
    }
}