using InstaConnect.Identity.Application.Features.Users.Abstractions;

namespace InstaConnect.Identity.Application.Features.Users.Queries.GetDetailsById;

public record GetUserDetailsByIdQueryRequest(
    string Id,
    string CurrentId) : IQueryRequest<GetUserDetailsByIdQueryResponse>, ICurrentUserableQueryRequest;
