using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Posts.Tests.Features.PostCommentLikes.DataAttributes.SortOrder;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentLikeSortOrderWithAscendingTermDataAttribute
    : SortEnumWithAscendingTermDataAttribute<CommonSortOrder, PostCommentLike, DateTimeOffset>
{
    public PostCommentLikeSortOrderWithAscendingTermDataAttribute()
        : base(CommonSortOrder.Ascending, p => p.CreatedAtUtc)
    {
    }
}
