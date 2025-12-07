namespace InstaConnect.Follows.Domain.Features.Follows.Models.Responses;
public record FollowCollection(
    ICollection<Follow> Entities,
    int Page,
    int PageSize,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage);
