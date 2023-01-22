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
    }
}
