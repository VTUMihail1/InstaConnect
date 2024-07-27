using InstaConnect.Shared.Business.Models;

namespace InstaConnect.Posts.Business.Models.PostComment;

public record PostCommentPaginationQueryViewModel(
    ICollection<PostCommentQueryViewModel> Items,
    int Page,
    int PageSize,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage)
    : PaginationQueryViewModel<PostCommentQueryViewModel>(Items, Page, PageSize, TotalCount, HasNextPage, HasPreviousPage);
