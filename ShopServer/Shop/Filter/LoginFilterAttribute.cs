using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using Shop.Tools;

namespace Shop.Filter
{
    public class LoginFilterAttribute: ActionFilterAttribute
    {
        public bool IsAdmin { get; set; }

        public LoginFilterAttribute(bool isAdmin = false)
        {
            IsAdmin = isAdmin;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string token = context.HttpContext.Request.Headers["token"];
            Dictionary<string, object> res = new Dictionary<string, object>();
            bool success = false;
            string username = "";
            if (token == null)
            {
                res["status"] = "failed";
                res["message"] = "请将令牌添加到请求头中!";
            }
            else
            {
                Tuple<string, DateTime> info = JWTTools.Decode(token, IsAdmin);
                if (info?.Item1 == null)
                {
                    res["status"] = "failed";
                    res["message"] = "令牌被篡改, 请重新登录!";
                }
                else if (info.Item2 < DateTime.Now)
                {
                    res["status"] = "failed";
                    res["message"] = "令牌失效, 请重新登录!";
                }
                else
                {
                    username = info.Item1;
                    success = true;
                }
            }
            if (!success)
            {
                context.Result = new ContentResult()
                {
                    Content = JsonConvert.SerializeObject(res),
                    ContentType = "application/json",
                    StatusCode = 200
                };
            }
            else
            {
                context.HttpContext.Request.Headers["username"] = username;
                base.OnActionExecuting(context);
            }
        }

    }
}
