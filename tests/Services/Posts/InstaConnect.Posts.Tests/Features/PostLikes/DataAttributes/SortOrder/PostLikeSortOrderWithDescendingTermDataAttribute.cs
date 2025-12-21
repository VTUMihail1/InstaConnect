using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Posts.Tests.Features.PostLikes.DataAttributes.SortOrder;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostLikeSortOrderWithDescendingTermDataAttribute
    : SortEnumWithDescendingTermDataAttribute<CommonSortOrder, PostLike, DateTimeOffset>
{
    public PostLikeSortOrderWithDescendingTermDataAttribute()
        : base(CommonSortOrder.Descending, p => p.CreatedAtUtc)
    {
    }
}
