using Project_DAW.Models.Base;

namespace Project_DAW.Models
{
    public class Stock : BaseEntity
    {
        public int Quantity { get; set; }
        public Product Product { get; set; }

        public Guid ProductId { get; set; }
    }
}
