using Microsoft.AspNetCore.Mvc;
using onlinePharmacy.Models;
using System.Diagnostics;

namespace onlinePharmacy.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View(userRepository.ViewUsers()); //list of users passed to Homepage view
        }
    }
}