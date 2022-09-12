using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DMART.Models.Interfaces;
using DMART.Models;

namespace DMART.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository productRepo;
        public ProductController(IProductRepository productRepository)
        {
            productRepo = productRepository;
        }

        public ViewResult ProductCategory()
        {
            List<Product> item = productRepo.GetAllProducts();
            return View(item);
        }

        public ViewResult SearchResults(Boolean isSuccess) //show message if no item found in search
        {
            List<Product> products = productRepo.GetAllProducts();
            ViewBag.isSuccess = isSuccess;
            return View("productCategory", products);
        }
        
        [HttpPost]
        public IActionResult SearchResult(String searchItem) //search a product by name
        {
            (List<Product> products , int count) = productRepo.Search(searchItem);
            if (count==0)
            {
                return RedirectToAction("SearchResults", new { isSuccess = false });
            }
            return View("productCategory", products);
        }

    }
}
