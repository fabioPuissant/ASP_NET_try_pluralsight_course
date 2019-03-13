using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OdeToFood_home.Models;
using OdeToFood_home.Services;
using OdeToFood_home.ViewModels.Home;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OdeToFood_home.Controllers
{
    public class HomeController : Controller
    {
        private IRestaurantData _restaurantData;
        private IGreeter _greeter;
        
        public HomeController(IRestaurantData restaurantData, IGreeter greeter)
        {
            _restaurantData = restaurantData;
            _greeter = greeter;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var model = new Restaurant{Id = 1, Name = "Pizzahut"};
            return View(model);
        }

        public IActionResult Restaurants()
        {
            return View(_restaurantData.GetAllRestaurants());
        }

        public IActionResult Index1()
        {
            var model = new RestaurantGreeterViewModel();
            model.Restaurants = _restaurantData.GetAllRestaurants();
            model.Greeter = _greeter;
            return View(model);
        }

        public IActionResult Details(int id)
        {
            var model = _restaurantData.Get(id);
            if (model == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(RestaurantEditModel postModel)
        {
            Restaurant newRestaurant = new Restaurant
            {
                Name = postModel.Name,
                Cuisine = postModel.Cuisine
            };

            newRestaurant = _restaurantData.Add(newRestaurant);

            return View("Details", newRestaurant);
        }
    }
}
