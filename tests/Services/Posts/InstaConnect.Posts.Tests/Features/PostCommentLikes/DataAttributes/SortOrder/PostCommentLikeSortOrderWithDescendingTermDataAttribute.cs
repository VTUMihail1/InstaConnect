using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Posts.Tests.Features.PostCommentLikes.DataAttributes.SortOrder;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentLikeSortOrderWithDescendingTermDataAttribute
    : SortEnumWithDescendingTermDataAttribute<CommonSortOrder, PostCommentLike, DateTimeOffset>
{
    public PostCommentLikeSortOrderWithDescendingTermDataAttribute()
        : base(CommonSortOrder.Descending, p => p.CreatedAtUtc)
    {
    }
}
