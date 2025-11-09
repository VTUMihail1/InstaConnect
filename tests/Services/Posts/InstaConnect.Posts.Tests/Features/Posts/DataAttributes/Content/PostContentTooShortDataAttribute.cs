using InstaConnect.Posts.Tests.Features.Posts.Utilities;

namespace InstaConnect.Posts.Tests.Features.Posts.DataAttributes.Content;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostContentTooShortDataAttribute : LengthStringDataAttribute
{
    public PostContentTooShortDataAttribute()
        : base(PostOutOfBoundsUtilities.ContentTooShort)
    {
    }
}
