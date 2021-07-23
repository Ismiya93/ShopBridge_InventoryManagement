using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge_InventoryManagement.Controllers
{
    public class ErrorController : Controller
    {
        public readonly ILogger<ErrorController> Logger;

        public ErrorController(ILogger<ErrorController> logger)
        {
            Logger = logger;
        }
        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            var statusCodeResult=HttpContext.Features.Get<StatusCodeReExecuteFeature>();
            switch (statusCode)
            {
                case 404:
                    ViewBag.ErrorMessage = "Sorry,the resource you requested could not be found";
                    Logger.LogWarning($"404 Error occured.The Path {statusCodeResult.OriginalPath} and queryString {statusCodeResult.OriginalQueryString}");
                    break;
            }
            return View("NotFound");
        }
        [Route("Error")]
        [AllowAnonymous]
        public IActionResult Error()
        {
            var expectionDetails = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            Logger.LogError($"The Path {expectionDetails.Path} threw an expection {expectionDetails.Error.Message}");
            return View("Error");
        }
    }
}
