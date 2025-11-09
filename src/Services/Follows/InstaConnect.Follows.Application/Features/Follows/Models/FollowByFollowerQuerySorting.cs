using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Follows.Application.Features.Follows.Models;

public record FollowByFollowerQuerySorting(
    SortOrder Order,
    FollowByFollowerSortProperty Property);
