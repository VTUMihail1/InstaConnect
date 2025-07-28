using InstaConnect.Posts.Infrastructure.Features.Posts.Models;

namespace InstaConnect.Common.Infrastructure.SortOrders;
internal static class PostSortPropertyUtilities
{
    public const string ByCreatedAt = nameof(PostQueryEntity.CreatedAt);

    public const string ByTitle = nameof(PostQueryEntity.Title);

    public const string ByUserName = nameof(PostQueryEntity.UserName);
}
