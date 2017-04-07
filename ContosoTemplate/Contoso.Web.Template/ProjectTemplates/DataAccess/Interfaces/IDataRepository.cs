using System.Collections.Generic;
using System.Threading.Tasks;

namespace $safeprojectname$.Interfaces
{
    public interface IDataRepository<TEntity>
        where TEntity : class
    {
        Task<ICollection<TEntity>> FetchAllAsync();

        Task AddItemAsync(TEntity entity);
    }
}
