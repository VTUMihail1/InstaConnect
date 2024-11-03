namespace InstaConnect.Posts.Web.Features.Posts.Models.Responses;

public record PostPaginationQueryResponse(
    ICollection<PostQueryResponse> Items,
    int Page,
    int PageSize,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage);
