using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Posts.Tests.Features.PostComments.DataAttributes.SortOrder;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentSortOrderWithAscendingTermDataAttribute
    : SortEnumWithAscendingTermDataAttribute<CommonSortOrder, PostComment, DateTimeOffset>
{
    public PostCommentSortOrderWithAscendingTermDataAttribute()
        : base(CommonSortOrder.Ascending, p => p.CreatedAtUtc)
    {
    }
}
