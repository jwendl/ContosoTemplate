using $safeprojectname$.Models;
using System.Data.Entity;
using System.Threading.Tasks;

namespace $safeprojectname$.Interfaces
{
    public interface IDataContext
    {
        DbSet<TEntity> Set<TEntity>()
            where TEntity : class;

        Task<int> SaveChangesAsync();

        IDbSet<Customer> Customers { get; set; }
    }
}
