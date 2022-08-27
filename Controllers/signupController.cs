using Microsoft.AspNetCore.Mvc;
using DMART.Models;
using DMART.Models.Interfaces;

namespace DMART.Controllers
{
    public class signupController : Controller
    {
        private readonly IUserRepository usersRepo = null;

        public signupController(IUserRepository bookRepository)
        {
            usersRepo=bookRepository;
        }

        [HttpGet]
        public ViewResult Signup()
        {
            return View("signup");
        }

        [HttpPost]
        public IActionResult Signup(users user)
        {
            if (ModelState.IsValid)
            {
                if (usersRepo.validateNewUser(user))
                {
                   int id = usersRepo.RegisterUser(user);
                    if (id>0) //if user is registered, go to login page
                    {
                        return RedirectToAction("Login");
                    }
                }
                else
                {
                    string msg = "User with this email or phone number already exist. Please login with your existing account";
                    return View("Error", msg);
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Please enter correct data");
            }
            return View();
        }


        [HttpGet]
        public ViewResult Login()
        {
            return View("login");
        }

        [HttpPost]
        public IActionResult Login(users user)
        {
            if (usersRepo.validateLogin(user))
            {
                return RedirectToAction("Index", "Home");
            }

            string msg = "Wrong login credentials. Please Try again";
            return View("Error", msg);
        }
    }
}