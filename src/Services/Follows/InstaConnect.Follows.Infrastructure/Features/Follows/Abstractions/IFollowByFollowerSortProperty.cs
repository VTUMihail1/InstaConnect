using System.Linq.Expressions;

namespace InstaConnect.Follows.Infrastructure.Features.Follows.Abstractions;

public interface IFollowByFollowerSortProperty
{
    public FollowByFollowerSortProperty SortProperty { get; }

    public Expression<Func<Follow, object>> Property { get; }
}
