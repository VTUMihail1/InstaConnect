﻿using InstaConnect.Data.Abstraction.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace InstaConnect.Presentation.API.Filters
{
    public class AccessTokenAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var tokenManager = context.HttpContext.RequestServices.GetService<ITokenManager>();
            var value = context.HttpContext.Request.Headers.Authorization;

            var token = tokenManager
                .GetByValueAsync(value)
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
