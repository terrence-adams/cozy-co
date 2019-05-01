using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CozyCo.Domain.Models;
using System.Linq;

namespace CozyCo.WebUI.Controllers
{
    public class PropertyController : Controller
    {
        private List<Property> Properties = new List<Property>
        {
            new Property {ID = 1, Address ="1234 Main Street", Address2 = "Suite D", City="Austin", Zipcode="34523"},
            new Property {ID = 2,Address="2344 Wilkerson",Address2="Drive Two",City="Houston",Zipcode="23234"}

        };
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
            if (ModelState.IsValid)
            {

                Properties.Add(newProperty);
                return View(nameof(Index), Properties);

            }
            //adds the passed in values as instance of the class
            //return RedirectToAction(nameof(Index)); //runs at time of compiling because it may be dynamic

            return View("Form", newProperty); //we're calling the page and passing the collection


        }

        public IActionResult Delete(int id)
        {
            var property = Properties.Single(p => p.ID == id);
            Properties.Remove(property);
            return View(nameof(Index), Properties);

        }

        public IActionResult Detail(int id)
        {
            var property = Properties.Single(p => p.ID == id);
            return View(property);
        }

        [HttpPost]
        public IActionResult Edit(int iD)
        {

            var myProperty = Properties.Single(p => p.ID == iD);

            return View(nameof(Index), Properties);

        }


    }
}