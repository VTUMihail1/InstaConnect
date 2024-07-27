using InstaConnect.Shared.Business.Models;

namespace InstaConnect.Posts.Web.Models.Responses.PostComments;

public record PostCommentPaginationQueryResponse(
    ICollection<PostCommentQueryResponse> Items,
    int Page,
    int PageSize,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage)
    : PaginationQueryViewModel<PostCommentQueryResponse>(Items, Page, PageSize, TotalCount, HasNextPage, HasPreviousPage);
