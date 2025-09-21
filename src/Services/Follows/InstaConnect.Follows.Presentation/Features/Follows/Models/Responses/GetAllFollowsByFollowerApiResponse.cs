using InstaConnect.Follows.Application.Features.Follows.Models;

namespace InstaConnect.Follows.Application.Features.Follows.Queries.GetAll;

public record GetAllFollowsByFollowerApiResponse(
    ICollection<FollowApiResponse> Data,
    int Page,
    int PageSize,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage);
