using System.Collections.Generic;
using Awesome.Models.DB;

namespace Awesome.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Awesome.Models.DB.DataModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Awesome.Models.DB.DataModel context)
        {
            //context.Users.AddOrUpdate(
            //new User
            //{
            //    FirstName = "Joakim",
            //    LastName = "Wågström",
            //    LoginName = "Jollebrunjor",
            //    Password = "Password1",
            //    Roles = new List<Role>()
            //       {
            //            new Role()
            //            {
            //                RoleId = 1,
            //                Rolename = "Admin"
            //            }
            //       }
            //});
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
