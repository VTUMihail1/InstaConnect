using System.Linq.Expressions;

using InstaConnect.Follows.Domain.Features.Follows.Models.Entities;
using InstaConnect.Follows.Domain.Features.Follows.Models.Requests;
using InstaConnect.Follows.Infrastructure.Features.Follows.Abstractions;

namespace InstaConnect.Common.Infrastructure.SortOrders;

public class ByFollowByFollowerCreatedAtSortProperty : IFollowByFollowerSortProperty
{
    public FollowByFollowerSortProperty SortProperty => FollowByFollowerSortProperty.ByCreatedAt;

    public Expression<Func<Follow, object>> Property => p => p.CreatedAt;
}
