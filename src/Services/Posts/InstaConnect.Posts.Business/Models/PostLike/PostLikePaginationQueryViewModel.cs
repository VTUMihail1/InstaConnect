using InstaConnect.Shared.Business.Models;

namespace InstaConnect.Posts.Business.Models.PostLike;

public record PostLikePaginationQueryViewModel(
    ICollection<PostLikeQueryViewModel> Items,
    int Page,
    int PageSize,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage)
    : PaginationQueryViewModel<PostLikeQueryViewModel>(Items, Page, PageSize, TotalCount, HasNextPage, HasPreviousPage);
