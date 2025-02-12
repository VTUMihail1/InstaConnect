namespace InstaConnect.Posts.Application.Features.PostComments.Models;

public record PostCommentPaginationQueryViewModel(
    ICollection<PostCommentQueryViewModel> Items,
    int Page,
    int PageSize,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage);
