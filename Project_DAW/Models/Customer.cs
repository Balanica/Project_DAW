using Project_DAW.Models.Base;
using Project_DAW.Models.Roles;
using System.Diagnostics.Contracts;

namespace Project_DAW.Models
{
    public class Customer : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public Role Role { get; set; }
        public ICollection<Order>? Orders { get; set; }
    }
}
