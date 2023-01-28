using Project_DAW.Models;
using Project_DAW.Models.DTOs;

namespace Project_DAW.Services.CustomerService
{
    public interface ICustomerService
    {
        Task Create(Customer customer);
        Task Delete(Guid id);
        Task<List<Customer>> GetAll();
        Task<Customer> GetById(Guid id);
        Task<Customer> Update(Guid id, CustomerDTO customer);
    }
}
