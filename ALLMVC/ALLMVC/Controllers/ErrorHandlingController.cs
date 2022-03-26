using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ALLMVC.Controllers
{
    public class ErrorHandlingController : Controller
    {
        private readonly ILogger<ErrorHandlingController> logger;

        public ErrorHandlingController(ILogger<ErrorHandlingController> logger)
        {
            this.logger = logger;
        }

        public  IActionResult Index()
        {
            var exeception = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            logger.LogError($"The path {exeception.Path} throw an exeption" + $" {exeception.Error}");
            return View("Index");
        }

        public IActionResult HttpStatusCodeHandler(int StatusCode)
        {
            var StatusCodeResult = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();

            switch (StatusCode)
            {
                case 404:
                    ViewBag.ErrorMesage = "Sorry";
                    logger.LogWarning($"404 Error occured path = {StatusCodeResult.OriginalPath}" + $"and QueryString = {StatusCodeResult.OriginalPath}");
                    logger.LogWarning($"Please check 'c:/temp' ");
                    break;
            };
            return View();
        }

    }
}
