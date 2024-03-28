using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using UniforBackend.Domain.Models.Entities;
using UniforBackend.Domain.Models.enums;

namespace UniforBackend.API.Authorization
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class CustomAuthorizeAttribute : TypeFilterAttribute
    {
        public CustomAuthorizeAttribute(params Role[] roles) : base(typeof(CustomAuthorizeFilter))
        {
            Arguments = new object[] { roles };
        }
    }

    public class CustomAuthorizeFilter : IAuthorizationFilter
    {
        private readonly IList<Role> _roles;

        public CustomAuthorizeFilter(params Role[] roles)
        {
            _roles = roles ?? new Role[] { };
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // Skip authorization if action is decorated with [AllowAnonymous] attribute
            var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
            if (allowAnonymous)
                return;

            // Authorization
            var user = (User)context.HttpContext.Items["User"];
            if (user == null || (_roles.Any() && !_roles.Contains(user.Tipo)))
            {
                // Not logged in or role not authorized
                context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
            }
        }
    }
}
