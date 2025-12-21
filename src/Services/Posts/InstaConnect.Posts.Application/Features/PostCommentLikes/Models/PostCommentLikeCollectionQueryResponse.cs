namespace InstaConnect.Posts.Application.Features.PostCommentLikes.Models;

public record PostCommentLikeCollectionQueryResponse(
    ICollection<PostCommentLikeQueryResponse> Entities,
    int Page,
    int PageSize,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage) : ICollectionQueryResponse;
