using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Follows.Application.Features.Follows.Models;

public record FollowByFollowingQuerySorting(
    CommonSortOrder Order,
    FollowByFollowingSortProperty Property);
