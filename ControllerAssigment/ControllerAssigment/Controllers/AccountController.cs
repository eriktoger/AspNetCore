using Microsoft.AspNetCore.Mvc;

namespace ControllerAssigment.Controllers
{
    public class AccountController : Controller
    {
        [Route("/")]
        public IActionResult Home()
        {
            return Ok("Welcome to the Best Bank");
        } 
        [Route("/account-details")]
        public IActionResult AccountDetails()
        {

            return Json(new {accountNumber =1001,
                accountHolderName ="Example Name",
                currentBalance= 5000
            });
        }

        [Route("/account-statement")]
        public IActionResult AccountStatement()
        {
            return new VirtualFileResult("/collision.png", "image/png");
        }

        [Route("/get-current-balance/{id:int}")]
        public IActionResult Balance()
        {
            var id = Convert.ToInt32(Request.RouteValues["id"]);
            if ( id == 1001)
            {
                return Ok(5000);
            }
            return BadRequest("Account Number should be 1001");
            
        }

        [Route("/get-current-balance")]
        public IActionResult NoBalance()
        {
            return NotFound("Account Number should be supplied");
        }
    }
}
