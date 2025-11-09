namespace InstaConnect.Posts.Domain.Features.PostLikes.Models.Responses;
public record PostLikeCollection(
    ICollection<PostLike> Data,
    int Page,
    int PageSize,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage);
