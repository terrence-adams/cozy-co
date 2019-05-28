using CozyCo.Domain.Models;
using CozyCo.WebUI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CozyCo.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            RedirectUserWhenAlreadyLoggedIn();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerVM)
        {
            if (ModelState.IsValid)
            {
                var newUser = new AppUser
                {
                    UserName = registerVM.Email,
                    NormalizedUserName = registerVM.Email.ToUpper(),
                    Email = registerVM.Email,
                    NormalizedEmail = registerVM.Email.ToUpper()
                };

                var result = await _userManager.CreateAsync(newUser, registerVM.Password);

                if (result.Succeeded)
                {
                    // new user got created
                    // we can login the user
                    await _signInManager.SignInAsync(newUser, false);
                    // send the user to the right page (redirect)
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    // new user was not added
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }

            // sending back the error(s) to the view (register form)
            return View(registerVM);
        }

        [HttpGet]
        public IActionResult Login()
        {
            RedirectUserWhenAlreadyLoggedIn();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel lvm)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(lvm.Email, lvm.Password, lvm.RememberMe, false);
                var user = User;

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", lvm);
                }
                else
                {
                    ModelState.AddModelError("", "Email or Password Incorrect");
                }
            }

            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        private IActionResult RedirectUserWhenAlreadyLoggedIn()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            return null;
        }
    }
}