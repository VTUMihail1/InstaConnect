using System.Linq.Expressions;

namespace InstaConnect.Follows.Infrastructure.Features.Follows.Helpers.SortProperties;

public class ByFollowByFollowingCreatedAtSortProperty : IFollowByFollowingSortProperty
{
    public FollowByFollowingSortProperty SortProperty => FollowByFollowingSortProperty.ByCreatedAt;

    public Expression<Func<Follow, object>> Property => p => p.CreatedAtUtc;
}
