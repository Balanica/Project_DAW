using Project_DAW.Data;
using Project_DAW.Models;
using Project_DAW.Repositories.GenericRepository;
using Project_DAW.Repositories.Inventory;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_DAW.Repositories.InventoryRepository
{
    public class StockRepository : GenericRepository<Stock>, IStockRepository
    {
        public StockRepository(DataBaseContext dataBaseContext) : base(dataBaseContext)
        {

        }
    }
}
