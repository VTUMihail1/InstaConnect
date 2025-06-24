namespace InstaConnect.Posts.Application.Features.Posts.Queries.GetAll;

public record GetAllPostsApiResponse(
    ICollection<PostApiResponse> Data,
    int Page,
    int PageSize,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage);
