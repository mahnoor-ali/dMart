using DMART.Models;
using DMART.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DMART.ViewComponents
{
    public class CategoryViewComponent : ViewComponent
    {
        public readonly ICategoryRepository categoryRepo;
        public CategoryViewComponent(ICategoryRepository _categoryRepo)
        {
            categoryRepo = _categoryRepo;
        }
        public IViewComponentResult Invoke()
        {
            List<Category> categories = categoryRepo.GetAllCategories();
            return View(categories);
        }

    }
}
