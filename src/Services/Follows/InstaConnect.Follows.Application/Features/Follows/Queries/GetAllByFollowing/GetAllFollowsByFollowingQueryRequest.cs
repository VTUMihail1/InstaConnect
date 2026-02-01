using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Follows.Application.Features.Follows.Queries.GetAllByFollowing;

public record GetAllFollowsByFollowingQueryRequest(
    string FollowingId,
    string FollowerName,
    CommonSortOrder SortOrder,
    FollowByFollowingSortProperty SortTerm,
    int Page,
    int PageSize)
    : IQueryRequest<GetAllFollowsByFollowingQueryResponse>, ISortableQueryRequest<FollowByFollowingSortProperty>, IPaginatableQueryRequest;
