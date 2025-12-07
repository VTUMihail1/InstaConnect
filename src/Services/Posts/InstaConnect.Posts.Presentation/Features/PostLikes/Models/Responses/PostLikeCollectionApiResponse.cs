namespace InstaConnect.Posts.Presentation.Features.PostLikes.Models.Responses;

public record PostLikeCollectionApiResponse(
    ICollection<PostLikeApiResponse> Entities,
    int Page,
    int PageSize,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage);
