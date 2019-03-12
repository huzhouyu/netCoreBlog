using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace Baidu.Netcore.UEditor
{
    /// <summary>
    /// Handler 的摘要说明
    /// </summary>
    public abstract class Handler
    {
        public String serverPath { get; set; }
        public Handler(HttpContext context)
        {

            this.Request = context.Request;
            this.Response = context.Response;
            this.Context = context;

        }
        public string GetKeyValue(string Key)
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

        public abstract object Process();

        protected object WriteJson(object response)
        {
            //string jsonpCallback = null,
            //    json = JsonConvert.SerializeObject(response);
            //if (Request.Method == "GET")
            //{
            //    jsonpCallback = Request.Query["callback"];
            //}
            //else if(Request.Method=="POST")
            //{
            //    jsonpCallback = Request.Form["callback"];
            //}

            //if (String.IsNullOrWhiteSpace(jsonpCallback))
            //{
            //    Response.Headers.Add("Content-Type", "text/plain");
            //    Response.WriteAsync(json);
            //}
            //else 
            //{
            //    Response.Headers.Add("Content-Type", "application/javascript");
            //    Response.WriteAsync(String.Format("{0}({1});", jsonpCallback, json));
            //}
            return response;
        }

        public HttpRequest Request { get; private set; }
        public HttpResponse Response { get; private set; }
        public HttpContext Context { get; private set; }
    }
}