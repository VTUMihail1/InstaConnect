using InstaConnect.Identity.Business.Features.Users.Models;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Identity.Business.Features.Users.Queries.GetCurrentUser;

public record GetCurrentUserQuery(string CurrentUserId) : IQuery<UserQueryViewModel>, ICachable
{
    private const int CACHE_EXPIRATION_AMOUNT = 15;

    public string Key => $"{nameof(GetCurrentUserQuery)}-{CurrentUserId}";

    public DateTimeOffset Expiration => DateTimeOffset.UtcNow.AddMinutes(CACHE_EXPIRATION_AMOUNT);
}
