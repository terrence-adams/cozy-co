﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CozyCo.WebUI.Controllers
{
    [Authorize(Roles = "Tenant")]
    public class TenantController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}