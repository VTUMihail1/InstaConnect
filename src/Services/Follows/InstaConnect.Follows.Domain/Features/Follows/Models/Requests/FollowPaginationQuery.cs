namespace InstaConnect.Follows.Domain.Features.Follows.Models.Requests;

public record FollowPaginationQuery(
    int Page,
    int PageSize);
