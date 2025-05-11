using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Domain.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Domain.Data.Context.BankDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Data\Migrations";
        }

        protected override void Seed(Domain.Data.Context.BankDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
