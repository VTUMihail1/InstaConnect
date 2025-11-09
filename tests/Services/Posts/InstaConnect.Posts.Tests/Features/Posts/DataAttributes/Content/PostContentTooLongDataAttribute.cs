using InstaConnect.Posts.Tests.Features.Posts.Utilities;

namespace InstaConnect.Posts.Tests.Features.Posts.DataAttributes.Content;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostContentTooLongDataAttribute : LengthStringDataAttribute
{
    public PostContentTooLongDataAttribute()
        : base(PostOutOfBoundsUtilities.ContentTooLong)
    {
    }
}
