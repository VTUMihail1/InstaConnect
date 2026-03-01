using System.Linq.Expressions;

namespace InstaConnect.Follows.Infrastructure.Features.Follows.Helpers.SortTermers.ForFollower;

internal class ByCreatedAtSortTermer : IFollowsForFollowerSortTermer
{
    public FollowsForFollowerSortTerm SortTerm => FollowsForFollowerSortTerm.ByCreatedAt;

    public Expression<Func<FollowResponse, object>> Term => p => p.CreatedAtUtc;
}
