using Microsoft.AspNetCore.Mvc;
using dMart.Models;
using System.Diagnostics;

namespace dMart.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View(); 
        }

    }
}