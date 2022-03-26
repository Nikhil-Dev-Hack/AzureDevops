using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ALLMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ALLMVC.Controllers
{
    public class SessionsController : Controller
    {
        const string SessionName = "_Name";
        const string SessionAge = "_Age";
        [Route("sessions/Session")]
        public IActionResult Session()
        {
            HttpContext.Session.SetString(SessionName, "Nikhil");
            HttpContext.Session.SetInt32(SessionAge, 22);
            return View();
        }
        [Route("sessions/about")]
        public IActionResult About()
        {
            ViewBag.Name = HttpContext.Session.GetString(SessionName);
            ViewBag.Age = HttpContext.Session.GetInt32(SessionAge);
            ViewData["Message"] = "Sessions";
            return View();
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}
