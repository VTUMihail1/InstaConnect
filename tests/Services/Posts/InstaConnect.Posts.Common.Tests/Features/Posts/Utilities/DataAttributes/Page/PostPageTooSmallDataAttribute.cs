using InstaConnect.Common.Tests.Utilities.DataAttributes;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.DataAttributes.Page;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostPageTooSmallDataAttribute : OutOfBoundsIntDataAttribute
{
    public PostPageTooSmallDataAttribute()
        : base(PostOutOfBoundUtilities.PageTooSmall, PostErrorMessages.GetPageTooSmall(PostOutOfBoundUtilities.PageTooSmall))
    {
    }
}

