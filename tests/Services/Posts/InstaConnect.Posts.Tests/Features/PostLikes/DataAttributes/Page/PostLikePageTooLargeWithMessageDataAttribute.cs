using InstaConnect.Posts.Tests.Features.PostLikes.Utilities;

namespace InstaConnect.Posts.Tests.Features.PostLikes.DataAttributes.Page;


[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostLikePageTooLargeWithMessageDataAttribute : ValueIntWithMessageDataAttribute
{
    public PostLikePageTooLargeWithMessageDataAttribute()
        : base(PostLikeOutOfBoundsUtilities.PageTooLarge, PostLikeErrorMessages.GetPageTooLarge(PostLikeOutOfBoundsUtilities.PageTooLarge))
    {
    }
}

