namespace InstaConnect.Posts.Presentation.Features.PostLikes.Models.Responses;

public record GetAllPostLikesApiResponse(
    ICollection<PostLikeApiResponse> Data,
    int Page,
    int PageSize,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage);
