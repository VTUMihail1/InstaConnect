using InstaConnect.Posts.Tests.Features.Posts.Utilities;

namespace InstaConnect.Posts.Tests.Features.Posts.DataAttributes.Title;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostTitleTooLongDataAttribute : LengthStringDataAttribute
{
    public PostTitleTooLongDataAttribute()
        : base(PostOutOfBoundsUtilities.TitleTooLong)
    {
    }
}
