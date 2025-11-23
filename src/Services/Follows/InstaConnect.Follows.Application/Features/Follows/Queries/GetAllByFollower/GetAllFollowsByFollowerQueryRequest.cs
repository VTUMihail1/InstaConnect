namespace InstaConnect.Follows.Application.Features.Follows.Queries.GetAllByFollower;

public record GetAllFollowsByFollowerQueryRequest(
    FollowByFollowerFilterQueryRequest Filter,
    FollowByFollowerSortingQueryRequest Sorting,
    FollowPaginationQueryRequest Pagination)
    : IQueryRequest<GetAllFollowsByFollowerQueryResponse>;
