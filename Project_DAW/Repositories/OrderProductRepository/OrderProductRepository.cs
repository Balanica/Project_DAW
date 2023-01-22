using Project_DAW.Data;
using Project_DAW.Models;
using Project_DAW.Repositories.GenericRepository;

namespace Project_DAW.Repositories.OrderProductRepository
{
    public class OrderProductRepository : GenericRepository<OrderProduct>, IOrderProductRepository
    {
        public OrderProductRepository(DataBaseContext dataBaseContext) : base(dataBaseContext)
        {

        }
    }
}
