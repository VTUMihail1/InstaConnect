using InstaConnect.Identity.Application.Features.Users.Utilities;

namespace InstaConnect.Identity.Application.Features.Users.Queries.GetCurrentDetailsById;

public record GetCurrentUserDetailsByIdQueryRequest(string Id) : IQueryRequest<GetCurrentUserDetailsByIdQueryResponse>, ICachable
{
    public string Key => UserCacheKeys.GetCurrentDetailed;

    public int ExpirationSeconds => UserCacheExpirations.GetCurrentDetailed;
}
