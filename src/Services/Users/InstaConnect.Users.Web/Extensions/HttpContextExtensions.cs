﻿using InstaConnect.Users.Web.Models.Requests.Token;

namespace InstaConnect.Users.Web.Extensions;

public static class HttpContextExtensions
{
    public static TokenRequestModel GetTokenRequestModel(this HttpContext context)
    {
        return new()
        {
            Value = context.Request.Headers.Authorization!
        };
    }
}
