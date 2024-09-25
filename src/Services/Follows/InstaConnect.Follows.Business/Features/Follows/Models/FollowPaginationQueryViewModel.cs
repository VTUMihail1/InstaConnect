namespace InstaConnect.Follows.Business.Features.Follows.Models;

public record FollowPaginationQueryViewModel(
    ICollection<FollowQueryViewModel> Items,
    int Page,
    int PageSize,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage);
