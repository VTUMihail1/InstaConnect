using InstaConnect.Common.Tests.Utilities.DataAttributes.Ints.Empty;
using InstaConnect.PostComments.Common.Features.PostComments.Utilities;

namespace InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities.DataAttributes.PageSize;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentPageSizeEmptyWithMessageDataAttribute : EmptyIntWithMessageDataAttribute
{
    public PostCommentPageSizeEmptyWithMessageDataAttribute()
        : base(PostCommentErrorMessages.GetPageSizeEmpty())
    {
    }
}

