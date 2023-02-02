namespace Project_DAW.Models.DTOs
{
    public class CustomerResponseDTO
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }


        public CustomerResponseDTO(Customer customer, string token)
        {
            Id = customer.Id;
            FirstName = customer.FirstName;
            LastName = customer.LastName;
            Email = customer.Email;
            Token = token;
        }
    }
}
