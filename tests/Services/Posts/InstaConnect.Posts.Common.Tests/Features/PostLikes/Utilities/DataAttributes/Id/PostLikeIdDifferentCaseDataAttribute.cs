using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.DifferentCase;

namespace InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.DataAttributes.Id;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostLikeIdDifferentCaseDataAttribute : DifferentCaseStringDataAttribute
{
}
