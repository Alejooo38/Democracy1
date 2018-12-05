using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Democracy1.Models
{
    public class UserView
    {
        public int UserId { get; set; }

        [Display(Name = "E-Mail")]
        [Required(ErrorMessage = "The field {0}")]
        [StringLength(100, ErrorMessage =
         "The flied {0} could contain maximun {1} and minumum" +
           "{2} characters", MinimumLength = 7)]
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "The field {0}")]
        [StringLength(50, ErrorMessage =
          "The flied {0} could contain maximun {1} and minumum" +
            "{2} characters", MinimumLength = 2)]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "The field {0}")]
        [StringLength(50, ErrorMessage =
          "The flied {0} could contain maximun {1} and minumum" +
            "{2} characters", MinimumLength = 2)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "The field {0}")]
        [StringLength(20, ErrorMessage =
          "The flied {0} could contain maximun {1} and minumum" +
            "{2} characters", MinimumLength = 7)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "The field {0}")]
        [StringLength(100, ErrorMessage =
          "The flied {0} could contain maximun {1} and minumum" +
            "{2} characters", MinimumLength = 10)]
        public string Address { get; set; }

        public string Grade { get; set; }

        public string Group { get; set; }
        
        public HttpPostedFileBase Photo { get; set; }
    }
}