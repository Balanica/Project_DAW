using Microsoft.Data.SqlClient;
using Project_DAW.Data;
using Project_DAW.Repositories.CustomerRepository;
using Project_DAW.Repositories.Inventory;
using Project_DAW.Repositories.OrderProductRepository;
using Project_DAW.Repositories.OrderRepository;
using Project_DAW.Repositories.ProductRepository;
using System.Data;

namespace Project_DAW.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICustomerRepository customerRepository { get; set; }
        public IOrderRepository orderRepository { get; set; }
        public IOrderProductRepository orderProductRepository { get; set; }
        public IProductRepository productRepository { get; set; }
        public IStockRepository stockRepository { get; set; }
        private DataBaseContext DbContext { get; set; }
        public UnitOfWork(ICustomerRepository customerRepository, IOrderRepository orderRepository, IOrderProductRepository orderProductRepository, IProductRepository productRepository, IStockRepository stockRepository, DataBaseContext dbContext)
        {
            this.customerRepository = customerRepository;
            this.orderRepository = orderRepository;
            this.orderProductRepository = orderProductRepository;
            this.productRepository = productRepository;
            this.stockRepository = stockRepository;
            this.DbContext = dbContext;
        }

        public async Task<bool> SaveAsync()
        {
            try
            {
                return await DbContext.SaveChangesAsync() > 0;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }
    }
}
