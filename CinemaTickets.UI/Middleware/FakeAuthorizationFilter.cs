using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CinemaTickets.UI.Middleware
{
    public class FakeAuthorizationFilter : IResourceFilter
    {
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            context.HttpContext.User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, "jmarcinik"),
                new Claim(ClaimTypes.Role, "Admin") 
            }, "FakeAuth"));
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
        }
    }
}
