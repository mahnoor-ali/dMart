using Microsoft.AspNetCore.Mvc;
using dMart.Models;

namespace dMart.Controllers
{
    public class signupController : Controller
    {
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
                if (userRepository.validateNewUser(user))
                {
                    userRepository.RegisterUser(user);
                    return RedirectToAction("Login");
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
            if (userRepository.validateLogin(user))
            {
                return RedirectToAction("Index", "Home");
            }

            string msg = "Wrong login credentials. Please Try again";
            return View("Error", msg);
        }
    }
}