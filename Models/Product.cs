using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCore.Models
{
    public class Product
    {
        [Required(ErrorMessage="Enter product Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Select product name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Select Quantity")]
        public int Quantity { get; set; }

        
        public long Cost { get; set; }

    }
    
}
