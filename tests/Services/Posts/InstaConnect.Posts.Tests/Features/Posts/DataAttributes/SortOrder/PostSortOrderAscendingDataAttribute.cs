using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Posts.Tests.Features.Posts.DataAttributes.SortOrder;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostSortOrderAscendingDataAttribute : SortEnumDataAttribute<CommonSortOrder>
{
    public PostSortOrderAscendingDataAttribute()
        : base(CommonSortOrder.Ascending)
    {
    }
}
