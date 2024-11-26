namespace InstaConnect.Posts.Application.Features.PostCommentLikes.Models;

public record PostCommentLikePaginationQueryViewModel(
    ICollection<PostCommentLikeQueryViewModel> Items,
    int Page,
    int PageSize,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage);
