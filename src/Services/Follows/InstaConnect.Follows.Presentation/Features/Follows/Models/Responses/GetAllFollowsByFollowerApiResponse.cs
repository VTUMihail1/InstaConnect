namespace InstaConnect.Follows.Presentation.Features.Follows.Models.Responses;

public record GetAllFollowsByFollowerApiResponse(
    ICollection<FollowApiResponse> Data,
    int Page,
    int PageSize,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage);
