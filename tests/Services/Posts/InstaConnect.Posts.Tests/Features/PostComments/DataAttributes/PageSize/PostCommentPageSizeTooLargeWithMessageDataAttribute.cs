using InstaConnect.Posts.Tests.Features.PostComments.Utilities;

namespace InstaConnect.Posts.Tests.Features.PostComments.DataAttributes.PageSize;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentPageSizeTooLargeWithMessageDataAttribute : ValueIntWithMessageDataAttribute
{
    public PostCommentPageSizeTooLargeWithMessageDataAttribute()
        : base(PostCommentOutOfBoundsUtilities.PageSizeTooLarge, PostCommentErrorMessages.GetPageSizeTooLarge(PostCommentOutOfBoundsUtilities.PageSizeTooLarge))
    {
    }
}
