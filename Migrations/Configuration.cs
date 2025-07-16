namespace TaskManagement.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TaskManagement.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TaskManagement.Data.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            context.Tasks.AddOrUpdate(
        t => t.Title,
        new Models.Task { Title = "Development", Description = "Develop a module", DueDate = DateTime.Today.AddDays(1) },
        new Models.Task { Title = "Test", Description = "Test the module", DueDate = DateTime.Today.AddDays(3) },
        new Models.Task { Title = "Error Correction", Description = "", DueDate = null }
    );
        }
    }
}
