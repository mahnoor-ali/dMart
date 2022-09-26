using Microsoft.AspNetCore.Mvc;
using DMART.Models;
using DMART.Models.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace DMART.Controllers
{
    public class signupController : Controller
    {
        private readonly IUserRepository usersRepo;
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public signupController(IUserRepository bookRepository, UserManager<IdentityUser> uManager, SignInManager<IdentityUser> sManager)
        {
            usersRepo=bookRepository;
            userManager = uManager;
            signInManager = sManager;
        }

        [HttpGet]
        public ViewResult Signup()
        {
            return View("signup");
        }

        [HttpPost]
        public async Task<IActionResult> Signup(User model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    UserName = model.Name,
                    Email = model.Email,
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                };
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    if (signInManager.IsSignedIn(User))
                    {
                        return RedirectToAction("index", "Home");
                    }
                    return RedirectToAction("login", "Signup");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View();
        }

        /*
        [HttpPost]
        public IActionResult Signup(User user)
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
        */


        [HttpGet]
        public async Task<IActionResult> Logout(User user)
        {
            HttpContext.Session.Remove("username");
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");

        }

        /*
        [HttpGet]
        public IActionResult Logout(User user)
        {
            HttpContext.Session.Remove("username");
            return RedirectToAction("Index", "Home");
        }
        */

        /*
        [HttpGet]
        public ViewResult Login()
        {
            return View("login");
        }
        */

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
                if (result.Succeeded)
                {
                    String username = usersRepo.GetUserByEmail(model.Email);
                    HttpContext.Session.SetString("username", username);
                    return RedirectToAction("index", "Home");
                }
                ModelState.AddModelError(string.Empty, "Invalid Email or Password");
            }
            return View(model);
        }
        /*
        [HttpPost]
        public IActionResult Login(User user)
        {
            if (usersRepo.validateLogin(user))
            {
                String username = usersRepo.GetUserByEmail(user.Email);
                HttpContext.Session.SetString("username", username);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                string msg = "Wrong login credentials. Please Try again";
                return View("Error", msg);
            }
        }
        */

    }
}