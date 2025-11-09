using System.Linq.Expressions;

namespace InstaConnect.Follows.Infrastructure.Features.Follows.Abstractions;

public interface IFollowByFollowingSortProperty
{
    public FollowByFollowingSortProperty SortProperty { get; }

    public Expression<Func<Follow, object>> Property { get; }
}
