using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DMART.Models;
using DMART.Models.Interfaces;


namespace DMART.Controllers
{
    public class AdminController : Controller
    {

        private readonly IProductRepository productRepo;
        private readonly IWebHostEnvironment Environment;

        public AdminController(IProductRepository productRepository, IWebHostEnvironment environment)
        {
            productRepo = productRepository;
            Environment = environment;
        }

        //upload image of a product to the server
        public String UploadImage(IFormFile image) 
        {
            string wwwPath = this.Environment.WebRootPath;
            //absolute path of images folder
            string path = Path.Combine(wwwPath, "ProductImages");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            String fileName = Path.GetFileName(image.FileName);
           
            //TO MAKE FILENAME UNIQUE
            // fileName = Guid.NewGuid().ToString() + "_" +  fileName;
            //absolute path of uploaded image file
            var pathWithFileName = Path.Combine(path, fileName);
            using (FileStream stream = new FileStream(pathWithFileName, FileMode.Create))
            {
                image.CopyTo(stream);
                ViewBag.Message = "File uploaded successfully";
            }
            return ("/" + pathWithFileName);
        }

        public ViewResult addProduct(bool isSuccess = false, int bookId = 0)
        {
            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = bookId;
            return View();
        }

        [HttpPost]
        public IActionResult addProduct(Product item)
        {
            item.ImageUrl =  UploadImage(item.Image); //upload image along with saving its path to Database
            int id = productRepo.AddProduct(item);
            if (id > 0)
            {
                return RedirectToAction("addProduct", new { isSuccess = true, bookId = id });
            }
            return View();
        }

        [HttpGet]
        public ViewResult updateProduct(int id)
        {
            Product item = productRepo.GetProductById(id);
            Product updatedItem = productRepo.UpdateProduct(item);
            return View(updatedItem);
        }
        [HttpPost]
        public IActionResult updateProduct(Product item)
        {
            productRepo.GetProductById(item.Id);
            return View("showProduct", item); //show singleProduct
        }
        
/* public ViewResult showProduct(int id)
        { }
        */
        
        public ViewResult getAllProducts()
        {
            List<Product> items = productRepo.GetAllProducts();
            //getAll****.cshtml
            return View(items);
        }

        public ViewResult getProduct(int id) 
        {
            Product item = productRepo.GetProductById(id);
            //view that shows item not found
            if (item == null)
            {
                return View("Error");
            }
            return View(item);
        }

        public IActionResult deleteProduct(int id)
        {
            Product item = productRepo.GetProductById(id);
            productRepo.DeleteProduct(item);
            return RedirectToAction("getAllProducts");
        }
        
        [Authorize]
        public ViewResult addCategory(bool isSuccess = false, int bookId = 0)
        {
            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = bookId;
            return View();
        }
        
        [HttpPost]
        public IActionResult addCategory(Category item)
        {
            int id = productRepo.AddCategory(item);
            if (id > 0)
            {
                return RedirectToAction("addCategory", new { isSuccess = true, bookId = id });
            }

            return View();
        }
        

        

    }
}
