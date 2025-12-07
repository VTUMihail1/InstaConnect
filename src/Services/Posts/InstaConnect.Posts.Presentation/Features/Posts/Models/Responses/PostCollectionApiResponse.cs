namespace InstaConnect.Posts.Presentation.Features.Posts.Models.Responses;

public record PostCollectionApiResponse(
    ICollection<PostApiResponse> Entities,
    int Page,
    int PageSize,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage);
