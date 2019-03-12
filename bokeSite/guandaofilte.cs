using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace bokeSite
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class test404

    {
        private readonly RequestDelegate _next;

        public test404(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            await _next(httpContext);
            List<string> alltrght =new List<string>() { "css", "imges", "js", "lib", "login", "moban1648", "moban216", "ue" };
           string url= httpContext.Request.Path;
            url = url.Trim('/');
            if (url != null && url != "")
            {
               string[] urlpath = url.Split('/');
                if (urlpath.Length==4&&urlpath[0].ToLower() == "upload" && urlpath[1] == "wenzhang")
                {
                    httpContext.Request.PathBase = httpContext.Request.Path;
                    httpContext.Request.Path = "/boke/test404";
                    await _next(httpContext);
                }
                else
                {
                    if (httpContext.Response.StatusCode == 404)
                    {
                        if (urlpath.Length == 1)
                        {
                            httpContext.Request.PathBase = httpContext.Request.Path;
                            httpContext.Request.Path = "/boke/index";
                            await _next(httpContext);
                        }
                        else if (urlpath.Length == 3)
                        {
                            if (urlpath[1].ToLower() == "wenzhang")
                            {
                                httpContext.Request.PathBase = httpContext.Request.Path;
                                httpContext.Request.Path = "/boke/wenzhangdetl";
                                await _next(httpContext);
                            }
                            else
                            {
                                httpContext.Request.PathBase = httpContext.Request.Path;
                                httpContext.Request.Path = "/boke/test404";
                                await _next(httpContext);
                            }
                        }
                        else
                        {
                            httpContext.Request.PathBase = httpContext.Request.Path;
                            httpContext.Request.Path = "/boke/test404";
                            await _next(httpContext);
                        }

                    }
                }
            }

        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class test404Extensions
    {
        public static IApplicationBuilder Usetest404(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<test404>();
        }
    }
}
