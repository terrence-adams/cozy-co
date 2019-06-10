using CozyCo.Domain.Models;
using CozyCo.WebUI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CozyCo.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        private readonly SignInManager<AppUser> _signInManager;

        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            RedirectUserWhenAlreadyLoggedIn();

            var roles = _roleManager.Roles.ToList();
            var vm = new RegisterViewModel()

            {
                Roles = roles
            };
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
                    result = await _userManager.CreateAsync(newUser, registerVM.Password);

                    if (result.Succeeded)
                    {
                        await _signInManager.SignInAsync(newUser, false);

                        if (registerVM.Role == "Landlord")
                        {
                            return RedirectToAction("Index", "Landlord");
                        }

                        return RedirectToAction("Index", "Tenant");
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

            }

            var roles = _roleManager.Roles.ToList();
            registerVM.Roles = roles;
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

            return View(lvm);
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