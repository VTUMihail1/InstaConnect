using InstaConnect.Identity.Business.Models;
using InstaConnect.Shared.Web.Models.Responses;

namespace InstaConnect.Identity.Web.Models.Response;

public record UserPaginationQueryResponse(
    ICollection<UserQueryViewModel> Items,
    int Page,
    int PageSize,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage)
    : PaginationQueryResponse<UserQueryViewModel>(Items, Page, PageSize, TotalCount, HasNextPage, HasPreviousPage);
