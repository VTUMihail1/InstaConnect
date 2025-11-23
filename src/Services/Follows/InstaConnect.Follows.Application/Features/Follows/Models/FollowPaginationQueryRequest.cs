namespace InstaConnect.Follows.Application.Features.Follows.Models;

public record FollowPaginationQueryRequest(
    int Page,
    int PageSize);
