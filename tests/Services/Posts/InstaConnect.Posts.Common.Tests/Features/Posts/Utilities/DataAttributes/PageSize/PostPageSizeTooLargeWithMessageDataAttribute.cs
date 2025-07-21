using InstaConnect.Common.Tests.Utilities.Types.Ints.Value;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.DataAttributes.PageSize;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostPageSizeTooLargeWithMessageDataAttribute : ValueIntWithMessageDataAttribute
{
    public PostPageSizeTooLargeWithMessageDataAttribute()
        : base(PostTestValueUtilities.PageSizeTooLarge, PostErrorMessages.GetPageSizeTooLarge(PostTestValueUtilities.PageSizeTooLarge))
    {
    }
}
