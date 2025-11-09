namespace InstaConnect.Follows.Application.Features.Follows.Queries.GetAllByFollower;

public record GetAllFollowsByFollowerQueryRequest(
    FollowByFollowerQueryFilter Filter,
    FollowByFollowerQuerySorting Sorting,
    FollowQueryPagination Pagination)
    : IQueryRequest<GetAllFollowsByFollowerQueryResponse>;
