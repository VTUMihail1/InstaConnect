using InstaConnect.Posts.Tests.Features.PostCommentLikes.Utilities;

namespace InstaConnect.Posts.Tests.Features.PostCommentLikes.DataAttributes.Page;


[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentLikePageTooLargeWithMessageDataAttribute : ValueIntWithMessageDataAttribute
{
    public PostCommentLikePageTooLargeWithMessageDataAttribute()
        : base(PostCommentLikeOutOfBoundsUtilities.PageTooLarge, PostCommentLikeErrorMessages.GetPageTooLarge(PostCommentLikeOutOfBoundsUtilities.PageTooLarge))
    {
    }
}

