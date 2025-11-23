using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Follows.Application.Features.Follows.Models;

public record FollowByFollowingSortingQueryRequest(
    CommonSortOrder Order,
    FollowByFollowingSortProperty Property);
