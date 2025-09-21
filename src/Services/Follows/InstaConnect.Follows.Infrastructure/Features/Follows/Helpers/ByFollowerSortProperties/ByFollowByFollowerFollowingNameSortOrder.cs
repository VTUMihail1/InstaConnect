using InstaConnect.Common.Infrastructure.SortOrders;
using InstaConnect.Follows.Domain.Features.Follows.Models.Requests;
using InstaConnect.Follows.Infrastructure.Features.Follows.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Features.Follows.Helpers.SortProperties;

public class ByFollowByFollowerFollowingNameSortOrder : IFollowByFollowerSortProperty
{
    public FollowByFollowerSortProperty SortProperty => FollowByFollowerSortProperty.ByFollowingName;

    public string Property => FollowByFollowerSortPropertyUtilities.ByFollowingName;
}
