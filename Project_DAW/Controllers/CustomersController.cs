using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project_DAW.Models;
using Project_DAW.Models.DTOs;
using Project_DAW.Services.CustomerService;
using Project_DAW.Helpers.Attributes;
using Project_DAW.Models.Roles;
using BCrypt.Net;

namespace Project_DAW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        public readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public static List<Customer> customers = new List<Customer>
        {
            new Customer{ FirstName = "Bob", LastName = "c"}
        };

        /*[HttpGet]

        public List<Customer> Get()
        {
            return customers;
        }*/

        [HttpPost]
        public async Task<IActionResult> AddCustomer(CustomerDTO newCustomer)
        {
            await this._customerService.Create(newCustomer);
            return Ok();
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateCustomer(CustomerDTO _customer, Guid customerId)
        {
            var updcustomer = await this._customerService.Update(customerId, _customer);
            if (updcustomer == null)
                return NotFound();  
            return Ok( updcustomer);

        }

        [HttpGet]
        [Authorization (Role.Admin, Role.Customer)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await this._customerService.GetAll());
        }

        [HttpDelete]

        public async Task<IActionResult> DeleteCustomer(Guid id)
        {
            await _customerService.Delete(id);
            return Ok();
        }

        [HttpPost("create-customer")]

        public async Task<IActionResult> CreateCustomer(CustomerRequestDTO customer)
        {
            await _customerService.CreateAut(customer);
            return Ok();
        }

        [HttpPost("login-customer")]
        public IActionResult Login(CustomerRequestDTO customer)
        {
            var res =  _customerService.Authentificate(customer);
            if(res == null)
            {
                return BadRequest("Invalid Authentification attempt!");
            }
            return Ok(res.Token);
        }
    }
}
