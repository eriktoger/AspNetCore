using Microsoft.AspNetCore.Mvc;

namespace ControllersExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("file")]
        public VirtualFileResult File()
        {
            return new VirtualFileResult("/collision.png", "image/png");
        }

        [Route("bookstore")]
        public IActionResult BookStore()
        {
            return new RedirectToActionResult("Books","Store", new {});
        }

        [Route("/books")]
        public IActionResult Book()
        {
            if (!Request.Query.ContainsKey("bookid"))
            {
                Response.StatusCode = 400;
                return BadRequest("Book Id is not supplied");
            }

            if (Request.Query["bookid"] == "404")
            {
                return new NotFoundResult();
            }

            return new VirtualFileResult("/collision.png", "image/png");
        }

        [Route("")]
        public string Base()
        {
            return "Base";
        }
    }
}
