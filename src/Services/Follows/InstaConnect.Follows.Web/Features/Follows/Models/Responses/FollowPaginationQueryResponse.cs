using InstaConnect.Follows.Business.Features.Follows.Models;
using InstaConnect.Shared.Web.Models.Responses;

namespace InstaConnect.Follows.Web.Features.Follows.Models.Responses;

public record FollowPaginationQueryResponse(
    ICollection<FollowQueryViewModel> Items,
    int Page,
    int PageSize,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage)
    : PaginationQueryResponse<FollowQueryViewModel>(Items, Page, PageSize, TotalCount, HasNextPage, HasPreviousPage);
