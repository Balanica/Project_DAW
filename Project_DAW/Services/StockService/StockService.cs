using Project_DAW.Models.DTOs;
using Project_DAW.Models;
using Project_DAW.Repositories.ProductRepository;
using Project_DAW.Repositories.Inventory;

namespace Project_DAW.Services.StockService
{
    public class StockService : IStockService
    {
        public IStockRepository _stockRepository;

        public StockService(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }
        public async Task Create(Stock stock)
        {
            await _stockRepository.CreateAsync(stock);
            await _stockRepository.SaveAsync();
        }
        public async Task Delete(Guid id)
        {
            var stock = await _stockRepository.FindByIdAsync(id);
            _stockRepository.Delete(stock);
            await _stockRepository.SaveAsync();
        }
        public async Task<List<Stock>> GetAll()
        {
            return await _stockRepository.GetAll();
        }
        public async Task<Stock> GetById(Guid id)
        {
            return await _stockRepository.FindByIdAsync(id);
        }
        public async Task<Stock?> Update(Guid id, StockDTO stock)
        {
            var s = await _stockRepository.FindByIdAsync(id);
            if (s == null)
                return null;
            s.Quantity = stock.Quantity;
            return s;

        }
    }
}
