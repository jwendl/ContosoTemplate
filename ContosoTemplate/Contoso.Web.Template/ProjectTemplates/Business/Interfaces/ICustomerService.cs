using $safeprojectname$.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace $safeprojectname$.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerNameListItem>> FetchCustomerNamesAsync();

        Task AddItemsAsync(IEnumerable<CustomerItem> customerItems);
    }
}
