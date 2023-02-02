using Microsoft.Identity.Client;
using Project_DAW.Models;

namespace Project_DAW.Helpers.JwtToken
{
    public interface IJwtUtils
    {
        public string GenerateJwtToken(Customer customer);
        public Guid ValidateJwtToken(string token);
    }
}
