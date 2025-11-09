using InstaConnect.Posts.Tests.Features.Posts.Utilities;

namespace InstaConnect.Posts.Tests.Features.Posts.DataAttributes.PageSize;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostPageSizeTooSmallWithMessageDataAttribute : ValueIntWithMessageDataAttribute
{
    public PostPageSizeTooSmallWithMessageDataAttribute()
        : base(PostOutOfBoundsUtilities.PageSizeTooSmall, PostErrorMessages.GetPageSizeTooSmall(PostOutOfBoundsUtilities.PageSizeTooSmall))
    {
    }
}
