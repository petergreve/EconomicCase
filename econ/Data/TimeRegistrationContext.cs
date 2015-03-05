using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace econ.Data
{
    public class TimeRegistrationContext : DbContext
    {
        public TimeRegistrationContext() : base("DefaultConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;

            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<TimeRegistrationContext, TimeRegistrationMigrationConfiguration>()
                );
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Registration> Registrations { get; set; }

    }
}