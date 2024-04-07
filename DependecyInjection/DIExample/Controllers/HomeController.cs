using Microsoft.AspNetCore.Mvc;
using Services;
using ServiceContracts;

namespace DIExample.Controllers
{
    public class HomeController(ICitiesService citiesService) : Controller
    {

        [Route("/")]
        public ActionResult Index()
        {
            List<string> cities = citiesService.GetCities();
            return View(cities);
        }

    }
}
