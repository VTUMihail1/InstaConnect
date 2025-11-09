using InstaConnect.Posts.Tests.Features.PostLikes.Utilities;

namespace InstaConnect.Posts.Tests.Features.PostLikes.DataAttributes.PageSize;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostLikePageSizeTooLargeDataAttribute : ValueIntDataAttribute
{
    public PostLikePageSizeTooLargeDataAttribute()
        : base(PostLikeOutOfBoundsUtilities.PageSizeTooLarge)
    {
    }
}

