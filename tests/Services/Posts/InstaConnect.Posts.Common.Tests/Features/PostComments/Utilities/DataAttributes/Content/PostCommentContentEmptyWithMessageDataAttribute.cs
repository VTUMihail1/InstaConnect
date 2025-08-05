using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Empty;
using InstaConnect.PostComments.Common.Features.PostComments.Utilities;

namespace InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities.DataAttributes.Content;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentContentEmptyWithMessageDataAttribute : EmptyStringWithMessageDataAttribute
{
    public PostCommentContentEmptyWithMessageDataAttribute()
        : base(PostCommentErrorMessages.GetContentEmpty())
    {
    }
}
