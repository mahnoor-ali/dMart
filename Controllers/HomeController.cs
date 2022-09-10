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
            return View(); 
        }

        /*
        public ViewResult Index()
        {
            List<Category> items = categoryRepo.GetAllCategories();
            return View(items); 
        }
        */

    }
}