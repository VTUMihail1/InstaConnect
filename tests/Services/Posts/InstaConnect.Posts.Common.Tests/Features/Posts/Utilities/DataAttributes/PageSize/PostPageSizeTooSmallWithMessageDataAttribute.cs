using InstaConnect.Common.Tests.Utilities.DataAttributes.Int;
using InstaConnect.Common.Tests.Utilities.DataAttributes.Ints.Value;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.DataAttributes.PageSize;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostPageSizeTooSmallWithMessageDataAttribute : ValueIntWithMessageDataAttribute
{
    public PostPageSizeTooSmallWithMessageDataAttribute()
        : base(PostOutOfBoundsUtilities.PageSizeTooSmall, PostErrorMessages.GetPageSizeTooSmall(PostOutOfBoundsUtilities.PageSizeTooSmall))
    {
    }
}
