using Project_DAW.Models;
using Project_DAW.Repositories.GenericRepository;

namespace Project_DAW.Repositories.CustomerRepository
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        public Task<List<Customer>> GetCustomerOrders();
        public Guid GetCustomerId(string firstname, string lastname);
    }
}
