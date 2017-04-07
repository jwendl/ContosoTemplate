using AutoMapper;
using $safeprojectname$.Interfaces;
using $safeprojectname$.Models;
using $rootprojectname$.Data.Interfaces;
using $rootprojectname$.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace $safeprojectname$.Services
{
    public class CustomerService
        : ICustomerService
    {
        private IMapper MapperInstance { get; set; }
        private IDataRepository<Customer> CustomerRepository { get; set; }

        public CustomerService(IMapper mapper, IDataRepository<Customer> customerRepository)
        {
            MapperInstance = mapper;
            CustomerRepository = customerRepository;
        }

        public async Task<IEnumerable<CustomerNameListItem>> FetchCustomerNamesAsync()
        {
            var customerItems = await CustomerRepository.FetchAllAsync();
            return MapperInstance.Map<ICollection<Customer>, ICollection<CustomerNameListItem>>(customerItems);
        }

        public async Task AddItemsAsync(IEnumerable<CustomerItem> customerItems)
        {
            foreach (var customerItem in customerItems)
            {
                var customer = MapperInstance.Map<CustomerItem, Customer>(customerItem);
                await CustomerRepository.AddItemAsync(customer);
            }
        }
    }
}
