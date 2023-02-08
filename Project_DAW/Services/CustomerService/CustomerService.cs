using AutoMapper;
using Project_DAW.Helpers.JwtToken;
using Project_DAW.Models;
using Project_DAW.Models.DTOs;
using Project_DAW.Models.Roles;
using Project_DAW.Repositories.UnitOfWork;

namespace Project_DAW.Services.CustomerService
{
    public class CustomerService : ICustomerService
    {
        //public ICustomerRepository _customerRepository;
        public IMapper _mapper;
        public IJwtUtils _jwtUtils;
        public IUnitOfWork _unitOfWork;

        public CustomerService(IMapper mapper, IJwtUtils jwtUtils, IUnitOfWork unitOfWork)
        {
            //_customerRepository = customerRepository;
            _mapper = mapper;
            _jwtUtils = jwtUtils;
            _unitOfWork = unitOfWork;

        }

        public async Task Create(CustomerDTO newcustomer)
        {
            var customer = _mapper.Map<Customer>(newcustomer);
            await _unitOfWork.customerRepository.CreateAsync(customer);
            await _unitOfWork.customerRepository.SaveAsync();
        }

        public async Task Delete(Guid id)
        {
            var customer = await _unitOfWork.customerRepository.FindByIdAsync(id);
            _unitOfWork.customerRepository.Delete(customer);
            await _unitOfWork.customerRepository.SaveAsync();
        }
        public Task<List<Customer>> GetAll()
        {
            return _unitOfWork.customerRepository.GetAll();
        }
        public async Task<Customer> GetById(Guid id)
        {
            return await _unitOfWork.customerRepository.FindByIdAsync(id);
        }

        public async Task<Customer?> Update(Guid id, CustomerDTO customer)
        {
            var c = await _unitOfWork.customerRepository.FindByIdAsync(id);

            if (c == null)
                return null;

            c.Phone = customer.Phone;
            c.LastName = customer.LastName;
            c.FirstName = customer.FirstName;
            c.Email = customer.Email;
            c.Address = customer.Address;

            await _unitOfWork.customerRepository.SaveAsync();

            return c;

        }
        public CustomerResponseDTO? Authentificate(CustomerRequestDTO customer)
        {
            var _customer = _unitOfWork.customerRepository.GetCustomerByEmail(customer.Email);
            if (_customer == null || !BCrypt.Net.BCrypt.Verify(customer.Password, _customer.PasswordHash))
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

        public async Task CreateAdm(CustomerRequestDTO customer)
        {
            var newCustomer = _mapper.Map<Customer>(customer);
            newCustomer.PasswordHash = BCrypt.Net.BCrypt.HashPassword(customer.Password);
            newCustomer.Role = Role.Admin;

            await _unitOfWork.customerRepository.CreateAsync(newCustomer);
            await _unitOfWork.customerRepository.SaveAsync();
        }

        public async Task CreateCus(CustomerRequestDTO customer)
        {
            var newCustomer = _mapper.Map<Customer>(customer);
            newCustomer.PasswordHash = BCrypt.Net.BCrypt.HashPassword(customer.Password);
            newCustomer.Role = Role.Customer;

            await _unitOfWork.customerRepository.CreateAsync(newCustomer);
            await _unitOfWork.customerRepository.SaveAsync();
        }


    }
}
