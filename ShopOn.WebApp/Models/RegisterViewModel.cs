using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOn.WebApp.Models
{
    public class RegisterViewModel
    {
        [Display(Name ="Enter email-id")]
        [Required(ErrorMessage ="email cannot be empty")]
        [EmailAddress]
        public string LoginId { get; set; }

        [Display(Name = "Enter password")]
        [Required(ErrorMessage = "password cannot be empty")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Re-enter password")]
        [Required(ErrorMessage = "password cannot be empty")]
        [Compare("Password",ErrorMessage ="Passwords should match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
