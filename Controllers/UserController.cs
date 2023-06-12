using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RotaryClub.Interfaces;
using RotaryClub.ViewModels;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RotaryClub.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService) {
            _userService = userService;
        }

        public IActionResult RegisterSuccess()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            var model = new UserRegisterViewModel();
            return View(model);
        }


        [HttpPost]
        public IActionResult Register(UserRegisterViewModel request)
        {
            if (!ModelState.IsValid)
            {
                return View("Register", request);
            }
            if (request == null)
            {
                return BadRequest();
            }

            var status = _userService.CreateUser(request.Email, request.Password);
            if (status.Success)
                return Redirect("RegisterSuccess");
            
            this.ViewBag.Message = status.ErrorMessage + "!";
            return View(request);
        }

        [HttpGet]
        public IActionResult Login()
        {
            var model = new UserLoginViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Login(UserLoginViewModel request)
        {
            if (request == null)
                return BadRequest();

            var status = _userService.GetUser(request.Email, request.Password);

            if (status.Success)
                return RedirectToAction("Index", "Home");
            this.ViewBag.Message = status.ErrorMessage + "!";
            return View(request);
        }
    }
}