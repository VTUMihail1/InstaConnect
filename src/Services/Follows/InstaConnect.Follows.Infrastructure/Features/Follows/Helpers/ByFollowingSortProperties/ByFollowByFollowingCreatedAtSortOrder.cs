using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.Common.Infrastructure.SortOrders;
using InstaConnect.Common.Models.Enums;
using InstaConnect.Follows.Domain.Features.Follows.Models.Requests;
using InstaConnect.Follows.Infrastructure.Features.Follows.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Features.Follows.Helpers.SortProperties;
public class ByFollowByFollowingCreatedAtSortOrder : IFollowByFollowingSortProperty
{
    public FollowByFollowingSortProperty SortProperty => FollowByFollowingSortProperty.ByCreatedAt;

    public string Property => FollowByFollowingSortPropertyUtilities.ByCreatedAt;
}
