using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Democracy1.Models
{
    public class VoutingGroup
    {
        [Key]
        public int VoutingGroupId { get; set; }

        public int VoutingId { get; set; }

        public int GroupId { get; set; }

        public virtual Vouting Vouting { get; set; }

        public virtual Group Group { get; set; }
    }
}