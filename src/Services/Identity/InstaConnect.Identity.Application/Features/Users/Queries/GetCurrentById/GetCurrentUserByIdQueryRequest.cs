using InstaConnect.Identity.Application.Features.Users.Utilities;
using InstaConnect.Users.Application.Features.Users.Queries.GetAll;

namespace InstaConnect.Users.Application.Features.Users.Queries.GetById;

public record GetCurrentUserByIdQueryRequest(string Id) : IQueryRequest<GetCurrentUserByIdQueryResponse>, ICachable
{
    public string Key => UserCacheKeys.GetCurrent;

    public int ExpirationSeconds => UserCacheExpirations.GetCurrent;
}
