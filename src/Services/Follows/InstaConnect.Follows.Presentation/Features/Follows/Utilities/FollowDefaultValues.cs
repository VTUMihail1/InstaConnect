using InstaConnect.Follows.Domain.Features.Follows.Models.Requests;

namespace InstaConnect.Follows.Presentation.Features.Follows.Utilities;

public static class FollowDefaultValues
{
    public const FollowsForFollowerSortTerm ByFollowerSortProperty = FollowsForFollowerSortTerm.ByCreatedAt;

    public const FollowsForFollowingSortTerm ByFollowingSortProperty = FollowsForFollowingSortTerm.ByCreatedAt;

    public const int Page = 1;

    public const int PageSize = 20;
}
