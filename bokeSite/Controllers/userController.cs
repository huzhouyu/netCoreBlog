using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using bokeSite.BLL;
using bokeSite.Models;
using System.Text;
using bokeSite.tools;
using bokeSite.Filter;
using Microsoft.AspNetCore.Http;
using Baidu.Netcore.UEditor;
using Microsoft.AspNetCore.Hosting;

namespace bokeSite.Controllers
{
    public class userController : Controller
    {

        private readonly IHostingEnvironment _hostingEnvironment;

        public userController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            serverPath = hostingEnvironment.ContentRootPath + "/";
            Config.serverPath = serverPath;
        }
        private string serverPath { get; }


        [TypeFilter(typeof(LoginFilter))]
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 登录注册界面
        /// </summary>
        /// <returns></returns>
        public IActionResult login()
        {
            userinfo uif = new userinfo();
            uif.username=jiami.Decrypt( HttpContext.Request.Cookies["user"]);
            uif.pwd=jiami.Decrypt( HttpContext.Request.Cookies["key"]);
            if(uif.username!=null&&uif.pwd!=null&&new WenZhangBLL().islogin(uif))
            {
                HttpContext.Response.Redirect("/user/index");
            }
            else
            {
                var Origin = HttpContext.Request.Headers["Origin"];
                if (Origin.Count==0) Origin = "/user/index";
                HttpContext.Response.Cookies.Append("backurl", Origin);
            }
            return View();
        }
        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="uif"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult register(userinfo uif)
        {
            UserInfoBLL uib = new UserInfoBLL();
            var data =uif.username!=null&&uif.pwd!=null?uib.register(uif):false;

            if (data)
            {
                HttpContext.Response.Cookies.Append("key", jiami.Encrypt(uif.pwd));
                HttpContext.Response.Cookies.Append("user", jiami.Encrypt(uif.username));
                string backurl = HttpContext.Request.Cookies["backurl"]!=null? HttpContext.Request.Cookies["backurl"]: "/user/index";

                return Json(new { issuf = true, msg = "登陆成功", backurl = backurl });
            }
            else
            {
                return Json(new { issuf = false, msg = "注册失败.账号已存在或未设置密码" });
            }
        }
        /// <summary>
        /// 判断登录是否成功
        /// </summary>
        /// <param name="uif"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult islogin(userinfo uif)
        {

                WenZhangBLL uib = new WenZhangBLL();
              var data=  uib.islogin(uif);
            
            if (data)
            {
             HttpContext.Response.Cookies.Append("key",jiami.Encrypt(uif.pwd));
             HttpContext.Response.Cookies.Append("user", jiami.Encrypt(uif.username));
             string backurl=HttpContext.Request.Cookies["backurl"];

                return Json(new { issuf = true, msg = "登陆成功",backurl= backurl });
            }
            else
            {
                return Json(new { issuf = false, msg = "登陆失败" });
            }
        }

        public JsonResult info()
        {
            userinfo uif = new userinfo();
            uif.username = jiami.Decrypt(HttpContext.Request.Cookies["user"]);
            uif.pwd = jiami.Decrypt(HttpContext.Request.Cookies["key"]);
            var data = new WenZhangBLL().Getuserinfo(uif);
           if (data.Rows.Count == 1)
            {
                return Json(new { issuf = true, userinfo = data});
            }
            else
            {
                return Json(new { issuf = false, msg = "用户不存在" });
            }
        }

