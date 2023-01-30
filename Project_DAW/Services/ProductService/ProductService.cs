using Project_DAW.Models.DTOs;
using Project_DAW.Models;
using Project_DAW.Repositories.OrderRepository;
using Project_DAW.Repositories.ProductRepository;

namespace Project_DAW.Services.ProductService
{
    public class ProductService : IProductService
    {
        public IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task Create(Product product)
        {
            await _productRepository.CreateAsync(product);
            await _productRepository.SaveAsync();
        }
        public async Task Delete(Guid id)
        {
            var product = await _productRepository.FindByIdAsync(id);
            _productRepository.Delete(product);
            await _productRepository.SaveAsync();
        }
        public async Task<List<Product>> GetAll()
        {
            return await _productRepository.GetAll();
        }
        public async Task<Product> GetById(Guid id)
        {
            return await _productRepository.FindByIdAsync(id);
        }
        public async Task<Product?> Update(Guid id, ProductDTO product)
        {
            var p = await _productRepository.FindByIdAsync(id);
            if(p == null)
                return null;

            p.Price = (double)product.Price;
            p.ProductName = p.ProductName;
            p.Brand = p.Brand;
            p.Description = p.Description;

            await _productRepository.SaveAsync();
            return p;

        }
    }
}
