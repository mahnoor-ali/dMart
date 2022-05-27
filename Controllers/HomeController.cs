using Microsoft.AspNetCore.Mvc;
using dMart.Models;
using System.Diagnostics;

namespace dMart.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View(userRepository.ViewUsers()); //list of users passed to Homepage view
        }
        public ViewResult home()
        {
            return View();
        }

    }
}