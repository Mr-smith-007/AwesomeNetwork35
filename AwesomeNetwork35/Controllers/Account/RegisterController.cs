using AwesomeNetwork35.ViewModels.Account;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AwesomeNetwork35.Controllers.Account
{
    public class RegisterController : Controller
    {
        [Route("Register")]
        [HttpGet]
        public IActionResult Register()
        {
            return View("Home/Register");
        }

        [Route("RegisterPart2")]
        [HttpGet]
        public IActionResult RegisterPart2(RegisterViewModel model)
        {
            return View("RegisterPart2", model);
        }
    }
}
