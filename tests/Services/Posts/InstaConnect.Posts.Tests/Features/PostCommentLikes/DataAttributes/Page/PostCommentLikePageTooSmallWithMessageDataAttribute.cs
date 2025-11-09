using InstaConnect.Posts.Tests.Features.PostCommentLikes.Utilities;

namespace InstaConnect.Posts.Tests.Features.PostCommentLikes.DataAttributes.Page;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentLikePageTooSmallWithMessageDataAttribute : ValueIntWithMessageDataAttribute
{
    public PostCommentLikePageTooSmallWithMessageDataAttribute()
        : base(PostCommentLikeOutOfBoundsUtilities.PageTooSmall, PostCommentLikeErrorMessages.GetPageTooSmall(PostCommentLikeOutOfBoundsUtilities.PageTooSmall))
    {
    }
}

