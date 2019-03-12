using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Baidu.Netcore.UEditor
{
    /// <summary>
    /// NotSupportedHandler 的摘要说明
    /// </summary>
    public class NotSupportedHandler : Handler
    {
        public NotSupportedHandler(HttpContext context)
            : base(context)
        {
        }

        public override object Process()
        {
            return WriteJson(new
            {
                state = "action 参数为空或者 action 不被支持。"
            });
        }
    }
}