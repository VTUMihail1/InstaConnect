using InstaConnect.Common.Infrastructure.SortOrders;
using InstaConnect.Follows.Domain.Features.Follows.Models.Requests;
using InstaConnect.Follows.Infrastructure.Features.Follows.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Features.Follows.Helpers.SortProperties;

public class ByFollowByFollowingFollowingNameSortOrder : IFollowByFollowingSortProperty
{
    public FollowByFollowingSortProperty SortProperty => FollowByFollowingSortProperty.ByFollowerName;

    public string Property => FollowByFollowingSortPropertyUtilities.ByFollowerName;
}
