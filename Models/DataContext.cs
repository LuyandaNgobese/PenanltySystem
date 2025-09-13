using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;

namespace PenanltySystem.Models
{
    public class DataContext: DbContext
    {
        public DataContext(): base("ViolateDB")
        {
        }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Violation> Violations { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<EstatePenalty> EstatePenalties { get; set; }
    }
}