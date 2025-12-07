namespace InstaConnect.Posts.Presentation.Features.PostComments.Models.Responses;

public record PostCommentCollectionApiResponse(
    ICollection<PostCommentApiResponse> Entities,
    int Page,
    int PageSize,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage);
