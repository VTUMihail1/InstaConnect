using InstaConnect.Posts.Tests.Features.PostCommentLikes.Utilities;

namespace InstaConnect.Posts.Tests.Features.PostCommentLikes.DataAttributes.PageSize;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentLikePageSizeTooLargeWithMessageDataAttribute : ValueIntWithMessageDataAttribute
{
    public PostCommentLikePageSizeTooLargeWithMessageDataAttribute()
        : base(PostCommentLikeOutOfBoundsUtilities.PageSizeTooLarge, PostCommentLikeErrorMessages.GetPageSizeTooLarge(PostCommentLikeOutOfBoundsUtilities.PageSizeTooLarge))
    {
    }
}
