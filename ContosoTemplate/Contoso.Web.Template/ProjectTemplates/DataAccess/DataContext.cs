using $safeprojectname$.Interfaces;
using $safeprojectname$.Models;
using System.Data.Entity;

namespace $safeprojectname$
{
    public class DataContext
        : DbContext, IDataContext
    {
        public IDbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .Property(c => c.FirstName)
                .HasMaxLength(64);

            modelBuilder.Entity<Customer>()
                .Property(c => c.LastName)
                .HasMaxLength(128);
                
            base.OnModelCreating(modelBuilder);
        }
    }
}
