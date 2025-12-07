namespace InstaConnect.Follows.Presentation.Features.Follows.Models.Responses;

public record FollowCollectionApiResponse(
    ICollection<FollowApiResponse> Entities,
    int Page,
    int PageSize,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage);
