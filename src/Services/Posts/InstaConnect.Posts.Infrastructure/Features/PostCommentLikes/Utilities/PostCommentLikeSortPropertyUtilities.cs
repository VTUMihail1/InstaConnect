using InstaConnect.PostCommentLikes.Infrastructure.Features.PostCommentLikes.Models;

namespace InstaConnect.Common.Infrastructure.SortOrders;
internal static class PostCommentLikeSortPropertyUtilities
{
    public const string ByCreatedAt = nameof(PostCommentLikeQueryEntity.CreatedAt);

    public const string ByUserName = nameof(PostCommentLikeQueryEntity.UserName);
}
