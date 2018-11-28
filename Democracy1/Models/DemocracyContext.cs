using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Democracy1.Models
{
    public class DemocracyContext : DbContext
    {
        public DemocracyContext()
            : base("DefaultConnection")
        {    
        }
        public DbSet<State> States { get; set; }
    }
}