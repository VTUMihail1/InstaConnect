using System.Linq.Expressions;

using InstaConnect.Follows.Domain.Features.Follows.Models.Requests;

namespace InstaConnect.Follows.Infrastructure.Features.Follows.Abstractions;

public interface IFollowByFollowingSortProperty
{
    public FollowByFollowingSortProperty SortProperty { get; }

    public Expression<Func<Follow, object>> Property { get; }
}
