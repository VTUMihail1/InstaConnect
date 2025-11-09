using InstaConnect.Posts.Tests.Features.Posts.Utilities;

namespace InstaConnect.Posts.Tests.Features.Posts.DataAttributes.Title;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostTitleTooShortDataAttribute : LengthStringDataAttribute
{
    public PostTitleTooShortDataAttribute()
        : base(PostOutOfBoundsUtilities.TitleTooShort)
    {
    }
}
