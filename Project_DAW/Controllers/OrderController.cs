using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_DAW.Helpers.Attributes;
using Project_DAW.Models.DTOs;
using Project_DAW.Models.Roles;
using Project_DAW.Services.CustomerService;
using Project_DAW.Services.OrderService;

namespace Project_DAW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        public readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPut("update-order")]
        [Authorization(Role.Admin, Role.Customer)]
        public async Task<IActionResult> UpdateProduct(OrderDTO _order, Guid orderId)
        {
            var order = await this._orderService.Update(orderId, _order);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpGet("getAll-orders")]
        [Authorization(Role.Admin, Role.Customer)]
        public async Task<IActionResult> GetAllOrders()
        {
            return Ok(await this._orderService.GetAll());
        }

        [HttpPost("add-order")]
        //[Authorization(Role.Admin, Role.Customer)]
        public async Task<IActionResult> AddProduct(OrderDTO order)
        {
            await this._orderService.Create(order);
            return Ok(order);
        }

        [HttpDelete("delete-order")]
        [Authorization(Role.Admin, Role.Customer)]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            await this._orderService.Delete(id);
            return Ok("Order has been deleted!");
        }

        [HttpGet("get-paymentmethods-and-count")]
        public async Task<IActionResult> GetPaymentMethods()
        {
            var payment = this._orderService.GetAllPayment();
            return Ok(payment);
        }

    }
}
