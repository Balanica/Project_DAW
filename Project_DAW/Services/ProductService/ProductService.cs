using Project_DAW.Models.DTOs;
using Project_DAW.Models;
using Project_DAW.Repositories.OrderRepository;
using Project_DAW.Repositories.ProductRepository;
using AutoMapper;
using Project_DAW.Helpers;
using Project_DAW.Repositories.UnitOfWork;

namespace Project_DAW.Services.ProductService
{
    public class ProductService : IProductService
    {
        //public IProductRepository _productRepository;
        public IMapper _mapper;
        public IUnitOfWork _unitOfWork;

        public ProductService( IMapper mapper, IUnitOfWork unitOfWork)
        {
            //_productRepository = productRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task Create(ProductDTO product)
        {
            var _product = _mapper.Map<Product>(product);
            await _unitOfWork.productRepository.CreateAsync(_product);
            await _unitOfWork.productRepository.SaveAsync();
        }
        public async Task Delete(Guid id)
        {
            var product = await _unitOfWork.productRepository.FindByIdAsync(id);
            _unitOfWork.productRepository.Delete(product);
            await _unitOfWork.productRepository.SaveAsync();
        }
        public async Task<List<Product>> GetAll()
        {
            return await _unitOfWork.productRepository.GetAll();
        }

        public List<Product> GetByBrand(string brand)
        {
            return _unitOfWork.productRepository.GetByBrand(brand);
        }

        public async Task<Product> GetById(Guid id)
        {
            return await _unitOfWork.productRepository.FindByIdAsync(id);
        }
        public async Task<Product?> Update(Guid id, ProductDTO product)
        {
            var p = await _unitOfWork.productRepository.FindByIdAsync(id);
            if(p == null)
                return null;

            p.Price = product.Price;
            p.ProductName = p.ProductName;
            p.Brand = p.Brand;
            p.Description = p.Description;

            await _unitOfWork.productRepository.SaveAsync();
            return p;

        }
    }
}