        public JsonResult quit()
        {
            Response.Cookies.Delete("key");
            Response.Cookies.Delete("user");
            return Json(new { issuf = true ,backurl="/user/login"});
        }
        /// <summary>
        /// usetest
        /// </summary>
        /// <returns></returns>
        [TypeFilter(typeof(LoginFilter))]
        public JsonResult UeTest()
        {
            HttpContext context = HttpContext;
            //var ss = HttpContext.Request.Form;
            Handler action = null;
            //action.serverPath = serverPath;
            switch (GetKeyValue("action"))
            {
                case "config":
                    action = new ConfigHandler(context)
                    {
                        serverPath = serverPath
                    };
                    break;

                case "uploadimage":
                    action = new UploadHandler(context, new UploadConfig()
                    {
                        AllowExtensions = Config.GetStringList("imageAllowFiles"),
                        PathFormat = Config.GetString("imagePathFormat"),
                        SizeLimit = Config.GetInt("imageMaxSize"),
                        UploadFieldName = Config.GetString("imageFieldName")
                    })
                    {
                        serverPath = serverPath
                    };
                    break;
                case "uploadscrawl":
                    action = new UploadHandler(context, new UploadConfig()
                    {
                        AllowExtensions = new string[] { ".png" },
                        PathFormat = Config.GetString("scrawlPathFormat"),
                        SizeLimit = Config.GetInt("scrawlMaxSize"),
                        UploadFieldName = Config.GetString("scrawlFieldName"),
                        Base64 = true,
                        Base64Filename = "scrawl.png",

                    })
                    {
                        serverPath = serverPath
                    };
                    break;
                case "uploadvideo":
                    action = new UploadHandler(context, new UploadConfig()
                    {
                        AllowExtensions = Config.GetStringList("videoAllowFiles"),
                        PathFormat = Config.GetString("videoPathFormat"),
                        SizeLimit = Config.GetInt("videoMaxSize"),
                        UploadFieldName = Config.GetString("videoFieldName"),

                    })
                    {
                        serverPath = serverPath
                    };
                    break;
                case "uploadfile":
                    action = new UploadHandler(context, new UploadConfig()
                    {
                        AllowExtensions = Config.GetStringList("fileAllowFiles"),
                        PathFormat = Config.GetString("filePathFormat"),
                        SizeLimit = Config.GetInt("fileMaxSize"),
                        UploadFieldName = Config.GetString("fileFieldName")
                    })
                    {
                        serverPath = serverPath
                    };
                    break;
                case "listimage":
                    action = new ListFileManager(context, Config.GetString("imageManagerListPath"), Config.GetStringList("imageManagerAllowFiles"))
                    {
                        serverPath = serverPath
                    };
                    break;
                case "listfile":
                    action = new ListFileManager(context, Config.GetString("fileManagerListPath"), Config.GetStringList("fileManagerAllowFiles"))
                    {
                        serverPath = serverPath
                    };
                    break;
                case "catchimage":
                    action = new CrawlerHandler(context)
                    {
                        serverPath = serverPath
                    };
                    break;
                default:
                    action = new NotSupportedHandler(context)
                    {
                        serverPath = serverPath
                    };
                    break;
            }
            return Json(action.Process());

        }
         /// <summary>
         /// 获取文章类型
         /// </summary>
         /// <returns></returns>
        public JsonResult wenzhangleixing()
        {
            userinfo uif = new userinfo();
            uif.username = jiami.Decrypt(HttpContext.Request.Cookies["user"]);
            uif.pwd = jiami.Decrypt(HttpContext.Request.Cookies["key"]);
            WenZhangBLL uib = new WenZhangBLL();
            var data = uib.Getuserinfo(uif);
            if (data.Rows.Count == 1)
            {
                var wenzhangleixinglist= uib.Getuserwenzhang(data.Rows[0]["id"].ToString());
                var count = wenzhangleixinglist.Count;
                return Json(new { issuf = true, wenzhangleixing = wenzhangleixinglist,count=count });
            }
            else
            {
                return Json(new { issuf = false, backurl = "/user/login" });
            }
        }
        /// <summary>
        /// 获取文章列表
        /// </summary>
        /// <returns></returns>

        public IActionResult wenzhanglist()
        {
            userinfo uif = new userinfo();
            uif.username = jiami.Decrypt(HttpContext.Request.Cookies["user"]);
            uif.pwd = jiami.Decrypt(HttpContext.Request.Cookies["key"]);
            WenZhangBLL uib = new WenZhangBLL();
            var data = uib.Getuserinfo(uif);
            List<userwenzhangkuozhan> wenzhangleixinglist = new List<userwenzhangkuozhan>();
            if (data.Rows.Count == 1)
            {
               string leixing= GetKeyValue("leixing");
                string keyword = GetKeyValue("keyword");
                string qpagestart = GetKeyValue("page");
                ViewData["nowpage"] = 1;
                string qpagecount = GetKeyValue("pagecount");
                int pagestart = 0;
                int pagecount =20;
                if (!string.IsNullOrEmpty(qpagestart) && !string.IsNullOrEmpty(qpagecount))
                {
                    pagestart = Convert.ToInt32(qpagestart);
                    pagecount = Convert.ToInt32(qpagecount);
                    ViewData["nowpage"] = pagestart + 1;
                }
                if (string.IsNullOrEmpty(leixing)||leixing=="-1"){
                    ViewData["leixing"] = "-1";
                  wenzhangleixinglist = uib.Getuserwenzhanglist(data.Rows[0]["id"].ToString(),leixing="-1",keyword,pagestart,pagecount);
                }
                else
                {
                    ViewData["leixing"] = leixing;
                    wenzhangleixinglist = uib.Getuserwenzhanglist(data.Rows[0]["id"].ToString(),leixing,keyword, pagestart, pagecount);
                }
                ViewData["dat"] = wenzhangleixinglist;
                return View();
            }
            else
            {
                wenzhangleixinglist.Add(new userwenzhangkuozhan() { count = 0, toal = 0 });
                ViewData["dat"] = wenzhangleixinglist;
                return View();
            }
        }


