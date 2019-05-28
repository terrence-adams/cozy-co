using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CozyCo.Domain.Models;
using CozyCo.Service.Services;

namespace CozyCo.WebUI.Controllers
{
    public class PropertyController : Controller
    {
        private readonly IPropertyService _propertyService;
        private readonly IPropertyTypeService _propertyTypeService;
        private readonly string PROPERTYTYPES = "PropertyTypes";

        public PropertyController(IPropertyService propertyService, IPropertyTypeService propertyTypeService)
        {
            _propertyService = propertyService;
            _propertyTypeService = propertyTypeService;
        }

        private List<Property> Properties = new List<Property>
        {
            new Property {ID = 1, Address ="1234 Main Street", Address2 = "Suite D", City="Austin", Zipcode="34523"},
            new Property {ID = 2,Address="2344 Wilkerson",Address2="Drive Two",City="Houston",Zipcode="23234"}

        };
        public IActionResult Index()
        {
            if (TempData["Error"] != null)
            {
                ViewData.Add("Error", TempData["Error"]);
            }

            var properties = _propertyService.GetAllProperties();//passing in the model type
            return View(properties);
        }

        [HttpGet]
        public IActionResult Add()
        {
            GetPropertyTypes();
            return View("Form");

        }

        private void GetPropertyTypes()
        {
            var property = _propertyService.GetAllProperties();
            ViewData.Add(PROPERTYTYPES, property);
        }

        [HttpPost]
        public IActionResult Add(Property newProperty)
        {
            if (ModelState.IsValid)
            {

                _propertyService.Create(newProperty);
                return RedirectToAction(nameof(Index));

            }
            //adds the passed in values as instance of the class
            //return RedirectToAction(nameof(Index)); //runs at time of compiling because it may be dynamic

            return View("Form"); //we're calling the page and passing the collection


        }

        public IActionResult Delete(int id)
        {
            var succeeded = _propertyService.Delete(id);
            if (!succeeded)
            {
                TempData.Add("Error", " This was not deleted successfully.");
            }
            return RedirectToAction(nameof(Index));

        }

        public IActionResult Detail(int id)
        {
            var property = Properties.Single(p => p.ID == id);
            return View(property);
        }


        public IActionResult Edit(int iD)
        {
            var property = _propertyService.GetById(iD);


            return View("Form", property);

        }

        [HttpPost]
        public IActionResult Edit(int id, Property newProperty)
        {
            if (ModelState.IsValid)
            {
                _propertyService.Update(newProperty);
                return RedirectToAction(nameof(Index));

            }

            return View("Form", newProperty);


        }


    }
}