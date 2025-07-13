using InstaConnect.Common.Tests.Utilities.DataAttributes;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.DataAttributes.Title;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostTitleTooShortDataAttribute : OutOfBoundsStringDataAttribute
{
    public PostTitleTooShortDataAttribute()
        : base(PostOutOfBoundUtilities.TitleTooShort, PostErrorMessages.GetTitleTooShort(PostOutOfBoundUtilities.TitleTooShort))
    {
    }
}
