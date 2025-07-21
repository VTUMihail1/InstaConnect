using InstaConnect.Common.Tests.Utilities.Types.Ints.Default;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.DataAttributes.Page;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostPageDefaultDataAttribute : DefaultIntDataAttribute
{
}
