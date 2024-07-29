using InstaConnect.Shared.Business.Models;

namespace InstaConnect.Identity.Business.Features.Users.Models;

public record UserPaginationQueryViewModel(
    ICollection<UserQueryViewModel> Items,
    int Page,
    int PageSize,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage)
    : PaginationQueryViewModel<UserQueryViewModel>(Items, Page, PageSize, TotalCount, HasNextPage, HasPreviousPage);
