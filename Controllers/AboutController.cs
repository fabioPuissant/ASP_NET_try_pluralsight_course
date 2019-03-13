using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace OdeToFood_home
{
    [Route("[controller]/[action]")]
    public class AboutController : Controller
    {
        [Route("")]
        public string Phone()
        {
            return "+3249/1125718";
        }

        public string Address()
        {
            return "Brikhof 100 \n3840 Hoepertingen";
        }
    }
}
