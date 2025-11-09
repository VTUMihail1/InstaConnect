using InstaConnect.Posts.Tests.Features.PostLikes.Utilities;

namespace InstaConnect.Posts.Tests.Features.PostLikes.DataAttributes.Page;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostLikePageTooSmallWithMessageDataAttribute : ValueIntWithMessageDataAttribute
{
    public PostLikePageTooSmallWithMessageDataAttribute()
        : base(PostLikeOutOfBoundsUtilities.PageTooSmall, PostLikeErrorMessages.GetPageTooSmall(PostLikeOutOfBoundsUtilities.PageTooSmall))
    {
    }
}

