using Microsoft.AspNetCore.Mvc;
using RotaryClub.Interfaces;
using RotaryClub.Models;

namespace RotaryClub.Controllers
{
    public class EmailController : Controller
    {
        private readonly IEmailSenderService _emailSenderService;

        public EmailController(IEmailSenderService emailSenderService)
        {
            _emailSenderService = emailSenderService;
        }
        [HttpPost]
        public IActionResult SendContactEmail(Email email)
        {
            _emailSenderService.SendContactEmail(email);
            return RedirectToAction("ContactFormSuccess", "Home");
        }
    }
}
