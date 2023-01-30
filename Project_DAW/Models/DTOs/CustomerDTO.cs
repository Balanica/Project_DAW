namespace Project_DAW.Models.DTOs
{
    public class CustomerDTO
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty; 
        public string Email { get; set; } = string.Empty;   
        public string Phone { get; set; } = string.Empty;
        //public ICollection<OrderDTO>? Orders { get; set; }
    }
}
