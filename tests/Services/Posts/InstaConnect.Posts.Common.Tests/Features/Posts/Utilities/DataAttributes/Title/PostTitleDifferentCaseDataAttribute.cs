using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.DifferentCase;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.DataAttributes.Title;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostTitleDifferentCaseDataAttribute : DifferentCaseStringDataAttribute
{
}
