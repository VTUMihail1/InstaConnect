namespace InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Responses;
public record PostCommentLikeCollection(
    ICollection<PostCommentLike> Data,
    int Page,
    int PageSize,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage);
