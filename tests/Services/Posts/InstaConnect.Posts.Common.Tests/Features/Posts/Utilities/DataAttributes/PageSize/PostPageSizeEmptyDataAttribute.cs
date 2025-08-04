using InstaConnect.Common.Tests.Utilities.DataAttributes.Ints.Empty;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.DataAttributes.Page;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostPageSizeEmptyDataAttribute : EmptyIntDataAttribute
{
}
