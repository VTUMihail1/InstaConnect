using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Null;

namespace InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities.DataAttributes.Content;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentContentNullDataAttribute : NullStringDataAttribute
{
}
