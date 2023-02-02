using Project_DAW.Models;
using Project_DAW.Models.DTOs;
using Project_DAW.Repositories.GenericRepository;

namespace Project_DAW.Services.CustomerService
{
    public interface ICustomerService 
    {
        Task Create(CustomerDTO customer);
        Task Delete(Guid id);
        Task<List<Customer>> GetAll();
        Task<Customer> GetById(Guid id);
        Task<Customer?> Update(Guid id, CustomerDTO customer);

        CustomerResponseDTO? Authentificate(CustomerRequestDTO customer);
        /*CustomerRequestDTO GetByIdRequest(Guid id);*/
        Task CreateAut(CustomerRequestDTO Customer);
    }
}
