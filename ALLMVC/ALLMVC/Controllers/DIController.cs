using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ALLMVC.Dependency_Injection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ALLMVC.Controllers
{
    public class DIController : Controller
    {
        private readonly IAgeCal _age;

        public DIController(IAgeCal age)
        {
            _age = age ?? throw new ArgumentNullException(nameof(age));
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Index(IFormCollection form)
        {
            var dob = DateTime.Parse(form["YourAge"]);
            ViewBag.DOB = dob;
            ViewBag.YourAge = _age.GetAge(dob);
            return View();
        }
    }
}
