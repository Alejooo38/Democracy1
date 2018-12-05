using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Democracy1.Models
{
    /// <summary>
    /// Para relacionar tablas en Vb me ubico en la tabla muchos
    /// es decir en vouting de claro una propiedad virtual la propiedad
    /// la llamo igual a la tabla del lado uno es decir State
    /// Es decir una votacion tiene un estado.. Despues defino en 
    /// el lado uno tambnien.
    /// </summary>
    public class Vouting
    {
        [Key]
        [Display(Name = "State Description")]
        [Required(ErrorMessage = "The field {0}")]
        public int VoutingId { get; set; }

        [Required(ErrorMessage = "The field {0}")]
        [StringLength(50, ErrorMessage =
          "The flied {0} could contain maximun {1} and minumum" +
            "{2} characters", MinimumLength = 3)]
        [Display(Name = "Vouting Description")]
        public string Description { get; set; }
        
        [Display (Name = "State")]
        public int StateId { get; set; }

        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "The field {0}")]
        public string Remarks { get; set; }
        
        [Required(ErrorMessage = "The field {0}")]
        [Display(Name = "Bigin Date")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh:mm tt}", 
            ApplyFormatInEditMode = true)]
        public DateTime DateTimeStart { get; set; }
        
        [Required(ErrorMessage = "The field {0}")]
        [Display(Name = "End Date")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh:mm tt}",
            ApplyFormatInEditMode = true)]
        public DateTime DateTimeEnd { get; set; }
        
        [Required(ErrorMessage = "The field {0}")]
        [Display(Name = "Everyone is enable")]

        public bool IsForAllUser { get; set; }
        
        [Required(ErrorMessage = "The field {0}")]
        [Display(Name = "Blank Vote is enable")]
        public bool IsEnableBlankVote { get; set; }
       
        [Display(Name = "Quantity Votes")]
        public int QuantityVotes { get; set; }

        [Display(Name = "Quantity Empy Votes")]
        public int QuantityBlankVotes { get; set; }

        [Display(Name = "Winner")]
        public int CandidateWinId { get; set; }

        
        public virtual State State { get; set; }

    }
}