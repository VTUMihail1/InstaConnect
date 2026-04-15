using InstaConnect.Identity.Application.Features.Users.Abstractions;
using InstaConnect.Identity.Application.Features.Users.Utilities;

namespace InstaConnect.Identity.Application.Features.Users.Queries.GetCurrentDetailsById;

public record GetCurrentUserDetailsByIdQueryRequest(string CurrentId) : IQueryRequest<GetCurrentUserDetailsByIdQueryResponse>, ICachable, ICurrentUserableQueryRequest
{
    public string Key => UserCacheKeys.GetCurrentDetailed(CurrentId);

    public int ExpirationSeconds => UserCacheExpirations.GetCurrentDetailed;
}
