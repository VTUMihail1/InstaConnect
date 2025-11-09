namespace InstaConnect.Posts.Domain.Features.Posts.Models.Responses;
public record PostCollection(
    ICollection<Post> Data,
    int Page,
    int PageSize,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage);
