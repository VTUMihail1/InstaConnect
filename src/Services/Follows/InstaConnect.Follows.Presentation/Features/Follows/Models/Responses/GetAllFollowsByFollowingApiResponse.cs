namespace InstaConnect.Follows.Application.Features.Follows.Queries.GetAll;

public record GetAllFollowsByFollowingApiResponse(
    ICollection<FollowApiResponse> Data,
    int Page,
    int PageSize,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage);
