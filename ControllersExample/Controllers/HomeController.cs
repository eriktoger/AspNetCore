using Microsoft.AspNetCore.Mvc;
using IActionResultExample.Models;
using System.Net;

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
        public IActionResult Book(int? bookId)
        {
            if (bookId == null )
            {
                Response.StatusCode = 400;
                return BadRequest("Book Id is not supplied");
            }

            if (bookId == 404)
            {
                return new NotFoundResult();
            }

            return new VirtualFileResult("/collision.png", "image/png");
        }

        [Route("/books/{Author}/{BookId}")]
        public IActionResult BookWithId(Book? book)
        {
            

            if (book == null)
            {
                return new NotFoundResult();
            }

            if (book.BookId < 0)
            {
                return NotFound( "Id must be non-negative");
            }

            return Content(book.ToString(), "plain/text");
        }

        [Route("")]
        public string Base()
        {
            return "Base";
        }
    }
}
