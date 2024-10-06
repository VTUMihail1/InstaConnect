namespace InstaConnect.Posts.Web.Features.PostComments.Models.Responses;

public record PostCommentPaginationQueryResponse(
    ICollection<PostCommentQueryResponse> Items,
    int Page,
    int PageSize,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage);
