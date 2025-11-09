using InstaConnect.Posts.Tests.Features.PostCommentLikes.Utilities;

namespace InstaConnect.Posts.Tests.Features.PostCommentLikes.DataAttributes.Page;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostCommentLikePageTooLargeDataAttribute : ValueIntDataAttribute
{
    public PostCommentLikePageTooLargeDataAttribute()
        : base(PostCommentLikeOutOfBoundsUtilities.PageTooLarge)
    {
    }
}

