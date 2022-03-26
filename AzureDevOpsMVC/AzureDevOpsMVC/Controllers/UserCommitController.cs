using AzureDevOpsMVC.Data;
using AzureDevOpsMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureDevOpsMVC.Controllers
{
    public class UserCommitController : Controller
    {
        private readonly AzureDevOpsMVCContext _context;
        public UserCommitController(AzureDevOpsMVCContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public  IActionResult ShowCommitData()
        {
            string user = User.Identity.Name;
            user = "Thahaseen Shaik";

            string[] subs = user.Split('\\');
            var Commitlist = _context.CommitsData.Where(s => s.UserName.Contains(user)).ToList();



        

            return View(Commitlist);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ShowCommitDataFilter(IFormCollection form)
        {
            string user = User.Identity.Name;
            user = "Thahaseen Shaik";

            string[] subs = user.Split('\\');
            DateTime Startdate = DateTime.Parse(form["StartDate"]);
            
            DateTime EndDate = DateTime.Parse(form["EndDate"]);

            var Commitlist = _context.CommitsData.Where(s => s.UserName.Contains(user)).ToList();
            Commitlist = Commitlist.Where(s => s.CommitDate >= Startdate && s.CommitDate <= EndDate).ToList();





            return View(Commitlist);
        }
        public  IActionResult DetailsUserChanges(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            List<ChangesData> changedata = new List<ChangesData>();
            changedata = _context.ChangesData.Where(m => m.CommitId == id).ToList();
            if (changedata == null)
            {
                return NotFound();
            }

            return View(changedata);
        }
        public IActionResult DetailsUserCommmits(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            List<CommitsData> commitdatas = new List<CommitsData>();
            commitdatas = _context.CommitsData.Where(m => m.CommitId == id).ToList();
            if (commitdatas == null)
            {
                return NotFound();
            }

            return View(commitdatas);
        }


    }
}
