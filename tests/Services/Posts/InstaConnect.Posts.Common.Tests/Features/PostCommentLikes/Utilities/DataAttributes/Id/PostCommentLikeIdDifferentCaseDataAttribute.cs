using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.DifferentCase;

namespace InstaConnect.PostCommentLikes.Common.Tests.Features.PostCommentLikes.Utilities.DataAttributes.Id;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentLikeIdDifferentCaseDataAttribute : DifferentCaseStringDataAttribute
{
}
