using InstaConnect.PostComments.Infrastructure.Features.PostComments.Models;

namespace InstaConnect.Common.Infrastructure.SortOrders;
internal static class PostCommentSortPropertyUtilities
{
    public const string ByCreatedAt = nameof(PostCommentQueryEntity.CreatedAt);

    public const string ByUserName = nameof(PostCommentQueryEntity.UserName);
}
