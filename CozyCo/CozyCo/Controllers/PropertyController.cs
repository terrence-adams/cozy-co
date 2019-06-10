using CozyCo.Domain.Models;
using CozyCo.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CozyCo.WebUI.Controllers
{
    [Authorize(Roles = "Landlord")]
    public class PropertyController : Controller
    {
        private readonly IPropertyService _propertyService;
        private readonly IPropertyTypeService _propertyTypeService;
        private readonly UserManager<AppUser> _userManager;
        private readonly string PROPERTYTYPES = "PropertyTypes";

        public PropertyController(IPropertyService propertyService, IPropertyTypeService propertyTypeService, UserManager<AppUser> userManager)
        {
            _propertyService = propertyService;
            _propertyTypeService = propertyTypeService;
            _userManager = userManager;
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

            var userId = _userManager.GetUserId(User);
            var properties = _propertyService.GetAllPropertiesByUserId(userId);//passing in the model type
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
            string Id = "0";
            var property = _propertyService.GetAllPropertiesByUserId(Id); // need to update service and add new method
            ViewData.Add(PROPERTYTYPES, property);
        }

        [HttpPost]
        public IActionResult Add(Property newProperty)
        {
            if (ModelState.IsValid)
            {
                newProperty.AppUserId = _userManager.GetUserId(User);
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

        [Authorize(Roles = "Landlord, Tenant")]
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