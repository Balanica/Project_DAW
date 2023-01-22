using Project_DAW.Data;
using Project_DAW.Models;
using Project_DAW.Repositories.GenericRepository;

namespace Project_DAW.Repositories.CustomerRepository
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(DataBaseContext dataBaseContext) : base(dataBaseContext)
        {

        }
    }
}
