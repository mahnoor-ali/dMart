using Microsoft.AspNetCore.Mvc;
using DMART.Models;
using System.Diagnostics;

namespace DMART.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            
            return View(); 
        }

    }
}