namespace InstaConnect.Posts.Domain.Features.PostComments.Models.Responses;
public record PostCommentCollection(
    ICollection<PostComment> Entities,
    int Page,
    int PageSize,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage) : IEntityCollection;
