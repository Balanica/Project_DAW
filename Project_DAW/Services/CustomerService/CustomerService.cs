using AutoMapper;
using Project_DAW.Helpers.JwtToken;
using Project_DAW.Helpers.JwtUtils;
using Project_DAW.Models;
using Project_DAW.Models.DTOs;
using Project_DAW.Models.Roles;
using Project_DAW.Repositories.CustomerRepository;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Project_DAW.Services.CustomerService
{
    public class CustomerService : ICustomerService
    {
        public ICustomerRepository _customerRepository;
        public IMapper _mapper;
        public IJwtUtils _jwtUtils;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper, IJwtUtils jwtUtils)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
            _jwtUtils = jwtUtils;
        }

        public async Task Create(CustomerDTO newcustomer)
        {
            var customer = _mapper.Map<Customer>(newcustomer);
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

        public async Task<Customer?> Update(Guid id, CustomerDTO customer)
        {
            var c = await _customerRepository.FindByIdAsync(id);

            if (c == null)
                return null;

            c.Phone = customer.Phone;
            c.LastName = customer.LastName;
            c.FirstName = customer.FirstName;
            c.Email = customer.Email;
            c.Address = customer.Address;

            await _customerRepository.SaveAsync();
            
            return c;

        }
        public CustomerResponseDTO? Authentificate(CustomerRequestDTO customer)
        {
            var _customer = _customerRepository.GetCustomerByEmail(customer.Email);
            if(_customer == null || !BCrypt.Net.BCrypt.Verify(customer.Password, _customer.PasswordHash))
            {
                return null;
            }
            var jwtToken = _jwtUtils.GenerateJwtToken(_customer);
            return new CustomerResponseDTO(_customer, jwtToken);
        }

        /*public CustomerRequestDTO GetByIdRequest(Guid id)
        {
            throw new NotImplementedException();
        }*/

        public async Task CreateAut(CustomerRequestDTO customer)
        {
            var newCustomer = _mapper.Map<Customer>(customer);
            newCustomer.PasswordHash = BCrypt.Net.BCrypt.HashPassword(customer.Password);
            newCustomer.Role = Role.Admin;

            await _customerRepository.CreateAsync(newCustomer);
            await _customerRepository.SaveAsync();
        }


    }
}
