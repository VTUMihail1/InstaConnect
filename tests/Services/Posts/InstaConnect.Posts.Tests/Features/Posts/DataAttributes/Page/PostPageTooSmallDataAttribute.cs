using InstaConnect.Posts.Tests.Features.Posts.Utilities;

namespace InstaConnect.Posts.Tests.Features.Posts.DataAttributes.Page;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostPageTooSmallDataAttribute : ValueIntDataAttribute
{
    public PostPageTooSmallDataAttribute()
        : base(PostOutOfBoundsUtilities.PageTooSmall)
    {
    }
}

