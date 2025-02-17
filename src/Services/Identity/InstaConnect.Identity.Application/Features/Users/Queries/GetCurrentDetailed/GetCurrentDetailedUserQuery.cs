using System.Globalization;

using InstaConnect.Identity.Application.Features.Users.Utilities;

namespace InstaConnect.Identity.Application.Features.Users.Queries.GetCurrentDetailed;

public record GetCurrentDetailedUserQuery(string CurrentUserId) : IQuery<UserDetailedQueryViewModel>, ICachable
{
    private const int EXPIRATION_SECONDS = 1500;

    public string Key => string.Format(
        CultureInfo.InvariantCulture,
        UserCacheKeys.GetCurrentDetailedUser,
        CurrentUserId);

    public int ExpirationSeconds => EXPIRATION_SECONDS;
}
