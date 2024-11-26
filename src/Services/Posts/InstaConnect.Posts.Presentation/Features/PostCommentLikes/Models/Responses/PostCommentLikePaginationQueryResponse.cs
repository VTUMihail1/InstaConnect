namespace InstaConnect.Posts.Presentation.Features.PostCommentLikes.Models.Responses;

public record PostCommentLikePaginationQueryResponse(
    ICollection<PostCommentLikeQueryResponse> Items,
    int Page,
    int PageSize,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage);
