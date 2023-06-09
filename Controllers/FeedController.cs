using Microsoft.AspNetCore.Mvc;
using RotaryClub.Interfaces;

namespace RotaryClub.Controllers
{
    public class FeedController : Controller
    {

        private readonly IFacebookService _facebookService;

        public FeedController(IFacebookService facebookService)
        {
            _facebookService = facebookService;
        }
        public IActionResult Index()
        {
            var posts = _facebookService.GetAllAsync();
            return View();
        }
    }
}
