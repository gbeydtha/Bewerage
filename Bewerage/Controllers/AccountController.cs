using Bewerage.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Bewerage.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _usermanager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> usermanager, SignInManager<IdentityUser> signInManager)
        {
            _usermanager = usermanager;
            _signInManager = signInManager;

        }
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginViewModel()
            {
                RetunrUrl =returnUrl
            });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(); 
            }

            var user = await _usermanager.FindByNameAsync(loginViewModel.Usernname);
            if(user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false);
                if (result.Succeeded)
                {
                    if (string.IsNullOrEmpty(loginViewModel.RetunrUrl))
                    {
                        return RedirectToAction("Index", "Home"); 
                    }

                    return Redirect(loginViewModel.RetunrUrl); 
                }
            }

            ModelState.AddModelError("", "Username/Password not found");
            return View(loginViewModel);
        }

        public ActionResult Register()
        {
            return View(); 
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Register(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser() { UserName = loginViewModel.Usernname };
                var result = await _usermanager.CreateAsync(user, loginViewModel.Password);

                if (result.Succeeded)
                    return RedirectToAction("Index", "Home"); 
            }

            return View(loginViewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}