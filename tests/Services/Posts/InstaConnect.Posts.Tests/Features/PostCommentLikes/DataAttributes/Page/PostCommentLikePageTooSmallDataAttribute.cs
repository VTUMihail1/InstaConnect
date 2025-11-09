using InstaConnect.Posts.Tests.Features.PostCommentLikes.Utilities;

namespace InstaConnect.Posts.Tests.Features.PostCommentLikes.DataAttributes.Page;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentLikePageTooSmallDataAttribute : ValueIntDataAttribute
{
    public PostCommentLikePageTooSmallDataAttribute()
        : base(PostCommentLikeOutOfBoundsUtilities.PageTooSmall)
    {
    }
}

