using InstaConnect.Shared.Business.Models;

namespace InstaConnect.Posts.Web.Models.Responses.PostCommentLikes;

public record PostCommentLikePaginationQueryResponse(
    ICollection<PostCommentLikeQueryResponse> Items,
    int Page,
    int PageSize,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage)
    : PaginationQueryViewModel<PostCommentLikeQueryResponse>(Items, Page, PageSize, TotalCount, HasNextPage, HasPreviousPage);
