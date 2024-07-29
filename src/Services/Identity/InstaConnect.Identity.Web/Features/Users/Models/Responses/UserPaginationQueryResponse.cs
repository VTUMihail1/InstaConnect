using InstaConnect.Identity.Business.Features.Users.Models;
using InstaConnect.Shared.Web.Models.Responses;

namespace InstaConnect.Identity.Web.Features.Users.Models.Responses;

public record UserPaginationQueryResponse(
    ICollection<UserQueryViewModel> Items,
    int Page,
    int PageSize,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage)
    : PaginationQueryResponse<UserQueryViewModel>(Items, Page, PageSize, TotalCount, HasNextPage, HasPreviousPage);
