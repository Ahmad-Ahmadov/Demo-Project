using Core.Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login(UserLoginDto userLoginDto)
        {
            return View();
        }

    }
}
