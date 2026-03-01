using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Follows.Domain.Features.Follows.Models.Requests;

public record FollowsForFollowerSortingQuery(
    CommonSortOrder Order,
    FollowsForFollowerSortTerm Term) : ISortingQuery<FollowsForFollowerSortTerm>;
