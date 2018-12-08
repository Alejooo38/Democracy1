using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Democracy1.Models
{
    public class Group
    {
           [Key]
            public int GroupId { get; set; }

            /// <summary>
            /// cuando se usa el parametro {0} en un Required nos 
            /// toma el valor del campo.
            /// </summary>
            [Required(ErrorMessage = "The field {0}")]
            [StringLength(50, ErrorMessage =
                "The flied {0} could contain maximun {1} and minumum {2} characters", MinimumLength = 3)]
            public string Description { get; set; }

            public virtual ICollection<GroupMember> GroupMembers{ get; set; }

        public virtual ICollection<VoutingGroup> VoutingGroups { get; set; }
    }
    }
