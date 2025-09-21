using InstaConnect.Follows.Infrastructure.Features.Follows.Models;

namespace InstaConnect.Common.Infrastructure.SortOrders;

internal static class FollowByFollowingSortPropertyUtilities
{
    public const string ByCreatedAt = nameof(FollowQueryEntity.CreatedAt);

    public const string ByFollowerName = nameof(FollowQueryEntity.FollowerName);
}
