using InstaConnect.Follows.Infrastructure.Features.Follows.Models;

namespace InstaConnect.Common.Infrastructure.SortOrders;
internal static class FollowByFollowerSortPropertyUtilities
{
    public const string ByCreatedAt = nameof(FollowQueryEntity.CreatedAt);

    public const string ByFollowingName = nameof(FollowQueryEntity.FollowingName);
}
