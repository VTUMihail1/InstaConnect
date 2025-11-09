using InstaConnect.Posts.Tests.Features.Posts.Utilities;

namespace InstaConnect.Posts.Tests.Features.Posts.DataAttributes.Page;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostPageTooLargeDataAttribute : ValueIntDataAttribute
{
    public PostPageTooLargeDataAttribute()
        : base(PostOutOfBoundsUtilities.PageTooLarge)
    {
    }
}

