using AutoMapper;
using DMART.Models;
using DMART.Models.Interfaces;
using DMART.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DMART.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductRepository productRepository;
        private readonly ICartRepository cartRepository;
        private readonly IMapper mapper;

        public CartController(IProductRepository productRepository, ICartRepository cartRepository, IMapper _mapper)
        {
            this.productRepository = productRepository;
            this.cartRepository = cartRepository;
            mapper = _mapper;
        }
        public ViewResult shoppingcart()
        {
            List<ProductCartModel> products = cartRepository.GetCart();
            return View(products);
        }
        
        public ViewResult AddToCart(Product item)
        {
            ProductCartModel product = mapper.Map<ProductCartModel>(item);
            cartRepository.AddtoCart(product);
            return View();
        }
    }
}
