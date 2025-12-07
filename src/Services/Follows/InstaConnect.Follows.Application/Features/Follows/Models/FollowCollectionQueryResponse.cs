namespace InstaConnect.Follows.Application.Features.Follows.Models;

public record FollowCollectionQueryResponse(
    ICollection<FollowQueryResponse> Entities,
    int Page,
    int PageSize,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage);
