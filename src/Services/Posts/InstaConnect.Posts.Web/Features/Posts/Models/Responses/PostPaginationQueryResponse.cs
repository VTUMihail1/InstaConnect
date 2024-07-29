using InstaConnect.Shared.Business.Models;

namespace InstaConnect.Posts.Web.Features.Posts.Models.Responses;

public record PostPaginationQueryResponse(
    ICollection<PostQueryResponse> Items,
    int Page,
    int PageSize,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage)
    : PaginationQueryViewModel<PostQueryResponse>(Items, Page, PageSize, TotalCount, HasNextPage, HasPreviousPage);
