using Project_DAW.Data;
using Project_DAW.Models;
using Project_DAW.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace Project_DAW.Repositories.CustomerRepository
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(DataBaseContext dataBaseContext) : base(dataBaseContext)
        {

        }


        public async Task<List<Customer>> GetCustomerOrders()
        {
            var customer =  _table.Join(_dataBaseContext.Orders, customer => customer.Id, order => order.CustomerID,
                (customer, order) => new { customer, order }).Select(obj => obj.customer);
            return customer.ToList();
        }
        public Guid GetCustomerId(string firstname, string lastname)
        {
            var customer = _table.FirstOrDefault(x => x.FirstName == firstname && x.LastName == lastname);
            return customer == null ? Guid.Empty : customer.Id;
        }

    }
}
