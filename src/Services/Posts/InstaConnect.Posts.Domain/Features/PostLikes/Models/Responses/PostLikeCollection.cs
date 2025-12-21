namespace InstaConnect.Posts.Domain.Features.PostLikes.Models.Responses;
public record PostLikeCollection(
    ICollection<PostLike> Entities,
    int Page,
    int PageSize,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage) : IEntityCollection;
