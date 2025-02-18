using System.Globalization;

using InstaConnect.Identity.Application.Features.Users.Utilities;

namespace InstaConnect.Identity.Application.Features.Users.Queries.GetCurrent;

public record GetCurrentUserQuery(string CurrentUserId) : IQuery<UserQueryViewModel>, ICachable
{
    private const int EXPIRATION_SECONDS = 1500;

    public string Key => string.Format(
        CultureInfo.InvariantCulture,
        UserCacheKeys.GetCurrentUser,
        CurrentUserId);

    public int ExpirationSeconds => EXPIRATION_SECONDS;
}
