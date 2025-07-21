using InstaConnect.Common.Tests.Utilities.Types.Enums.Default;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.DataAttributes.SortProperty;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostSortPropertyDefaultDataAttribute : DefaultEnumDataAttribute<PostSortProperty>
{
}
