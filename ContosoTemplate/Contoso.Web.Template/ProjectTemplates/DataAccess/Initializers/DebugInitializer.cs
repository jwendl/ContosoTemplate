using $safeprojectname$.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace $safeprojectname$.Initializers
{
    public class DebugInitializer
        : DropCreateDatabaseAlways<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            context.Customers.AddOrUpdate(new Customer()
            {
                Id = 1,
                FirstName = "Bob",
                LastName = "Smith",
                BirthDate = DateTime.Now.AddYears(-24).AddDays(-15),
            });

            context.Customers.AddOrUpdate(new Customer()
            {
                Id = 2,
                FirstName = "Jane",
                LastName = "Smith",
                BirthDate = DateTime.Now.AddYears(-22).AddDays(-12),
            });

            context.SaveChanges();
            base.Seed(context);
        }
    }
}