        public IActionResult wenzhangdtl ()
        {
            return View();
        }

        /// <summary>
        /// 文章详细页面
        /// </summary>
        /// <returns></returns>
        public JsonResult getwenzhangdtl()
        {
            userinfo uif = new userinfo();
            uif.username = jiami.Decrypt(HttpContext.Request.Cookies["user"]);
            uif.pwd = jiami.Decrypt(HttpContext.Request.Cookies["key"]);
            WenZhangBLL uib = new WenZhangBLL();
            var data = uib.Getuserinfo(uif);
            string wenzhangid = GetKeyValue("id");
            if (string.IsNullOrEmpty(wenzhangid) && data.Rows.Count != 1)
            {
                return Json(new { issuf=false});
            }
            else
            {
               return Json(new { issuf = true, dtl = uib.GetUserwenzhang(data.Rows[0]["id"].ToString(), wenzhangid)});
            }
        }
        /// <summary>
        /// 添加文章类型
        /// </summary>
        /// <param name="uwz"></param>
        /// <returns></returns>
        public JsonResult addleixing(userwenzhangleixing uwz)
        {
            userinfo uif = new userinfo();
            uif.username = jiami.Decrypt(HttpContext.Request.Cookies["user"]);
            uif.pwd = jiami.Decrypt(HttpContext.Request.Cookies["key"]);
            WenZhangBLL uib = new WenZhangBLL();
            var data = uib.Getuserinfo(uif);
            string leixingming = uwz.leixingming;
            if (string.IsNullOrEmpty(leixingming) && data.Rows.Count != 1)
            {
                return Json(new { issuf = false });
            }
            else
            {
                return Json(new { issuf = uib.addleixing(data.Rows[0]["id"].ToString(), leixingming) });
            }
        }
        /// <summary>
        /// 文章的添加
        /// </summary>
        /// <param name="uwz"></param>
        /// <returns></returns>
        public JsonResult addwenzhang(userwenzhang uwz)
        {
            userinfo uif = new userinfo();
            uif.username = jiami.Decrypt(HttpContext.Request.Cookies["user"]);
            uif.pwd = jiami.Decrypt(HttpContext.Request.Cookies["key"]);
            WenZhangBLL uib = new WenZhangBLL();
            var data = uib.Getuserinfo(uif);
            uwz.userid = data.Rows.Count != 0 ? Convert.ToInt32(data.Rows[0]["id"]) : 0;
            if (string.IsNullOrEmpty(uwz.content) && string.IsNullOrEmpty(uwz.content100) && string.IsNullOrEmpty(uwz.wenzhangname))
            {
                return Json(new { issuf = false,msg="参数错误" });
            }
            else
            {
                Result<userwenzhang> result = uib.addwenzhang(uwz,serverPath);
                return Json(new {result });
            }
        }

        public JsonResult delwenzhang(userwenzhang uwz)
        {
            userinfo uif = new userinfo();
            uif.username = jiami.Decrypt(HttpContext.Request.Cookies["user"]);
            uif.pwd = jiami.Decrypt(HttpContext.Request.Cookies["key"]);
            WenZhangBLL uib = new WenZhangBLL();
            var data = uib.Getuserinfo(uif);
            uwz.userid = data.Rows.Count != 0 ? Convert.ToInt32(data.Rows[0]["id"]) : 0;
            if (uwz.userid == 0|| uwz.id == 0)
            {
                return Json(new { msg = "你是傻子吧" });
            }
            else
            {
                Result<userwenzhang> result = uib.delwenzhang(uwz);
                return Json(new { result });
            }

        }

        public JsonResult editwenzhang(userwenzhang uwz)
        {
            userinfo uif = new userinfo();
            uif.username = jiami.Decrypt(HttpContext.Request.Cookies["user"]);
            uif.pwd = jiami.Decrypt(HttpContext.Request.Cookies["key"]);
            WenZhangBLL uib = new WenZhangBLL();
            var data = uib.Getuserinfo(uif);
            uwz.userid = data.Rows.Count != 0 ? Convert.ToInt32(data.Rows[0]["id"]) : 0;
            if (string.IsNullOrEmpty(uwz.content) && string.IsNullOrEmpty(uwz.content100) && string.IsNullOrEmpty(uwz.wenzhangname)&&uwz.id==0)
            {
                return Json(new { issuf = false, msg = "参数错误" });
            }
            else
            {
                Result<userwenzhang> result = uib.editwenzhang(uwz, serverPath);
                return Json(new { result });
            }
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