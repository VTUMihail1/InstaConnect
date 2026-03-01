using System.Linq.Expressions;

namespace InstaConnect.Follows.Infrastructure.Features.Follows.Helpers.SortTermers.ForFollower;

internal class ByFollowingNameSortTermer : IFollowsForFollowerSortTermer
{
    public FollowsForFollowerSortTerm SortTerm => FollowsForFollowerSortTerm.ByFollowingName;

    public Expression<Func<FollowResponse, object>> Term => p => p.Following!.Name.Value;
}
