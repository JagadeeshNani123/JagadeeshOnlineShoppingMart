using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCore.Models
{
    public class Payment
    {
        [Required(ErrorMessage = "Enter Town")]
        public string CardHolderName { get; set; }

        [Required(ErrorMessage = "Enter card number")]
        public long CardNumber { get; set; }

        [Phone]
        [Required(ErrorMessage = "Enter cvv number")]
        public int CVV { get; set; }

        [Required(ErrorMessage = "Enter date of expiry")]
        
        public string DateOfExpiry  { get; set; }

        public Payment()
        {

        }
        
    }
}
