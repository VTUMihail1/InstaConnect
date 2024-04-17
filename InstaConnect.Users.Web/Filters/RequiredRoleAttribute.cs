using InstaConnect.Users.Data.Models.Entities;
using InstaConnect.Users.Web.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace InstaConnect.Users.Web.Filters
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
            var userRequestModel = context.HttpContext.User.GetUserRequestModel();

            var user = userManager.FindByIdAsync(userRequestModel.Id).GetAwaiter().GetResult();
            var userRoles = userManager.GetRolesAsync(user!).GetAwaiter().GetResult();

            if (!_requiredRoles.Any(userRoles.Contains))
            {
                context.Result = new ForbidResult();
            }

            return;
        }
    }
}
