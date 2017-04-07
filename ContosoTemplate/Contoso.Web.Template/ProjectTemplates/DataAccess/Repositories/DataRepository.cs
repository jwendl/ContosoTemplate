using $safeprojectname$.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace $safeprojectname$.Repositories
{
    public class DataRepository<TEntity>
        : IDataRepository<TEntity>
        where TEntity : class
    {
        private IDataContext DataContext { get; set; }
        
        public DataRepository(IDataContext dataContext)
        {
            DataContext = dataContext;
        }

        public async Task<ICollection<TEntity>> FetchAllAsync()
        {
            return await DataContext.Set<TEntity>().ToListAsync();
        }

        public async Task AddItemAsync(TEntity entity)
        {
            DataContext.Set<TEntity>().Add(entity);
            await DataContext.SaveChangesAsync();
        }
    }
}
