using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using OdeToFood_home.Services;

namespace OdeToFood_home
{
    public class Greeter:IGreeter
    {
        private IConfiguration _configuration;

        public Greeter(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GetMessageOfTheDay() => _configuration["Greeting"];
       
    }
}
