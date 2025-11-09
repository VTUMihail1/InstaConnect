using System.Linq.Expressions;

namespace InstaConnect.Follows.Infrastructure.Features.Follows.Helpers.SortProperties;

public class ByFollowByFollowerCreatedAtSortProperty : IFollowByFollowerSortProperty
{
    public FollowByFollowerSortProperty SortProperty => FollowByFollowerSortProperty.ByCreatedAt;

    public Expression<Func<Follow, object>> Property => p => p.CreatedAt;
}
