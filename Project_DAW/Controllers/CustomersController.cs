using Microsoft.AspNetCore.Mvc;
using Project_DAW.Models;
using Project_DAW.Models.DTOs;
using Project_DAW.Services.CustomerService;

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

        public async Task<IActionResult> UpdateCustomer(CustomerDTO _customer, Guid customerId)
        {
            var updcustomer = await this._customerService.Update(customerId, _customer);
            if (updcustomer == null)
                return NotFound();  
            return Ok( updcustomer);

        }

        [HttpGet]

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
    }
}
