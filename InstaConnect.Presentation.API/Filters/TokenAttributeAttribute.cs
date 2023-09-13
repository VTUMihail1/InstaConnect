using InstaConnect.Business.Abstraction.Services;
using InstaConnect.Business.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace InstaConnect.Presentation.API.Filters
{
    public class AccessTokenAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var tokenService = context.HttpContext.RequestServices.GetService<ITokenService>();
            var token = context.HttpContext.Request.Headers.Authorization;

            var exisitngToken = tokenService
                .GetByValueAsync(token)
                .GetAwaiter()
                .GetResult();

            if (exisitngToken.StatusCode == InstaConnectStatusCode.Unauthorized)
            {
                context.Result = new UnauthorizedResult();
            }

            return;
        }
    }
}
