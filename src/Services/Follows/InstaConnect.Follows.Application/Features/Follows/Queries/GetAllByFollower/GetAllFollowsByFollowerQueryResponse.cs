namespace InstaConnect.Follows.Application.Features.Follows.Queries.GetAllByFollower;

public record GetAllFollowsByFollowerQueryResponse(
    ICollection<FollowQueryResponse> Data,
    int Page,
    int PageSize,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage);
