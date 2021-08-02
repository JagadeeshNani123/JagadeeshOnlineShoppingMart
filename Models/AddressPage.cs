using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCore.Models
{
    public class AddressPage
    {

        [Required(ErrorMessage = "Enter your full name")]
        public string FullName { get; set; }

        [Phone]
        [Required(ErrorMessage = "Enter Mobile Number number")]
        public long MobileNumber { get; set; }

        [Required(ErrorMessage = "Enter Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Enter Town")]
        public string Town { get; set; }

        [Required(ErrorMessage = "Enter Pin code")]
        public int PINCode { get; set; }

        public AddressPage()
        {

        }
        
    }
}
