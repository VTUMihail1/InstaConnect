using InstaConnect.Shared.Business.Models;

namespace InstaConnect.Posts.Business.Features.Posts.Models;

public record PostPaginationQueryViewModel(
    ICollection<PostQueryViewModel> Items,
    int Page,
    int PageSize,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage)
    : PaginationQueryViewModel<PostQueryViewModel>(Items, Page, PageSize, TotalCount, HasNextPage, HasPreviousPage);
