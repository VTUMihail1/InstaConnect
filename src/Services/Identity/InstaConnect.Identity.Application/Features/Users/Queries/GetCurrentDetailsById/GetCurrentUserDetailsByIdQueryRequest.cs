using InstaConnect.Identity.Application.Features.Users.Utilities;
using InstaConnect.Users.Application.Features.Users.Queries.GetAll;

namespace InstaConnect.Users.Application.Features.Users.Queries.GetById;

public record GetCurrentUserDetailsByIdQueryRequest(string Id) : IQueryRequest<GetCurrentUserDetailsByIdQueryResponse>, ICachable
{
    public string Key => UserCacheKeys.GetCurrentDetailed;

    public int ExpirationSeconds => UserCacheExpirations.GetCurrentDetailed;
}
