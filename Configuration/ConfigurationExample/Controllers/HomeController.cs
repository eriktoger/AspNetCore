using ConfigurationExample;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ConfiguartionExample.Controllers
{
    public class HomeController(IConfiguration configuration, IOptions<WeatherApiOptions> weatherApiOptions) : Controller
    {

        [Route("/")]
        public IActionResult Index()
        {
            ViewBag.MyKey = configuration["MyKey"];
            ViewBag.MyAPIKey = configuration.GetValue<string>("MyKey1", "Api key is missing");
            ViewBag.ClientID = weatherApiOptions.Value.ClientID;
            ViewBag.ClientSecret = weatherApiOptions.Value.ClientSecret;
            return View();
        }



    }
}
