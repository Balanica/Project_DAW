using Project_DAW.Models.DTOs;
using Project_DAW.Models;
using Project_DAW.Repositories.ProductRepository;
using Project_DAW.Repositories.Inventory;
using Project_DAW.Repositories.UnitOfWork;

namespace Project_DAW.Services.StockService
{
    public class StockService : IStockService
    {
        //public IStockRepository _stockRepository;
        public IUnitOfWork _unitOfWork;

        public StockService( IUnitOfWork unitOfWork)
        {
            //_stockRepository = stockRepository;
            _unitOfWork = unitOfWork;

        }
        public async Task Create(Stock stock)
        {
            await _unitOfWork.stockRepository.CreateAsync(stock);
            await _unitOfWork.stockRepository.SaveAsync();
        }
        public async Task Delete(Guid id)
        {
            var stock = await _unitOfWork.stockRepository.FindByIdAsync(id);
            _unitOfWork.stockRepository.Delete(stock);
            await _unitOfWork.stockRepository.SaveAsync();
        }
        public async Task<List<Stock>> GetAll()
        {
            return await _unitOfWork.stockRepository.GetAll();
        }
        public async Task<Stock> GetById(Guid id)
        {
            return await _unitOfWork.stockRepository.FindByIdAsync(id);
        }
        public async Task<Stock?> Update(Guid id, StockDTO stock)
        {
            var s = await _unitOfWork.stockRepository.FindByIdAsync(id);
            if (s == null)
                return null;
            s.Quantity = stock.Quantity;

            await _unitOfWork.stockRepository.SaveAsync();
            return s;

        }
    }
}
