using InstaConnect.Shared.Presentation.Abstractions;
using InstaConnect.Shared.Presentation.Extensions;
using InstaConnect.Shared.Presentation.Models.Users;
using Microsoft.AspNetCore.Http;

namespace InstaConnect.Shared.Presentation.Helpers;

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
