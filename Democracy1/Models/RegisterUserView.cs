using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Democracy1.Models
{
    public class RegisterUserView : UserView
    {

        [Display(Name = "E-Password")]
        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(20, ErrorMessage =
         "The flied {0} could contain maximun {1} and minumum" +
           "{2} characters", MinimumLength = 8)]
        [DataType(DataType.Password)]      
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(20, ErrorMessage =
        "The flied {0} could contain maximun {1} and minumum" +
          "{2} characters", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and confirm doesn't match")]
        public string ConfirmPassword { get; set; }
    }
}