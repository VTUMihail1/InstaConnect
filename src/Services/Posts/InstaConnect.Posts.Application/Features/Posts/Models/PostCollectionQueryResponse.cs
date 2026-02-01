namespace InstaConnect.Posts.Application.Features.Posts.Models;

public record PostCollectionQueryResponse(
    UserQueryResponse? User,
    ICollection<PostQueryResponse> Posts,
    int Page,
    int PageSize,
    long TotalCount,
    bool HasNextPage,
    bool HasPreviousPage) : ICollectionQueryResponse;
