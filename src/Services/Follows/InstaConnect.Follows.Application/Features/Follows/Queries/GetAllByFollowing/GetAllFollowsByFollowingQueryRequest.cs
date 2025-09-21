using InstaConnect.Follows.Domain.Features.Follows.Models;

namespace InstaConnect.Follows.Application.Features.Follows.Queries.GetAll;

public record GetAllFollowsByFollowingQueryRequest(
    FollowByFollowingQueryFilter Filter,
    FollowByFollowingQuerySorting Sorting,
    FollowQueryPagination Pagination)
    : IQueryRequest<GetAllFollowsByFollowingQueryResponse>;
