namespace Project_DAW.Models.DTOs
{
    public class OrderDTO
    {
        //public Guid Id { get; set; } 
        public string ShippingAddress { get; set; } = string.Empty;
        public string BillingAddress { get; set; } = string.Empty;
        public string PaymentMethod { get; set; } = string.Empty;
        public double TotalCost { get; set; } = 0;
        public string CustomerEmail { get; set; } = string.Empty;
        //public DateTime OrderTime { get; set; }
        //public ICollection<OrderProduct>? OrdersProducts { get; set; }

    }
}
