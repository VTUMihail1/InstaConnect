using InstaConnect.Identity.Application.Features.Users.Models;
using InstaConnect.Identity.Application.Features.Users.Utilities;
using InstaConnect.Shared.Application.Abstractions;

namespace InstaConnect.Identity.Application.Features.Users.Queries.GetCurrentUserDetailed;

public record GetCurrentDetailedUserQuery(string CurrentUserId) : IQuery<UserDetailedQueryViewModel>, ICachable
{
    private const int EXPIRATION_SECONDS = 1500;

    public string Key => string.Format(UserCacheKeys.GetCurrentDetailedUser, CurrentUserId);

    public int ExpirationSeconds => EXPIRATION_SECONDS;
}
