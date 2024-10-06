using InstaConnect.Shared.Web.Abstractions;
using InstaConnect.Shared.Web.Extensions;
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
        return new CurrentUserModel(
            _httpContextAccessor?.HttpContext?.User.GetUserId() ?? string.Empty,
            _httpContextAccessor?.HttpContext?.User.GetUserName() ?? string.Empty);
    }
}
