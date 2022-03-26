using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ALLMVC.Controllers
{
    public class CookieDemoController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CookieDemoController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        string Key = "MyCookie";
        string value = "Welcome";

        //string cookieValueFromContext = _httpContextAccessor.HttpContext.
        //public IActionResult Set(string key)


        public IActionResult Write(bool isPersistent)
        {
            CookieOptions options = new CookieOptions();
            if (isPersistent)
            {
                options.Expires = DateTime.Now.AddSeconds(15);
            }
            else
            {
                options.Expires = DateTime.Now.AddSeconds(10);
                _httpContextAccessor.HttpContext.Response.Cookies.Append(Key, value, options);
            }
            return View("Write");
        }

        public IActionResult Read()
        {
            ViewBag.Data = _httpContextAccessor.HttpContext.Request.Cookies[Key];
            return View("Read");
        }

        public IActionResult Delete()
        {
            Response.Cookies.Delete(Key);
            return View("Delete");
        }
    }
}
