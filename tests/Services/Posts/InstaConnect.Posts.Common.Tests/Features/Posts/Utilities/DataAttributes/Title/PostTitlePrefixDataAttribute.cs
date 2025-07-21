using InstaConnect.Common.Tests.Utilities.Types.Strings.Prefix;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.DataAttributes.Title;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostTitlePrefixDataAttribute : PrefixStringDataAttribute
{
}
