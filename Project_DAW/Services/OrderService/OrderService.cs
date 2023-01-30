using Project_DAW.Models.DTOs;
using Project_DAW.Models;
using Project_DAW.Repositories.CustomerRepository;
using Project_DAW.Repositories.OrderRepository;

namespace Project_DAW.Services.OrderService
{
    public class OrderService : IOrderService
    {
        public IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task Create(Order order)
        {
            await _orderRepository.CreateAsync(order);
            await _orderRepository.SaveAsync();
        }
        public async Task Delete(Guid id)
        {
            var order = await _orderRepository.FindByIdAsync(id);
            _orderRepository.Delete(order);
            await _orderRepository.SaveAsync();
        }
        public async Task<List<Order>> GetAll()
        {
            return await _orderRepository.GetAll();
        }
        public async Task<Order> GetById(Guid id)
        {
            return await _orderRepository.FindByIdAsync(id);
        }
        public async Task<Order?> Update(Guid id, OrderDTO order)
        {
            var ord = await _orderRepository.FindByIdAsync(id);

            if (ord == null)
                return null;

            ord.PaymentMethod = order.PaymentMethod;
            ord.ShippingAddress = order.ShippingAdress;
            ord.BillingAddress = order.BillingAdress;
            ord.TotalCost = order.TotalCost;

            await _orderRepository.SaveAsync();
            return ord;
        }
    }
}
