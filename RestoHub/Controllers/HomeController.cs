using Microsoft.AspNetCore.Mvc;
using RestoHub.Models;
using RestoHub.Services;
using RestoHub.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestoHub.Controllers
{
    public class HomeController : Controller
    {
        private IRestaurantData _restaurantData;

        public HomeController(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }
        public IActionResult Index()
        {
            var model = _restaurantData.GetAll();
            return View(model);
        }

        public IActionResult Details(int id)
        {
            var model = _restaurantData.Get(id);
            if(model == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public IActionResult About()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(RestaurantViewModel model)
        {
            if (ModelState.IsValid)
            {
                Restaurant rest = new Restaurant();
                rest.Name = model.Name;
                rest.Cuisine = model.Cuisine;
                _restaurantData.Add(rest);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _restaurantData.Get(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(int id, RestaurantViewModel model)
        {
            var restaurant = _restaurantData.Get(id);
            if (ModelState.IsValid)
            {
                _restaurantData.Update(model);
                return RedirectToAction ("Details", new { id = restaurant.Id });
            }
            return View();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _restaurantData.Delete(id);
            return View("Index");
        }
    }
}
