using InstaConnect.Posts.Tests.Features.PostLikes.Utilities;

namespace InstaConnect.Posts.Tests.Features.PostLikes.DataAttributes.Page;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostLikePageTooLargeDataAttribute : ValueIntDataAttribute
{
    public PostLikePageTooLargeDataAttribute()
        : base(PostLikeOutOfBoundsUtilities.PageTooLarge)
    {
    }
}

