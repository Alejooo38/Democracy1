using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Democracy1.Models
{
    public class Candidate
    {
        [Key]
        public int CandidateId { get; set; }

        public int VoutingId { get; set; }

        public int UserId { get; set; }

        public int QuantityVotes { get; set; }

        public virtual Vouting Vouting { get; set; }

        public virtual User User { get; set; }
    }
}