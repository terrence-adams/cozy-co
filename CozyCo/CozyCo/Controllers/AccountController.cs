using CozyCo.Domain.Models;
using CozyCo.WebUI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CozyCo.WebUI.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<AppUser> _userManager;
        public AccountController(UserManager<AppUser> userManager)
        {



        }
        [HttpGet]
        public IActionResult Register()
        {

            return View();

        }

        public IActionResult Register(RegisterViewModel registerVM)
        {

            if (ModelState.IsValid)
            {
                var UserName = registerVM.Email;
                var NormalizedUserName = registerVM.Email.ToUpper();
                var Password = registerVM.Password;
                var PasswordNormalized = registerVM.Password.ToUpper();

            }

            return View(registerVM);
        }
    }
}
