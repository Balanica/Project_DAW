using Project_DAW.Models;
using Project_DAW.Models.DTOs;
using Project_DAW.Repositories.CustomerRepository;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Project_DAW.Services.CustomerService
{
    public class CustomerService : ICustomerService
    {
        public ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task Create(Customer customer)
        {
            await _customerRepository.CreateAsync(customer);
            await _customerRepository.SaveAsync();
        }

        public async Task Delete(Guid id)
        {
            var customer = await _customerRepository.FindByIdAsync(id);
            _customerRepository.Delete(customer);
            await _customerRepository.SaveAsync();
        }
        public Task<List<Customer>> GetAll()
        {
            return _customerRepository.GetAll();
        }
        public async Task<Customer> GetById(Guid id)
        {
            return await _customerRepository.FindByIdAsync(id);
        }
        public async Task<Customer> Update(Guid id, CustomerDTO customer)
        {
            var c = await _customerRepository.FindByIdAsync(id);

            if (c == null)
                return null;

            c.Phone = customer.Phone;
            c.LastName = customer.LastName;
            c.FirstName = customer.FirstName;
            c.Email = customer.Email;
            c.Address = customer.Address;
            
            return c;

        }

    }
}
