namespace InstaConnect.Posts.Application.Features.Posts.Queries.GetAll;

public record GetAllPostsResponse(
    ICollection<PostResponse> Data,
    int Page,
    int PageSize,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage);
