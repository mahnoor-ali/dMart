using DMART.Models;
using DMART.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DMART.ViewComponents
{
    public class Category : ViewComponent
    {
        public readonly ICategoryRepository categoryRepo;
        public Category(ICategoryRepository _categoryRepo)
        {
            categoryRepo = _categoryRepo;
        }
        public IViewComponentResult Invoke()
        {
            List<Models.Category> categories = categoryRepo.GetAllCategories();
            return View("Default",categories);
        }

    }
}
