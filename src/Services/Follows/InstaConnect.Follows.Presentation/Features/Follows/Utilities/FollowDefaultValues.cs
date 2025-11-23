using InstaConnect.Follows.Domain.Features.Follows.Models.Requests;

namespace InstaConnect.Follows.Presentation.Features.Users.Utilities;

public static class FollowDefaultValues
{
    public const FollowByFollowerSortProperty ByFollowerSortProperty = FollowByFollowerSortProperty.ByCreatedAt;

    public const FollowByFollowingSortProperty ByFollowingSortProperty = FollowByFollowingSortProperty.ByCreatedAt;

    public const int Page = 1;

    public const int PageSize = 20;
}
