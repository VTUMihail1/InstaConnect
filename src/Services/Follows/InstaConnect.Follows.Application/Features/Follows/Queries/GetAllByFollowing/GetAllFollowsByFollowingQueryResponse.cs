namespace InstaConnect.Follows.Application.Features.Follows.Queries.GetAllByFollowing;

public record GetAllFollowsByFollowingQueryResponse(
    ICollection<FollowQueryResponse> Data,
    int Page,
    int PageSize,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage);
