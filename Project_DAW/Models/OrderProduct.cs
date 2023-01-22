using Project_DAW.Models.Base;

namespace Project_DAW.Models
{
    public class OrderProduct : BaseEntity
    {
        public Guid OrderId { get; set; }
        public Order Order { get; set; }

        public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }
}
