using InstaConnect.Posts.Tests.Features.Posts.Utilities;

namespace InstaConnect.Posts.Tests.Features.Posts.DataAttributes.PageSize;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostPageSizeTooLargeWithMessageDataAttribute : ValueIntWithMessageDataAttribute
{
    public PostPageSizeTooLargeWithMessageDataAttribute()
        : base(PostOutOfBoundsUtilities.PageSizeTooLarge, PostErrorMessages.GetPageSizeTooLarge(PostOutOfBoundsUtilities.PageSizeTooLarge))
    {
    }
}
