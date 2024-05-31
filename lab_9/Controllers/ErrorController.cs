using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace lab_9.Controllers
{
    public class ErrorController : Controller
    {
        [Route("/Error")]
        public IActionResult HandleError()
        {
            var exception = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            switch (exception?.Error)
            {
                case null:
                    return View("GenericError");
                case InvalidOperationException ex:
                    ViewBag.ErrorMessage = ex.Message;
                    return View("~/Views/Error/DatabaseError.cshtml", ex.Message);
                case BadHttpRequestException ex:
                    ViewBag.ErrorMessage = ex.Message;
                    return View("~/Views/Error/404Error.cshtml", ex.Message);
                default:
                    return View("GenericError");
            }
        }
    }
}
