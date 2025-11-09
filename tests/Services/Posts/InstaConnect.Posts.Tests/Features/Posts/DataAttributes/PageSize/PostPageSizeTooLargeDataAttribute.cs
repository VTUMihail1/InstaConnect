using InstaConnect.Posts.Tests.Features.Posts.Utilities;

namespace InstaConnect.Posts.Tests.Features.Posts.DataAttributes.PageSize;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostPageSizeTooLargeDataAttribute : ValueIntDataAttribute
{
    public PostPageSizeTooLargeDataAttribute()
        : base(PostOutOfBoundsUtilities.PageSizeTooLarge)
    {
    }
}

