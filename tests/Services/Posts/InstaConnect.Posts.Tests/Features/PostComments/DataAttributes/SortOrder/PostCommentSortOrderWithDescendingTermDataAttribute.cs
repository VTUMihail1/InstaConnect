using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Posts.Tests.Features.PostComments.DataAttributes.SortOrder;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentSortOrderWithDescendingTermDataAttribute
    : SortEnumWithDescendingTermDataAttribute<CommonSortOrder, PostComment, DateTimeOffset>
{
    public PostCommentSortOrderWithDescendingTermDataAttribute()
        : base(CommonSortOrder.Descending, p => p.CreatedAtUtc)
    {
    }
}
