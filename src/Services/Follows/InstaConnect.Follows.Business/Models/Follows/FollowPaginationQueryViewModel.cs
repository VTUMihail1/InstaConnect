using InstaConnect.Follows.Business.Models.Follows;
using InstaConnect.Shared.Business.Models;

namespace InstaConnect.Messages.Business.Models;

public record FollowPaginationQueryViewModel(
    ICollection<FollowQueryViewModel> Items,
    int Page, 
    int PageSize, 
    int TotalCount, 
    bool HasNextPage, 
    bool HasPreviousPage) 
    : PaginationQueryViewModel<FollowQueryViewModel>(Items, Page, PageSize, TotalCount, HasNextPage, HasPreviousPage);
