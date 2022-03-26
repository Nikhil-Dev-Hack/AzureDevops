using ALLMVC.Data;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ALLMVC.Controllers
{
    public class AllViewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult PartialViewExample()
        {
            //@{
            //    await Html.RenderPartialAsync("PartialViewExample");
            //}
            return View();
        }

        public IActionResult ViewComponentExample()
        {
            return View();
        }
        public IActionResult google()
        {
            return View();
        }
        public IActionResult facebook()
        {
            return View();
        }
        public IActionResult linkedin()
        {
            return View();
        }
        public IActionResult youtube()
        {
            return View();
        }
        public IActionResult twitter()
        {
            return View();
        }

    }
}
