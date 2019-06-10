using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CozyCo.WebUI.Controllers
{
    public class LandLordController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}