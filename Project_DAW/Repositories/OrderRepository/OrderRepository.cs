using Microsoft.EntityFrameworkCore;
using Project_DAW.Data;
using Project_DAW.Models;
using Project_DAW.Repositories.GenericRepository;

namespace Project_DAW.Repositories.OrderRepository
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(DataBaseContext dataBaseContext) : base(dataBaseContext)
        {

        }
        public async Task<List<Order>> GetAllOrdersAndProducts()
        {
            var order = _table.Include(x => x.OrdersProducts).ThenInclude(x => x.Product).ToListAsync();
            return await order;
        }
    }
}
