using InstaConnect.Common.Domain.Models;
using InstaConnect.Follows.Application.Features.Users.Abstractions;

namespace InstaConnect.Follows.Application.Features.Follows.Queries.GetAllForFollower;

public record GetAllFollowsForFollowerQueryRequest(
    string FollowerId,
    string FollowingName,
    string CurrentUserId,
    CommonSortOrder SortOrder,
    FollowsForFollowerSortTerm SortTerm,
    int Page,
    int PageSize)
    : IQueryRequest<GetAllFollowsForFollowerQueryResponse>, ISortableQueryRequest<FollowsForFollowerSortTerm>, IPaginatableQueryRequest, ICurrentUserableQueryRequest;
