namespace InstaConnect.Posts.Domain.Features.PostComments.Models.Responses;
public record PostCommentCollection(
    ICollection<PostComment> Data,
    int Page,
    int PageSize,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage);
