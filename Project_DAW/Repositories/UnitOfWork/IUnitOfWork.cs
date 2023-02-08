using Project_DAW.Repositories.CustomerRepository;
using Project_DAW.Repositories.Inventory;
using Project_DAW.Repositories.OrderProductRepository;
using Project_DAW.Repositories.OrderRepository;
using Project_DAW.Repositories.ProductRepository;

namespace Project_DAW.Repositories.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task<bool> SaveAsync();
        ICustomerRepository customerRepository { get; }
        IOrderRepository orderRepository { get; }
        IOrderProductRepository orderProductRepository { get; }
        IProductRepository productRepository { get; }
        IStockRepository stockRepository { get; }

    }
}
