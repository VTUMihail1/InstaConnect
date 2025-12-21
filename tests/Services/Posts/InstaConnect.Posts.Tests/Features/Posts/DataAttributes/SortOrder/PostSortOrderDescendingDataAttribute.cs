using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Posts.Tests.Features.Posts.DataAttributes.SortOrder;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostSortOrderDescendingDataAttribute : SortEnumDataAttribute<CommonSortOrder>
{
    public PostSortOrderDescendingDataAttribute()
        : base(CommonSortOrder.Descending)
    {
    }
}
