using Project_DAW.Models.DTOs;
using Project_DAW.Models;

namespace Project_DAW.Services.StockService
{
    public interface IStockService
    {
        Task Create(Stock stock);
        Task Delete(Guid id);
        Task<List<Stock>> GetAll();
        Task<Stock> GetById(Guid id);
        Task<Stock?> Update(Guid id, StockDTO stock);
    }
}
