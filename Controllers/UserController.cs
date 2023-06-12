using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using RotaryClub.Interfaces;
using RotaryClub.ViewModels;
using System.Security.Claims;
using RotaryClub.Models;

namespace RotaryClub.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
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

            var status = _userService.CreateUser(request);
            if (status.Success)
                return RedirectToAction("SendVerificationEmail", "Email", new Email()
                {
                    EmailAddress = request.Email,
                });

            this.ViewBag.Message = status.ErrorMessage + "!";
            return View(request);
        }

        [HttpGet]
        public IActionResult Login()
        {
            ClaimsPrincipal claimUser = claimUser = HttpContext.User;
            if (claimUser.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");
            var model = new UserLoginViewModel();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Verify(string token)
        {
            var response = await _userService.VerifyUser(token);
            if (response.Success)
                 return View("VerificationSuccess");
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(UserLoginViewModel request)
        {
            if (request == null)
                return BadRequest();

            var status = _userService.GetUser(request.Email, request.Password);

            if (status.Success)
            {
                _userService.Login(request.Email, HttpContext);
                return RedirectToAction("Index", "Home");
            }

            this.ViewBag.Message = status.ErrorMessage + "!";
            return View(request);
        }


        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}