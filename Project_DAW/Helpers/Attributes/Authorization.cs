using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Project_DAW.Models;
using Project_DAW.Models.Roles;

namespace Project_DAW.Helpers.Attributes
{
    public class Authorization : Attribute, IAuthorizationFilter
    {
        private readonly ICollection<Role> _roles;

        public Authorization(params Role[] roles)
        {
            _roles = roles;
        }

        void IAuthorizationFilter.OnAuthorization(AuthorizationFilterContext context)
        {
            var unauthorizationStatusObject = new JsonResult(new { Message = "Unauthorized" }){ StatusCode = StatusCodes.Status401Unauthorized };

            if (_roles == null)
            {
                context.Result = unauthorizationStatusObject;
            }

            Customer? customer = context.HttpContext.Items["Customer"] as Customer;

            if ( customer == null || _roles.Contains(customer.Role))
            {
                context.Result = unauthorizationStatusObject;
            }
        }
    }
}
