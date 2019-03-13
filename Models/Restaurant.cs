using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OdeToFood_home.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        [MinLength(2)]
        [MaxLength(50)]
        [Display(Name = "Restaurant name:")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Cuisine type:")]
        [Required]
        public CuisineType Cuisine { get; set; }

    }
}
