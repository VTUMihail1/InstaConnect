using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Posts.Tests.Features.PostLikes.DataAttributes.SortOrder;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostLikeSortOrderWithAscendingTermDataAttribute
    : SortEnumWithAscendingTermDataAttribute<CommonSortOrder, PostLike, DateTimeOffset>
{
    public PostLikeSortOrderWithAscendingTermDataAttribute()
        : base(CommonSortOrder.Ascending, p => p.CreatedAtUtc)
    {
    }
}
