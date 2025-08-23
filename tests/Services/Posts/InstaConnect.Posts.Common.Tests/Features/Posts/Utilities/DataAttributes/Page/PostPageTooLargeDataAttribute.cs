using InstaConnect.Common.Tests.Utilities.DataAttributes.Ints.Value;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.DataAttributes.Page;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostPageTooLargeDataAttribute : ValueIntDataAttribute
{
    public PostPageTooLargeDataAttribute()
        : base(PostOutOfBoundsUtilities.PageTooLarge)
    {
    }
}

