using InstaConnect.Shared.Business.Models;

namespace InstaConnect.Posts.Business.Models.PostCommentLike;

public record PostCommentLikePaginationQueryViewModel(
    ICollection<PostCommentLikeQueryViewModel> Items,
    int Page,
    int PageSize,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage)
    : PaginationQueryViewModel<PostCommentLikeQueryViewModel>(Items, Page, PageSize, TotalCount, HasNextPage, HasPreviousPage);
