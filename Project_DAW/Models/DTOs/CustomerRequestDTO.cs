using System.ComponentModel.DataAnnotations;

namespace Project_DAW.Models.DTOs
{
    public class CustomerRequestDTO
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        public string? LastName { get; set; }
    }
}
