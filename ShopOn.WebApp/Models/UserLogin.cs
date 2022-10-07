using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOn.WebApp.Models
{
    public class UserLogin
    {
        [Display(Name="Enter email-ID")]
        [Required(ErrorMessage ="email cannot be empty")]
        public string LoginId { get; set; }

        [Display(Name = "Enter password")]
        [Required(ErrorMessage = "password cannot be empty")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
