using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Democracy1.Models
{
    public class AddGroupView
        {   
            public int VoutingId { get; set; }


            [Required(ErrorMessage = "You should select a group")]
            public int GroupId { get; set; }
        }
}
