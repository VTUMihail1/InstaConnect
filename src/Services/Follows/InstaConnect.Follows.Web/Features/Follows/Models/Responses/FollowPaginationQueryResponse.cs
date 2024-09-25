using InstaConnect.Follows.Business.Features.Follows.Models;

namespace InstaConnect.Follows.Web.Features.Follows.Models.Responses;

public record FollowPaginationQueryResponse(
    ICollection<FollowQueryViewModel> Items,
    int Page,
    int PageSize,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage);
