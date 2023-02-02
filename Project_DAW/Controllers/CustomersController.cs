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

        [HttpPut("update-customer")]
        [Authorization(Role.Admin, Role.Customer)]
        public async Task<IActionResult> UpdateCustomer(CustomerDTO _customer, Guid customerId)
        {
            var updcustomer = await this._customerService.Update(customerId, _customer);
            if (updcustomer == null)
                return NotFound();  
            return Ok( updcustomer);

        }

        [HttpGet("getAll-customer")]
        [Authorization (Role.Admin, Role.Customer)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await this._customerService.GetAll());
        }

        [HttpDelete("delete-customer")]
        [Authorization(Role.Admin)]
        public async Task<IActionResult> DeleteCustomer(Guid id)
        {
            await _customerService.Delete(id);
            return Ok();
        }

        [HttpPost("create-admin")]

        public async Task<IActionResult> CreateAdmin(CustomerRequestDTO customer)
        {
            await _customerService.CreateAdm(customer);
            return Ok();
        }

        [HttpPost("create-customer")]

        public async Task<IActionResult> CreateCustomer(CustomerRequestDTO customer)
        {
            await _customerService.CreateCus(customer);
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
