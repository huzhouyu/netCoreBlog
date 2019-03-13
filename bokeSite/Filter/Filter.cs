using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bokeSite.Models;
using bokeSite.tools;
using bokeSite.BLL;
namespace bokeSite.Filter
{
    
        public class LoginFilter : IActionFilter
        {
            public void OnActionExecuted(ActionExecutedContext context)
            {
               // Console.WriteLine("action执行之后");
            }

            public void OnActionExecuting(ActionExecutingContext context)
            {

            userinfo uif = new userinfo();
            uif.pwd= context.HttpContext.Request.Cookies["key"];
            uif.username=context.HttpContext.Request.Cookies["user"];
            WenZhangBLL bLL = new WenZhangBLL();
            if(!bLL.islogin(uif))
            {
                context.HttpContext.Response.Redirect("/user/login");
            }
            else
            {
                
            }
        }
        }
}
