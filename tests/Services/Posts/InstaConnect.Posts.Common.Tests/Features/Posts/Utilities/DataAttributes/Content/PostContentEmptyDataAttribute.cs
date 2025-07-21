using InstaConnect.Common.Tests.Utilities.Types.Strings.Empty;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.DataAttributes.Content;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostContentEmptyDataAttribute : EmptyStringDataAttribute
{
}
