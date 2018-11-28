﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Democracy1.Models
{
    public class State
    {
        [Key]
        public int StateId { get; set; }

        public string Description { get; set; }
    }
}