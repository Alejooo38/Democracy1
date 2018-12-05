using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Democracy1.Models
{

    /// <summary>
    /// Cuando se requiere usar una clave unica adicional a la primaria
    /// se puede usar el dataanotation 
    /// System.ComponentModel.DataAnnotations.Schema; en el evento 
    /// Index("UserNameIndex", IsUnique = true)
    /// </summary>
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Display(Name = "E-Mail")]
        [Required(ErrorMessage = "The field {0}")]
        [StringLength(100, ErrorMessage =
          "The flied {0} could contain maximun {1} and minumum" +
            "{2} characters", MinimumLength = 7)]
        [DataType(DataType.EmailAddress)]
        [Index("UserNameIndex", IsUnique = true)]
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

        //Se crea una propiedad de solo lectura. es decir con solo
        //get para concatenar nombre y apellido

        [Display(Name = "User")]
        public string  FullName { get { return string.Format("{0} {1}", this.FirstName, this.LastName); }}

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

        [StringLength(200, ErrorMessage =
          "The flied {0} could contain maximun {1} and minumum" +
            "{2} characters", MinimumLength = 5)]
        [DataType(DataType.ImageUrl)]
        public string Photo { get; set; }

        public virtual ICollection<GroupMember> GroupMembers { get; set; }
    }
}