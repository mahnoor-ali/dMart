using Microsoft.AspNetCore.Mvc;
using DMART.Models.Interfaces;
using DMART.Models;
using System.Diagnostics;

namespace DMART.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryRepository categoryRepo;
        private readonly IWebHostEnvironment Environment;

        public HomeController(ICategoryRepository categoryRepository, IWebHostEnvironment environment)
        {
            categoryRepo = categoryRepository;
            Environment = environment;
        }

        public ViewResult Index()
        {
            ViewData["username"] ="";
            if (HttpContext.Session.Keys.Contains("username"))
            {
                ViewData["isLogin"] = "true";
                ViewData["username"] = HttpContext.Session.GetString("username");
            }
            else
            {
                ViewData["isLogin"] = "false";
                ViewData["username"] = "Account";
            }
            return View();
        }

        public IActionResult getTopDealsVc()
        {
            return ViewComponent("TopDeals", 5);
        }

    }
}