using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Empty;

namespace InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities.DataAttributes.Content;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentContentEmptyDataAttribute : EmptyStringDataAttribute
{
}
