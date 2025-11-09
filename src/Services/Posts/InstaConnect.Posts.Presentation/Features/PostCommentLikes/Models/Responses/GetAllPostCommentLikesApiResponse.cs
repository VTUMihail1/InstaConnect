namespace InstaConnect.Posts.Presentation.Features.PostCommentLikes.Models.Responses;

public record GetAllPostCommentLikesApiResponse(
    ICollection<PostCommentLikeApiResponse> Data,
    int Page,
    int PageSize,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage);
