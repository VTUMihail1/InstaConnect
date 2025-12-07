namespace InstaConnect.Posts.Application.Features.Posts.Models;

public record PostCollectionQueryResponse(
    ICollection<PostQueryResponse> Entities,
    int Page,
    int PageSize,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage);
