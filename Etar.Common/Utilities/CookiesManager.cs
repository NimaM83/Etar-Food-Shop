using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etar.Common.Utilities
{
    public class CookiesManager
    {

        public void Add(HttpContext context, string key,string value, int days)
        {
            context.Response.Cookies.Append(key,value,GetCookieOptions(context,days));
        }

        public bool Contains(HttpContext context, string key)
        {
            return context.Request.Cookies.ContainsKey(key);
        }

        public string GetValue(HttpContext context, string key)
        {
            string value;
            if (context.Request.Cookies.TryGetValue(key, out value))
            {
                return value;
            }

            return null;
        }

        private CookieOptions GetCookieOptions (HttpContext context, int days)
        {
            return new CookieOptions
            {
                HttpOnly = true,
                Path = context.Request.PathBase.HasValue ? context.Request.PathBase.ToString() : "/",
                Secure = context.Request.IsHttps,
                Expires = DateTime.Now.AddDays(days)
            };
        }
    }
}
