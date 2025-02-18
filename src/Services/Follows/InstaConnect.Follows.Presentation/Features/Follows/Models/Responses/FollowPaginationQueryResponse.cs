namespace InstaConnect.Follows.Presentation.Features.Follows.Models.Responses;

public record FollowPaginationQueryResponse(
    ICollection<FollowQueryViewModel> Items,
    int Page,
    int PageSize,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage);
