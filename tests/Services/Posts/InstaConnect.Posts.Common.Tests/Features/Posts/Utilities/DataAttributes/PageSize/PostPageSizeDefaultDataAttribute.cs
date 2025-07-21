using InstaConnect.Common.Tests.Utilities.Types.Ints.Default;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.DataAttributes.PageSize;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostPageSizeDefaultDataAttribute : DefaultIntDataAttribute
{
}
