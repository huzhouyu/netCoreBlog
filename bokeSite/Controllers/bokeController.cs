using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using bokeSite.BLL;
using bokeSite.Models;
using bokeSite.tools;

namespace bokeSite.Controllers
{
    public class bokeController : Controller
    {
        public IActionResult tmpIndex()
        {
            HttpContext.Response.Redirect("/huzhouyu");
            return View();
        }
        public IActionResult Index()
        {
            var userName= Request.PathBase.Value.Trim('/').ToLower();
            var leixing = GetKeyValue("leixing");

            ViewBag.leixing = leixing;
            UserInfoBLL uif = new UserInfoBLL();
            var uiInfo = uif.GetThisUserNameInfo(userName);
            if (uiInfo!=null)
            {
                Response.StatusCode = 200;
                ViewBag.userInfo = uiInfo;
                WenZhangBLL wzb = new WenZhangBLL();               
                ViewBag.userWenZhangType= wzb.Getuserwenzhang(uiInfo.id.ToString());
            }
            else
            {
                Response.StatusCode = 404;
                return View("/Views/boke/test404.cshtml");
            }
            return View();
        }


        /// <summary>
        /// 获取文章列表
        /// </summary>
        /// <returns></returns>

        public JsonResult wenzhanglist()
        {
            WenZhangBLL uib = new WenZhangBLL();
            UserInfoBLL uifbll = new UserInfoBLL();
            string userName = GetKeyValue("username");
            var userInfo = uifbll.GetThisUserNameInfo(userName);
            Result<List<userwenzhangkuozhan>> result = new Result<List<userwenzhangkuozhan>>();
            List<userwenzhangkuozhan> wenzhangleixinglist = new List<userwenzhangkuozhan>();
            if (userInfo!=null)
            {
                string leixing = GetKeyValue("leixing");
                string keyword = GetKeyValue("keyword");
                string qpagestart = GetKeyValue("page");
                //ViewData["nowpage"] = 1;
                string qpagecount = GetKeyValue("pagecount");
                int pagestart = 0;
                int pagecount = 20;
                if (!string.IsNullOrEmpty(qpagestart) && !string.IsNullOrEmpty(qpagecount))
                {
                    pagestart = Convert.ToInt32(qpagestart);
                    pagecount = Convert.ToInt32(qpagecount);
                    //ViewData["nowpage"] = pagestart + 1;
                }
                if (string.IsNullOrEmpty(leixing) || leixing == "-1")
                {
                    //ViewData["leixing"] = "-1";
                    wenzhangleixinglist = uib.Getuserwenzhanglist(userInfo.id.ToString(), leixing = "-1", keyword, pagestart, pagecount);
                }
                else
                {
                    //ViewData["leixing"] = leixing;
                    wenzhangleixinglist = uib.Getuserwenzhanglist(userInfo.id.ToString(), leixing, keyword, pagestart, pagecount);
                }
                result.content = wenzhangleixinglist;
                result.count = wenzhangleixinglist.Count;
                result.issuf = true;
                result.msg = "";
            }
            else
            {
                result.count = 0;
                result.issuf = false;
                result.msg="用户不存在";
            }
            return Json(result); 
        }





        public IActionResult wenzhangzaishi()
        {
            return View();
        }

        public IActionResult wenzhang()
        {
            return View();
        }
        public IActionResult wenzhangdetl()
        {
            var pathList = Request.PathBase.Value.Trim('/').ToLower().Split(new char[] { '/','\\'});
            if (pathList.Length != 3||pathList[1]!= "wenzhang")
            {
                Response.StatusCode = 404;
                return View("/Views/boke/test404.cshtml");
            }
            var userName = pathList[0];
            UserInfoBLL uif = new UserInfoBLL();
            var uiInfo = uif.GetThisUserNameInfo(userName);
            if (uiInfo != null)
            {
                Response.StatusCode = 200;
                ViewBag.userInfo = uiInfo;
                WenZhangBLL wzb = new WenZhangBLL();
                ViewBag.userWenZhangType = wzb.Getuserwenzhang(uiInfo.id.ToString());
                var wenzhangdtl= wzb.GetUserwenzhangText(uiInfo.id.ToString(), pathList[2]);
                if (wenzhangdtl == null)
                {
                    Response.StatusCode = 404;
                    return View("/Views/boke/test404.cshtml");
                }
                else
                {
                    ViewBag.wenzhangdtl = wenzhangdtl;
                }
            }
            else
            {
                Response.StatusCode = 404;
                return View("/Views/boke/test404.cshtml");
            }
            return View();
        }

        /// <summary>
        /// 文章详细页面
        /// </summary>
        /// <returns></returns>
        public JsonResult getwenzhangdtl()
        {
            userinfo uif = new userinfo();
            uif.username = HttpContext.Request.Cookies["user"];
            uif.pwd = HttpContext.Request.Cookies["key"];
            WenZhangBLL uib = new WenZhangBLL();
            var data = uib.Getuserinfo(uif);
            string wenzhangid = GetKeyValue("id");
            if (string.IsNullOrEmpty(wenzhangid) && data.Rows.Count != 1)
            {
                return Json(new { issuf = false });
            }
            else
            {
                return Json(new { issuf = true, dtl = uib.GetUserwenzhang(data.Rows[0]["id"].ToString(), wenzhangid) });
            }
        }


        public IActionResult test404()
        {
            return View();
        }
        private string GetKeyValue(string Key)
        {
            if (Request.Method == "GET" || Request.Method == "POST")
            {

                return Request.Query[Key];
            }
            else if (Request.Method == "POST")
            {

                return Request.Form[Key];

            }
            return null;
        }
    }
}