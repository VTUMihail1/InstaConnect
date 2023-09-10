using InstaConnect.Business.Abstraction.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace InstaConnect.Presentation.API.Filters
{
    public class TokenAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var tokenService = context.HttpContext.RequestServices.GetService<ITokenService>();

            var token = context.HttpContext.Request.Headers.Authorization;

            var realToken = tokenService
                .GetByValueAsync(token)
                .GetAwaiter()
                .GetResult()
                .Data;

            if (realToken == null)
            {
                context.Result = new ForbidResult();
            }

            return;
        }
    }
}
