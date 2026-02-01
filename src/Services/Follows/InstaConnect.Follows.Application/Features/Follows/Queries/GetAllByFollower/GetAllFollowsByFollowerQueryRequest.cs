using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Follows.Application.Features.Follows.Queries.GetAllByFollower;

public record GetAllFollowsByFollowerQueryRequest(
    string FollowerId,
    string FollowingName,
    CommonSortOrder SortOrder,
    FollowByFollowerSortProperty SortTerm,
    int Page,
    int PageSize)
    : IQueryRequest<GetAllFollowsByFollowerQueryResponse>, ISortableQueryRequest<FollowByFollowerSortProperty>, IPaginatableQueryRequest;
