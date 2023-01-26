namespace Project_DAW.Models.DTOs
{
    public class ProductDTO
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double? Price { get; set; } = 0;
        public string Brand { get; set; } = string.Empty;
        public ICollection<Stock>? Stock { get; set; }
    }
}
