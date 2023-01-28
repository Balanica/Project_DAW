using Project_DAW.Models.DTOs;
using Project_DAW.Models;

namespace Project_DAW.Services.ProductService
{
    public interface IProductService
    {
        Task Create(Product product);
        Task Delete(Guid id);
        Task<List<Product>> GetAll();
        Task<Product> GetById(Guid id);
        Task<Product?> Update(Guid id, ProductDTO product);
    }
}
