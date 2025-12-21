namespace InstaConnect.Posts.Application.Features.PostComments.Models;

public record PostCommentCollectionQueryResponse(
    ICollection<PostCommentQueryResponse> Entities,
    int Page,
    int PageSize,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage) : ICollectionQueryResponse;
