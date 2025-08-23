using InstaConnect.Common.Tests.Utilities.DataAttributes.Ints.Value;
using InstaConnect.PostComments.Common.Features.PostComments.Utilities;

namespace InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities.DataAttributes.Page;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentPageTooSmallWithMessageDataAttribute : ValueIntWithMessageDataAttribute
{
    public PostCommentPageTooSmallWithMessageDataAttribute()
        : base(PostCommentOutOfBoundsUtilities.PageTooSmall, PostCommentErrorMessages.GetPageTooSmall(PostCommentOutOfBoundsUtilities.PageTooSmall))
    {
    }
}

