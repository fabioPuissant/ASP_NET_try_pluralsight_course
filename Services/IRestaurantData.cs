using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OdeToFood_home.Models;

namespace OdeToFood_home.Services
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAllRestaurants();
        Restaurant Get(int id);
        Restaurant Add(Restaurant newRestaurant);
    }

}
