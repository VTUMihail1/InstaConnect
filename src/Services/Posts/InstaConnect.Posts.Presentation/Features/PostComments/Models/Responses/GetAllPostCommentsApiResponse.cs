namespace InstaConnect.Posts.Presentation.Features.PostComments.Models.Responses;

public record GetAllPostCommentsApiResponse(
    ICollection<PostCommentApiResponse> Data,
    int Page,
    int PageSize,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage);
