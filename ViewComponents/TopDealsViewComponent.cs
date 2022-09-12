using DMART.Models;
using DMART.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;


namespace DMART.ViewComponents
{
    public class TopDealsViewComponent: ViewComponent
    {
        public readonly IProductRepository productRepo;
        public TopDealsViewComponent(IProductRepository __productRepo)
        {
            productRepo = __productRepo;
        }
        public IViewComponentResult Invoke(int count)
        {
           List<Product> topDeals = productRepo.getTopDeals();
           return View("Default", topDeals);
        }
    }
}
