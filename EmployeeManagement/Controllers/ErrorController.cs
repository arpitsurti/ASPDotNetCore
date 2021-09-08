using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EmployeeManagement.Controllers
{
    public class ErrorController : Controller
    {
        private readonly ILogger<ErrorController> logger;

        public ErrorController(ILogger<ErrorController> logger)
        {
            this.logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            var statusCodeResult = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
            switch (statusCode)
            {
                case 404:
                    logger.LogWarning($"404 error occured {statusCodeResult.OriginalPath}"+
                        $" and quertstring is {statusCodeResult.OriginalQueryString}");//Using dollar with {} is called strin interpolation
                    break;
                default:
                    break;
            }
            return View("NotFound");
        }

        [Route("Error")]
        [AllowAnonymous]
        public IActionResult Error()
        {
            var expDetails = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            ViewBag.ErrorMessage = expDetails.Error.Message;
            ViewBag.StackTrace = expDetails.Error.StackTrace;
            ViewBag.Path = expDetails.Path;
            return View("Error");
        }
    }
}
