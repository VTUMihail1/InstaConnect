using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Posts.Tests.Features.Posts.DataAttributes.SortOrder;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostSortOrderWithAscendingTermDataAttribute
    : SortEnumWithAscendingTermDataAttribute<CommonSortOrder, Post, DateTimeOffset>
{
    public PostSortOrderWithAscendingTermDataAttribute()
        : base(CommonSortOrder.Ascending, p => p.CreatedAtUtc)
    {
    }
}
