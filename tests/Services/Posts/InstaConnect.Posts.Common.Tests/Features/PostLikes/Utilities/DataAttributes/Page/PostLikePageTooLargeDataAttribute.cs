using InstaConnect.Common.Tests.Utilities.DataAttributes.Ints.Value;

namespace InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.DataAttributes.Page;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostLikePageTooLargeDataAttribute : ValueIntDataAttribute
{
    public PostLikePageTooLargeDataAttribute()
        : base(PostLikeOutOfBoundsUtilities.PageTooLarge)
    {
    }
}

