using System.Linq.Expressions;

namespace InstaConnect.Follows.Infrastructure.Features.Follows.Helpers.SortProperties;

public class ByFollowByFollowerNameSortProperty : IFollowByFollowingSortProperty
{
    public FollowByFollowingSortProperty SortProperty => FollowByFollowingSortProperty.ByFollowerName;

    public Expression<Func<Follow, object>> Property => p => p.Follower!.Name;
}
