using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Extensions;
using InstaConnect.Shared.Business.Models.Users;
using Microsoft.AspNetCore.Http;

namespace InstaConnect.Shared.Business.Helpers;

public class CurrentUserContext : ICurrentUserContext
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserContext(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public CurrentUserDetails GetCurrentUserDetails()
    {
        return new CurrentUserDetails
        {
            Id = _httpContextAccessor?.HttpContext.User.GetUserId()
        };
    }
}
