using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore2.Models
{
    public class Orders
    {
        [BindNever]
        public int OrderId { get; set; }
        [BindNever]
        public ICollection<CartLine> Lines { get; set; }
        [Required(ErrorMessage ="Please entry name")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Please enter  the first address line")]
        public string Street { get; set; }

        public string NumberHouse { get; set; }

        public string NumberFlat { get; set; }
        [Required(ErrorMessage = "Please enter  a city name")]
        public string City { get; set; }
        [Required(ErrorMessage = "Please enter  a oblast name")]
        public string Oblast { get; set; }

        public string Zip { get; set; }
        [Required(ErrorMessage = "Please enter  a country name")]
        public string Country { get; set; }

        public bool GiftWrap { get; set; }
    }
}
