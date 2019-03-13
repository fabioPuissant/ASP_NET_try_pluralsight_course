using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OdeToFood_home.Models;

namespace OdeToFood_home.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        private List<Restaurant> _allRestaurants;

        public InMemoryRestaurantData()
        {
            _allRestaurants = new List<Restaurant>()
            {
                new Restaurant
                {
                    Id = 1,
                    Name = "PizzaHut"
                },
                new Restaurant
                {
                    Id=2,
                    Name = "Mc Donalds"
                },
                new Restaurant
                {
                    Id=3,
                    Name = "'t Patatje"
                }
            };
        }

        public IEnumerable<Restaurant> GetAllRestaurants()
        {
            return _allRestaurants.OrderBy(r=> r.Name);
        }

        public Restaurant Get(int id)
        {
            return _allRestaurants.FirstOrDefault(r => r.Id == id);
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            newRestaurant.Id = _allRestaurants.Max(r => r.Id) + 1;
            _allRestaurants.Add(newRestaurant);
            return newRestaurant;
        }
    }
}
