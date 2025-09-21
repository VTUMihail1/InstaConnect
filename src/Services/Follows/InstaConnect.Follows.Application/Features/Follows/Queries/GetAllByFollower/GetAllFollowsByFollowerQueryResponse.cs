using InstaConnect.Follows.Application.Features.Follows.Models;

namespace InstaConnect.Follows.Application.Features.Follows.Queries.GetAll;

public record GetAllFollowsByFollowerQueryResponse(
    ICollection<FollowQueryResponse> Data,
    int Page,
    int PageSize,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage);
