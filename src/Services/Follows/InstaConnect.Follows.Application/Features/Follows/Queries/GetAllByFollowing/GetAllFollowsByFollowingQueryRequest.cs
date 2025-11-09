namespace InstaConnect.Follows.Application.Features.Follows.Queries.GetAllByFollowing;

public record GetAllFollowsByFollowingQueryRequest(
    FollowByFollowingQueryFilter Filter,
    FollowByFollowingQuerySorting Sorting,
    FollowQueryPagination Pagination)
    : IQueryRequest<GetAllFollowsByFollowingQueryResponse>;
