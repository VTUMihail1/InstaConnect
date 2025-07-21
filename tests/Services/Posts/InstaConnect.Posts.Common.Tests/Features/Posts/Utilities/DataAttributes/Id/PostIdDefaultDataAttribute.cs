using InstaConnect.Common.Tests.Utilities.Types.Strings.Default;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.DataAttributes.Id;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostIdDefaultDataAttribute : DefaultStringDataAttribute
{
}
