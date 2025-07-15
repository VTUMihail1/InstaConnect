using InstaConnect.Common.Tests.Utilities.DataAttributes.String;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.DataAttributes.Title;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostTitleTooShortDataAttribute : OutOfBoundsStringWithMessageDataAttribute
{
    public PostTitleTooShortDataAttribute()
        : base(PostOutOfBoundUtilities.TitleTooShort, PostErrorMessages.GetTitleTooShort(PostOutOfBoundUtilities.TitleTooShort))
    {
    }
}
