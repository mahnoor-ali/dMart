using Microsoft.AspNetCore.Mvc;
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
        
         public ViewResult SearchResult(String searchItem)
         {
            List<Product> products = productRepo.Search(searchItem);
            if (products.Count!=0)
            {
                return View("productCategory", products);
            }
            string msg = "No such item found.";
            return View("Error", msg);
         }


    }
}
