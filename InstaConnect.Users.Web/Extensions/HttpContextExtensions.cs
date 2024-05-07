using InstaConnect.Users.Web.Models.Requests.Token;
using Microsoft.AspNetCore.Http;

namespace InstaConnect.Users.Web.Extensions;

public static class HttpContextExtensions
{
    public static TokenRequestModel GetTokenRequestModel(this HttpContext context) => new()
    {
        Value = context.Request.Headers.Authorization!
    };
}
