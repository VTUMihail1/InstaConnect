using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Posts.Tests.Features.Posts.DataAttributes.SortOrder;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostSortOrderWithDescendingTermDataAttribute
    : SortEnumWithDescendingTermDataAttribute<CommonSortOrder, Post, DateTimeOffset>
{
    public PostSortOrderWithDescendingTermDataAttribute()
        : base(CommonSortOrder.Descending, p => p.CreatedAtUtc)
    {
    }
}
