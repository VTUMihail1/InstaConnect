namespace InstaConnect.Follows.Presentation.Features.Follows.Models.Responses;

public record GetAllFollowsByFollowingApiResponse(
    ICollection<FollowApiResponse> Data,
    int Page,
    int PageSize,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage);
