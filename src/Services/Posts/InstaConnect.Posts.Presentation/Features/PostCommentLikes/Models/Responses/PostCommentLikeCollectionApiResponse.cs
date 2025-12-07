namespace InstaConnect.Posts.Presentation.Features.PostCommentLikes.Models.Responses;

public record PostCommentLikeCollectionApiResponse(
    ICollection<PostCommentLikeApiResponse> Entities,
    int Page,
    int PageSize,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage);
