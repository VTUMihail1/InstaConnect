using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.Common.Infrastructure.SortOrders;
using InstaConnect.Common.Models.Enums;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Requests;
using InstaConnect.PostLikes.Infrastructure.Features.PostLikes.Abstractions;

namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Helpers.SortProperties;
public class ByPostLikeCreatedAtSortOrder : IPostLikeSortProperty
{
    public PostLikeSortProperty SortProperty => PostLikeSortProperty.ByCreatedAt;

    public string Property => PostLikeSortPropertyUtilities.ByCreatedAt;
}
