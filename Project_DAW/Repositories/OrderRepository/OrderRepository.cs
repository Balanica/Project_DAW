using Microsoft.EntityFrameworkCore;
using Project_DAW.Data;
using Project_DAW.Models;
using Project_DAW.Models.DTOs;
using Project_DAW.Repositories.GenericRepository;
using System.Linq;

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

        public IQueryable<PaymentDTO> GetOrdersByPaymentMethod()
        {
            var orders = from order in _table
                         group order by order.PaymentMethod into ceva
                         select new PaymentDTO
                         {
                             PaymentMethod = ceva.Key,
                             Number = ceva.Count()
                         };
            return orders;

        }
    }
}
