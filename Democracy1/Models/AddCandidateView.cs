using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Democracy1.Models
{
    public class AddCandidateView
    {
        public int VoutingId { get; set; }

        [Required(ErrorMessage = "You must select an user....")]
        public int UserId { get; set; }

    }
}