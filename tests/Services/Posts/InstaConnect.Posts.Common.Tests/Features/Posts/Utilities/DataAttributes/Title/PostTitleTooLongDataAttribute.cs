using InstaConnect.Common.Tests.Utilities.DataAttributes;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.DataAttributes.Title;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostTitleTooLongDataAttribute : OutOfBoundsStringDataAttribute
{
    public PostTitleTooLongDataAttribute()
        : base(PostOutOfBoundUtilities.TitleTooLong, PostErrorMessages.GetTitleTooLong(PostOutOfBoundUtilities.TitleTooLong))
    {
    }
}
