using Microsoft.AspNetCore.Mvc;
using Services;
using System.Diagnostics;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BlogLanguageServices _langService;

        public HomeController(ILogger<HomeController> logger, BlogLanguageServices langService)
        {
            _logger = logger;
            _langService = langService;
        }

        public IActionResult Index()
        {
            return View(_langService.GetAllBlogs());
        }

        public async Task<ActionResult> Detail(int id, string LangCode)
        {
            var blog = _langService.GetBlogById(id, LangCode);
            return   View(blog);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}