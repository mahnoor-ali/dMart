using Microsoft.AspNetCore.Mvc;
using DMART.Models;
using DMART.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using DMART.Models.ViewModels;

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
                    PhoneNumber = model.Number,
                    PhoneNumberConfirmed= true,
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
                    ModelState.AddModelError("", "Please enter correct data. " + error.Description);
                }
            }
            return View();
        }
        
        [HttpGet]
        public async Task<IActionResult> Logout(User user)
        {
            HttpContext.Session.Remove("username");
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");

        }
        
        [HttpGet]
        public ViewResult Login()
        {
            return View("login");
        }
        
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);
                if (result.Succeeded)
                {
                    HttpContext.Session.SetString("username", model.Username);
                    return RedirectToAction("index", "home");
                }
                ModelState.AddModelError(string.Empty, "Invalid Username or Password");
              }
            return View(model);
        }

    }
}