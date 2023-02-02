using Project_DAW.Data;
using Project_DAW.Models;
using Project_DAW.Repositories.GenericRepository;

namespace Project_DAW.Repositories.ProductRepository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(DataBaseContext dataBaseContext) : base(dataBaseContext)
        {

        }

        public List<Product> GetByBrand(string brand)
        {
            var products = _table.Where(x => x.Brand == brand).ToList();
            return products;
        }

        public Product GetProductByProductName(string name)
        {
            return _table.FirstOrDefault(x => x.ProductName == name);
        }
    }
}
