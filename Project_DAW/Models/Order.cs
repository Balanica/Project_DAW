using Project_DAW.Models.Base;

namespace Project_DAW.Models
{
    public class Order : BaseEntity
    {
        public string ShippingAddress { get; set; }
        public string BillingAddress { get; set; }
        public string PaymentMethod { get; set; }
        public double TotalCost { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public ICollection<OrderProduct> OrdersProducts { get; set; }

        public Customer Customer { get; set; }
        public Guid CustomerID { get; set; }
    }
}
