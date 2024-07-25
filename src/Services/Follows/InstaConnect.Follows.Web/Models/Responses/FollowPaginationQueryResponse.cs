using InstaConnect.Follows.Business.Models.Follows;
using InstaConnect.Shared.Business.Models;
using InstaConnect.Shared.Web.Models.Responses;

namespace InstaConnect.Follows.Web.Models.Responses;

public record FollowPaginationQueryResponse(
    ICollection<FollowQueryViewModel> Items,
    int Page,
    int PageSize,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage)
    : PaginationQueryResponse<FollowQueryViewModel>(Items, Page, PageSize, TotalCount, HasNextPage, HasPreviousPage);
