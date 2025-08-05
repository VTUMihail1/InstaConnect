using InstaConnect.Common.Tests.Utilities.DataAttributes.Ints.Empty;
using InstaConnect.PostComments.Common.Features.PostComments.Utilities;

namespace InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities.DataAttributes.Page;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentPageEmptyWithMessageDataAttribute : EmptyIntWithMessageDataAttribute
{
    public PostCommentPageEmptyWithMessageDataAttribute()
        : base(PostCommentErrorMessages.GetPageEmpty())
    {
    }
}
