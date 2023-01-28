using Project_DAW.Models.DTOs;
using Project_DAW.Models;

namespace Project_DAW.Services.OrderService
{
    public interface IOrderService
    {
        Task Create(Order order);
        Task Delete(Guid id);
        Task<List<Order>> GetAll();
        Task<Order> GetById(Guid id);
        Task<Order?> Update(Guid id, OrderDTO order);
    }
}
