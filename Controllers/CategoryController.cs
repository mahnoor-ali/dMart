using Microsoft.AspNetCore.Mvc;
using DMART.Models;
using DMART.Models.Interfaces;

namespace DMART.Controllers
{
    public class CategoryController : Controller
    {

        private readonly ICategoryRepository categoryRepo;
        private readonly IWebHostEnvironment Environment;

        public CategoryController(ICategoryRepository categoryRepository, IWebHostEnvironment environment)
        {
            categoryRepo = categoryRepository;
            Environment = environment;
        }

        public ViewResult getAllCategories()
        {
            List<Category> items = categoryRepo.GetAllCategories();
            return View(items);
        }
    }
}
