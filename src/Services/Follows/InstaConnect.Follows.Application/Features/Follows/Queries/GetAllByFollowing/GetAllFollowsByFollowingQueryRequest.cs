namespace InstaConnect.Follows.Application.Features.Follows.Queries.GetAllByFollowing;

public record GetAllFollowsByFollowingQueryRequest(
    FollowByFollowingFilterQueryRequest Filter,
    FollowByFollowingSortingQueryRequest Sorting,
    FollowPaginationQueryRequest Pagination)
    : IQueryRequest<GetAllFollowsByFollowingQueryResponse>;
