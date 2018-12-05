using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Democracy1.Models
{
    /// <summary>
    /// Para que se genere la relacion con el lado varios de la relacion
    /// se debe declarar una propiedad virtual de tipo Icolletion del 
    /// tipo del lado varios de la relacion es decir Vouting
    /// </summary>
    public class State
    {
        [Key]
        public int StateId { get; set; }

        /// <summary>
        /// cuando se usa el parametro {0} en un Required nos 
        /// toma el valor del campo.
        /// </summary>
        [Required(ErrorMessage = "The field {0}")]
        [StringLength(50, ErrorMessage = 
            "The flied {0} could contain maximun {1} and minumum {2} characters", MinimumLength = 3)]
        [Display(Name = "State Description")]
        public string Description { get; set; }

        public virtual ICollection<Vouting> Voutings  { get; set; }
    }
}