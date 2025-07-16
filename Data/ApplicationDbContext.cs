using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TaskManagement.Models;

namespace TaskManagement.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<
                    ApplicationDbContext,
                    Migrations.Configuration>());
        }

        public DbSet<Task> Tasks { get; set; }
    }
}