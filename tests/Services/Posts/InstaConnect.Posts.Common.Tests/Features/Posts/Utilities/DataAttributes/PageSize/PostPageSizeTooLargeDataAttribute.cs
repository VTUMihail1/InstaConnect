using InstaConnect.Common.Tests.Utilities.DataAttributes.Int;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.DataAttributes.PageSize;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostPageSizeTooLargeDataAttribute : OutOfBoundsIntDataAttribute
{
    public PostPageSizeTooLargeDataAttribute()
        : base(PostOutOfBoundUtilities.PageSizeTooLarge, PostErrorMessages.GetPageSizeTooLarge(PostOutOfBoundUtilities.PageSizeTooLarge))
    {
    }
}
