using InstaConnect.Shared.Business.Models;

namespace InstaConnect.Posts.Web.Features.PostLikes.Models.Responses;

public record PostLikePaginationQueryResponse(
    ICollection<PostLikeQueryResponse> Items,
    int Page,
    int PageSize,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage)
    : PaginationQueryViewModel<PostLikeQueryResponse>(Items, Page, PageSize, TotalCount, HasNextPage, HasPreviousPage);
