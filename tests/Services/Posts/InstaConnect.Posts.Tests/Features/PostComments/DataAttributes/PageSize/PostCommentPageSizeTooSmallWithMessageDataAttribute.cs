using InstaConnect.Posts.Tests.Features.PostComments.Utilities;

namespace InstaConnect.Posts.Tests.Features.PostComments.DataAttributes.PageSize;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentPageSizeTooSmallWithMessageDataAttribute : ValueIntWithMessageDataAttribute
{
    public PostCommentPageSizeTooSmallWithMessageDataAttribute()
        : base(PostCommentOutOfBoundsUtilities.PageSizeTooSmall, PostCommentErrorMessages.GetPageSizeTooSmall(PostCommentOutOfBoundsUtilities.PageSizeTooSmall))
    {
    }
}
