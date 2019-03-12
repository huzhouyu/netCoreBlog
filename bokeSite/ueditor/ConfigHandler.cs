using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Http;


namespace Baidu.Netcore.UEditor
{
    /// <summary>
    /// Config 的摘要说明
    /// </summary>
    public class ConfigHandler : Handler
    {
        public ConfigHandler(HttpContext context) : base(context) { }

        public override object Process()
        {
            return WriteJson(Config.Items);
        }
    }
}