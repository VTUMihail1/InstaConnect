using InstaConnect.Common.Tests.Utilities.DataAttributes.Ints.Empty;

namespace InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities.DataAttributes.Page;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentPageEmptyDataAttribute : EmptyIntDataAttribute
{
}
