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

            var exisitngToken = tokenService
                .GetByValueAsync(token)
                .GetAwaiter()
                .GetResult()
                .Data;

            if (exisitngToken == null)
            {
                context.Result = new UnauthorizedResult();
            }

            return;
        }
    }
}
