using InstaConnect.Follows.Domain.Features.Follows.Models;

namespace InstaConnect.Follows.Application.Features.Follows.Queries.GetAll;

public record GetAllFollowsByFollowerQueryRequest(
    FollowByFollowerQueryFilter Filter,
    FollowByFollowerQuerySorting Sorting,
    FollowQueryPagination Pagination)
    : IQueryRequest<GetAllFollowsByFollowerQueryResponse>;
