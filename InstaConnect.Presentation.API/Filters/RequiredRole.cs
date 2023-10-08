using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using InstaConnect.Data.Models.Entities;
using InstaConnect.Presentation.API.Extensions;

namespace InstaConnect.Presentation.API.Filters
{
    public class RequiredRoleAttribute : ActionFilterAttribute
    {
        private readonly string[] _requiredRoles;

        public RequiredRoleAttribute(params string[] requiredRoles)
        {
            _requiredRoles = requiredRoles;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var userManager = context.HttpContext.RequestServices.GetRequiredService<UserManager<User>>();
            var userId = context.HttpContext.User.GetCurrentUserId();

            var user = userManager.FindByIdAsync(userId).GetAwaiter().GetResult();
            var userRoles = userManager.GetRolesAsync(user).GetAwaiter().GetResult();

            if (!_requiredRoles.Any(userRoles.Contains))
            {
                context.Result = new ForbidResult();
            }

            return;
        }
    }
}
