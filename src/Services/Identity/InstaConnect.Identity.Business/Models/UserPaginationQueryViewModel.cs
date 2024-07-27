using InstaConnect.Identity.Business.Models;
using InstaConnect.Shared.Business.Models;

namespace InstaConnect.Messages.Business.Models;

public record UserPaginationQueryViewModel(
    ICollection<UserQueryViewModel> Items,
    int Page,
    int PageSize,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage)
    : PaginationQueryViewModel<UserQueryViewModel>(Items, Page, PageSize, TotalCount, HasNextPage, HasPreviousPage);
