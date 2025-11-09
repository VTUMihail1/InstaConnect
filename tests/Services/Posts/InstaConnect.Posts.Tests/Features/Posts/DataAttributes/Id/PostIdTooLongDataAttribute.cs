using InstaConnect.Posts.Tests.Features.Posts.Utilities;

namespace InstaConnect.Posts.Tests.Features.Posts.DataAttributes.Id;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PostIdTooLongDataAttribute : LengthStringDataAttribute
{
    public PostIdTooLongDataAttribute()
        : base(PostOutOfBoundsUtilities.IdTooLong)
    {
    }
}
