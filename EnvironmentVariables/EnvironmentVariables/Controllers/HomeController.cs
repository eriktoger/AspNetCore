using Microsoft.AspNetCore.Mvc;

namespace EnvironmentsExample.Controllers
{
    public class HomeController(IWebHostEnvironment webHostEnvironment) : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment = webHostEnvironment;

        [Route("/")]
        public IActionResult Index()
        {

            ViewBag.CurrentEnvironment = _webHostEnvironment.EnvironmentName;
            return View();
        }



    }
}
