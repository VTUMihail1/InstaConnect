using InstaConnect.Identity.Application.Features.Users.Utilities;

namespace InstaConnect.Identity.Application.Features.Users.Queries.GetCurrentById;

public record GetCurrentUserByIdQueryRequest(string Id) : IQueryRequest<GetCurrentUserByIdQueryResponse>, ICachable
{
    public string Key => UserCacheKeys.GetCurrent;

    public int ExpirationSeconds => UserCacheExpirations.GetCurrent;
}
