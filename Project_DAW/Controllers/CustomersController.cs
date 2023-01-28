using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_DAW.Models;

namespace Project_DAW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        public static List<Customer> customers = new List<Customer>
        {
            new Customer{ FirstName = "Bob", LastName = "c"}
        };

        [HttpGet]

        public List<Customer> Get()
        {
            return customers;
        }
    }
}
