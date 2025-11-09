using System.Linq.Expressions;

namespace InstaConnect.Follows.Infrastructure.Features.Follows.Helpers.SortProperties;

public class ByFollowByFollowingNameSortProperty : IFollowByFollowerSortProperty
{
    public FollowByFollowerSortProperty SortProperty => FollowByFollowerSortProperty.ByFollowingName;

    public Expression<Func<Follow, object>> Property => p => p.Following!.Name;
}
