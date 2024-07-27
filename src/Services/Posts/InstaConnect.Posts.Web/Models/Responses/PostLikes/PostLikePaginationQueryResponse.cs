using InstaConnect.Posts.Read.Web.Models.Responses;
using InstaConnect.Shared.Business.Models;

namespace InstaConnect.Posts.Business.Models.PostComment;

public record PostLikePaginationQueryResponse(
    ICollection<PostLikeQueryResponse> Items,
    int Page,
    int PageSize,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage)
    : PaginationQueryViewModel<PostLikeQueryResponse>(Items, Page, PageSize, TotalCount, HasNextPage, HasPreviousPage);
