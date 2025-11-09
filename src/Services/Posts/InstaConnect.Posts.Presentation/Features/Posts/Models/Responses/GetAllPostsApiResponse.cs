namespace InstaConnect.Posts.Presentation.Features.Posts.Models.Responses;

public record GetAllPostsApiResponse(
    ICollection<PostApiResponse> Data,
    int Page,
    int PageSize,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage);
