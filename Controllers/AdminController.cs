using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DMART.Models;
using DMART.Models.Interfaces;


namespace DMART.Controllers
{
    public class AdminController : Controller
    {

        private readonly IProductRepository productRepo;

        public AdminController(IProductRepository productRepository)
        {
            productRepo = productRepository;
        }

        [Authorize]
        public ViewResult addProduct(bool isSuccess = false, int bookId = 0)
        {
            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = bookId;
            return View();
        }


        [HttpPost]
        public IActionResult addProduct(Product item)
        {
                int id = productRepo.AddProduct(item);
                if (id > 0)
                {
                    return RedirectToAction(nameof(item), new { isSuccess = true, bookId = id });
                }

                return View();
        }


    }
}
