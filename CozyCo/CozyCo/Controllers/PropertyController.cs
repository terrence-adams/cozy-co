using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CozyCo.Models;

namespace CozyCo.WebUI.Controllers
{
    public class PropertyController : Controller
    {
        private List<Property> Properties = new List<Property>();
        public IActionResult Index()
        {
            return View(Properties); //passing in the model type
        }

        public IActionResult Add()
        {

            return View();

        }
        [HttpPost]
        public IActionResult Add(Property newProperty)
        {
            Properties.Add(newProperty); //adds the passed in values as instance of the class
            //return RedirectToAction(nameof(Index)); //runs at time of compiling because it may be dynamic

            return View(nameof(Index), Properties); //we're calling the page and passing the collection


        }
    }
}