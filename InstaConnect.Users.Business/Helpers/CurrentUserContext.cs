using InstaConnect.Users.Business.Abstractions;
using InstaConnect.Users.Business.Extensions;
using Microsoft.AspNetCore.Http;

namespace InstaConnect.Users.Business.Helpers;

public class CurrentUserContext : ICurrentUserContext
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserContext(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string? GetUsedId()
    {
        return _httpContextAccessor?.HttpContext.User.GetUserId();
    }
}
