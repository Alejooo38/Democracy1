using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Democracy1.Models
{
    public class VoutingView
    {
        public int VoutingId { get; set; }

        [Required(ErrorMessage = "The field {0}")]
        [StringLength(50, ErrorMessage =
          "The flied {0} could contain maximun {1} and minumum" +
            "{2} characters", MinimumLength = 3)]
        [Display(Name = "Vouting Description")]
        public string Description { get; set; }

        [Display(Name = "State")]
        public int StateId { get; set; }

        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "The field {0}")]
        public string Remarks { get; set; }

        [Required(ErrorMessage = "The field {0}")]
        [Display(Name = "Bigin Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
            ApplyFormatInEditMode = true)]
        public DateTime DateStart { get; set; }

        [Required(ErrorMessage = "The field {0}")]
        [Display(Name = "Bigen Hour")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0: hh:mm tt}",
            ApplyFormatInEditMode = true)]
        public DateTime TimeStart { get; set; }

        [Required(ErrorMessage = "The field {0}")]
        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
            ApplyFormatInEditMode = true)]
        public DateTime DateEnd { get; set; }

        [Required(ErrorMessage = "The field {0}")]
        [Display(Name = "Hour End")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0: hh:mm tt}",
            ApplyFormatInEditMode = true)]
        public DateTime TimeEnd { get; set; }

        [Required(ErrorMessage = "The field {0}")]
        [Display(Name = "Everyone is enable")]

        public bool IsForAllUser { get; set; }

        [Required(ErrorMessage = "The field {0}")]
        [Display(Name = "Blank Vote is enable")]
        public bool IsEnableBlankVote { get; set; }

        [Display(Name = "Quantity Votes")]
        public int QuantityVotes { get; set; }
    }
}