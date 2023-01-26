using Project_DAW.Models;
using Project_DAW.Repositories.GenericRepository;

namespace Project_DAW.Repositories.OrderRepository
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        public Task<List<Order>> GetAllOrdersAndProducts();
    }
}
