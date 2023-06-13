using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using RotaryClub.Interfaces;
using System.Security.Claims;
using RotaryClub.Models;
using RotaryClub.ViewModels.User;

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
                return View("RegisterSuccess");

            this.ViewBag.Message = status.ErrorMessage + "!";
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> Verify(string token)
        {
            var response = await _userService.VerifyUser(token);
            if (response.Success)
                return View("VerificationSuccess");
            return BadRequest(response.ErrorMessage);
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


        [HttpPost]
        public Task<IActionResult> Login(UserLoginViewModel request)
        {
            if (request == null)
                return Task.FromResult<IActionResult>(BadRequest());

            var status = _userService.GetUser(request.Email, request.Password);

            if (status.Success)
            {
                _userService.Login(request.Email, HttpContext);
                return Task.FromResult<IActionResult>(RedirectToAction("Index", "Home"));
            }

            this.ViewBag.Message = status.ErrorMessage + "!";
            return Task.FromResult<IActionResult>(View(request));
        }


        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            var response = await _userService.CreateResetTokenAsync(email);
            if (response.Success)
                return View("ResetSent");
            return BadRequest(response.ErrorMessage);
        }

        [HttpGet]
        public async Task<IActionResult> ResetPassword(string token)
        {
            var response = await _userService.CheckPasswordToken(token);
            if (!response.Success)
                return BadRequest(response.ErrorMessage);
            var vm = new ResetPasswordViewModel()
            {
                Token = token
            };
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel request)
        {
            if (!ModelState.IsValid)
            {
                return View("ResetPassword", request);
            }
            if (request == null)
            {
                return BadRequest();
            }

            var response = await _userService.ResetPassword(request);
            if (!response.Success)
                return BadRequest(response.ErrorMessage);

            return RedirectToAction("Login");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}