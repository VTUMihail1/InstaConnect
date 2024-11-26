using InstaConnect.Identity.Application.Features.Users.Models;
using InstaConnect.Identity.Application.Features.Users.Utilities;
using InstaConnect.Shared.Application.Abstractions;

namespace InstaConnect.Identity.Application.Features.Users.Queries.GetCurrentUser;

public record GetCurrentUserQuery(string CurrentUserId) : IQuery<UserQueryViewModel>, ICachable
{
    private const int CACHE_EXPIRATION_AMOUNT = 15;

    public string Key => string.Format(UserCacheKeys.GetCurrentUser, CurrentUserId);

    public DateTimeOffset Expiration => DateTimeOffset.UtcNow.AddMinutes(CACHE_EXPIRATION_AMOUNT);
}
