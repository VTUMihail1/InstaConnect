namespace InstaConnect.Posts.Application.Features.PostLikes.Models;

public record PostLikeCollectionQueryResponse(
    ICollection<PostLikeQueryResponse> Entities,
    int Page,
    int PageSize,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage);
