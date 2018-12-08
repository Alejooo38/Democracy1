using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
        public DbSet<State> States { get; set; }

        public DbSet<Group> Groups { get; set; }

        public DbSet<Vouting> Voutings { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<GroupMember> GroupMembers { get; set; }

        public DbSet<VoutingGroup> VoutingGroups { get; set; }

        public DbSet<Candidate> Candidates { get; set; }
    }
}