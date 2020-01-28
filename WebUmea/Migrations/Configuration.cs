namespace WebUmea.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebUmea.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebUmea.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebUmea.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            //context.Roles.AddOrUpdate(r => r.Name,
            //    new IdentityRole { Name = "Admin"},
            //    new IdentityRole { Name = "Editor" },
            //    new IdentityRole { Name = "Contributor" },
            //    new IdentityRole { Name = "UserPrime" },
            //    new IdentityRole { Name = "UserPremium" },
            //    new IdentityRole { Name = "UserPlatinum" }
            //    );

        }
    }
}
