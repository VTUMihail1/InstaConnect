using System.Linq.Expressions;

using InstaConnect.Follows.Domain.Features.Follows.Models.Requests;
using InstaConnect.Follows.Infrastructure.Features.Follows.Abstractions;

namespace InstaConnect.Common.Infrastructure.SortOrders;

public class ByFollowByFollowerNameSortProperty : IFollowByFollowingSortProperty
{
    public FollowByFollowingSortProperty SortProperty => FollowByFollowingSortProperty.ByFollowerName;

    public Expression<Func<Follow, object>> Property => p => p.Follower!.Name;
}
