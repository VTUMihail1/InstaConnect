namespace InstaConnect.Posts.Domain.Features.Posts.Models.Responses;
public record PostCollection(
    ICollection<Post> Entities,
    int Page,
    int PageSize,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage) : IEntityCollection;
