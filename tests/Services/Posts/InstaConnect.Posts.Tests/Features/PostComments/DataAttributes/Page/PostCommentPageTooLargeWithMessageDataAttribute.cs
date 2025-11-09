using InstaConnect.Posts.Tests.Features.PostComments.Utilities;

namespace InstaConnect.Posts.Tests.Features.PostComments.DataAttributes.Page;


[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentPageTooLargeWithMessageDataAttribute : ValueIntWithMessageDataAttribute
{
    public PostCommentPageTooLargeWithMessageDataAttribute()
        : base(PostCommentOutOfBoundsUtilities.PageTooLarge, PostCommentErrorMessages.GetPageTooLarge(PostCommentOutOfBoundsUtilities.PageTooLarge))
    {
    }
}

