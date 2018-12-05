using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Democracy1.Models
{
    public class AddMemberView
    {
        public int GroupId { get; set; }


        [Required(ErrorMessage = "You should select a user")]
        public int UserId { get; set; }
    }
}