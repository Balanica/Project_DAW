using Project_DAW.Models;
using Project_DAW.Repositories.GenericRepository;

namespace Project_DAW.Repositories.ProductRepository
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        public Product GetProductByProductName(string name);
    }
}
