using InstaConnect.Common.Tests.Utilities.DataAttributes.Ints.Value;
using InstaConnect.PostComments.Common.Features.PostComments.Utilities;

namespace InstaConnect.PostComments.Common.Tests.Features.PostComments.Utilities.DataAttributes.Page;


[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentPageTooLargeWithMessageDataAttribute : ValueIntWithMessageDataAttribute
{
    public PostCommentPageTooLargeWithMessageDataAttribute()
        : base(PostCommentOutOfBoundsUtilities.PageTooLarge, PostCommentErrorMessages.GetPageTooLarge(PostCommentOutOfBoundsUtilities.PageTooLarge))
    {
    }
}

