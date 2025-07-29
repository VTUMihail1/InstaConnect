using InstaConnect.PostLikes.Infrastructure.Features.PostLikes.Models;

namespace InstaConnect.Common.Infrastructure.SortOrders;
internal static class PostLikeSortPropertyUtilities
{
    public const string ByCreatedAt = nameof(PostLikeQueryEntity.CreatedAt);

    public const string ByUserName = nameof(PostLikeQueryEntity.UserName);
}
