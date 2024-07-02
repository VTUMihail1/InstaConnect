using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Extensions;
using InstaConnect.Shared.Web.Abstractions;
using InstaConnect.Shared.Web.Models.Users;
using Microsoft.AspNetCore.Http;

namespace InstaConnect.Shared.Web.Helpers;

public class CurrentUserContext : ICurrentUserContext
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserContext(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public CurrentUserModel GetCurrentUser()
    {
        return new CurrentUserModel
        {
            Id = _httpContextAccessor?.HttpContext?.User.GetUserId() ?? string.Empty,
            UserName = _httpContextAccessor?.HttpContext?.User.GetUserName() ?? string.Empty,
        };
    }
}
