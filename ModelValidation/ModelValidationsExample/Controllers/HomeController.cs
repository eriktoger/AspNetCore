using Microsoft.AspNetCore.Mvc;
using ModelValidationsExample.Models;

namespace ModelValidationsExample.Controllers
{
  public class HomeController : Controller
  {
    [Route("register")]
    public IActionResult Index([FromBody][Bind("PersonName", "Email")] Person person)
    {
      if (!ModelState.IsValid)
      {

        List<string> errorsList = ModelState.Values.SelectMany(value => value.Errors).Select(err => err.ErrorMessage).ToList();
        // Same as:
        // List<string> errorsList = new();
        // foreach (var value in ModelState.Values)
        // {
        //   foreach (var error in value.Errors)
        //   {
        //     errorsList.Add(error.ErrorMessage);
        //   }
        // }
        string errors = string.Join("\n", errorsList);

        return BadRequest(errors);
      }

      return Content($"{person}");
    }
  }
}
