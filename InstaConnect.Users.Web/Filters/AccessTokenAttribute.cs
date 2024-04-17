using InstaConnect.Users.Business.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace InstaConnect.Users.Web.Filters
{
    public class AccessTokenAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var tokenManager = context.HttpContext.RequestServices.GetService<ITokenService>();
            var value = context.HttpContext.Request.Headers.Authorization;

            var token = tokenManager
                .GetByValueAsync(value, new CancellationToken())
                .GetAwaiter()
                .GetResult();

            if (token == null)
            {
                context.Result = new UnauthorizedResult();
            }

            return;
        }
    }
}
