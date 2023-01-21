using Project_DAW.Models.Base;

namespace Project_DAW.Models
{
    public class Product : BaseEntity
    {
        public string ProductName { get; set; }
        public string Description { get; set; } 
        public double Price { get; set; }
        public string Brand { get; set; }

        public ICollection<OrderProduct> OrdersProducts { get; set; }

        public Inventory Inventory { get; set; }   
    }
}
