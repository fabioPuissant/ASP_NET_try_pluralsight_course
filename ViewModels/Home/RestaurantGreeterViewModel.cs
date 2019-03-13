using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OdeToFood_home.Models;
using OdeToFood_home.Services;

namespace OdeToFood_home.ViewModels.Home
{
    public class RestaurantGreeterViewModel
    {
        public IEnumerable<Restaurant> Restaurants { get; set; }
        public IGreeter Greeter { get; set; }
    }
}
