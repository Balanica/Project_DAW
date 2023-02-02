using Azure.Core;
using Project_DAW.Helpers.JwtToken;
using Project_DAW.Services.CustomerService;
using System.Runtime.CompilerServices;

namespace Project_DAW.Helpers.Middleware
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _requestDelegate;

        public JwtMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        public async Task Invoke(HttpContext httpContext, ICustomerService customerService, IJwtUtils jwtUtils)
        {
            var token = httpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split("").Last();
            var customerId = jwtUtils.ValidateJwtToken(token);
            if(customerId != Guid.Empty)
            {
                httpContext.Items["Customer"] = customerService.GetById(customerId);
            }

            await _requestDelegate(httpContext);
        }
    }
}
