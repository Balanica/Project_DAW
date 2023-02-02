using Project_DAW.Models.Base;
using Project_DAW.Models.Roles;
using System.Diagnostics.Contracts;
using System.Text.Json.Serialization;

namespace Project_DAW.Models
{
    public class Customer : BaseEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Phone { get; set; }
        public Role Role { get; set; }
        public ICollection<Order>? Orders { get; set; }

        [JsonIgnore]
        public string PasswordHash { get; set; } = string.Empty;
    }
}
